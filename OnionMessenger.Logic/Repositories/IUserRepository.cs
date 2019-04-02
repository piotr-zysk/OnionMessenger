using System.Collections.Generic;
using System.Threading.Tasks;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLoginAsync(string login);

        User GetByLogin(string login);

        User GetWithMessages(int id);
    }
}
