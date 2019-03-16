using System.Collections.Generic;
using System.Linq;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;

namespace OnionMessenger.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        protected OMDBContext _dataContext;

        public Repository(OMDBContext dataConetxt)
        {
            this._dataContext = dataConetxt;
        }

        public void Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllActive()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            return _dataContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
