using beqom.Domain.Contract.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beqom.Application.CommandQuery
{
    public partial class ApplicationService
    {
        #region Report Aggregate

        /// <summary>
        /// GetReportsAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ReportRequestDto request)
        {
            return await this.mediator.Send(request);
        }
        #endregion
    }
}
