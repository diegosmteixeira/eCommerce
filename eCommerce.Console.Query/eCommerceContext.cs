using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer("Server=DRACULA;Database=eCommerce;User Id=sa;Password=123456;");
                    // options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                // .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                // .EnableSensitiveDataLogging();
        }

        // Code-First approach
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(u => u.Contact).AutoInclude();
        }
    }
}