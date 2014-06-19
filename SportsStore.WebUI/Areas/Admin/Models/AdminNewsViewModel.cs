using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Areas.Admin.Models
{
    public class AdminNewsViewModel : NewsViewModel
    {
        public SelectList NewsTypes { get; set; }
    }
}