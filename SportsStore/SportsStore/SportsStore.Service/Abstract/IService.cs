
namespace SportsStore.Service.Abstract
{
    public interface IService<T>
    {
        void Add(T entity);

        void Delete(T entity);
    }
}
