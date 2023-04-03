using eCommerce.FluentAPI.Configurations;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.FluentAPI.Database
{
    public class eCommerceFluentContext : DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------------------------------------------------
            // [ In case of Entity Configuration in other class ]:
            // ---------------------------------------------------
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            // modelBuilder.ApplyConfiguration(new ContactsConfiguration());
            // modelBuilder.ApplyConfiguration(new DeliveryAddressesConfiguration());
            // etc..

            // ----------------------------------------------
            // [ Microsoft.EntityFrameworkCore.Relational ] : 
            // ---------------------------------------------- 

            // * Table *
            modelBuilder.Entity<User>().ToTable("TB_USERS");

            // * Column * ( Property )
            modelBuilder.Entity<User>().Property(p => p.RG)
                .HasColumnName("GENERAL_REGISTER")
                .HasMaxLength(10)
                .HasDefaultValue("EMPTY")
                .IsRequired();

            // * NotMapped * (ignore)
            modelBuilder.Entity<User>().Ignore(p => p.Gender);

            // --- * Database Generated * (None, Identity, Computed) ---
            // [NONE]: modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedNever(); 
            // [IDENTITY]: modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
            // [COMPUTED]: modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAddOrUpdate();
            
            // * Index *
            modelBuilder.Entity<User>().HasIndex("CPF")
                .IsUnique()
                .HasFilter("[CPF] is not null")
                .HasDatabaseName("IX_CPF_UNIQUE");

            modelBuilder.Entity<User>().HasIndex(p => p.CPF); //another way to do (better)

            modelBuilder.Entity<User>().HasIndex("CPF", "Email");
            modelBuilder.Entity<User>().HasIndex(p => new {p.CPF, p.Email});

            // * Key *
            modelBuilder.Entity<User>().HasKey("Id");
            modelBuilder.Entity<User>().HasKey("Name", "Email");

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(p => new { p.Name, p.Email});

            // Entity without PK
            modelBuilder.Entity<User>().HasNoKey();

            // Property that will be an Alternative Key (it's not the Primary Key)
            modelBuilder.Entity<User>().HasAlternateKey("CPF");
            modelBuilder.Entity<User>().HasAlternateKey(p => p.CPF);
            modelBuilder.Entity<User>().HasAlternateKey(p => new { p.CPF, p.Email });


            // [] Has/With + One/Many = HasOne, HasMany, WithOne, WithMany ]

            // (1-1) One > One -- Simple property navigation
            modelBuilder.Entity<User>().HasOne(u => u.Contact).WithOne(c => c.User).HasForeignKey<Contact>(u => u.Id).OnDelete(DeleteBehavior.NoAction);

            // (1xN) One > Many -- Collection property navigation
            modelBuilder.Entity<User>().HasMany(u => u.DeliveryAddresses).WithOne(d => d.User).HasForeignKey(d => d.UserId);

            // (MxN) Many > Many
            modelBuilder.Entity<User>().HasMany(u => u.Departments).WithMany(d => d.Users);

            // --------------
            // [ OnDelete() ] 
            // --------------

            // Database:
            //      [NonAction] => only for stand alone property
            //      modelBuilder.Entity<User>()..OnDelete(DeleteBehavior.NoAction);

            //      [Cascade] => Parent deleted => all childrens deleted
            //      modelBuilder.Entity<User>()..OnDelete(DeleteBehavior.Cascade);

            //      [SetNull] => Only if FK can be nullable
            //      modelBuilder.Entity<User>()..OnDelete(DeleteBehavior.SetNull);

            // Entity Framework:   *Only Entity Framework will be affected (DB not)
            // --------------------------------------------------------------------
            // ClientCascade (EF => cascade delete) -- DB will not assume same behavior by default
            // ClienNoAction
            // ClientSetNull
            //                  Client == EF Core
            // --------------------------------------------------------------------

            // IsRequired & HasMaxLength
            modelBuilder.Entity<User>().Property(p => p.RG).IsRequired().HasMaxLength(12);


        }

        
    }
}