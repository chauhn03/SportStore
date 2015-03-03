using System.Collections.Generic;

namespace SportsStore.WebUI.Models
{
    public class TopicListViewModel
    {
        public IEnumerable<TopicViewModel> Topics { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
