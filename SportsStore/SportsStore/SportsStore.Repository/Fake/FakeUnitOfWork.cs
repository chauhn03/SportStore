using System;

namespace SportsStore.Repository.Fake
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public Abstract.ICustomerRepository Customers
        {
            get
            {
                return FakeCustomerRepository.Instance;
            }
        }

        public Abstract.IProductRepository Products
        {
            get
            {
                return FakeProductRepository.Instance;
            }
        }

        public Abstract.ICategoryRepository Categories
        {
            get
            {
                return FakeCategoryRepository.Instance;
            }
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Abstract.INewsRepository News
        {
            get
            {
                return FakeNewsRepository.Instance;
            }
        }


        public Abstract.ITopicRepository Topics
        {
            get
            {
                return FakeTopicRepository.Instance;
            }
        }


        public Abstract.IOrderRepository Orders
        {
            get
            {
                return FakeOrderRepository.Instance;
            }
        }


        public Abstract.IOrderDetailRepository OrderDetails
        {
            get
            {
                return FakeOrderDetailRepository.Instance;
            }
        }


        public Abstract.ISystemSettingRepository SystemSettings
        {
            get 
            {
                return FakeSystemSettingRepository.Instance;
            }
        }
    }
}
