using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public string CategoryName { get; set; }

        public SelectList Categories { get; set; }
    }    
}