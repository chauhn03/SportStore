namespace SportsStore.Repository.Abstract
{
    using SportsStore.Domain.Entities;
    using SportsStore.Repository.EF;

    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
