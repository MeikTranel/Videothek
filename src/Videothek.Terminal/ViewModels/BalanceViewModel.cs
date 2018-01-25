using Stylet;
using System;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    class BalanceViewModel:Screen
    {
        private readonly User _user;
        
        public BalanceViewModel(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
           
        }

        public float Balance
        {
            get => _user.Balance;
            set => _user.Balance = value;
        }
    }
}
