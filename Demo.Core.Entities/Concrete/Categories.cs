using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.Entities.Concrete
{
    public class Categories: IEntity

    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get;  set; }
    }
}
