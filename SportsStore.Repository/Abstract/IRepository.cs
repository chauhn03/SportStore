using System.Linq;

namespace SportsStore.Repository.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();   
     
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}