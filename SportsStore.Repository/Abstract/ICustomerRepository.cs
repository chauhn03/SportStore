namespace SportsStore.Repository.Abstract
{
    using SportsStore.Domain.Entities;
    using System.Linq;

    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetByName(string name);
    }
}