using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeNewsRepository : FakeRepository<News>, INewsRepository
    {
        private static FakeNewsRepository instance;
        private List<News> news;

        public FakeNewsRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeNewsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeNewsRepository();
                }

                return instance;
            }
        }

        public override void Create(News entity)
        {
            int maxId = this.news.Max(news => news.Id);
            entity.Id = maxId + 1;
            this.news.Add(entity);
        }

        public override void Delete(News entity)
        {
            this.news.Remove(entity);
        }

        public override IQueryable<News> GetAll()
        {
            return this.news.AsQueryable();
        }

        public override News GetById(int id)
        {
            return this.news.Single(news => news.Id == id);
        }

        public override void Update(News entity)
        {
            News news = this.GetById(entity.Id);
            news.Title = entity.Title;
            news.TypeId = entity.TypeId;
            news.Content = entity.Content;
            news.Modified = DateTime.Now;
        }

        private void GenerateDummyData()
        {
            this.news = new List<News>();
            this.news.Add(new News { Id = 1, TypeId = 1, Title = "Title 1", Content = "Content 1" });
            this.news.Add(new News { Id = 2, TypeId = 1, Title = "Title 2", Content = "Content 2" });
            this.news.Add(new News { Id = 3, TypeId = 1, Title = "Title 3", Content = "Content 3" });
            this.news.Add(new News { Id = 4, TypeId = 1, Title = "Title 4", Content = "Content 4" });
            this.news.Add(new News { Id = 5, TypeId = 2, Title = "Title 5", Content = "Content 5" });
            this.news.Add(new News { Id = 6, TypeId = 2, Title = "Title 6", Content = "Content 6" });
            this.news.Add(new News { Id = 7, TypeId = 2, Title = "Title 7", Content = "Content 7" });
            this.news.Add(new News { Id = 8, TypeId = 3, Title = "Title 8", Content = "Content 8" });
            this.news.Add(new News { Id = 9, TypeId = 3, Title = "Title 9", Content = "Content 9" });
            this.news.Add(new News { Id = 10, TypeId = 4, Title = "Title 10", Content = "Content 10" });
            this.news.Add(new News { Id = 11, TypeId = 4, Title = "Title 11", Content = "Content 11" });
            this.news.Add(new News { Id = 12, TypeId = 2, Title = "Title 12", Content = "Content 12" });
            this.news.Add(new News { Id = 13, TypeId = 3, Title = "Title 13", Content = "Content 13" });
            this.news.Add(new News { Id = 14, TypeId = 2, Title = "Title 14", Content = "Content 14" });
            this.news.Add(new News { Id = 15, TypeId = 1, Title = "Title 15", Content = "Content 15" });
            this.news.Add(new News { Id = 16, TypeId = 1, Title = "Title 16", Content = "Content 16" });
            this.news.Add(new News { Id = 17, TypeId = 1, Title = "Title 17", Content = "Content 17" });
            this.news.Add(new News { Id = 18, TypeId = 1, Title = "Title 18", Content = "Content 18" });
            this.news.Add(new News { Id = 19, TypeId = 1, Title = "Title 19", Content = "Content 19" });
            this.news.Add(new News { Id = 20, TypeId = 1, Title = "Title 20", Content = "Content 20" });
        }
    }
}