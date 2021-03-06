using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.CoreBusiness.Models
{
    public class Order
    {
        public Order()
        {
            this.LineItems = new List<OrderItem>();
        }

        public int? OrderId { get; set; }
        public string OrderIdentifier { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessing { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string AdminUser { get; set; }
        public List<OrderItem> LineItems { get; set; }

        public void AddProduct(int productId, int quantity, double price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
                item.Quantity += quantity;
            else
                LineItems.Add(new OrderItem() { ProductId = productId, Quantity = quantity, Price = price });
        }

        public void RemoveProduct(int productId)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null) LineItems.Remove(item);

        }
    }
}
