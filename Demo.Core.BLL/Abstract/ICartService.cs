using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLL.Abstract
{
    public interface ICartService
    {

        void AddToCart(Cart cart, Products products);
        void RemoveToCart(Cart cart, int productID);
        List<CartLine> List(Cart cart);


    }
}
