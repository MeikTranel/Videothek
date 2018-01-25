using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    class BalanceViewModel:Screen
    {
        private  User _user;
        
        public BalanceViewModel(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
           
        }

        public float Amount => _user.Balance;  
    }
}
