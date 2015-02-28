using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;
using SportsStore.WebUI.Areas.Admin.Models;
using SportsStore.WebUI.Infrastructure.Common;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private INewsService newsService;
        private ITopicService topicService;

        public NewsController(INewsService newsService, ITopicService topicService)
        {
            this.newsService = newsService;
            this.topicService = topicService;
            this.PageSize = 12;
        }

        public int PageSize { get; set; }

        public ActionResult Create()
        {
            News news = new News();
            IEnumerable<Topic> newsTypes = this.topicService.GetAll();

            AdminNewsViewModel viewModel = this.CreateNewsViewModel(news) as AdminNewsViewModel;
            viewModel.NewsTypes = new SelectList(newsTypes, "Id", "Name");
            return View("Edit");
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
            IEnumerable<Topic> newsTypes = this.topicService.GetAll();

            AdminNewsViewModel viewModel = this.CreateNewsViewModel(news) as AdminNewsViewModel;
            viewModel.NewsTypes = new SelectList(newsTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(News news, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                this.newsService.Update(news);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/News/
        public ActionResult Index()
        {
            return View();
        }

        private NewsListViewModel CreateNewsListViewModel(IEnumerable<News> newsList, int page)
        {
            NewsListViewModel viewModel = new NewsListViewModel()
            {
                PagingInfo = this.CreatePagingInfo(page, this.PageSize, newsList.Count()),
                NewsList = newsList.GetDataOfPage<News>(page, this.PageSize),
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

        private NewsViewModel CreateNewsViewModel(News news, string newsType = null)
        {
            NewsViewModel newsViewProduct = new NewsViewModel();
            newsViewProduct.News = news;
            newsViewProduct.NewsType = newsType;
            return newsViewProduct;
        }        
    }
}