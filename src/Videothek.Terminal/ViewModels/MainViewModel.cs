﻿using Stylet;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public MainViewModel()
        {
            RegisterDetailViewModel(
              new BalanceViewModel(new User(1, "Meik"))
              {
                  Balance = 1.1f,
                  IBAN = "DE12XXXXXXXXXXXXXXXXXX15"
                  
             }
           );
            RegisterDetailViewModel(
              new BalanceViewModel(new User(2, "Admin"))
              {
                  Balance = 2.1f,
                  IBAN="DE13XXXXXXXXXXXXXXXXXXX16"


              }
            );

            RegisterDetailViewModel(
                new VideoViewModel(
                    new Video()
                    {
                        Name = "Boondock Saints",
                        Availability = 123,
                        Price  = 13.37f,
                        CoverImageLocation = ""
                    }
                )
            );
        }


        public void DoActivateDetailViewModel(IScreen detailViewModel)
        {
            this.ActivateItem(detailViewModel);
        }


        private void RegisterDetailViewModel(IScreen detailViewModel)
        {
            this.Items.Add(detailViewModel);
        }
    }
}
