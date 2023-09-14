using System.Threading.Tasks;
using beqom.Core.Enumeration;
using beqom.Domain.Contract.DTO.Option;
using MediatR;

namespace beqom.Application.EventHandlers.RefType
{
    public class OptionQuery
    {
        private readonly IMediator mediator;

        public OptionQuery(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OptionResponseDto> GetOptionByDefault()
        {
            return await this.mediator.Send(new OptionRequestDto { option = Options.Default});
        }

        public async Task<OptionResponseDto> GetOption(OptionRequestDto requestDto)
        {
            return await this.mediator.Send(requestDto);
        }
    }
}
