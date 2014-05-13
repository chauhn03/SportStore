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

        private void GenerateDummyData()
        {
            this.products = new List<Product>();
            this.products.Add(new Product() { ProductId = 1, CategoryId = 1, Created = DateTime.Now, Description = "Description 1", Modified = DateTime.Now, Name = "Product 1", Price = 110 });
            this.products.Add(new Product() { ProductId = 2, CategoryId = 1, Created = DateTime.Now, Description = "Description 2", Modified = DateTime.Now, Name = "Product 2", Price = 142 });
            this.products.Add(new Product() { ProductId = 3, CategoryId = 3, Created = DateTime.Now, Description = "Description 3", Modified = DateTime.Now, Name = "Product 3", Price = 150 });
            this.products.Add(new Product() { ProductId = 4, CategoryId = 4, Created = DateTime.Now, Description = "Description 4", Modified = DateTime.Now, Name = "Product 4", Price = 180 });
            this.products.Add(new Product() { ProductId = 5, CategoryId = 3, Created = DateTime.Now, Description = "Description 5", Modified = DateTime.Now, Name = "Product 5", Price = 220 });
            this.products.Add(new Product() { ProductId = 6, CategoryId = 2, Created = DateTime.Now, Description = "Description 6", Modified = DateTime.Now, Name = "Product 6", Price = 250 });
            this.products.Add(new Product() { ProductId = 7, CategoryId = 2, Created = DateTime.Now, Description = "Description 7", Modified = DateTime.Now, Name = "Product 7", Price = 160 });
            this.products.Add(new Product() { ProductId = 8, CategoryId = 4, Created = DateTime.Now, Description = "Description 8", Modified = DateTime.Now, Name = "Product 8", Price = 280 });
            this.products.Add(new Product() { ProductId = 9, CategoryId = 1, Created = DateTime.Now, Description = "Description 9", Modified = DateTime.Now, Name = "Product 9", Price = 300 });
            this.products.Add(new Product() { ProductId = 10, CategoryId = 2, Created = DateTime.Now, Description = "Description 10", Modified = DateTime.Now, Name = "Product 10", Price = 230 });


            this.products.Add(new Product() { ProductId = 11, CategoryId = 1, Created = DateTime.Now, Description = "Description 11", Modified = DateTime.Now, Name = "Product 11", Price = 320 });
            this.products.Add(new Product() { ProductId = 12, CategoryId = 1, Created = DateTime.Now, Description = "Description 12", Modified = DateTime.Now, Name = "Product 12", Price = 350 });
            this.products.Add(new Product() { ProductId = 13, CategoryId = 3, Created = DateTime.Now, Description = "Description 13", Modified = DateTime.Now, Name = "Product 13", Price = 380 });
            this.products.Add(new Product() { ProductId = 14, CategoryId = 4, Created = DateTime.Now, Description = "Description 14", Modified = DateTime.Now, Name = "Product 14", Price = 210 });
            this.products.Add(new Product() { ProductId = 15, CategoryId = 3, Created = DateTime.Now, Description = "Description 15", Modified = DateTime.Now, Name = "Product 15", Price = 190 });
            this.products.Add(new Product() { ProductId = 16, CategoryId = 2, Created = DateTime.Now, Description = "Description 16", Modified = DateTime.Now, Name = "Product 16", Price = 165 });
            this.products.Add(new Product() { ProductId = 17, CategoryId = 2, Created = DateTime.Now, Description = "Description 17", Modified = DateTime.Now, Name = "Product 17", Price = 285 });
            this.products.Add(new Product() { ProductId = 18, CategoryId = 4, Created = DateTime.Now, Description = "Description 18", Modified = DateTime.Now, Name = "Product 18", Price = 275 });
            this.products.Add(new Product() { ProductId = 19, CategoryId = 1, Created = DateTime.Now, Description = "Description 19", Modified = DateTime.Now, Name = "Product 19", Price = 350 });
            this.products.Add(new Product() { ProductId = 20, CategoryId = 2, Created = DateTime.Now, Description = "Description 20", Modified = DateTime.Now, Name = "Product 20", Price = 335 });
        }

        public override Product GetById(int id)
        {
            return this.products.Single(product => product.ProductId == id);
        }

        public override void Create(Product entity)
        {
            int maxId = this.products.Max(product => product.ProductId);
            entity.ProductId = maxId + 1;
            this.products.Add(entity);
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
    }
}
