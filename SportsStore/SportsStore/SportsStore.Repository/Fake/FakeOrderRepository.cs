using System;
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

        private void GenerateDummyData()
        {
            this.orders = new List<Order>();
            this.orders.Add(new Order
            {
                OrderId = 1,
                OrderNo = "Order 1",
                Address = "123 Lê Thánh Tôn",                
                CustomerName = "Nguyễn Văn A",
                Email = "nguyenvana@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "09332345678",
                Total = 12000
            });

            this.orders.Add(new Order
            {
                OrderId = 2,
                OrderNo = "Order 2",
                Address = "456 Mạc Đỉnh Chi",
                CustomerName = "Lê Thị B",
                Email = "lethib@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0903911228",
                Total = 36000
            });


            this.orders.Add(new Order
            {
                OrderId = 3,
                OrderNo = "Order 3",
                Address = "179 Tôn Thất Tùng",
                CustomerName = "Lê Văn C",
                Email = "levanc@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "098355428",
                Total = 25000
            });

            this.orders.Add(new Order
            {
                OrderId = 4,
                OrderNo = "Order 4",
                Address = "259 Trần Quang Diệu",
                CustomerName = "Trần Minh D",
                Email = "tranminhd@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "01662949750",
                Total = 42000
            });

            this.orders.Add(new Order
            {
                OrderId = 5,
                OrderNo = "Order 5",
                Address = "256 Trần Não",
                CustomerName = "Phan Minh E",
                Email = "phanminhe@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "01687459234",
                Total = 56000
            });

            this.orders.Add(new Order
            {
                OrderId = 6,
                OrderNo = "Order 6",
                Address = "76 Phan Đăng Lưu",
                CustomerName = "Lê Huy F",
                Email = "lehuyf@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0906478954",
                Total = 45000
            });

            this.orders.Add(new Order
            {
                OrderId = 7,
                OrderNo = "Order 7",
                Address = "85 Phan Huy Ích",
                CustomerName = "Nguyễn Thị H",
                Email = "nguyenthih@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0902945678",
                Total = 32000
            });

            this.orders.Add(new Order
            {
                OrderId = 8,
                OrderNo = "Order 8",
                Address = "65 Lê Quang Định",
                CustomerName = "Quách Thị K",
                Email = "quachthik@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "09029985124",
                Total = 52000
            });

            this.orders.Add(new Order
            {
                OrderId = 9,
                OrderNo = "Order 9",
                Address = "26 Nguyễn Bỉnh Khiêm",
                CustomerName = "Lê Thị N",
                Email = "lethiN@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0903457214",
                Total = 33000
            });

            this.orders.Add(new Order
            {
                OrderId = 10,
                OrderNo = "Order 10",
                Address = "153 Lê Lai",
                CustomerName = "Trương Thị Mỹ M",
                Email = "truongthimym@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0903400005",
                Total = 22000
            });

            this.orders.Add(new Order
            {
                OrderId = 11,
                OrderNo = "Order 11",
                Address = "64 Trần Hưng Đạo",
                CustomerName = "Nguyền Hoàng T",
                Email = "nguyenhoangt@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0903400005",
                Total = 31000
            });

            this.orders.Add(new Order
            {
                OrderId = 12,
                OrderNo = "Order 12",
                Address = "98 Nguyễn Xí",
                CustomerName = "Võ Trung C",
                Email = "votrungc@gmail.com",
                OrderDate = DateTime.Now,
                Phone = "0903547814",
                Total = 12000
            });
        }
    }
}
