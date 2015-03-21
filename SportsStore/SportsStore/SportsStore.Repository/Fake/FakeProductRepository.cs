using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.Fake
{
    public class FakeProductRepository : FakeRepository<Product>, IProductRepository
    {
        private static FakeProductRepository instance;
        private List<Product> products;
        private FakeProductRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeProductRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeProductRepository();
                }

                return instance;
            }
        }

        public override int Create(Product entity)
        {
            int maxId = this.products.Max(product => product.ProductId);
            entity.ProductId = maxId + 1;
            this.products.Add(entity);
            return 1;
        }

        public override void Delete(Product entity)
        {
            this.products.Remove(entity);
        }

        public override IQueryable<Product> GetAll()
        {
            return this.products.AsQueryable();
        }

        public IQueryable<Product> GetByCategory(int? categoryId)
        {
            return this.products.Where(product => !categoryId.HasValue || product.CategoryId == categoryId).AsQueryable();
        }

        public override Product GetById(int id)
        {
            return this.products.Single(product => product.ProductId == id);
        }

        public override void Update(Product entity)
        {
            Product product = this.GetById(entity.ProductId);
            product.CategoryId = entity.CategoryId;
            product.Description = entity.Description;
            product.ImageData = entity.ImageData;
            product.ImageMimeType = entity.ImageMimeType;
            product.Modified = DateTime.Now;
            product.Name = entity.Name;
            product.Price = entity.Price;
        }

        private void GenerateDummyData()
        {
            this.products = new List<Product>();
            this.products.Add(new Product() { ProductId = 1, CategoryId = 1, Created = DateTime.Now, Description = "Description 1", Modified = DateTime.Now, ProductNo = "Product No 1", Name = "Product 1", Price = 110 });
            this.products.Add(new Product() { ProductId = 2, CategoryId = 1, Created = DateTime.Now, Description = "Description 2", Modified = DateTime.Now, ProductNo = "Product No 2", Name = "Product 2", Price = 142 });
            this.products.Add(new Product() { ProductId = 3, CategoryId = 3, Created = DateTime.Now, Description = "Description 3", Modified = DateTime.Now, ProductNo = "Product No 3", Name = "Product 3", Price = 150 });
            this.products.Add(new Product() { ProductId = 4, CategoryId = 4, Created = DateTime.Now, Description = "Description 4", Modified = DateTime.Now, ProductNo = "Product No 4", Name = "Product 4", Price = 180 });
            this.products.Add(new Product() { ProductId = 5, CategoryId = 3, Created = DateTime.Now, Description = "Description 5", Modified = DateTime.Now, ProductNo = "Product No 5", Name = "Product 5", Price = 220 });
            this.products.Add(new Product() { ProductId = 6, CategoryId = 2, Created = DateTime.Now, Description = "Description 6", Modified = DateTime.Now, ProductNo = "Product No 6", Name = "Product 6", Price = 250 });
            this.products.Add(new Product() { ProductId = 7, CategoryId = 2, Created = DateTime.Now, Description = "Description 7", Modified = DateTime.Now, ProductNo = "Product No 7", Name = "Product 7", Price = 160 });
            this.products.Add(new Product() { ProductId = 8, CategoryId = 4, Created = DateTime.Now, Description = "Description 8", Modified = DateTime.Now, ProductNo = "Product No 8", Name = "Product 8", Price = 280 });
            this.products.Add(new Product() { ProductId = 9, CategoryId = 1, Created = DateTime.Now, Description = "Description 9", Modified = DateTime.Now, ProductNo = "Product No 9", Name = "Product 9", Price = 300 });
            this.products.Add(new Product() { ProductId = 10, CategoryId = 2, Created = DateTime.Now, Description = "Description 10", Modified = DateTime.Now, ProductNo = "Product No 10", Name = "Product 10", Price = 230 });


            this.products.Add(new Product() { ProductId = 11, CategoryId = 1, Created = DateTime.Now, Description = "Description 11", Modified = DateTime.Now, ProductNo = "Product No 11", Name = "Product 11", Price = 320 });
            this.products.Add(new Product() { ProductId = 12, CategoryId = 1, Created = DateTime.Now, Description = "Description 12", Modified = DateTime.Now, ProductNo = "Product No 12", Name = "Product 12", Price = 350 });
            this.products.Add(new Product() { ProductId = 13, CategoryId = 3, Created = DateTime.Now, Description = "Description 13", Modified = DateTime.Now, ProductNo = "Product No 13", Name = "Product 13", Price = 380 });
            this.products.Add(new Product() { ProductId = 14, CategoryId = 4, Created = DateTime.Now, Description = "Description 14", Modified = DateTime.Now, ProductNo = "Product No 14", Name = "Product 14", Price = 210 });
            this.products.Add(new Product() { ProductId = 15, CategoryId = 3, Created = DateTime.Now, Description = "Description 15", Modified = DateTime.Now, ProductNo = "Product No 15", Name = "Product 15", Price = 190 });
            this.products.Add(new Product() { ProductId = 16, CategoryId = 2, Created = DateTime.Now, Description = "Description 16", Modified = DateTime.Now, ProductNo = "Product No 16", Name = "Product 16", Price = 165 });
            this.products.Add(new Product() { ProductId = 17, CategoryId = 2, Created = DateTime.Now, Description = "Description 17", Modified = DateTime.Now, ProductNo = "Product No 17", Name = "Product 17", Price = 285 });
            this.products.Add(new Product() { ProductId = 18, CategoryId = 4, Created = DateTime.Now, Description = "Description 18", Modified = DateTime.Now, ProductNo = "Product No 18", Name = "Product 18", Price = 275 });
            this.products.Add(new Product() { ProductId = 19, CategoryId = 1, Created = DateTime.Now, Description = "Description 19", Modified = DateTime.Now, ProductNo = "Product No 19", Name = "Product 19", Price = 350 });
            this.products.Add(new Product() { ProductId = 20, CategoryId = 2, Created = DateTime.Now, Description = "Description 20", Modified = DateTime.Now, ProductNo = "Product No 20", Name = "Product 20", Price = 335 });

            this.products.Add(new Product() { ProductId = 21, CategoryId = 1, Created = DateTime.Now, Description = "Description 21", Modified = DateTime.Now, ProductNo = "Product No 21", Name = "Product 21", Price = 115 });
            this.products.Add(new Product() { ProductId = 22, CategoryId = 1, Created = DateTime.Now, Description = "Description 22", Modified = DateTime.Now, ProductNo = "Product No 22", Name = "Product 22", Price = 1145 });
            this.products.Add(new Product() { ProductId = 23, CategoryId = 3, Created = DateTime.Now, Description = "Description 23", Modified = DateTime.Now, ProductNo = "Product No 23", Name = "Product 23", Price = 155 });
            this.products.Add(new Product() { ProductId = 24, CategoryId = 4, Created = DateTime.Now, Description = "Description 24", Modified = DateTime.Now, ProductNo = "Product No 24", Name = "Product 24", Price = 185 });
            this.products.Add(new Product() { ProductId = 25, CategoryId = 3, Created = DateTime.Now, Description = "Description 25", Modified = DateTime.Now, ProductNo = "Product No 25", Name = "Product 25", Price = 225 });
            this.products.Add(new Product() { ProductId = 26, CategoryId = 2, Created = DateTime.Now, Description = "Description 26", Modified = DateTime.Now, ProductNo = "Product No 26", Name = "Product 26", Price = 250 });
            this.products.Add(new Product() { ProductId = 27, CategoryId = 2, Created = DateTime.Now, Description = "Description 27", Modified = DateTime.Now, ProductNo = "Product No 27", Name = "Product 27", Price = 163 });
            this.products.Add(new Product() { ProductId = 28, CategoryId = 4, Created = DateTime.Now, Description = "Description 28", Modified = DateTime.Now, ProductNo = "Product No 28", Name = "Product 28", Price = 287 });
            this.products.Add(new Product() { ProductId = 29, CategoryId = 1, Created = DateTime.Now, Description = "Description 29", Modified = DateTime.Now, ProductNo = "Product No 29", Name = "Product 29", Price = 310 });
            this.products.Add(new Product() { ProductId = 30, CategoryId = 2, Created = DateTime.Now, Description = "Description 30", Modified = DateTime.Now, ProductNo = "Product No 30", Name = "Product 30", Price = 235 });


            this.products.Add(new Product() { ProductId = 31, CategoryId = 5, Created = DateTime.Now, Description = "Description 31", Modified = DateTime.Now, ProductNo = "Product No 31", Name = "Product 31", Price = 326 });
            this.products.Add(new Product() { ProductId = 32, CategoryId = 5, Created = DateTime.Now, Description = "Description 32", Modified = DateTime.Now, ProductNo = "Product No 32", Name = "Product 32", Price = 351 });
            this.products.Add(new Product() { ProductId = 33, CategoryId = 6, Created = DateTime.Now, Description = "Description 33", Modified = DateTime.Now, ProductNo = "Product No 33", Name = "Product 33", Price = 388 });
            this.products.Add(new Product() { ProductId = 34, CategoryId = 7, Created = DateTime.Now, Description = "Description 34", Modified = DateTime.Now, ProductNo = "Product No 34", Name = "Product 34", Price = 212 });
            this.products.Add(new Product() { ProductId = 35, CategoryId = 8, Created = DateTime.Now, Description = "Description 35", Modified = DateTime.Now, ProductNo = "Product No 35", Name = "Product 35", Price = 195 });
            this.products.Add(new Product() { ProductId = 36, CategoryId = 9, Created = DateTime.Now, Description = "Description 36", Modified = DateTime.Now, ProductNo = "Product No 36", Name = "Product 36", Price = 169 });
            this.products.Add(new Product() { ProductId = 37, CategoryId = 7, Created = DateTime.Now, Description = "Description 37", Modified = DateTime.Now, ProductNo = "Product No 37", Name = "Product 37", Price = 289 });
            this.products.Add(new Product() { ProductId = 38, CategoryId = 8, Created = DateTime.Now, Description = "Description 38", Modified = DateTime.Now, ProductNo = "Product No 38", Name = "Product 38", Price = 277 });
            this.products.Add(new Product() { ProductId = 39, CategoryId = 5, Created = DateTime.Now, Description = "Description 39", Modified = DateTime.Now, ProductNo = "Product No 39", Name = "Product 39", Price = 356 });
            this.products.Add(new Product() { ProductId = 40, CategoryId = 6, Created = DateTime.Now, Description = "Description 40", Modified = DateTime.Now, ProductNo = "Product No 40", Name = "Product 40", Price = 335 });

            this.products.Add(new Product() { ProductId = 41, CategoryId = 7, Created = DateTime.Now, Description = "Description 41", Modified = DateTime.Now, ProductNo = "Product No 41", Name = "Product 41", Price = 110 });
            this.products.Add(new Product() { ProductId = 42, CategoryId = 6, Created = DateTime.Now, Description = "Description 42", Modified = DateTime.Now, ProductNo = "Product No 42", Name = "Product 42", Price = 142 });
            this.products.Add(new Product() { ProductId = 43, CategoryId = 10, Created = DateTime.Now, Description = "Description 43", Modified = DateTime.Now, ProductNo = "Product No 43", Name = "Product 43", Price = 150 });
            this.products.Add(new Product() { ProductId = 44, CategoryId = 7, Created = DateTime.Now, Description = "Description 44", Modified = DateTime.Now, ProductNo = "Product No 44", Name = "Product 44", Price = 180 });
            this.products.Add(new Product() { ProductId = 45, CategoryId = 9, Created = DateTime.Now, Description = "Description 45", Modified = DateTime.Now, ProductNo = "Product No 45", Name = "Product 45", Price = 220 });
            this.products.Add(new Product() { ProductId = 46, CategoryId = 8, Created = DateTime.Now, Description = "Description 46", Modified = DateTime.Now, ProductNo = "Product No 46", Name = "Product 46", Price = 250 });
            this.products.Add(new Product() { ProductId = 47, CategoryId = 6, Created = DateTime.Now, Description = "Description 47", Modified = DateTime.Now, ProductNo = "Product No 47", Name = "Product 47", Price = 160 });
            this.products.Add(new Product() { ProductId = 48, CategoryId = 9, Created = DateTime.Now, Description = "Description 48", Modified = DateTime.Now, ProductNo = "Product No 48", Name = "Product 48", Price = 280 });
            this.products.Add(new Product() { ProductId = 49, CategoryId = 10, Created = DateTime.Now, Description = "Description 49", Modified = DateTime.Now, ProductNo = "Product No 49", Name = "Product 49", Price = 300 });
            this.products.Add(new Product() { ProductId = 50, CategoryId = 8, Created = DateTime.Now, Description = "Description 50", Modified = DateTime.Now, ProductNo = "Product No 50", Name = "Product 50", Price = 230 });


            this.products.Add(new Product() { ProductId = 51, CategoryId = 9, Created = DateTime.Now, Description = "Description 51", Modified = DateTime.Now, ProductNo = "Product No 51", Name = "Product 51", Price = 320 });
            this.products.Add(new Product() { ProductId = 52, CategoryId = 10, Created = DateTime.Now, Description = "Description 52", Modified = DateTime.Now, ProductNo = "Product No 52", Name = "Product 52", Price = 350 });
            this.products.Add(new Product() { ProductId = 53, CategoryId = 6, Created = DateTime.Now, Description = "Description 53", Modified = DateTime.Now, ProductNo = "Product No 53", Name = "Product 53", Price = 380 });
            this.products.Add(new Product() { ProductId = 54, CategoryId = 7, Created = DateTime.Now, Description = "Description 54", Modified = DateTime.Now, ProductNo = "Product No 54", Name = "Product 54", Price = 210 });
            this.products.Add(new Product() { ProductId = 55, CategoryId = 9, Created = DateTime.Now, Description = "Description 55", Modified = DateTime.Now, ProductNo = "Product No 55", Name = "Product 55", Price = 190 });
            this.products.Add(new Product() { ProductId = 56, CategoryId = 10, Created = DateTime.Now, Description = "Description 56", Modified = DateTime.Now, ProductNo = "Product No 56", Name = "Product 56", Price = 165 });
            this.products.Add(new Product() { ProductId = 57, CategoryId = 8, Created = DateTime.Now, Description = "Description 57", Modified = DateTime.Now, ProductNo = "Product No 57", Name = "Product 57", Price = 285 });
            this.products.Add(new Product() { ProductId = 58, CategoryId = 8, Created = DateTime.Now, Description = "Description 58", Modified = DateTime.Now, ProductNo = "Product No 58", Name = "Product 58", Price = 275 });
            this.products.Add(new Product() { ProductId = 59, CategoryId = 10, Created = DateTime.Now, Description = "Description 59", Modified = DateTime.Now, ProductNo = "Product No 59", Name = "Product 59", Price = 350 });
            this.products.Add(new Product() { ProductId = 60, CategoryId = 9, Created = DateTime.Now, Description = "Description 60", Modified = DateTime.Now, ProductNo = "Product No 60", Name = "Product 60", Price = 335 });
        }
    }
}
