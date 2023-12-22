using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Contexts.Configurations
{
    internal class RelationshipConfig : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.Property(r => r.Id)
               .IsRequired();

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.FriendId)
                .IsRequired();

            builder.Property(r => r.Status)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

        }
    }
}
