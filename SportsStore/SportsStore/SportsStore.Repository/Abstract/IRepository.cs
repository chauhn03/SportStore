using System.Linq;

namespace SportsStore.Repository.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
    }
}