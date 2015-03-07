using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using SportsStore.Service.Abstract;
using System.Linq;
using SportsStore.WebUI.Infrastructure.Common;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private int pageSize;
        private IOrderDetailService orderDetailService;
        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.pageSize = 10;

        }

        //
        // GET: /Admin/Order/

        public ActionResult Index(int page = 1)
        {
            var orders = from order in this.orderService.GetAll()
                         select this.CreateOrderViewModel(order, null);

            var listViewModel = this.CreateListViewModel(orders, page);
            return View(listViewModel);
        }

        public OrderListViewModel CreateListViewModel(IEnumerable<OrderViewModel> orders, int page)
        {
            return new OrderListViewModel
            {
                Orders = orders.GetDataOfPage<OrderViewModel>(page, this.pageSize),
                PagingInfo = this.CreatePagingInfo(page, this.pageSize, orders.Count()),
                Total = orders.Sum(order => order.Order.Total),
                Count = orders.Count()
            };
        }

        private PagingInfo CreatePagingInfo(int page, int pageSize, int totalItems)
        {
            return new PagingInfo()
            {
                CurrentPage = page,
                ItemPerPage = pageSize,
                TotalItems = totalItems
            };
        }


        private OrderViewModel CreateOrderViewModel(Order order, IEnumerable<OrderDetail> orderDetails = null)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Order = order;
            orderViewModel.OrderDetails = orderDetails;
            return orderViewModel;
        }

        //
        // GET: /Admin/Order/Create

        public ActionResult Create()
        {
            Order order = new Order();
            OrderViewModel viewModel = this.CreateOrderViewModel(order, null);
            return View("Edit", viewModel);
        }

        //
        // POST: /Admin/Order/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Order/Edit/5

        public ActionResult Edit(int id)
        {
            Order order = this.orderService.GetById(id);
            IEnumerable<OrderDetail> orderDetails = this.orderDetailService.GetByOrder(id);
            OrderViewModel viewModel = this.CreateOrderViewModel(order, orderDetails);
            return View(viewModel);
        }

        //
        // POST: /Admin/Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int orderId, int page, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Order product = this.orderService.GetById(orderId);
                this.orderService.Delete(product);
                TempData["message"] = string.Format("{0} was deleted", product.OrderNo);
                return this.RedirectToAction("Index", new { page = page });
            }
            catch
            {
                return View();
            }
        }
    }
}
