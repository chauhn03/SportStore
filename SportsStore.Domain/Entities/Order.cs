
using System.Collections.Generic;
namespace SportsStore.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public decimal Total { get; set; }
    }
}
