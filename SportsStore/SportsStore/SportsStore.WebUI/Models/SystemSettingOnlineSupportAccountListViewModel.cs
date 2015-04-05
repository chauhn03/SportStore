using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class SystemSettingOnlineSupportAccountListViewModel
    {        
        public IList<SystemSettingViewModel> YahooAccounts { get; set; }

        public IList<SystemSettingViewModel> SkypeAccounts { get; set; }

        public int Id { get; set; }
    }
}