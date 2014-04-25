using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests.Entities
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            Product product1 = new Product { ProductId = 1, Name = "P1" };
            Product product2 = new Product { ProductId = 2, Name = "P2" };

            Cart target = new Cart();

            target.AddItem(product1, 10);
            target.AddItem(product2, 20);

            CartLine[] results = target.GetItems().ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(results[0].Product, product1);
            Assert.AreEqual(results[1].Product, product2);
        }

        [TestMethod]
        public void Can_Add_Existing_Lines()
        {
            Product product1 = new Product { ProductId = 1, Name = "P1" };
            Product product2 = new Product { ProductId = 1, Name = "P2" };

            Cart target = new Cart();

            target.AddItem(product1, 10);
            target.AddItem(product2, 20);

            CartLine[] results = target.GetItems().ToArray();

            Assert.AreEqual(1, results.Length);
            Assert.AreEqual(30, results[0].Quantity);
        }

        [TestMethod]
        public void Can_Remove_Lines()
        {
            Product product1 = new Product { ProductId = 1, Name = "P1" };
            Product product2 = new Product { ProductId = 1, Name = "P2" };

            Cart target = new Cart();

            target.AddItem(product1, 10);
            target.AddItem(product2, 20);

            target.RemoveItem(product1);
            CartLine[] results = target.GetItems().ToArray();
            Assert.AreEqual(0, results.Length);
        }
    }
}
