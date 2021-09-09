using eShop.CoreBusiness.Models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}