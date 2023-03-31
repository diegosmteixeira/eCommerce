using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eCommerce.Console.Models;

namespace eCommerce.Console.Database
{
    public partial class eCommerceContext : DbContext
    {
        public eCommerceContext()
        {
        }

        public eCommerceContext(DbContextOptions<eCommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DRACULA;Database=eCommerce;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Contacts_UserId")
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Contact)
                    .HasForeignKey<Contact>(d => d.UserId);
            });

            modelBuilder.Entity<DeliveryAddress>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_DeliveryAddresses_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeliveryAddresses)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Departments)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartmentUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                        r => r.HasOne<Department>().WithMany().HasForeignKey("DepartmentsId"),
                        j =>
                        {
                            j.HasKey("DepartmentsId", "UsersId");

                            j.ToTable("DepartmentUser");

                            j.HasIndex(new[] { "UsersId" }, "IX_DepartmentUser_UsersId");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Rg).HasColumnName("RG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
