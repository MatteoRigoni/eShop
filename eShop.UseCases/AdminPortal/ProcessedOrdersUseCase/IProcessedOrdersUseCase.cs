using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AdminPortal.ProcessedOrdersUseCase
{
    public interface IProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}