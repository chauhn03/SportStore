using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        private int pageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            return this.View(this.repository.Products
                             .OrderBy(product => product.ProductId)
                             .Skip((page - 1) * this.pageSize)
                             .Take(this.pageSize));
        }
    }
}