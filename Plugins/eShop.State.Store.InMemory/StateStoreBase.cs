using eShop.UseCases.PluginInterfaces.State;
using System;

namespace eShop.State.Store.InMemory
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action listener) => this.listeners += (listener);

        public void BroadCastStateChange()
        {
            if (this.listeners != null) this.listeners.Invoke();
        }

        public void RemoveStateChangeListeners(Action listener) => this.listeners -= (listener);
    }
}
