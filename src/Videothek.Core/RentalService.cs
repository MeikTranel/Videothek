using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videothek.Persistence;
using Videothek.Persistence.Entities;

namespace Videothek.Core
{
    public class RentalService
    {
        private readonly Repository<RentalEntity> _rentalRepository;

        public RentalService(Repository<RentalEntity> rentalRepository)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
        }

        public void RentAVideo(Video video,User user)
        {
            _rentalRepository.Insert(
                new RentalEntity()
                {
                    VideoID = video.ID,
                    Date = DateTime.Now,
                    UserID = user.ID
                }
            );
        }
    }
}
