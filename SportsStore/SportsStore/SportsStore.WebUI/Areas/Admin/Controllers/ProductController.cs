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

		#region Public methods
        public ViewResult Create()
        {
            Product product = new Product();
            IEnumerable<Category> categories = categoryService.GetAll();

            ProductViewModel viewModel = this.CreateProductViewModel(product, categories);
            return this.View("Edit", viewModel);
        }

        [HttpPost]
		public ActionResult Delete(int productId, int? categoryId)
		{
			Product product = this.productService.GetById(productId);
			this.productService.Delete(product);
			TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index", new { categoryId = categoryId });
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
				this.UpdateProduct(product, image);
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
            var products = categoryId.GetValueOrDefault(0) > 0 ? this.productService.GetByCategory(categoryId.Value) : this.productService.GetAll();
            IQueryable<ProductViewModel> productViewModels = from product in products
															 join category in this.categoryService.GetAll()
															 on product.CategoryId equals category.CategoryId
															 select this.CreateProductViewModel(product, null, category.Name);

			ProductListViewModel viewModel = this.CreateProductListViewModel(productViewModels, categoryId, page);
			return this.View(viewModel);
		}
	
		#endregion

		#region Private methods
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
            var categoryList = this.categoryService.GetAll().ToList();
            categoryList.Insert(0, new Category { CategoryId = -1, Name = "All" });

            ProductListViewModel viewModel = new ProductListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.PageSize, productViewModels.Count()),
                ProductViewModels = productViewModels.GetDataOfPage<ProductViewModel>(page, this.PageSize),
                CurrentCategory = categoryId,
                Categories = categoryList
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

        //
		// GET: /Admin/Product/
		private Product UpdateProduct(Product product, HttpPostedFileBase image)
		{
            if (image != null)
            {
                product.ImageMimeType = image.ContentType;
                product.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

            if (product.ProductId <= 0)
            {
                this.productService.Add(product);
            }
            else
            {
                this.productService.Update(product);
            }

			return product;
		}
		#endregion
	}
}