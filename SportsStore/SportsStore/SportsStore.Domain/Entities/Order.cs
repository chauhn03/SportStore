﻿
using System;
using System.Collections.Generic;
namespace SportsStore.Domain.Entities
{
    public enum OrderStatus
    {
        New,
        Done
    }

    public class Order
    {
        public Order()
        {
            this.Status = (int)OrderStatus.New;
            this.OrderDate = DateTime.Now;
        }

        public int OrderId { get; set; }

        public string OrderNo { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }

        public int Status { get; set; }
    }
}
