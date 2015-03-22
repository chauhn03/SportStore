
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public enum OrderStatus
    {
        New,
        Done
    }

    public class Order : Entity
    {
        public Order()
        {
            this.Status = (int)OrderStatus.New;
            this.OrderDate = DateTime.Now;
        }

        public int OrderId { get; set; }

        [Display(Name= "Mã đơn hàng")]
        public string OrderNo { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Khách hàng")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        [Display(Name = "Tổng cộng")]
        public decimal Total { get; set; }

        [Display(Name = "Ngày lập")]
        public DateTime OrderDate { get; set; }

        public int Status { get; set; }
    }
}
