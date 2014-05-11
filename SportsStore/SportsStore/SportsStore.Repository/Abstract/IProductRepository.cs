namespace SportsStore.Repository.Abstract
{
    using SportsStore.Domain.Entities;

    public interface IProductRepository : IRepository<Product>
    {
        System.Linq.IQueryable<Product> GetByCategory(int? categoryId);
    }
}
