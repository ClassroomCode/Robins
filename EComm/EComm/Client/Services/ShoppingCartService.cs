using EComm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Client.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart Cart { get; }

        void AddToCart(Product product, int quantity);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartService()
        {
            _shoppingCart = new ShoppingCart();
        }

        public ShoppingCart Cart => _shoppingCart;

        public void AddToCart(Product product, int quantity)
        {
            var lineItem = _shoppingCart.LineItems.SingleOrDefault(l => l.Product.Id == product.Id);
            if (lineItem != null) {
                lineItem.Quantity += quantity;
            }
            else {
                var li = new ShoppingCart.LineItem(product) { Quantity = quantity };
                _shoppingCart.LineItems.Add(li);
            }
        }
    }
}
