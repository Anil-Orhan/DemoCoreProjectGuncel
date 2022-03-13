using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Entities.Concrete
{
    public class CartLine
    {
        public Products Products { get; set; }
        public decimal  Quantity { get; set; }
    }
}
