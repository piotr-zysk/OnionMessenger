using System.Collections.Generic;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic.Repositories
{
    interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
    }
}
