using beqom.Application.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace beqom.Presentation.API.Controllers
{
    public class RefTypeController : Controller
    {
        private readonly ICoreApplicationService appService;

        public RefTypeController(ICoreApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// AddRefType
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Route("api/RefType/AddRefType")]
        //[HttpPost]
        //public IActionResult AddRefType([FromBody]AddRefTypeRequestDTO request)
        //{
        //    return Ok(this.appService.AddRefType(request));
        //}
    }
}
