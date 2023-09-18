using AutoMapper;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.DTO.Option;
using beqom.Domain.Contract.Interface;
using MediatR;

namespace beqom.Domain.Repository.Handlers
{
    public class OptionServiceHandler : IRequestHandler<OptionRequestDto, OptionResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IOptionRepository optionRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="optionRepository"></param>
        public OptionServiceHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            this.mapper = mapper;
            this.optionRepository = optionRepository;
        }

        /// <summary>
        /// Task<OptionResponseDto> Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OptionResponseDto> Handle(OptionRequestDto request, CancellationToken cancellationToken)
        {
            var response = new OptionResponseDto();
            Option option = await this.optionRepository.GetOptionAsync(request.Option);
            response = mapper.Map<OptionResponseDto>(option);
            return response;

        }
    }
}
