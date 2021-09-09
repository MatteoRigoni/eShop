using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.State
{
    public interface IShoppingCartStateService: IStateStore
    {
        Task<int> GetItemsCount();
        void UpdateLineItemsCount();
        void UpdateProductQuantity();
    }
}