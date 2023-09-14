using AutoMapper;
using beqom.Core.Helper;
using beqom.Domain.Aggregate.Option;
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
            OptionResponseDto response;
            if (request.option == OptionType.Default)
            {
                DefaultOption option = await this.optionRepository.GetDefault();
                response = mapper.Map(option, new OptionResponseDto());
            }
            else
            {
                if (request.option == OptionType.Empty)
                {
                    IOptionGenericRepository<EmptyOption> repository = new OptionGenericRepository<EmptyOption>();
                    EmptyOption option = await repository.Get();
                    response = mapper.Map(option, new OptionResponseDto());
                }
                else if(request.option== OptionType.Config)
                {
                    IOptionGenericRepository<ConfigOption> repository = new OptionGenericRepository<ConfigOption>();
                    ConfigOption option = await repository.Get();
                    response = mapper.Map(option, new OptionResponseDto());
                }
                else
                    return null;
            }

            return response;
        }
    }
}
