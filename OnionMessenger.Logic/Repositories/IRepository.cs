using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic.Repositories
{
    public interface IRepository<T> where T : BaseModel, new()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAllActive();

        IEnumerable<T> GetAll();

        void SaveChanges();
    }
}