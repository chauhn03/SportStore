using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
            this.PageSize = 3;
        }

        public int PageSize
        {
            get;
            set;
        }

        public ViewResult List(string category, int page = 1)
        {
            IQueryable<Product> products = this.repository.Products.Where(product => category == null || product.Category == category);

            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemPerPage = this.PageSize, TotalItems = products.Count() },
                Products = products.OrderBy(product => product.ProductId)
                                   .Skip((page - 1) * this.PageSize)
                                   .Take(this.PageSize),
                CurrentCategory = category
            };

            return this.View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = this.repository.GetProductById(productId);
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