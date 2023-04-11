using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DRACULA;Database=eCommerceTemp;User Id=sa;Password=123456;");
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Only on SQL SERVER
            modelBuilder.Entity<User>().ToTable("Users", t => t.IsTemporal(
                c => {
                    c.HasPeriodStart("StartTime");
                    c.HasPeriodEnd("EndTime");
                    c.UseHistoryTable("UsersHistoric");
                }
            ));

            // GLOBAL FILTER
            modelBuilder.Entity<User>().HasQueryFilter(u => u.RegisterSituation == "A");
           
            // If use Value Conversion (in case RegisterSituation be enum type)
            modelBuilder.Entity<User>().Property(u => u.RegisterSituation).HasConversion<string>();
        }
    }
}