using beqom.Domain.Contract.DTO;
using beqom.Domain.Contract.DTO.Option;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beqom.Application.Contract.Services
{
    public interface IApplicationService
    {
        /// <summary>
        /// GetOptionAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OptionResponseDto> GetOptionAsync(OptionRequestDto request);

        /// <summary>
        /// GetOptionAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ReportRequestDto request);
    }
}
