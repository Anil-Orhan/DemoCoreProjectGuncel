using Demo.Core.BLL.Abstract;
using Demo.Core.MvcUI.Model;
using Demo.Core.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    public class CartController : Controller
    {

        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService=productService;

        }

        public ActionResult AddToCart(int productID)
        {
            var productToAdded = _productService.GetById(productID);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Your Product,{0},was successfulyy to the cart !",productToAdded.ProductName));
            return RedirectToAction("Index", "Product");

        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cart);
        }
        public ActionResult Remove(int productID)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveToCart(cart, productID);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Your Product was successfully removed from  the cart"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new Core.Entities.Concrete.ShippingDetails()
            };
            return View(shippingDetailViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetailsViewModel shippingDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", string.Format("Thank you {0}, you order is in procces",shippingDetailsViewModel.ShippingDetails.FirstName));
            return View(); 
        }






    }
}
