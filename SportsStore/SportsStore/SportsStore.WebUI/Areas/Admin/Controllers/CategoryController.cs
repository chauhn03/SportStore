using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        private int pageSize;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.pageSize = 12;
        }

        //
        // GET: /Admin/Category/

        //
        // GET: /Admin/Category/Create
        public ActionResult Create()
        {
            Category category = new Category();
            CategoryViewModel viewModel = this.CreateCategoryViewModel(category);
            return this.View("Edit", viewModel);
        }

        //
        // POST: /Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return this.View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int categoryId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Category category = this.categoryService.GetById(categoryId);
                this.categoryService.Delete(category);
                TempData["message"] = string.Format("{0} was deleted", category.Name);
                return this.RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Category category = this.categoryService.GetById(id);            
            CategoryViewModel viewModel = this.CreateCategoryViewModel(category);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Category category, string submitButton, FormCollection collection)
        {
            CategoryViewModel viewModel = this.CreateCategoryViewModel(category);
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                switch (submitButton)
                {
                    case "Save":
                        if (category.CategoryId > 0)
                        {
                            // TODO: Add update logic here
                            this.categoryService.Update(category);
                        }
                        else
                        {
                            this.categoryService.Add(category);
                        }

                        break;
                    default:
                        break;
                }
            }
            catch
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index(int page = 1)
        {
            IQueryable<Category> categories = this.categoryService.GetAll();
            CategoryListViewModel viewModel = this.CreateCategoryListViewModel(categories, page);
            return View(viewModel);
        }

        //
        // GET: /Admin/Category/Edit/5
        //
        // POST: /Admin/Category/Edit/5
        //
        // GET: /Admin/Category/Delete/5
        //
        // POST: /Admin/Category/Delete/5
        private CategoryListViewModel CreateCategoryListViewModel(IEnumerable<Category> categories, int page)
        {
            CategoryListViewModel viewModel = new CategoryListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.pageSize, categories.Count()),
                Categories = categories.GetDataOfPage<Category>(page, this.pageSize),
            };

            return viewModel;
        }

        private CategoryViewModel CreateCategoryViewModel(Category category)
        {
            CategoryViewModel viewmodel = new CategoryViewModel { Category = category };
            return viewmodel;
        }
        private PagingInfo CreatePagingInfo(int page, int pageSize, int totalItems)
        {
            return new PagingInfo()
            {
                CurrentPage = page,
                ItemPerPage = pageSize,
                TotalItems = totalItems
            };
        }
    }
}