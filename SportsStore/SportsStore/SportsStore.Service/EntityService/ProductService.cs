using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;

namespace SportsStore.Service.EntityService
{
    public class ProductService : Service<Product, IProductRepository>, IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = unitOfWork.Products;
        }

        public IQueryable<Product> GetByCategory(int? categoryId)
        {
            return this.unitOfWork.Products.GetByCategory(categoryId);
        }       
    }
}
