using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ShoppingCard.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IProductRepository repository;
        private const string cstrShoppingCart = "eShop.ShoppingCart";

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository repository)
        {
            this.jsRuntime = jsRuntime;
            this.repository = repository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.Id, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public Task EmptyAsync()
        {
            return this.SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await this.SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantity(int productId, int quantity)
        {
            var order = await this.GetOrder();
            if (quantity < 0)
                return order;
            else if (quantity == 0)
                return await DeleteProductAsync(productId);
            else
            {
                var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
                if (lineItem != null) lineItem.Quantity = quantity;
                await SetOrder(order);

                return order;
            }
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;

            var strOrder = await this.jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!String.IsNullOrEmpty(strOrder) && strOrder.ToLower() != "null")
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var line in order.LineItems)
            {
                line.Product = repository.GetProduct(line.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await this.jsRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
