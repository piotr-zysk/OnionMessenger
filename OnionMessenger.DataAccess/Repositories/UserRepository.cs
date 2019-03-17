using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using System.Linq;

namespace OnionMessenger.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OMDBContext dataConetxt) : base(dataConetxt)
        {
        }

        public User GetByLogin(string login)
        {
            return _dataContext.Set<User>().FirstOrDefault(e => e.Login == login);
        }

    }

}
