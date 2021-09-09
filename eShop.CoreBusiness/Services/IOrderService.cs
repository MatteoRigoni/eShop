using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(string name, string address);
        bool ValidateOrder(Order order);
    }
}