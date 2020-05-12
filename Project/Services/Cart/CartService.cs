using System.Collections.Generic;
using System.Linq;
using Project.Models;

namespace Project.Services
{
    public class CartService
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine cartLine = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (cartLine == null)
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else
                cartLine.Quantity += quantity;
        }

        public virtual void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        public virtual decimal ComputeTotalSum()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public virtual void Clear()
        {
            lineCollection.Clear();
        }

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
