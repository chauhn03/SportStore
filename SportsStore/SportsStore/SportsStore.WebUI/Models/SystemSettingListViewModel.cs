using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class SystemSettingListViewModel
    {
        public int Id { get; set; }

        public IList<SystemSettingViewModel> SystemSettingViewModels { get; set; }
    }
}