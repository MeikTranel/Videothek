using AutoMapper;
using Videothek.Persistence.Entities;

namespace Videothek.Core.Mapping
{
    public class EntityToBusinessObjectConfiguration : Profile
    {
        public override string ProfileName => "EntityToBusinessObjects";

        public EntityToBusinessObjectConfiguration()
        {
            ConfigureUserMappings();
            ConfigurePenaltyMappings();
            ConfigureVideoMappings();
            ConfigureRentalMappings();
        }

        private void ConfigureUserMappings()
        {
            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();
        }

        private void ConfigurePenaltyMappings()
        {
            CreateMap<Penalty, PenaltyEntity>();
            CreateMap<PenaltyEntity, Penalty>()
                .ForMember(
                    p => p.User,
                    opt => opt.ResolveUsing<ForeignKeyResolver<UserEntity,User>,int>(pE => pE.UserID)
                );
        }

        private void ConfigureVideoMappings()
        {
            CreateMap<Video, VideoEntity>();
            CreateMap<VideoEntity, Video>();
        }

        private void ConfigureRentalMappings()
        {
            CreateMap<Rental, RentalEntity>();
            CreateMap<RentalEntity, Rental>()
                .ForMember(
                    r => r.User,
                    opt => opt.ResolveUsing<ForeignKeyResolver<RentalEntity, User>, int>(rE => rE.UserID)
                )
                .ForMember(
                    r => r.Video,
                    opt => opt.ResolveUsing<ForeignKeyResolver<RentalEntity, Video>, int>(rE => rE.VideoID)
                );
        }
    }
}
