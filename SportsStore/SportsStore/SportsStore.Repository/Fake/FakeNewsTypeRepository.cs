using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeNewsTypeRepository : FakeRepository<NewsType>, INewsTypeRepository
    {
        private List<NewsType> newsTypes;

        public FakeNewsTypeRepository()
        {
            this.GenerateDummyData();
        }

        public override void Create(NewsType entity)
        {
            this.newsTypes.Add(entity);
        }

        public override void Delete(NewsType entity)
        {
            this.newsTypes.Remove(entity);
        }

        public override IQueryable<NewsType> GetAll()
        {
            return this.newsTypes.AsQueryable();
        }

        public override NewsType GetById(int id)
        {
            return this.newsTypes.Single(newsType => newsType.Id == id);
        }

        private void GenerateDummyData()
        {
            this.newsTypes = new List<NewsType>();
            this.newsTypes.Add(new NewsType { Id = 1, Name = "NewsType 1" });
            this.newsTypes.Add(new NewsType { Id = 2, Name = "NewsType 2" });
            this.newsTypes.Add(new NewsType { Id = 3, Name = "NewsType 3" });
            this.newsTypes.Add(new NewsType { Id = 4, Name = "NewsType 4" });
            this.newsTypes.Add(new NewsType { Id = 5, Name = "NewsType 5" });
        }
    }
}