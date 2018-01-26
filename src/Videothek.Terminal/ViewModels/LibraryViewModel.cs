using Stylet;
using System;
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

        public void DoVideoOpen(Video video)
        {
            OpenVideo?.Invoke(this, video);
        }

        private ObservableCollection<Video> videoLibrary;

        public ObservableCollection<Video> VideoLibrary { get => videoLibrary; set => videoLibrary = value; }

        public event EventHandler<Video> OpenVideo;
    }
}
