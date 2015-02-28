using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class NewsListViewModel
    {
        public IEnumerable<NewsViewModel> NewsList { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}