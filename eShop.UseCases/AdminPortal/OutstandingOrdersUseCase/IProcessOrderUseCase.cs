namespace eShop.UseCases.AdminPortal.OutstandingOrdersUseCase
{
    public interface IProcessOrderUseCase
    {
        bool Execute(int orderId, string adminUser);
    }
}