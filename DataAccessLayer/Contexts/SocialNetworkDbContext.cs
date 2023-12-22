using DataAccessLayer.Contexts.Configurations;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class SocialNetworkDbContext : DbContext
    {
        public virtual DbSet<Dialog> Dialogs { get; private set; }
        public virtual DbSet<Message> Messages { get; private set; }
        public virtual DbSet<Relationship> Relationships { get; private set; }
        public virtual DbSet<User> Users { get; private set; }

        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
            Dialogs = Set<Dialog>();
            Messages = Set<Message>();
            Relationships = Set<Relationship>();
            Users = Set<User>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new DialogConfig());
            builder.ApplyConfiguration(new MessageConfig());
            builder.ApplyConfiguration(new RelationshipConfig());
        }
    }
}
