using SportsStore.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportsStore.Repository.EF
{
    /// <summary>
    /// Creates the DB if it doesn't exist and populates it with seed data
    /// </summary>
    public class DatabaseInitialiser : CreateDatabaseIfNotExists<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            // TODO: Add your seed data here
            DataContext dataContext = context as DataContext;
            dataContext.Category.AddRange(this.GenerateCategories());
            dataContext.SaveChanges();
            
        }

        private IList<Category> GenerateCategories()
        {
            IList   <Category> categories = new List<Category>();
            categories.Add(new Category { CategoryId = 1, Name = "Category 1" });
            categories.Add(new Category { CategoryId = 2, Name = "Category 2" });
            categories.Add(new Category { CategoryId = 3, Name = "Category 3" });
            categories.Add(new Category { CategoryId = 4, Name = "Category 4" });
            categories.Add(new Category { CategoryId = 5, Name = "Category 5" });
            categories.Add(new Category { CategoryId = 6, Name = "Category 6" });
            categories.Add(new Category { CategoryId = 7, Name = "Category 7" });
            categories.Add(new Category { CategoryId = 8, Name = "Category 8" });
            return categories;
        }
    }
}