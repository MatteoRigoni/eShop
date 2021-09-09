using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<OrderItem> GetLinesByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            return orders[id];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            var allOrders = orders.Values;
            return allOrders.SingleOrDefault(o => o.OrderIdentifier == uniqueId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = orders.Values;
            return allOrders.Where(o => !o.DateProcessing.HasValue);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = orders.Values;
            return allOrders.Where(o => o.DateProcessing.HasValue);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null) return;

            var ord = orders[order.OrderId.Value];
            if (ord == null) return;
        }
    }
}
