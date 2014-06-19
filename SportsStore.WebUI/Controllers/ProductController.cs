using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
            this.PageSize = 5;
        }

        public int PageSize
        {
            get;
            set;
        }

        public ViewResult List(int? categoryId, int page = 1)
        {
            IQueryable<ProductViewModel> productViewModels = from product in this.productService.GetByCategory(categoryId)
                                                             select this.CreateProductViewModel(product, null, null);

            ProductListViewModel viewModel = this.CreateProductListViewModel(productViewModels, categoryId, page);
            return this.View(viewModel);
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

        private PagingInfo CreatePagingInfo(int page, int pageSize, int totalItems)
        {
            return new PagingInfo()
            {
                CurrentPage = page,
                ItemPerPage = this.PageSize,
                TotalItems = totalItems
            };
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