using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;
using System.Data.Entity;

namespace SportsStore.Repository.EF
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}
