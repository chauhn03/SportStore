using SportsStore.Domain.Entities;
using SportsStore.Repository.Fake;
using SportsStore.Service.Abstract;
using SportsStore.Service.EntityService;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
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
            IQueryable<Product> products = productService.GetByCategory(categoryId);
            ProductListViewModel viewModel = this.CreateProductListViewModel(products, categoryId, page);
            return this.View(viewModel);
        }

        public ViewResult Edit(int productId)
        {
            Product product = this.productService.GetById(productId);
            IEnumerable<Category> categories = categoryService.GetAll();
            ProductViewModel viewModel = this.CreateProductViewModel(categories, product);
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
                    this.productService.Add(product);
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
            return this.View("Create", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = this.productService.GetById(productId);
            this.productService.Delete(product);
            TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index");
        }

        private ProductViewModel CreateProductViewModel(IEnumerable<Category> categories, Product product)
        {
            return new ProductViewModel()
            {
                Categories = categories.ToDictionary(category => category.CategoryId, b => b.Name),
                Product = product
            };
        }

        private ProductListViewModel CreateProductListViewModel(IEnumerable<Product> products, int? categoryId, int page)
        {
            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.PageSize, products.Count()),
                Products = products.GetDataOfPage<Product>(page, this.PageSize),
                CurrentCategory = categoryId
            };

            return viewModel;
        }

        private PagingInfo CreatePagingInfo(int page, int pageSize, int totalItems)
        {
            return new PagingInfo()
                {
                    CurrentPage = page,
                    ItemPerPage = this.PageSize,
                    TotalItems = totalItems
                };
        }
    }
}
