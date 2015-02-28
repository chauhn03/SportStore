using SportsStore.Service.Abstract;
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

        //
        // GET: /Admin/Topic/

        public ActionResult Index()
        {
            return View();
        }

    }
}
