using Eticaret.Business.Abstract;
using Eticaret.Entities.Concrete;
using Eticaret.MVCUI.Models;
using Eticaret.MVCUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eticaret.MVCUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionServices _cartSessionService;
        private ICartService _cartServices;
        private IProductService _productServices;
        private int productid;

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
            _cartServices.AddToCart(cart, producttobeadded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("urun ,{0},", producttobeadded.ProductName));
            return RedirectToAction("Index", "Product");



        }
        public IActionResult List()
        {
            var cart= _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);

        }
        public IActionResult Remove(int ProductId)
        {
            var cart = _cartSessionService.GetCart();
            _cartServices.RemoveFromCart(cart, ProductId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("silindi"));
            return RedirectToAction("List","Cart");
        }
    }
}
