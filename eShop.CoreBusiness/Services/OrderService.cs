using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.CoreBusiness.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInformation(
            string name,
            string address)
        {
            if (String.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address)) return false;
            return true;
        }

        public bool ValidateOrder(Order order)
        {
            if (order.LineItems == null || order.LineItems.Count == 0) return false;
            return true;
        }

    }
}
