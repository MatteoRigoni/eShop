using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.State;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IProductRepository repository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateService shoppingState;

        public AddProductToCartUseCase(
            IProductRepository repository,
            IShoppingCart shoppingCart,
            IShoppingCartStateService shoppingState)
        {
            this.repository = repository;
            this.shoppingCart = shoppingCart;
            this.shoppingState = shoppingState;
        }

        public async void Execute(int productId)
        {
            var product = this.repository.GetProduct(productId);
            await shoppingCart.AddProductAsync(product);

            this.shoppingState.UpdateLineItemsCount();
        }
    }
}
