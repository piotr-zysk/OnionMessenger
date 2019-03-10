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
                
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                success = true;
            }

            return success;    
            
        }

        public bool ValidateCredentials(UserCredentials userCredentials)
        {
            string storedPassword = _userRepository.GetByLogin(userCredentials.Login)?.Password;

            if (string.IsNullOrEmpty(storedPassword)) return false;

            if (PasswordHash.Valid(userCredentials.Password, storedPassword)) return true;
                
            //if (PasswordHash.Encrypt(password) == UserInDb?.Password) return true;            
            else return false;            
        }
    }
}
