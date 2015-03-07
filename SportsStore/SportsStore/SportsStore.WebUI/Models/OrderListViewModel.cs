using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public int Count { get; set; }
        
        public decimal Total { get; set; }
    }
}