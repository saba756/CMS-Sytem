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
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(CustomerProfile));
builder.Services.AddDbContext<CustomerContext>(opt => opt.UseSqlServer
              (builder.Configuration.GetConnectionString("CMSConnection")));
builder.Services.AddDbContext<AppIdentityDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


builder.Services.AddControllers().AddNewtonsoftJson(s => {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    s.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddIdentityServices(builder.Configuration);
var identityBuilder = builder.Services.AddIdentityCore<AppUser>();

identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
identityBuilder.AddEntityFrameworkStores<AppIdentityDbContext>(); // it allow our user manager to work our identity database
identityBuilder.AddSignInManager<SignInManager<AppUser>>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IAddress, AddressRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
                      {
                          policy.WithOrigins("https://localhost:4200","http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                      });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = service.GetRequiredService<CustomerContext>();
        // it will update/create database with updated migration
        await context.Database.MigrateAsync();
        await CustomerSeed.SeedAsync(context);

        // it will update/create database with updated migration
        var userManager = service.GetRequiredService<UserManager<AppUser>>();
        var identityContext = service.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUserAsync(userManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration");
    }
  
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
