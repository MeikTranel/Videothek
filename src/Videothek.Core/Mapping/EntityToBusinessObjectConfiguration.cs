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
        }

        private void ConfigureUserMappings()
        {
            CreateMap<UserEntity,User>();
            CreateMap<User, UserEntity>();
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
    }
}
