using beqom.Application.Contract.Services;
using MediatR;

namespace beqom.Application.CommandQuery
{
    public partial class ApplicationService : IApplicationService
    {
        private readonly IMediator mediator;
        public ApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
