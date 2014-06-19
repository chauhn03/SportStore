using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICategoryService service;

        public NavController(ICategoryService service)
        {
            this.service = service;
        }
        //
        // GET: /Nav/

        public PartialViewResult Menu(int? categoryId = null)
        {
            ViewBag.SelectedCategory = categoryId; 
            IQueryable<Category> categories = this.service.GetAll();
            return this.PartialView(categories);
        }

    }
}
