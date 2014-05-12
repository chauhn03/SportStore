using System;

namespace SportsStore.Repository.Fake
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public Abstract.ICustomerRepository Customers
        {
            get 
            {
                return new FakeCustomerRepository();
            }
        }

        public Abstract.IProductRepository Products
        {
            get
            {
                return new FakeProductRepository();
            }
        }

        public Abstract.ICategoryRepository Categories
        {
            get 
            {
                return new FakeCategoryRepository();
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
