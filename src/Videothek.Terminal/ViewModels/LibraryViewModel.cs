using Stylet;
using System;
using System.Collections.ObjectModel;
using StyletIoC;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    public class LibraryViewModel : Screen
    {
        private readonly IContainer _container;


        private Conductor<IScreen>.Collection.OneActive HostConductor =>
            (Conductor<IScreen>.Collection.OneActive) Parent;



        public LibraryViewModel(IContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            LoadVideos();
        }


        private ObservableCollection<VideoViewModel> _videoLibrary;
        public ObservableCollection<VideoViewModel> VideoLibrary
        {
            get => _videoLibrary;
            set => SetAndNotify(ref _videoLibrary, value);
        }

        public void OpenVideo(VideoViewModel videoViewModel)
        {
            HostConductor.ActivateItem(videoViewModel);
        }

        public void LoadVideos()
        {
            ObservableCollection<VideoViewModel> videoViewModels = new ObservableCollection<VideoViewModel>();
            var videos = _container.Get<VideoService>().FetchAllVideos();
            foreach (var video in videos)
            {
                videoViewModels.Add(new VideoViewModel(video,_container));
            }
            VideoLibrary = videoViewModels;
        }
    }
}
