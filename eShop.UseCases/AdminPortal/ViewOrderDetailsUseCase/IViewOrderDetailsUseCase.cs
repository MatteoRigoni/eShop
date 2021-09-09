using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.ViewOrderDetailsUseCase
{
    public interface IViewOrderDetailsUseCase
    {
        Order Execute(int orderId);
    }
}