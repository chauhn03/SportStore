using SportsStore.Domain.Entities;
using System.Web.Mvc;

namespace SportsStore.WebUI.Models
{
    public class NewsViewModel
    {
        public News News { get; set; }

        public string TopicName { get; set; }

        public SelectList Topics { get; set; }
    }
}