using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.ViewOrderDetailsUseCase
{
    public class ViewOrderDetailsUseCase : IViewOrderDetailsUseCase
    {
        private readonly IOrderRepository repository;

        public ViewOrderDetailsUseCase(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public Order Execute(int orderId)
        {
            return this.repository.GetOrder(orderId);
        }
    }
}
