using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using beqom.Domain.Contract.Enum.OptionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.Interface
{
    public interface IOptionRepository
    {
        Task<Option> GetOption(OptionType request);
    }
}
