using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;
using System.Data.Entity;

namespace SportsStore.Repository.EF
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}
