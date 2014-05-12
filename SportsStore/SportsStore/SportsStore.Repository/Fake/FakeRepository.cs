using System.Linq;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public abstract class FakeRepository<T> : IRepository<T>
    {
        public abstract T GetById(int id);

        public abstract void Create(T entity);
        
        public abstract void Delete(T entity);

        public abstract IQueryable<T> GetAll();
    }
}
