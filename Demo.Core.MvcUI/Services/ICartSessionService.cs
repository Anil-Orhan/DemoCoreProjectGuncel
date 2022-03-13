using Demo.Core.Entities.Concrete;

namespace Demo.Core.MvcUI.Services
{
    public interface ICartSessionService
    {

        Cart GetCart();
        void SetCart(Cart cart);



    }
}
