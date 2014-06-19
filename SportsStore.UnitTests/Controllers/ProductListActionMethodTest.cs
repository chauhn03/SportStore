using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests.Controllers
{
    [TestClass]
    public class ProductListActionMethodTest
    {
        private IProductRepository GetRepository()
        {
            // Arrange 
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ ProductId = 1, Name = "Product 1", Description = "Description 1", Category = "Category 1", Price = 111 },
                    new Product{ ProductId = 2, Name = "Product 2", Description = "Description 2", Category = "Category 1", Price = 222 },
                    new Product{ ProductId = 3, Name = "Product 3", Description = "Description 3", Category = "Category 2", Price = 333 },
                    new Product{ ProductId = 4, Name = "Product 4", Description = "Description 4", Category = "Category 1", Price = 444 },
                    new Product{ ProductId = 5, Name = "Product 5", Description = "Description 5", Category = "Category 2", Price = 555 },
                    new Product{ ProductId = 6, Name = "Product 6", Description = "Description 6", Category = "Category 3", Price = 666 },
                    new Product{ ProductId = 7, Name = "Product 7", Description = "Description 7", Category = "Category 2", Price = 777 },
                    new Product{ ProductId = 8, Name = "Product 8", Description = "Description 8", Category = "Category 3", Price = 888 },
                    new Product{ ProductId = 9, Name = "Product 9", Description = "Description 9", Category = "Category 1", Price = 999 },
                    new Product{ ProductId = 10, Name = "Product 10", Description = "Description 10", Category = "Category 3", Price = 1111 },
                }.AsQueryable());

            return mock.Object;
        }

        [TestMethod]
        public void Can_Paginate()
        {
            IProductRepository repository = this.GetRepository();
            ProductController controller = new ProductController(repository);
            controller.PageSize = 3;
            
            // Act
            ProductListViewModel result = (ProductListViewModel)controller.List(null, 2).Model;

            Product[] productArray = result.Products.ToArray();
            Assert.AreEqual(3, productArray.Length);
            Assert.AreEqual("Product 4", productArray[0].Name);
            Assert.AreEqual("Product 6", productArray[2].Name);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            IProductRepository repository = this.GetRepository();
            ProductController controller = new ProductController(repository);
            controller.PageSize = 3;

            // Act
            ProductListViewModel result = (ProductListViewModel)controller.List("Category 2", 1).Model;

            Product[] productArray = result.Products.ToArray();
            Assert.AreEqual(3, productArray.Length);
            Assert.AreEqual("Product 3", productArray[0].Name);
            Assert.AreEqual("Product 7", productArray[2].Name);
        }
    }
}
