using SportsStore.Domain.Entities;

namespace SportsStore.Service.Abstract
{
    public interface IOrderService   
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
