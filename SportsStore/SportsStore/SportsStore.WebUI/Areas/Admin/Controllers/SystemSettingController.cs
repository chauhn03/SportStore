using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class SystemSettingController : Controller
    {
        private string systemSettingOnlineSupportGroup = "OnlineSupport";
        private string systemSettingSocialNetworkGroup = "SocialNetwork";
        private ISystemSettingService systemSettingService;

        public SystemSettingController(ISystemSettingService systemSettingService)
        {
            this.systemSettingService = systemSettingService;
        }

        public ActionResult SEO()
        {
            SystemSetting systemSetting = this.systemSettingService.GetById(1);
            SystemSettingViewModel viewModel = this.CreateViewModel(systemSetting);
            return this.View(viewModel);
        }

        public ActionResult OnlineSupport()
        {
            IQueryable<SystemSettingViewModel> viewModels = from systemSetting in this.systemSettingService.GetByGroup(this.systemSettingOnlineSupportGroup)
                                                                             select this.CreateViewModel(systemSetting);
            SystemSettingOnlineSupportAccountListViewModel viewModel = this.CreateSystemSettingOnlineSupportAccountListViewModel(viewModels);
            return this.View(viewModel);
        }

        public ActionResult OnlinePayment()
        {
            IQueryable<SystemSettingViewModel> viewModels = from systemSetting in this.systemSettingService.GetByGroup(this.systemSettingSocialNetworkGroup)
                                                            select this.CreateViewModel(systemSetting);
            SystemSettingListViewModel viewModel = this.CreateListViewModel(viewModels);
            return this.View(viewModel);
        }

        private SystemSettingListViewModel CreateListViewModel(IEnumerable<SystemSettingViewModel> viewModels)
        {
            return new SystemSettingListViewModel
            {
                Id = 1,
                SystemSettingViewModels = viewModels.ToList()
            };
        }

        private SystemSettingOnlineSupportAccountListViewModel CreateSystemSettingOnlineSupportAccountListViewModel(IEnumerable<SystemSettingViewModel> viewModels)
        {
            return new SystemSettingOnlineSupportAccountListViewModel
            {
                Id = 1,
                SkypeAccounts = viewModels.Where(account => account.SystemSetting.Name.Contains("Skype") ).ToList(),
                YahooAccounts = viewModels.Where(account => account.SystemSetting.Name.Contains("Yahoo") ).ToList()
            };
        }

        private SystemSettingViewModel CreateViewModel(SystemSetting systemSetting)
        {
            return new SystemSettingViewModel
            {
                SystemSetting = systemSetting
            };
        }

        //
        // GET: /Admin/SystemSetting/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/SystemSetting/Edit/5

        [HttpPost]
        public ActionResult Edit(SystemSettingViewModel systemSettingViewModel, FormCollection collection)
        {
            if (this.ModelState.IsValid)
            {
                this.systemSettingService.Update(systemSettingViewModel.SystemSetting);
                TempData["systemSettingUpdateMessage"] = string.Format("Cập nhật thành công");
            }

            return this.RedirectToAction("SEO");

        }

        [HttpPost]
        public ActionResult EditSystemSettingOnlineSupportAccountListViewModel(SystemSettingOnlineSupportAccountListViewModel systemSettingListViewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.DeleteYahooOnlineSupport(systemSettingListViewModel);
                this.DeleteSkypeOnlineSupport(systemSettingListViewModel);
                foreach (var systemSettingViewModel in systemSettingListViewModel.YahooAccounts)
                {
                    systemSettingViewModel.SystemSetting.Group = this.systemSettingOnlineSupportGroup;
                    systemSettingViewModel.SystemSetting.Name = "Yahoo";
                    this.UpdateSystemSetting(systemSettingViewModel);    
                }

                foreach (var systemSettingViewModel in systemSettingListViewModel.SkypeAccounts)
                {
                    systemSettingViewModel.SystemSetting.Group = this.systemSettingOnlineSupportGroup;
                    systemSettingViewModel.SystemSetting.Name = "Skype";
                    this.UpdateSystemSetting(systemSettingViewModel);    
                }
                
                TempData["message"] = string.Format("Cập nhật thành công");
            }

            return this.RedirectToAction("OnlineSupport");
        }

        private void DeleteYahooOnlineSupport(SystemSettingOnlineSupportAccountListViewModel systemSettingListViewModel)
        {
            var removedOnlineSupports = (from onlineSupport in this.systemSettingService.GetByGroup(this.systemSettingOnlineSupportGroup)
                                        join systemSetting in systemSettingListViewModel.YahooAccounts
                                        on onlineSupport.Id equals systemSetting.SystemSetting.Id
                                        into gsysetSetting
                                        from systemSetting in gsysetSetting.DefaultIfEmpty()
                                        where systemSetting == null && onlineSupport.Name.Contains("Yahoo")
                                        select onlineSupport).ToList();

            foreach (var item in removedOnlineSupports)
            {
                this.systemSettingService.Delete(item);
            }
        }

        private void DeleteSkypeOnlineSupport(SystemSettingOnlineSupportAccountListViewModel systemSettingListViewModel)
        {
            var removedOnlineSupports = (from onlineSupport in this.systemSettingService.GetByGroup(this.systemSettingOnlineSupportGroup)
                                        join systemSetting in systemSettingListViewModel.SkypeAccounts
                                        on onlineSupport.Id equals systemSetting.SystemSetting.Id
                                        into gsysetSetting
                                        from systemSetting in gsysetSetting.DefaultIfEmpty()
                                        where systemSetting == null && onlineSupport.Name.Contains("Skype")
                                        select onlineSupport).ToList();

            foreach (var item in removedOnlineSupports)
            {
                this.systemSettingService.Delete(item);
            }
        }

        private void UpdateSystemSetting(SystemSettingViewModel systemSettingViewModel)
        {
            if (systemSettingViewModel.SystemSetting.Id > 0)
            {
                this.systemSettingService.Update(systemSettingViewModel.SystemSetting);
            }
            else
            {
                this.systemSettingService.Add(systemSettingViewModel.SystemSetting);
            }
        }
    }
}
