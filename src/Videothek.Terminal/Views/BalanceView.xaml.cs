using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaktionslogik für BalanceView.xaml
    /// </summary>
    public partial class BalanceView : UserControl
    {
        public BalanceView()
        {
            InitializeComponent();
        }

        private void btnBestetigen_Click(object sender, RoutedEventArgs e)
        {
            sender.ToString();
            var bla = DataContext as BalanceViewModel;
        }
    }
}
