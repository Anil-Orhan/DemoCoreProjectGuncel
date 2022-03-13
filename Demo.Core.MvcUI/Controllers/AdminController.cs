using Demo.Core.BLL.Abstract;
using Demo.Core.Entities.Concrete;
using Demo.Core.MvcUI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Products = new Core.Entities.Concrete.Products(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Products products)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(products);
                TempData.Add("message", "Product was successfully added");
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel()
            {
                Products = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult Update(Products products)
        {
            if (ModelState.IsValid)
            {

                _productService.Update(products);
                TempData.Add("message", "Product was successfully updated");
            }
            return RedirectToAction("Update");
        }
        public ActionResult Delete(int productId)
        {


            _productService.Delete(productId);
            TempData.Add("message", "Product was succesfully deleted");
            return RedirectToAction("Index");
        }


    }
}
