using Eticaret.Business.Abstract;
using Eticaret.MVCUI.Models;
using Eticaret.MVCUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Eticaret.MVCUI.ViewComponents
{
   
    public class CartSummaryViewComponent:ViewComponent
    {
        private ICartSessionServices _cartSessionServices;
        public CartSummaryViewComponent(ICartSessionServices cartSessionService)
        {
            _cartSessionServices = cartSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionServices.GetCart()
        };
        return View(model);
        }
    }
}
