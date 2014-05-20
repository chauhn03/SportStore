using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public Dictionary<int, string> Categories { get; set; }
    }
}