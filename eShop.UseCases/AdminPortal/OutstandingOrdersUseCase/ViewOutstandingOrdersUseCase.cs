using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository repository;

        public ViewOutstandingOrdersUseCase(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> Execute()
        {
            return this.repository.GetOutstandingOrders();
        }
    }
}
