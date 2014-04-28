﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        //
        // GET: /Nav/

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = this.repository.Products.Select(product => product.Category)
                                                                     .Distinct()
                                                                     .OrderBy(category => category);
            return this.PartialView(categories);
        }

    }
}