using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeCustomerRepository : FakeRepository<Customer>, ICustomerRepository
    {
        private static FakeCustomerRepository instance;
        private List<Customer> customers;

        private FakeCustomerRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeCustomerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeCustomerRepository();
                }

                return instance;
            }
        }

        public override void Create(Customer entity)
        {
            this.customers.Add(entity);
        }

        public override void Delete(Customer entity)
        {
            this.customers.Remove(entity);
        }

        public override IQueryable<Customer> GetAll()
        {
            return this.customers.AsQueryable();
        }

        public override Customer GetById(int id)
        {
            return this.customers.Single(customer => customer.CustomerId == id);
        }

        public IQueryable<Customer> GetByName(string name)
        {
            return this.customers.Where(customer => customer.Name == name).AsQueryable();
        }

        public override void Update(Customer entity)
        {
            Customer customer = this.GetById(entity.CustomerId);
            customer.Name = entity.Name;
            customer.Age = entity.Age;
            customer.Modified = DateTime.Now;
        }

        private void GenerateDummyData()
        {
            this.customers = new List<Customer>();
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 1, Name = "Customer 1", Age = 18, Created = DateTime.Now, Modified = DateTime.Now });
        }
    }
}