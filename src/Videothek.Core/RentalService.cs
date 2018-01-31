using System;
using Videothek.Persistence;
using Videothek.Persistence.Entities;

namespace Videothek.Core
{
    public class RentalService
    {
        private readonly Repository<RentalEntity> _rentalRepository;
        private readonly UserService _userService;

        public RentalService(Repository<RentalEntity> rentalRepository,UserService userService)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public void RentAVideo(Video video,int userID)
        {
            if (video.Availability < 0)
                throw new InvalidOperationException("Video is not available for Rent at the moment.");

            _userService.Debit(userID,video.Price);
            _rentalRepository.Insert(
                new RentalEntity()
                {
                    VideoID = video.ID,
                    Date = DateTime.Now,
                    UserID = userID
                }
            );
        }
    }
}
