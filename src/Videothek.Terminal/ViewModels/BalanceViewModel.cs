using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videothek.Authentication;
using Videothek.Core.Authorization;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    public class BalanceViewModel:Screen
    {
      private Balance _balance;
      public BalanceViewModel(Balance balance)
        {
            _balance = balance ?? throw new ArgumentException(nameof(balance));
        }
        public string Name => _balance.Name;
        public string IBAN => _balance.IBAN;
        public float Betrag => _balance.Betrag;
    }
}
