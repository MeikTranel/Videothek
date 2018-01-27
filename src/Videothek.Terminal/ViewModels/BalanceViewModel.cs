using Stylet;
using System;
using System.Windows;
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

        private string _iBAN;

        public string IBAN
        {
            get { return _iBAN; }
            set { _iBAN = value; }
        }

        public void DoAccept()
        {
            if (Amount > 0)
            {
                Balance += Amount;
            }
            else
                MessageBox.Show("Please enter the amount", "Your amount is 0 ",
                  MessageBoxImage.Exclamation);

        }
    }
}
