using OnionMessenger.Domains;
using System;
using System.Data.Entity;
using System.Linq;

namespace OnionMessenger.DataAccess.DB
{
    public class OMDBContext : DbContext
    {
        public OMDBContext() : base("name=DefaultConnection")
            {}

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRecipient> MessageRecipients { get; set; }

        public override int SaveChanges()
        {
            // update TimeModified automatically for all changes for Message antities
            foreach (var x in this.ChangeTracker.Entries().Where(e=>e.Entity is Message && (e.State==EntityState.Added || e.State==EntityState.Modified)).Select(e=>e.Entity as Message))
            {
                x.TimeModified = DateTime.Now;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // set MaxLength in Database for all String properties except Password via fluent api
            modelBuilder
                .Properties()
                .Where(p => p.PropertyType.Name == "String" && p.Name != "Password")
                .Configure(p => p.HasMaxLength(20));

            base.OnModelCreating(modelBuilder);
        }
    }   
}
