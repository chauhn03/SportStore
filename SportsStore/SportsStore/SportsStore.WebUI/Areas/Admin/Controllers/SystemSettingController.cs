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
    public class SystemSettingController : Controller
    {
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
                TempData["message"] = string.Format("Cập nhật thành công");
            }

            return this.RedirectToAction("SEO");

        }
    }
}
