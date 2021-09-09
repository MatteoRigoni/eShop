using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.PluginInterfaces.State
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action listener);
        void RemoveStateChangeListeners(Action listener);
        void BroadCastStateChange();
    }
}
