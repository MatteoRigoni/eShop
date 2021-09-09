using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class OrderConfirmationUseCase : IOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;

        public OrderConfirmationUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Execute(string uniqueId)
        {
            return this.orderRepository.GetOrderByUniqueId(uniqueId);
        }
    }
}
