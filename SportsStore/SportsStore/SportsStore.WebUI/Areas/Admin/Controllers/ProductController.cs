using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private ICategoryService categoryService;
        private IProductService productService;

        #endregion Fields

        #region Contructors

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.PageSize = 12;
        }

        #endregion Contructors

        #region Properties

        public int PageSize
        {
            get;
            set;
        }

        #endregion Properties

        //
        // GET: /Admin/Product/

        public ViewResult Create()
        {
            Product product = new Product();
            IEnumerable<Category> categories = categoryService.GetAll();

            ProductViewModel viewModel = this.CreateProductViewModel(product, categories);
            return this.View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = this.productService.GetById(productId);
            this.productService.Delete(product);
            TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index");
        }

        public ViewResult Edit(int productId)
        {
            Product product = this.productService.GetById(productId);
            IEnumerable<Category> categories = categoryService.GetAll();

            ProductViewModel viewModel = this.CreateProductViewModel(product, categories);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                this.CommitChanges(product, image);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return this.RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values.
                return this.View(product);
            }
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = this.productService.GetById(productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Index(int? categoryId, int page = 1)
        {
            IQueryable<ProductViewModel> productViewModels = from product in this.productService.GetByCategory(categoryId)
                                                             join category in this.categoryService.GetAll()
                                                             on product.CategoryId equals category.CategoryId
                                                             select this.CreateProductViewModel(product, null, category.Name);

            ProductListViewModel viewModel = this.CreateProductListViewModel(productViewModels, categoryId, page);
            return this.View(viewModel);
        }

        private Product CommitChanges(Product product, HttpPostedFileBase image)
        {
            if (product.ProductId <= 0)
            {
                this.productService.Add(product);
            }
            else
            {
                product = this.productService.GetById(product.ProductId);                
            }

            if (image != null)
            {
                product.ImageMimeType = image.ContentType;
                product.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

            return product;
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

        private ProductListViewModel CreateProductListViewModel(IEnumerable<ProductViewModel> productViewModels, int? categoryId, int page)
        {
            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.PageSize, productViewModels.Count()),
                ProductViewModels = productViewModels.GetDataOfPage<ProductViewModel>(page, this.PageSize),
                CurrentCategory = categoryId
            };

            return viewModel;
        }

        private ProductViewModel CreateProductViewModel(Product product, IEnumerable<Category> categories = null, string categoryName = null)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = product;
            productViewModel.CategoryName = categoryName;
            productViewModel.Categories = (categories == null) ? null : (new SelectList(categories, "CategoryId", "Name"));
            return productViewModel;
        }
    }
}