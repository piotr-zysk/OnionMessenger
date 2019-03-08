using System;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Infrastructure;

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

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }

        public bool Register(User user)
        {
            bool success = false;

            var ExistingUser = _userRepository.GetByLogin(user.Login);

            if (ExistingUser == null)
            {
                user.Password = PasswordHash.Encrypt(user.Password);
                // todo: validate if user does not exist in database yet
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                success = true;
            }

            return success;    
            
        }

        public bool ValidateCredentials(string Login, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
