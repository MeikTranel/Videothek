﻿using System;
using Stylet;
using StyletIoC;
using Videothek.Core.Authorization;

namespace Videothek.Terminal.ViewModels
{
    public class HostViewModel : Conductor<Screen>.StackNavigation
    {
        private readonly IContainer _iocContainer;
        

        public HostViewModel(IContainer iocContainer)
        {
            _iocContainer = iocContainer ?? throw new ArgumentNullException();
        }

        protected override void OnInitialActivate()
        {
            var loginViewModel = new LoginViewModel(_iocContainer.Get<ISessionProvider>());
            loginViewModel.LoginSucceeded += LoginViewModel_LoginSucceeded;
            this.ActivateItem(loginViewModel);
        }

        private void LoginViewModel_LoginSucceeded(object sender, Session e)
        {
            UnsubscribeFromLoginViewModel((LoginViewModel)sender);
            this.Clear();
            this.ActivateItem(new MainViewModel());
        }

        private void UnsubscribeFromLoginViewModel(LoginViewModel loginViewModel)
        {
            loginViewModel.LoginSucceeded -= LoginViewModel_LoginSucceeded;
        }
    }
}
