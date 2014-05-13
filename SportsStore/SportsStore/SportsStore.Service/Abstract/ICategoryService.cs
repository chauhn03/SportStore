using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Service.Abstract
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
    }
}
