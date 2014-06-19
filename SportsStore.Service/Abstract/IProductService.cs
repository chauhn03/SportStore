namespace SportsStore.Service.Abstract
{
    using System.Linq;
    using SportsStore.Domain.Entities;

    public interface IProductService : IService<Product>
    {        
        IQueryable<Product> GetByCategory(int? categoryId);        
    }
}
