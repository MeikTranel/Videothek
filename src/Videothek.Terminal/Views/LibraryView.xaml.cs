using System;
using System.Windows;
using MahApps.Metro.Controls;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal.Views
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView
    {
        public LibraryView()
        {
            InitializeComponent();
        }

        private void Tile_OnClick(object sender, RoutedEventArgs e)
        {
            Tile selectedTile = (Tile)sender;
            VideoViewModel selectedViewModel = (VideoViewModel)selectedTile.DataContext;
            var viewModel = (LibraryViewModel)DataContext;
            viewModel.OpenVideo(selectedViewModel);
        }
    }
}
