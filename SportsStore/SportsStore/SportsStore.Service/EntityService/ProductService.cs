using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Service.Abstract;
using System.Linq;

namespace SportsStore.Service.EntityService
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Product> GetList()
        {
            return this.unitOfWork.Products.GetAll();
        }

        public IQueryable<Product> GetByCategory(int? categoryId)
        {
            return this.unitOfWork.Products.GetByCategory(categoryId);
        }

        public Product GetById(int productId)
        {
            return this.unitOfWork.Products.GetById(productId);
        }
    }
}
