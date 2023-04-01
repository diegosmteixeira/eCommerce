using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) 
            : base(options) { }

        // Code-First approach
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Mercado" },
                new Department { Id = 2, Name = "Moda" },
                new Department { Id = 3, Name = "Informática" },
                new Department { Id = 4, Name = "Eletrodomésticos" },
                new Department { Id = 5, Name = "Eletroportáteis" },
                new Department { Id = 6, Name = "Beleza" }
            );
        }


        #region without environment distinction
        // without environment distinction (Console, WPF application)
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce; Integrated Security=True;")
        // }
        #endregion
    }
}