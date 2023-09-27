using System;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service
{
	public class CartService : ICartService
	{
		public CartService()
		{
		}

        public Task DecrementCart(ShoppingCartVM shoppingCart)
        {
            throw new NotImplementedException();
        }

        public Task IncrementCart(ShoppingCartVM shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}

