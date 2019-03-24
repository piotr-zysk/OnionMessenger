using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic
{
    public interface IUserLogic
    {
        Result<User> Register(User User);

        bool ValidateCredentials(UserCredentials userCredentials);

        User GetById(int id);

        Task<User> GetByIdAsync(int id);

        Task<User> GetByLoginAsync(string login);

        User Update(User user);

        void Delete(int id); 

    }
}
