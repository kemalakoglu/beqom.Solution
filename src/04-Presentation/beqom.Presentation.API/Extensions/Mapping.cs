using AutoMapper;
using beqom.Domain.Aggregate.RefTypeValue;
using beqom.Domain.Contract.DTO.Option;

namespace beqom.Presentation.API.Extensions
{
    public class Mapping : Profile
    {
        //public static void ConfigureMapping()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.AllowNullCollections = true;
        //        cfg.CreateMap<RefType, RefTypeDTO>();
        //        cfg.CreateMap<AddRefTypeResponseDTO, AddRefTypeRequestDTO>();
        //    });
        //}

        public Mapping()
        {
            CreateMap<Option, OptionResponseDto>();
        }
    }
}