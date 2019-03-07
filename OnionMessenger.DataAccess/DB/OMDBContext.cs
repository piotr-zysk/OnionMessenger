using OnionMessenger.Domains;
using System.Data.Entity;


namespace OnionMessenger.DataAccess.DB
{
    public class OMDBContext : DbContext
    {
        public OMDBContext() : base("name=DefaultConnection")
            {}

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRecipient> MessageRecipients { get; set; }
    }   
}
