using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Contexts.Configurations
{
    internal class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.Id)
                .IsRequired();

            builder.Property(m => m.UserId)
                .IsRequired();

            builder.Property(m => m.FriendId)
                .IsRequired();

            builder.Property(m => m.DialogId)
                .IsRequired();

            builder.Property(m => m.Content)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(m => m.SentDateTime)
                .HasDefaultValueSql("getdate()");

        }
    }
}
