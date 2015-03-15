using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class OrderDetailViewModel
    {
        public OrderDetail OrderDetail { get; set; }

        public string ProductName { get; set; }

        public string ProductNo { get; set; }

        public bool Deleted { get; set; }
    }
}