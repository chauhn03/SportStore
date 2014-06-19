using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using SportsStore.Service.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;
        private IOrderService orderProcessor;

        public CartController(IProductService productService, IOrderService orderProcessor)
        {
            this.productService = productService;
            this.orderProcessor = orderProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return this.View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = this.productService.GetById(productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = this.productService.GetById(productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return this.PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return this.View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult CheckOut(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.GetItems().Count() == 0)
            {
                this.ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (this.ModelState.IsValid)
            {
                this.orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return this.View("Completed");
            }
            else
            {
                return this.View(shippingDetails);
            }
        }
    }
}