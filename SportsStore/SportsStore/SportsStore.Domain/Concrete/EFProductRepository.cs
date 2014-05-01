using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Product> Products
        {
            get
            {
                return context.Products;
            }
        }


        public Entities.Product GetProductById(int productId)
        {
            Product product = this.context.Products.SingleOrDefault(p => p.ProductId == productId);
            return product ?? new Product();
        }


        public void SaveProduct(Entities.Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }

            context.SaveChanges();
        }

        public void Delete(int productId)
        {
            Product product = this.context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                this.context.Products.Remove(product);
                this.context.SaveChanges();
            }
        }
    }
}
