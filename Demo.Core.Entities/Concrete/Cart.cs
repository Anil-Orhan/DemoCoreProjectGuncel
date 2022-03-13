using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Core.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLine = new List<CartLine>();
        }
        public List<CartLine> CartLine { get; set; }
        public decimal Total
        {
            get
            {

                return CartLine.Sum(x => x.Products.UnitPrice *  x.Quantity);
            }
        }
    }

   
}
