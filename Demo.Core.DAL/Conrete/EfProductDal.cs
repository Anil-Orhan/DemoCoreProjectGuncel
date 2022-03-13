using Demo.Core.DAL.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Core.DAL.EntityFramework;

namespace Demo.Core.DAL.Conrete
{
    public class EfProductDal : EfEntityRepositoryBase<Products>,IProductDal
    {
        public EfProductDal(NorthwindContext northwindContext) : base(northwindContext)
        {

        }


    }
}
