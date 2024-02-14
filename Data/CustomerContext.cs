using CMS.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CMS.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<AddressTypes> AddressTypes { get; set; }
        public DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public DbSet<Address> Address { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        // if we don't do this we get issues with identity and primary key
        //using for the id of app user field
        {
            //builder.Entity<CustomerAddresses>().HasKey(c => new { c.customerId, c.address_id });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


    }
    
}
