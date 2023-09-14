using beqom.Core.Helper;
using beqom.Domain.Contract.DTO.Option;
using System.Threading.Tasks;

namespace beqom.Application.Contract.Services
{
    public interface IApplicationService
    {
        /// <summary>
        /// GetOption
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OptionResponseDto> GetOption(OptionRequestDto request);
    }
}
