using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeTopicRepository : FakeRepository<Topic>, ITopicRepository
    {
        private List<Topic> topics;
        private static FakeTopicRepository instance;

        public FakeTopicRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeTopicRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeTopicRepository();
                }

                return instance;
            }
        }

        public override void Create(Topic entity)
        {
            int maxId = this.topics.Max(product => product.Id);
            entity.Id = maxId + 1;
            this.topics.Add(entity);
        }

        public override void Delete(Topic entity)
        {
            this.topics.Remove(entity);
        }

        public override IQueryable<Topic> GetAll()
        {
            return this.topics.AsQueryable();
        }

        public override Topic GetById(int id)
        {
            return this.topics.Single(newsType => newsType.Id == id);
        }

        private void GenerateDummyData()
        {
            this.topics = new List<Topic>();
            this.topics.Add(new Topic { Id = 1, Name = "Topic 1" });
            this.topics.Add(new Topic { Id = 2, Name = "Topic 2" });
            this.topics.Add(new Topic { Id = 3, Name = "Topic 3" });
            this.topics.Add(new Topic { Id = 4, Name = "Topic 4" });
            this.topics.Add(new Topic { Id = 5, Name = "Topic 5" });
        }

        public override void Update(Topic entity)
        {
            Topic topic = this.GetById(entity.Id);
            topic.Name = entity.Name;
            topic.Modified = DateTime.Now;
        }
    }
}