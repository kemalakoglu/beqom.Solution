using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.Enum.OptionType;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.Interface
{
    public interface IOptionRepository
    {
        Task<Option> GetOptionAsync(OptionType request);
    }
}
