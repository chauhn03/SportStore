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

        public override int Create(Customer entity)
        {
            this.customers.Add(entity);
            return 1;
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
            this.customers.Add(new Customer { CustomerId = 2, Name = "Customer 2", Age = 20, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 3, Name = "Customer 3", Age = 21, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 4, Name = "Customer 4", Age = 25, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 5, Name = "Customer 5", Age = 23, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 6, Name = "Customer 6", Age = 26, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 7, Name = "Customer 7", Age = 30, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 8, Name = "Customer 8", Age = 22, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 9, Name = "Customer 9", Age = 19, Created = DateTime.Now, Modified = DateTime.Now });
            this.customers.Add(new Customer { CustomerId = 10, Name = "Customer 10", Age = 27, Created = DateTime.Now, Modified = DateTime.Now });
        }
    }
}