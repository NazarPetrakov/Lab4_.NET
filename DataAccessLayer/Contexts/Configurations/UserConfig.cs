using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Contexts.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("nvarchar(40)");

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasColumnType("nvarchar(40)");

            //builder.Property(u => u.Login)
            //    .IsRequired()
            //    .HasColumnType("varchar(32)");

            //builder.Property(u => u.PasswordHash)
            //    .IsRequired()
            //    .HasColumnType("varchar(255)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(u => u.DateOfBirth)
                .IsRequired();
                
            builder.HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Dialogs)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Relationships)
                .WithOne(r => r.User) 
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
