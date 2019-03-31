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
            foreach (var x in this.ChangeTracker.Entries().Where(e=>e.Entity is Message && (e.State==EntityState.Added || e.State==EntityState.Modified)).Select(e=>e.Entity as Message))
            {
                x.TimeModified = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }   
}
