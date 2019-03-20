using System;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Infrastructure;
using System.Collections.Generic;
using OnionMessenger.Logic;

namespace OnionMessenger.Webapi.Logic
{
    public class UserLogic : IUserLogic
    {
        IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }

        public Result<User> Register(User user)
        {            
            user.Password = PasswordHash.Encrypt(user.Password);

            var result = new Result();

            try
            {
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Success = false;
                var error = new ErrorMessage("dbcontext", e.Message);
                result.Errors = new List<ErrorMessage>() { error };
            }


            if (result.Success) return Result.Ok<User>(user);
            else return Result.Failure<User>(result.Errors);
            
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
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
