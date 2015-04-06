using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeOrderDetailRepository : FakeRepository<OrderDetail>, IOrderDetailRepository
    {
        private List<OrderDetail> orderDetails;
        private static FakeOrderDetailRepository instance;
        public FakeOrderDetailRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeOrderDetailRepository Instance
        {
            get
            {
                
                if (instance == null)
                {
                    instance = new FakeOrderDetailRepository();
                }

                return instance;
            }
        }

        public override int Create(OrderDetail entity)
        {
            this.orderDetails.Add(entity);
            return 1;
        }

        public override void Delete(OrderDetail entity)
        {
            this.orderDetails.Remove(entity);
        }

        public IQueryable<OrderDetail> GetByOrderId(int orderId)
        {
            return this.orderDetails.Where(orderDetail => orderDetail.OrderId == orderId).AsQueryable();
        }

        public override IQueryable<OrderDetail> GetAll()
        {
            return this.orderDetails.AsQueryable();
        }

        public override OrderDetail GetById(int id)
        {
            return this.orderDetails.Single(orderDetail => orderDetail.OrderDetailId == id);
        }

        public override void Update(OrderDetail entity)
        {
            OrderDetail orderDetail = this.GetById(entity.OrderDetailId);
            orderDetail.OrderId = entity.OrderId;
            orderDetail.Price = entity.Price;
            orderDetail.ProductId = entity.ProductId;
            orderDetail.Quantity = entity.Quantity;
        }

        private void GenerateDummyData()
        {
            this.orderDetails = new List<OrderDetail>();
            this.orderDetails.Add(new OrderDetail
            {
                OrderDetailId = 1,
                OrderId = 1,
                Price = 12000,
                ProductId = 1,
                Quantity = 1,
                Total = 12000
            });

            this.orderDetails.Add(new OrderDetail
            {
                OrderDetailId = 2,
                OrderId = 1,
                Price = 2000,
                ProductId = 2,
                Quantity = 2,
                Total = 4000
            });
        }

        public IQueryable<OrderDetail> GetByOrder(int orderId)
        {
            return this.orderDetails.Where(orderDetail => orderDetail.OrderId == orderId).AsQueryable();
        }
    }
}
