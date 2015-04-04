using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class SystemSettingListViewModel
    {
        public IList<SystemSettingViewModel> SystemSettingViewModels { get; set; }

        public int Id { get; set; }
    }
}