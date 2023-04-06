using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace eCommerce.Office
{
    public class eCommerceOfficeContext : DbContext
    {
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<EmployeeSection>? EmployeesSections { get; set; }
        public DbSet<Section>? Sections { get; set; }
        public DbSet<TrainingClass>? TrainingClasses { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DRACULA;Database=eCommerceOffice;User Id=sa;Password=123456;");
        }

        // ------------------------------------
        // [ Many-To-Many Relationships - POO ]
        // ------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        #region Mapping: EmployeSection - using 2x One-To-Many
        
        // --------------------------------------------------------------------
        // *EF Core [Before version 5]           ( 3.1, 3.0, 2.1, 2.0, 1.0 )    
        //  Many-To-Many: 2x One-To-Many       (only with intermediate object)
        // --------------------------------------------------------------------
            #region 1st Approach - using all Entities
            
            // (1st Example) Many-To-Many [using 2x One-To-Many]

            // modelBuilder.Entity<EmployeeSection>()
            //     .HasKey(es => new {es.SectionId, es.EmployeeId});

            // modelBuilder.Entity<Employee>()
            //     .HasMany(e => e.EmployeeSection)
            //     .WithOne(es => es.Employee)
            //     .HasForeignKey(e => e.Id);
            
            // modelBuilder.Entity<Section>()
            //     .HasMany(s => s.EmployeeSection)
            //     .WithOne(es => es.Section)
            //     .HasForeignKey(s => s.Id);
            #endregion

            #region 2nd Approach - only using middle entity (EmployeeSection)

            // (2nd) Example) Many-To-Many [using 2x One-To-Many]

            modelBuilder.Entity<EmployeeSection>()
                .HasKey(es => new {es.SectionId, es.EmployeeId});

            modelBuilder.Entity<EmployeeSection>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSection)
                .HasForeignKey(es => es.EmployeeId);
            
            modelBuilder.Entity<EmployeeSection>()
                .HasOne(es => es.Section)
                .WithMany(s => s.EmployeeSection)
                .HasForeignKey(es => es.SectionId);
            #endregion

            #region Seeds
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "José" },
                new Employee() { Id = 2, Name = "Mary" },
                new Employee() { Id = 3, Name = "Phillip" },
                new Employee() { Id = 4, Name = "Joe" },
                new Employee() { Id = 5, Name = "Paul" },
                new Employee() { Id = 6, Name = "Zoe" }
            );
        
            modelBuilder.Entity<Section>().HasData(
                new Section() { Id = 1, Name = "Delivery" },
                new Section() { Id = 2, Name = "Transport" },
                new Section() { Id = 3, Name = "Marketing" },
                new Section() { Id = 4, Name = "Management" }
            );

            modelBuilder.Entity<EmployeeSection>().HasData(
                new EmployeeSection() { SectionId = 1, EmployeeId = 1, Created = DateTimeOffset.Now },
                new EmployeeSection() { SectionId = 1, EmployeeId = 6, Created = DateTimeOffset.Now },
                new EmployeeSection() { SectionId = 2, EmployeeId = 5, Created = DateTimeOffset.Now },
                new EmployeeSection() { SectionId = 2, EmployeeId = 4, Created = DateTimeOffset.Now },
                new EmployeeSection() { SectionId = 3, EmployeeId = 2, Created = DateTimeOffset.Now },
                new EmployeeSection() { SectionId = 4, EmployeeId = 3, Created = DateTimeOffset.Now }
            );

            modelBuilder.Entity<TrainingClass>().HasData(
                new TrainingClass() { Id = 1, Name = "Class A"},
                new TrainingClass() { Id = 2, Name = "Class B"},
                new TrainingClass() { Id = 3, Name = "Class C"},
                new TrainingClass() { Id = 4, Name = "Class D"}
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle() { Id = 1, Name = "Alfa Romeo - C43", LicensePlate = "ABC-7771" },
                new Vehicle() { Id = 2, Name = "AlphaTauri - AT04", LicensePlate = "ABC-7772" },
                new Vehicle() { Id = 3, Name = "Alpine - A523", LicensePlate = "ABC-7773" },
                new Vehicle() { Id = 4, Name = "Aston Martin - AMR23", LicensePlate = "ABC-7774" },
                new Vehicle() { Id = 5, Name = "Ferrari - SF-23", LicensePlate = "ABC-7775" }
            );
            #endregion
        
        #endregion

        #region Mapping: with [HasMany >> WithMany] (EF Core 5++)
        // ------------------------------------
        // *EF Core [After version 5]         
        //  Many-To-Many: 1x HasMany >> WithMany
        // ------------------------------------

        // it's not needed to create intermediate class; EF while migrating
        // but it is possible to do with [HasMany >> WithMany] => optional!
        modelBuilder.Entity<Employee>().HasMany(e => e.TrainingClasses).WithMany(tc => tc.Employees);
        #endregion

        #region Mapping: Employee <=> Vehicle (EF Core 5++)
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Vehicles)
            .WithMany(v => v.Employees)
            .UsingEntity<EmployeeVehicle>(
                ev => ev.HasOne(ev => ev.Vehicle).WithMany(v => v.EmployeeVehicles).HasForeignKey(ev => ev.VehicleId),
                ev => ev.HasOne(ev => ev.Employee).WithMany(e => e.EmployeeVehicles).HasForeignKey(ev => ev.EmployeeId),
                ev => ev.HasKey(ev => new {ev.VehicleId, ev.EmployeeId})
            );
        #endregion

        }   
    }
}