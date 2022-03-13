using Demo.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Demo.Core.MvcUI.Model
{
    public class CategoryListViewModel
    {
        public List<Categories> Categories  { get; set; }
        public int CurrentCategory { get; set; }
    }
}
