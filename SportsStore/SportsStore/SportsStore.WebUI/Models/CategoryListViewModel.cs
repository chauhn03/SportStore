using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}