using System.Windows;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView
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
