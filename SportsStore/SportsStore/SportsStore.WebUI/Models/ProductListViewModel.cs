using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> ProductViewModels { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public int? CurrentCategory { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}