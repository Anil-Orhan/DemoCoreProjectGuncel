using Demo.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Demo.Core.MvcUI.Model
{
    public class ProductAddViewModel
    {
        public List<Categories> Categories { get; set; }

        public Products Products { get; set; }
    }
}
