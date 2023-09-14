using AutoMapper;
using beqom.Core.Contract;
using beqom.Core.Helper;
using beqom.Domain.Contract.DTO.Option;

namespace beqom.Domain.Aggregate.RefTypeValue
{
    public class OptionService: IOptionService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ResponseDTO<OptionResponseDto> GetByKey(long key)
        {
            throw new System.NotImplementedException();
        }
    }
}
