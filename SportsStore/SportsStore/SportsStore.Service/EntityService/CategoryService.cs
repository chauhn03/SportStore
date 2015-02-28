using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;

namespace SportsStore.Service.EntityService
{
    public class CategoryService : Service<Category, ICategoryRepository>, ICategoryService
    {
        private IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = unitOfWork.Categories;
        }        
    }
}
