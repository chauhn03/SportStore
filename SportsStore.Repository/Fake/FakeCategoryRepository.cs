using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeCategoryRepository : FakeRepository<Category>, ICategoryRepository
    {
        private List<Category> categories;
        private static FakeCategoryRepository instance;

        private FakeCategoryRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeCategoryRepository Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeCategoryRepository();
                }

                return instance;
            }
        }

        private void GenerateDummyData()
        {
            this.categories = new List<Category>();
            this.categories.Add(new Category { CategoryId = 1, Name = "Category 1", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 2, Name = "Category 2", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 3, Name = "Category 3", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 4, Name = "Category 4", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 5, Name = "Category 5", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 6, Name = "Category 6", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 7, Name = "Category 7", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 8, Name = "Category 8", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 9, Name = "Category 9", Created = DateTime.Now, Modified = DateTime.Now });
            this.categories.Add(new Category { CategoryId = 10, Name = "Category 10", Created = DateTime.Now, Modified = DateTime.Now });
        }

        public override Category GetById(int id)
        {
            return this.categories.SingleOrDefault(category => category.CategoryId == id);
        }

        public override void Create(Category entity)
        {
            int maxId = this.categories.Max(category => category.CategoryId);
            entity.CategoryId = maxId + 1;
            this.categories.Add(entity);
        }

        public override void Delete(Category entity)
        {
            this.categories.Remove(entity);
        }

        public override IQueryable<Category> GetAll()
        {
            return this.categories.AsQueryable();
        }

        public override void Update(Category entity)
        {
            Category category = this.GetById(entity.CategoryId);
            category.Name = entity.Name;
            category.Modified = DateTime.Now;
        }
    }
}
