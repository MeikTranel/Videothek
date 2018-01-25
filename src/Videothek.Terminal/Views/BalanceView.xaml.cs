using System;
using System.Windows;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaktionslogik für BalanceView.xaml
    /// </summary>
    public partial class BalanceView
    {
        public BalanceView()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender);
        }
    }
}
