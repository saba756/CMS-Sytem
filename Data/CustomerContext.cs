using CMS.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CMS.Data
{
    public class CustomerContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Login> login { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {

        }
      


    }
    
}
