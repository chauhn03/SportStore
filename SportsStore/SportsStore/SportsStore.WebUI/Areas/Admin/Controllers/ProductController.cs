﻿using SportsStore.Domain.Entities;
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
            IQueryable<ProductViewModel> productViewModels = from product in this.productService.GetByCategory(categoryId)
                                                             join category in this.categoryService.GetAll()
                                                             on product.CategoryId equals category.CategoryId
                                                             select this.CreateProductViewModel(product, null, category.Name);

            ProductListViewModel viewModel = this.CreateProductListViewModel(productViewModels, categoryId, page);
            return this.View(viewModel);
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
                if (product.ProductId < 0)
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

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = this.productService.GetById(productId);
            this.productService.Delete(product);
            TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index");
        }

        private ProductViewModel CreateProductViewModel(Product product, IEnumerable<Category> categories = null, string categoryName = null)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = product;
            productViewModel.CategoryName = categoryName;
            productViewModel.Categories = (categories == null) ? null : (new SelectList(categories, "CategoryId", "Name"));
            return productViewModel;
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
    }
}
