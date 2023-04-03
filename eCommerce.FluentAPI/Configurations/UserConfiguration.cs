using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.FluentAPI.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
       /*
        * IEntityTypeConfiguration<T> commonly used when is needed map many Entities 
        */
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            // builder == modelBuilder.Entity<User>();

            builder.ToTable("TB_USERS");
            builder.Property(p => p.RG).HasColumnName("GENERAL_REGISTER");
            builder.Ignore(u => u.Gender);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}