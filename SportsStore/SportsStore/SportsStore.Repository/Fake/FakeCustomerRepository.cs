using System;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeCustomerRepository : FakeRepository<Customer>, ICustomerRepository
    {


        public override Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
