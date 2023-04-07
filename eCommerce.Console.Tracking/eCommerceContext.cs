using Microsoft.EntityFrameworkCore;
using eCommerce.Models;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DRACULA;Database=eCommerce;User Id=sa;Password=123456;")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging(); //to see Id and other propertys used on SQL's command
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    // this line disable Tracking of all context queries
        }

        // Code-First approach
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
    }
}