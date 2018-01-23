using System;
using Stylet;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    public class VideoViewModel : Screen
    {
        private readonly Video _video;

        public VideoViewModel(Video video)
        {
            _video = video ?? throw new ArgumentNullException(nameof(video));
        }

        public string Name => _video.Name;
        public float Price => _video.Price;
        public bool IsAvailable => _video.Availability > 0;
        public bool HasSetCoverLocation => string.IsNullOrWhiteSpace(_video.CoverImageLocation);
    }
}
