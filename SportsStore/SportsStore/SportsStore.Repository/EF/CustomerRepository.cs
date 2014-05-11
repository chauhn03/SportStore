namespace SportsStore.Repository.EF
{
    using SportsStore.Domain.Entities;
    using SportsStore.Repository.Abstract;
    using System.Data.Entity;
    using System.Linq;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Customer> GetByName(string name)
        {
            return DbSet.Where(c => c.Name.Contains(name));
        }
    }
}