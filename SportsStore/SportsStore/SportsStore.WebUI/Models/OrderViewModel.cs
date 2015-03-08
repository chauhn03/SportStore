using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public IList<OrderDetailViewModel> OrderDetails { get; set; }
    }
}