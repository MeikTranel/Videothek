using System.Windows.Controls;
using System.Windows.Input;
using Videothek.Core;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        public LibraryView()
        {
            InitializeComponent();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((LibraryViewModel)DataContext).DoVideoOpen(((ListViewItem)sender).Content as Video);
        }
    }
}
