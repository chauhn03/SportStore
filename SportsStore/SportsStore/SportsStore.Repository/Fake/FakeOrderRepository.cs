using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeOrderRepository : FakeRepository<Order>, IOrderRepository
    {
        private List<Order> orders;
        public FakeOrderRepository()
        {
            this.orders = new List<Order>();
        }

        public override Order GetById(int id)
        {
            return this.orders.Single(order => order.OrderId == id);
        }

        public override void Create(Order entity)
        {
            this.orders.Add(entity);
        }

        public override void Delete(Order entity)
        {
            this.orders.Remove(entity);
        }

        public override IQueryable<Order> GetAll()
        {
            return this.orders.AsQueryable();
        }

        public override void Update(Order entity)
        {
            Order order = this.GetById(entity.OrderId);
            order.CustomerId = entity.CustomerId;
            order.Total = entity.Total;            
        }
    }
}
