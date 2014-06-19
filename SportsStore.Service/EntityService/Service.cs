using System.Linq;
using SportsStore.Domain;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;

namespace SportsStore.Service.EntityService
{
    public class Service<T, R> : IService<T>
        where T : Entity
        where R : IRepository<T>
    {
        protected  R Repository { get; set; }

        public void Add(T entity)
        {
            this.Repository.Create(entity);
        }        

        public void Delete(T entity)
        {
            this.Repository.Delete(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this.Repository.GetAll();
        }

        public T GetById(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(T entity)
        {
            this.Repository.Update(entity);
        }
    }
}
