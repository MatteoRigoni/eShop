using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.State;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingcart;
        private readonly IShoppingCartStateService cartState;

        public DeleteProductUseCase(IShoppingCart shoppingcart, IShoppingCartStateService cartState)
        {
            this.shoppingcart = shoppingcart;
            this.cartState = cartState;
        }

        public async Task<Order> Execute(int productId)
        {
            var order = await this.shoppingcart.DeleteProductAsync(productId);
            this.cartState.UpdateLineItemsCount();

            return order;
        }
    }
}
