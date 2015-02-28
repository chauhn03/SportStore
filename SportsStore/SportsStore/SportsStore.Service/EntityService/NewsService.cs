using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Service.EntityService
{
    public class NewsService : Service<News, INewsRepository>, INewsService
    {       
          private IUnitOfWork unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = unitOfWork.News;
        }

        public IQueryable<News> GetByTopic(int topicId)
        {
            return this.Repository.GetAll().Where(news => news.TypeId == topicId);

        }
    }
}
