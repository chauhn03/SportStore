using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Fake
{
    public class FakeProductRepository : IProductRepository
    {
        private static IDictionary<int, Product> data;

        public FakeProductRepository()
        {
            if (data == null)
            {
                this.InitDummyData();
            }
        }

        private void InitDummyData()
        {
            Product[] dumyData = new Product[] 
            {
                new Product{ ProductId = 1, Name = "Product 1", Description = "Description 1", Category = "Category1", Price = 111 },
                new Product{ ProductId = 2, Name = "Product 2", Description = "Description 2", Category = "Category2", Price = 222 },
                new Product{ ProductId = 3, Name = "Product 3", Description = "Description 3", Category = "Category3", Price = 333 },
                new Product{ ProductId = 4, Name = "Product 4", Description = "Description 4", Category = "Category1", Price = 444 },
                new Product{ ProductId = 5, Name = "Product 5", Description = "Description 5", Category = "Category2", Price = 555 },
                new Product{ ProductId = 6, Name = "Product 6", Description = "Description 6", Category = "Category3", Price = 666 },
                new Product{ ProductId = 7, Name = "Product 7", Description = "Description 7", Category = "Category1", Price = 777 },
                new Product{ ProductId = 8, Name = "Product 8", Description = "Description 8", Category = "Category2", Price = 888 },
                new Product{ ProductId = 9, Name = "Product 9", Description = "Description 9", Category = "Category3", Price = 999 },
                new Product{ ProductId = 10, Name = "Product 10", Description = "Description 10", Category = "Category1", Price = 1111 },

                new Product{ ProductId = 11, Name = "Product 11", Description = "Description 11", Category = "Category2", Price = 120 },
                new Product{ ProductId = 12, Name = "Product 12", Description = "Description 12", Category = "Category3", Price = 220 },
                new Product{ ProductId = 13, Name = "Product 13", Description = "Description 13", Category = "Category4", Price = 320 },
                new Product{ ProductId = 14, Name = "Product 14", Description = "Description 14", Category = "Category3", Price = 420 },
                new Product{ ProductId = 15, Name = "Product 15", Description = "Description 15", Category = "Category2", Price = 520 },
                new Product{ ProductId = 16, Name = "Product 16", Description = "Description 16", Category = "Category1", Price = 620 },
                new Product{ ProductId = 17, Name = "Product 17", Description = "Description 17", Category = "Category2", Price = 720 },
                new Product{ ProductId = 18, Name = "Product 18", Description = "Description 18", Category = "Category3", Price = 820 },
                new Product{ ProductId = 19, Name = "Product 19", Description = "Description 19", Category = "Category4", Price = 920 },
                new Product{ ProductId = 20, Name = "Product 20", Description = "Description 20", Category = "Category1", Price = 1120 },
            };

            data = new List<Product>(dumyData).ToDictionary(p => p.ProductId);
        }

        public IQueryable<Entities.Product> Products
        {
            get
            {
                return data.Values.AsQueryable();
            }
        }


        public Product GetProductById(int productId)
        {
            return data.ContainsKey(productId) ? data[productId] : new Product();
        }


        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                product.ProductId = data.Count + 1;
                data.Add(product.ProductId, product);
            }
            else
            {
                data[product.ProductId] = product;
            }
        }

    }
}
