namespace SportsStore.Repository.EF
{
    using SportsStore.Domain.Entities;
    using SportsStore.Repository.Abstract;
    using System.Data.Entity;
    using System.Linq;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dataContext)
            : base(dataContext)
        {
        }

        public System.Linq.IQueryable<Product> GetByCategory(int? categoryId)
        {
            return from product in this.DbSet
                   where product.Category == null || product.CategoryId == categoryId
                   select product;
        }
    }
}
