using beqom.Application.Contract.Services;
using beqom.Domain.Aggregate.RefTypeValue;

namespace beqom.Application.Service
{
    public class ApplicationService : ICoreApplicationService
    {
        private readonly IOptionService refTypeService;

        public ApplicationService(IOptionService refTypeService)
        {
            this.refTypeService = refTypeService;
        }

        #region Option Aggregate

        #endregion
    }
}
