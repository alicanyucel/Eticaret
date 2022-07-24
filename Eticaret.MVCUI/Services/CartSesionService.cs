using Eticaret.Entities.Concrete;
using Eticaret.MVCUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace Eticaret.MVCUI.Services
{
    public class CartSesionService : ICartSessionServices

    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSesionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            // throw new System.NotImplementedException();
            Cart carttoCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if(carttoCheck==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                carttoCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return carttoCheck;
        }

        public void SetCart(Cart cart)
        {
            //throw new System.NotImplementedException();
            _httpContextAccessor.HttpContext.Session.SetObject("cart",cart);
        }
    }
}
