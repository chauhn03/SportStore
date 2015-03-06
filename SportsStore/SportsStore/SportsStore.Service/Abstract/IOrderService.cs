using SportsStore.Domain.Entities;

namespace SportsStore.Service.Abstract
{
    public interface IOrderService : IService<Order>
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
