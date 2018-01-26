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
        private float _amount;

        public float Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
               
            }
        }
        public float Balance
        {
            get
            {
                return _user.Balance;
            }
            set
            {
                _user.Balance = value;
                NotifyOfPropertyChange("Balance");
            }
        }

        //public float Balance
        //{
        //    get => _user.Balance;
        //    set => _user.Balance = value;
        //}
         public void DoAccept()
        {
            Balance += Amount;
        }
    }
}
