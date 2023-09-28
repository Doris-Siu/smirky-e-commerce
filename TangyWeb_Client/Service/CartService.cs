using Blazored.LocalStorage;
using Tangy_Common;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Serivce
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }

        public event Action OnChange;

        public async Task IncrementCart(ShoppingCartVM cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartVM>>(SD.ShoppingCart);
            bool itemInCart = false;

            if (cart == null)
            {
                cart = new List<ShoppingCartVM>();
            }


            // checks if the item already existed -> just increment the count if true
            foreach (var obj in cart)
            {
                if (obj.ProductId == cartToAdd.ProductId && obj.ProductPriceId == cartToAdd.ProductPriceId)
                {
                    itemInCart = true;
                    obj.Count += cartToAdd.Count;
                }
            }

            // if not -> add new item to the cart list
            if (!itemInCart)
            {
                cart.Add(new ShoppingCartVM()
                {
                    ProductId = cartToAdd.ProductId,
                    ProductPriceId = cartToAdd.ProductPriceId,
                    Count = cartToAdd.Count
                });
            }

            // update the local storage at the end
            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);

            // invoke & notify the binded component to
            OnChange.Invoke();

        }


        public async Task DecrementCart(ShoppingCartVM cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartVM>>(SD.ShoppingCart);

            //if count is 0 or 1 then we remove the item
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == cartToDecrement.ProductId && cart[i].ProductPriceId == cartToDecrement.ProductPriceId)
                {
                    if (cart[i].Count == 1 || cartToDecrement.Count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count -= cartToDecrement.Count;
                    }
                }
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            OnChange.Invoke();

        }
    }
}