using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;

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
            Topic topic = new Topic();
            TopicViewModel viewModel = this.CreateViewModel(topic);
            return this.View("Edit", viewModel);
        }
        
        private TopicListViewModel CreateTopicListViewModel(IEnumerable<TopicViewModel> viewModelList, int page)
        {
            TopicListViewModel viewModel = new TopicListViewModel()
            {                
                PagingInfo = this.CreatePagingInfo(page, this.pageSize, viewModelList.Count()),
                Topics = viewModelList.GetDataOfPage<TopicViewModel>(page, this.pageSize)                
            };

            return viewModel;
        }

        private PagingInfo CreatePagingInfo(int page, int pageSize, int totalItems)
        {
            return new PagingInfo()
            {
                CurrentPage = page,
                ItemPerPage = pageSize,
                TotalItems = totalItems
            };
        }

        private TopicViewModel CreateViewModel(Topic topic)
        {
            TopicViewModel viewModel = new TopicViewModel()
            {
                Topic = topic
            };

            return viewModel;
        }

        public ViewResult Edit(int id)
        {
            Topic topic = this.topicService.GetById(id);
            TopicViewModel viewModel = this.CreateViewModel(topic);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TopicViewModel viewModel, string submitButton)
        {
            if (!this.ModelState.IsValid)
                return this.View(viewModel);

            if (submitButton != "Save")
                return RedirectToAction("Index");

            if (viewModel.Topic.Id > 0)
            {
                this.topicService.Update(viewModel.Topic);
            }
            else
            {
                this.topicService.Add(viewModel.Topic);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Topic/

        public ActionResult Index(int page = 1)
        {
            var topicViewModels = from topic in this.topicService.GetAll()
                                  select this.CreateViewModel(topic);
            var topicListViewModel = this.CreateTopicListViewModel(topicViewModels, page);
            return View(topicListViewModel);
        }

    }
}
