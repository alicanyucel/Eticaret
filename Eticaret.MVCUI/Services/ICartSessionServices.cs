using Eticaret.Entities.Concrete;

namespace Eticaret.MVCUI.Services
{
    public interface ICartSessionServices
    {
        Cart GetCart();
        void SetCart(Cart cart);

    }
}
