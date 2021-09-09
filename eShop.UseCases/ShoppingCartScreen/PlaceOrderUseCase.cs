using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.Services;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.State;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateService cartState;

        public PlaceOrderUseCase(
            IOrderService orderService,
            IOrderRepository orderRepository,
            IShoppingCart shoppingCart,
            IShoppingCartStateService cartState)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
            this.cartState = cartState;
        }

        public async Task<string> Execute(Order order)
        {
            if (orderService.ValidateOrder(order))
            {
                order.DatePlaced = DateTime.UtcNow;
                order.OrderIdentifier = Guid.NewGuid().ToString();
                this.orderRepository.CreateOrder(order);

                await this.shoppingCart.EmptyAsync();
                this.cartState.UpdateLineItemsCount();

                return order.OrderIdentifier;
            }

            return null;
        }
    }
}
