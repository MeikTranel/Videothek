using System;

namespace Videothek.Terminal.ViewModels
{
    public interface ICanRequestRootViewModelExchange
    {
        event EventHandler<Object> RootVMExchangeRequested;
        void RequestVMExchange(object screen);
    }
}
