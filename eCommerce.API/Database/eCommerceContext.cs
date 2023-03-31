using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options) 
        {
        }

        // Code-First approach
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Department> Departments { get; set; }





        #region without environment distinction
        // without environment distinction (Console, WPF application)
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce; Integrated Security=True;")
        // }
        #endregion
    }
}