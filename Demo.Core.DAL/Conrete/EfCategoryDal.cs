using Demo.Core.DAL.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Conrete
{
    public class EfCategoryDal:EfEntityRepositoryBase<Categories,NorthwindContext>,ICategoryDal
    {                                            
    }
}
