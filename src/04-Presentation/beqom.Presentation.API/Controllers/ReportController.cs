using beqom.Application.Contract.Services;
using beqom.Core.Extension;
using beqom.Domain.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace beqom.Presentation.API.Controllers
{
    public class ReportController : Controller
    {

        private readonly IApplicationService appService;

        public ReportController(IApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// GetReportAsync
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Report/GetReportAsync")]
        public async Task<IActionResult> GetReportAsync()
        {
            var data = await this.appService.GetReportsAsync(new ReportRequestDto());
            var response = CreateResponse<ReportResponseDto>.Return(data, "GetReportAsync Controller");
            return Ok(response);
        }
    }
}
