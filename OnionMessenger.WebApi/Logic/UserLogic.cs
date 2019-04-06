using System;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Infrastructure;
using System.Collections.Generic;
using OnionMessenger.Logic;
//using NLog;
using System.Threading.Tasks;

namespace OnionMessenger.Webapi.Logic
{
    public class UserLogic : IUserLogic
    {
        private Lazy<IUserRepository> repository;

        protected IUserRepository Repository { get => repository.Value; }

        public UserLogic(Lazy<IUserRepository> userRepository)
        {
            this.repository = userRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return Repository.GetById(id);
        }


        public async Task<User> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public User GetByLogin(string login)
        {
            return Repository.GetByLogin(login);
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            //Logger logger = LogManager.GetCurrentClassLogger();
            //logger.Info("UserLogic.GetByLoginAsync");
            return await Repository.GetByLoginAsync(login);
        }

        public Result<User> Register(User user)
        {            
            user.Password = PasswordHash.Encrypt(user.Password);

            var result = new Result();

            try
            {
                Repository.Add(user);
                Repository.SaveChanges();
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
            string storedPassword = Repository.GetByLogin(userCredentials.Login)?.Password;

            if (string.IsNullOrEmpty(storedPassword)) return false;

            if (PasswordHash.Valid(userCredentials.Password, storedPassword)) return true;
                
            //if (PasswordHash.Encrypt(password) == UserInDb?.Password) return true;            
            else return false;            
        }

        public User GetWithMessages(int id)
        {
            return Repository.GetWithMessages(id);
        }
    }
}
