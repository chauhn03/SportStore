using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = lineCollection.SingleOrDefault(item => item.Product.ProductId == product.ProductId);
            if (cartLine == null)
            {
                cartLine = new CartLine() { Product = product, Quantity = quantity };
                lineCollection.Add(cartLine);
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(item => item.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return this.lineCollection.Sum(item => item.Product.Price * item.Quantity);
        }

        public void Clear()
        {
            this.lineCollection.Clear();
        }

        public IEnumerable<CartLine> GetItems()
        {
            return this.lineCollection;
        }
    }
}
