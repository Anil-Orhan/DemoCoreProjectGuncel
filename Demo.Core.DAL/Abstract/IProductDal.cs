using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Abstract
{
    public interface IProductDal:IEntityRepository<Products>
    {
        //özel operasyonlar yazabilirsiniz. ornegin view sp gibi.
    }
}
