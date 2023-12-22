using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Contexts.Configurations
{
    internal class DialogConfig : IEntityTypeConfiguration<Dialog>
    {
        public void Configure(EntityTypeBuilder<Dialog> builder)
        {
            builder.Property(d => d.Id)
                .IsRequired();

            builder.Property(d => d.UserId)
                .IsRequired();

            builder.Property(d => d.FriendId)
                .IsRequired();

            builder.HasMany(d => d.Messages)
                .WithOne(m => m.Dialog)
                .HasForeignKey(m => m.DialogId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
