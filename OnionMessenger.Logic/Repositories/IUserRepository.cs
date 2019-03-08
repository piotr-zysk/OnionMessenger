using System.Collections.Generic;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);
    }
}
