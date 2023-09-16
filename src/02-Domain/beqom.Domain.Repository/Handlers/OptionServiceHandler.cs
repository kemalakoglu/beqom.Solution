using AutoMapper;
using beqom.Core.Helper;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using beqom.Domain.Contract.DTO.Option;
using beqom.Domain.Contract.Enum.OptionType;
using beqom.Domain.Contract.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace beqom.Domain.Repository.Handlers
{
    public class OptionServiceHandler: IRequestHandler<OptionRequestDto, OptionResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IOptionRepository optionRepository;
        public OptionServiceHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            this.mapper = mapper;
            this.optionRepository = optionRepository;
        }

        public async Task<OptionResponseDto> Handle(OptionRequestDto request, CancellationToken cancellationToken)
        {
            var response = new OptionResponseDto();
            Option option = await this.optionRepository.GetOption(request.Option);
            response = mapper.Map<OptionResponseDto>(option);
            return response;

        }
    }
}
