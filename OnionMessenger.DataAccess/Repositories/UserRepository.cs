using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionMessenger.DataAccess.Repositories
{
    class UserRepository : IUserRepository
    {
        OMDBContext _dataContext;

        public UserRepository(OMDBContext dataConetxt)
        {
            this._dataContext = dataConetxt;
        }


        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _dataContext.Set<User>().FirstOrDefault(e => e.Id == id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }

}
