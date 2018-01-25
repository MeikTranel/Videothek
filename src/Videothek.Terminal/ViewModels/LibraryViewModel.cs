using Stylet;
using System.Collections.ObjectModel;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    class LibraryViewModel : Screen
    {
        public LibraryViewModel(ObservableCollection<Video> videoLibrary)
        {
            VideoLibrary = videoLibrary;
        }
        private ObservableCollection<Video> videoLibrary;

        public ObservableCollection<Video> VideoLibrary { get => videoLibrary; set => videoLibrary = value; }
    }
}
