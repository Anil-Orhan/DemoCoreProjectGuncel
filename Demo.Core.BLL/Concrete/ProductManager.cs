using Demo.Core.BLL.Abstract;
using Demo.Core.DAL.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Products products)
        {
           _productDal.Add(products);
        }

        public void Delete(int productID)
        {
            Products products = GetById(productID);
            _productDal.Delete(products);
        }

        public List<Products> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Products> GetByCategory(int categoryID)
        {
            return _productDal.GetList(p=>p.CategoryID==categoryID);
        }

        public Products GetById(int productID)
        {
            return _productDal.Get(p => p.ProductID == productID);

        }

        public void Update(Products products)
        {
            _productDal.Update(products);
        }
    }
}
