using CMS.Data;
using CMS.Profiles;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CMS.Identity;
using Microsoft.AspNetCore.Identity;
using CMS.Model;
using Microsoft.Extensions.Hosting;
using CMS.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(CustomerProfile));
builder.Services.AddDbContext<CustomerContext>(opt => opt.UseSqlServer
              (builder.Configuration.GetConnectionString("CMSConnection")));
builder.Services.AddDbContext<AppIdentityDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


builder.Services.AddControllers().AddNewtonsoftJson(s => {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});
builder.Services.AddIdentityServices(builder.Configuration);
var identityBuilder = builder.Services.AddIdentityCore<AppUser>();

identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
identityBuilder.AddEntityFrameworkStores<AppIdentityDbContext>(); // it allow our user manager to work our identity database
identityBuilder.AddSignInManager<SignInManager<AppUser>>();
builder.Services.AddScoped<ICustomerRepo, SqlCustomerRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();
    try
    {

        // it will update/create database with updated migration
        var userManager = service.GetRequiredService<UserManager<AppUser>>();
        var identityContext = service.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUserAsync(userManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration");
    }
    //var scope = app.Services.CreateScope();
    //var service = scope.ServiceProvider;
    //var loggerFactory = service.GetRequiredService<ILoggerFactory>();
    //try
    //{
    //    var userManager = service.GetRequiredService<UserManager<AppUser>>();
    //    var identityContext = service.GetRequiredService<AppIdentityDbContext>();
    //    await identityContext.Database.MigrateAsync();
    //    await AppIdentityDbContextSeed.SeedUserAsync(userManager);
    //}
    //catch (Exception ex)
    //{
    //    var logger = loggerFactory.CreateLogger<Program>();
    //    logger.LogError(ex, "An error occured during migration");
    //}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
