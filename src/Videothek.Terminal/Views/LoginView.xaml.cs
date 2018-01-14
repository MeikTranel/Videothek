using System.Diagnostics;
using MahApps.Metro.Controls;
using System.Windows;
using Stylet;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((LoginViewModel) this.DataContext).Password = pbPassword.SecurePassword;
        }
    }
}
