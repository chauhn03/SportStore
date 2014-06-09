using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class NewsListViewModel
    {
        public IEnumerable<News> NewsList { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}