namespace SportsStore.Service.Abstract
{
    using System.Linq;
    using SportsStore.Domain.Entities;

    public interface IProductService : IService<Product>
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetByCategory(int? categoryId);

        Product GetById(int productId);
    }
}
