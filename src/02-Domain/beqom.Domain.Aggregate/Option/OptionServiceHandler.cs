using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using beqom.Core.Contract;
using beqom.Domain.Contract.DTO.Option;
using MediatR;

namespace beqom.Domain.Aggregate.RefTypeValue
{
    public class OptionServiceHandler: IRequestHandler<OptionRequestDto, OptionResponseDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OptionServiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<OptionResponseDto> Handle(OptionRequestDto request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
