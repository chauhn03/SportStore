using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeOrderDetailRepository : FakeRepository<OrderDetail>, IOrderDetailRepository
    {
        private List<OrderDetail> orderDetails;
        public FakeOrderDetailRepository()
        {
            this.GenerateDummyData();
        }

        public override void Create(OrderDetail entity)
        {
            this.orderDetails.Add(entity);
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
        }
    }
}
