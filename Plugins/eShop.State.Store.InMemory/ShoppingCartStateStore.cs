using eShop.UseCases.PluginInterfaces.State;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.State.Store.InMemory
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateService
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<int> GetItemsCount()
        {
            var order = await shoppingCart.GetOrderAsync();
            if (order != null && order.LineItems != null && order.LineItems.Count > 0)
                return order.LineItems.Count();
            else
                return 0;

        }

        public void UpdateLineItemsCount()
        {
            this.BroadCastStateChange();
        }

        public void UpdateProductQuantity()
        {
            this.BroadCastStateChange();
        }
    }
}
