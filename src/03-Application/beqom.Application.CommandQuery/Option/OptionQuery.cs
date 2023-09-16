using beqom.Domain.Contract.DTO.Option;
using System.Threading.Tasks;

namespace beqom.Application.CommandQuery
{
    public partial class ApplicationService
    {
        #region Option Aggregate
        public async Task<OptionResponseDto> GetOption(OptionRequestDto request)
        {
            return await this.mediator.Send(request);
        }
        #endregion
    }
}
