using SportsStore.Domain.Entities;
using System.Linq;

namespace SportsStore.Service.Abstract
{
    public interface INewsService : IService<News>
    {
        IQueryable<News> GetByTopic(int topicId);
    }
}
