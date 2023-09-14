using beqom.Application.Contract.Services;
using beqom.Core.Helper;
using beqom.Domain.Aggregate.RefTypeValue;
using beqom.Domain.Contract.DTO.Option;
using System.Threading.Tasks;

namespace beqom.Application.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IOptionService optionService;

        public ApplicationService(IOptionService optionService)
        {
            this.optionService = optionService;
        }

        #region Option Aggregate
        public Task<ResponseDTO<OptionResponseDto>> GetOption(OptionRequestDto request)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
