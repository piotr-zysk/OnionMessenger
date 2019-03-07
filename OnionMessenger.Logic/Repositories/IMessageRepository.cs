using System.Collections.Generic;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        string Test();
    }
}
