using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace Videothek.Terminal.ViewModels
{
    public class HostViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public HostViewModel(IWindowManager windowManager, LoginViewModel loginViewModel)
        {
            ActivateItem(loginViewModel);
        }
    }
}
