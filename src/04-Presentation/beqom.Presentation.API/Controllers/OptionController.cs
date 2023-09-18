using beqom.Application.Contract.Services;
using beqom.Core.Extension;
using beqom.Domain.Contract.DTO.Option;
using beqom.Domain.Contract.Enum.OptionType;
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
        /// GetOption
        /// </summary>
        /// <param name="optionType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Option/GetOptionAsync/{optionType}")]
        public async Task<IActionResult> GetOptionAsync([FromRoute] OptionType optionType)
        {
            var data = await this.appService.GetOptionAsync(new OptionRequestDto { Option = optionType });
            var response = CreateResponse<OptionResponseDto>.Return(data, "GetOptionAsync Controller");
            return Ok(response);
        }
    }
}
