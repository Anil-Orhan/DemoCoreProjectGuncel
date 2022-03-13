using Demo.Core.BLL.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Core.BLL.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Products products)
        {
            CartLine cartLine = cart.CartLine.FirstOrDefault(x => x.Products.ProductID == products.ProductID);
            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;

            }
            cart.CartLine.Add(new CartLine { Products = products, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLine;
        }

        public void RemoveToCart(Cart cart, int productID)
        {
            cart.CartLine.Remove(cart.CartLine.FirstOrDefault(x => x.Products.ProductID == productID));
        }
    }
}
