using beqom.Application.Contract.Services;
using MediatR;

namespace beqom.Application.CommandQuery
{
    public partial class ApplicationService : IApplicationService
    {
        private readonly IMediator mediator;

        /// <summary>
        /// ApplicationService
        /// </summary>
        /// <param name="mediator"></param>
        public ApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
