using System;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service.IService
{
    public interface ICartService
	{
        public event Action OnChange;
        Task DecrementCart(ShoppingCartVM shoppingCart);
        Task IncrementCart(ShoppingCartVM shoppingCart);
    }
}

