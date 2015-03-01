using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Areas.Admin.Models;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        #region Fields
        private INewsService newsService;
        private ITopicService topicService;
        #endregion

        #region Constructors
        public NewsController(INewsService newsService, ITopicService topicService)
        {
            this.newsService = newsService;
            this.topicService = topicService;
            this.PageSize = 12;
        }
        #endregion

        #region Properties
        public int PageSize { get; set; }
        #endregion

        public ActionResult Create()
        {
            News news = new News();
            IEnumerable<Topic> newsTypes = this.topicService.GetAll();

            NewsViewModel viewModel = this.CreateNewsViewModel(news);
            viewModel.Topics = new SelectList(newsTypes, "Id", "Name");
            return View("Edit", viewModel);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                News news = this.newsService.GetById(id);
                this.newsService.Delete(news);
                TempData["message"] = string.Format("{0} was deleted", news.Title);
                return this.RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            News news = this.newsService.GetById(id);
            IEnumerable<Topic> topics = this.topicService.GetAll();

            var viewModel = this.CreateNewsViewModel(news);
            viewModel.Topics = new SelectList(topics, "Id", "Name");
            return View(viewModel);
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(News news, string submitButton, FormCollection collection)
        {
            try
            {
                switch (submitButton)
                {
                    case "Save":
                        // TODO: Add update logic here
                        this.UpdateNews(news);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/News/
        public ActionResult Index(int? topicId, int page = 1)
        {
            var newsList = topicId.GetValueOrDefault(0) > 0 ? this.newsService.GetByTopic(topicId.Value) : this.newsService.GetAll();
            IQueryable<NewsViewModel> newsViewModels = from news in newsList
                                                       join topic in this.topicService.GetAll()
                                                       on news.TypeId equals topic.Id
                                                       select this.CreateViewModel(news, topic.Name);

            NewsListViewModel viewModel = this.CreateNewsListViewModel(newsViewModels, page, topicId);
            return View(viewModel);
        }

        private NewsListViewModel CreateNewsListViewModel(IEnumerable<NewsViewModel> newsList, int page, int? topicId)
        {
            var topics = this.topicService.GetAll().ToList();
            topics.Insert(0, new Topic { Id = -1, Name = "All" });

            NewsListViewModel viewModel = new NewsListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.PageSize, newsList.Count()),
                NewsList = newsList.GetDataOfPage<NewsViewModel>(page, this.PageSize),
                Topics = topics,
                CurrentTopic = topicId.GetValueOrDefault(-1)
            };

            return viewModel;
        }

        private NewsViewModel CreateNewsViewModel(News news, string newsType = null)
        {
            NewsViewModel newsViewProduct = new NewsViewModel();
            newsViewProduct.News = news;
            newsViewProduct.TopicName = newsType;
            return newsViewProduct;
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

        private NewsViewModel CreateViewModel(News news, string categoryName = null)
        {
            NewsViewModel viewModel = new NewsViewModel();
            viewModel.News = news;
            viewModel.TopicName = categoryName;
            return viewModel;
        }

        private void UpdateNews(News news)
        {
            if (news.Id > 0)
            {
                this.newsService.Update(news);
            }
            else
            {
                this.newsService.Add(news);
            }
        }
    }
}