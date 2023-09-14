using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.Interface;

namespace beqom.Domain.Repository
{
    public class OptionRepository : IOptionRepository
    {
        public async Task<DefaultOption> GetDefault()
        {
            return new DefaultOption();
        }
    }
}