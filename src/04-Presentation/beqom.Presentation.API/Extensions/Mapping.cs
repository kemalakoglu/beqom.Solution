using AutoMapper;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using beqom.Domain.Contract.DTO.Option;

namespace beqom.Presentation.API.Extensions
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Option, OptionResponseDto>();
        }
    }
}