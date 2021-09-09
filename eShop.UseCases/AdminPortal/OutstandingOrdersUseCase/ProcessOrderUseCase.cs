using eShop.CoreBusiness.Services;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersUseCase
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRepository repository;
        private readonly IOrderService orderService;

        public ProcessOrderUseCase(
            IOrderRepository repository,
            IOrderService orderService)
        {
            this.repository = repository;
            this.orderService = orderService;
        }

        public bool Execute(int orderId, string adminUser)
        {
            var order = this.repository.GetOrder(orderId);
            order.AdminUser = adminUser;
            order.DateProcessing = DateTime.UtcNow;

            if (orderService.ValidateOrder(order))
            {
                this.repository.UpdateOrder(order);
                return true;
            }

            return false;
        }
    }
}
