using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUserCase : IViewShoppingCartUserCase
    {
        private readonly IShoppingCart shoppingCart;

        public ViewShoppingCartUserCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public Task<Order> Execute()
        {
            return this.shoppingCart.GetOrderAsync();
        }
    }
}
