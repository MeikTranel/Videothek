using System;
using AutoMapper;
using Videothek.Persistence;

namespace Videothek.Core.Mapping
{
    public class ForeignKeyResolver<TNestedEntity,TNestedBusinessClass> : IMemberValueResolver<object,object,int, TNestedBusinessClass>
        where TNestedEntity : class, new()
        where TNestedBusinessClass : class
    {
        private readonly Repository<TNestedEntity> _repository;

        public ForeignKeyResolver(Repository<TNestedEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }

        public TNestedBusinessClass Resolve(object source, object destination, int sourceMember, TNestedBusinessClass destMember,
            ResolutionContext context)
        {
            return Mapper.Map<TNestedBusinessClass>(_repository.Get(sourceMember));
        }
    }
}
