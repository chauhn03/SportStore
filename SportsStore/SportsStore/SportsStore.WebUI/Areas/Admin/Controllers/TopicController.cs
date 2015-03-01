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
    public class TopicController : Controller
    {        
        private ITopicService topicService;

        private int pageSize;

        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
            this.pageSize = 12;
        }

        public ViewResult Create()
        {
            TopicViewModel viewModel = new TopicViewModel { Topic = new Topic() };
            return this.View("Edit", viewModel);
        }

        public ViewResult Edit()
        {
            return this.View();
        }

        //
        // GET: /Admin/Topic/

        public ActionResult Index()
        {
            return View();
        }

    }
}
