using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using SportsStore.Service.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService service;

        public ProductController(IProductService productService)
        {
            this.service = productService;
            this.PageSize = 5;
        }

        public int PageSize
        {
            get;
            set;
        }

        public ViewResult List(int? categoryId, int page = 1)
        {
            IQueryable<Product> products = service.GetByCategory(categoryId);

            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemPerPage = this.PageSize, TotalItems = products.Count() },
                //ProductViewModels = products.OrderBy(product => product.ProductId)
                //                   .Skip((page - 1) * this.PageSize)
                //                   .Take(this.PageSize),
                CurrentCategory = categoryId
            };

            return this.View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = this.service.GetById(productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}