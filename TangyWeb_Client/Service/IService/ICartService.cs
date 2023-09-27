using System;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service.IService
{
    public interface ICartService
	{
        Task DecrementCart(ShoppingCartVM shoppingCart);
        Task IncrementCart(ShoppingCartVM shoppingCart);
    }
}

