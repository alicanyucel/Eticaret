using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.MVCUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionServices _cartSessionService;
        private ICartService _cartServices;
        private IProductService _productServices;
        public CartController(ICartService cartService, IProductService productService, ICartSessionServices cartSessionServices)
        {
            _cartServices = cartService;
            _productServices = productService;
            _cartSessionService = cartSessionServices;
        }
        public IActionResult AddToCart(int productid)
        {
            var producttobeadded = _productServices.GetById(productid);
            var cart = _cartSessionService.GetCart();
            _cartServices.AddToCart(cart,producttobeadded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message",string.Format("urun ,{0},",producttobeadded.ProductName));
          return   RedirectToAction("Index","Product");

    
            
        }
    }
}
