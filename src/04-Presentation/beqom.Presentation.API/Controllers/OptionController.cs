using beqom.Application.Contract.Services;
using beqom.Core.Extension;
using beqom.Domain.Contract.DTO.Option;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace beqom.Presentation.API.Controllers
{
    public class OptionController : Controller
    {
        private readonly IApplicationService appService;

        public OptionController(IApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// AddRefType
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/Option/Get")]
        [HttpPost]
        public async Task<IActionResult> GetOption([FromBody] OptionRequestDto request)
        {
            var data = await this.appService.GetOption(request);
            var response = CreateResponse<OptionResponseDto>.Return(data, "GetOption Controller");
            return Ok(response);
        }
    }
}
