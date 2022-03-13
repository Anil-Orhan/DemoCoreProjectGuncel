using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLL.Abstract
{
    public interface IProductService
    {
        Products GetById(int productID);
        List<Products> GetAll();
        List<Products>GetByCategory(int categoryID);
        void Add(Products products);
        void Delete(int productID);
        void Update(Products products);






    }
}
