using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService service;
        public ProductController(IProductService productService)
        {
            this.service = productService;
            this.PageSize = 12;
        }

        public int PageSize
        {
            get;
            set;
        }

        //
        // GET: /Admin/Product/

        public ActionResult Index(int? categoryId, int page = 1)
        {
            IQueryable<Product> products = service.GetByCategory(categoryId);

            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemPerPage = this.PageSize, TotalItems = products.Count() },
                Products = products.OrderBy(product => product.ProductId)
                                   .Skip((page - 1) * this.PageSize)
                                   .Take(this.PageSize),
                CurrentCategory = categoryId
            };

            return this.View(viewModel);
        }

        public ViewResult Edit(int productId)
        {
            Product product = this.service.GetById(productId);
            return this.View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                if (product.ProductId < 0)
                {
                    this.service.Add(product);
                }

                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return this.RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values.
                return this.View(product);
            }
        }

        public ViewResult Create()
        {
            return this.View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = this.service.GetById(productId);
            this.service.Delete(product);
            TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index");
        }
    }
}
