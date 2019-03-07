using System;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;

namespace OnionMessenger.Logic
{
    public class UserLogic : IUserLogic
    {
        IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public bool Register(User User)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCredentials(string Login, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
