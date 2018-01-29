using System;
using Stylet;
using StyletIoC;
using Videothek.Core;
using Videothek.Core.Authorization;

namespace Videothek.Terminal.ViewModels
{
    public class VideoViewModel : Screen
    {
        private readonly Video _video;
        private readonly IContainer _container;

        public VideoViewModel(Video video,IContainer container)
        {
            _video = video ?? throw new ArgumentNullException(nameof(video));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public string Name => _video.Name;
        public float Price => _video.Price;
        public bool IsAvailable => _video.Availability > 0;
        public bool HasSetCoverLocation => string.IsNullOrWhiteSpace(_video.CoverImageLocation);

        public void DoRent()
        {
            RentalService rentalService = _container.Get<RentalService>();
            if (_container.Get<ISessionProvider>().TryGetActiveSession(out Session session))
                try {
                    rentalService.RentAVideo(_video, session.User.ID);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            else
            {
                throw new InvalidOperationException("Could not fetch active Session");
            }
        }
    }
}
