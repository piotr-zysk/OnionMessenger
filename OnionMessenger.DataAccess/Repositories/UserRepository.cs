using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OnionMessenger.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OMDBContext dataConetxt) : base(dataConetxt)
        {
        }

        public async Task<User> GetByLoginAsync(string login)
        {   
            User user = await _dataContext.Set<User>().FirstOrDefaultAsync(e => e.Login == login);
            return user;
        }

        public User GetByLogin(string login)
        {
            User user = _dataContext.Set<User>().FirstOrDefault(e => e.Login == login);
            return user;
        }

    }

}
