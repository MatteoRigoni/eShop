using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.ProcessedOrdersUseCase
{
    public class ProcessedOrdersUseCase : IProcessedOrdersUseCase
    {
        private readonly IOrderRepository repository;

        public ProcessedOrdersUseCase(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> Execute()
        {
            return this.repository.GetProcessedOrders();
        }
    }
}
