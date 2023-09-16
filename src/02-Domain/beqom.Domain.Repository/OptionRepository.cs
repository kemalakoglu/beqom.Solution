using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using beqom.Domain.Contract.Enum.OptionType;
using beqom.Domain.Contract.Interface;

namespace beqom.Domain.Repository
{
    public class OptionRepository : IOptionRepository
    {
        public async Task<Option> GetOption(OptionType option)
        {
            Option response;
            switch (option)
            {
                case OptionType.Default:
                    response = new Option<Option>().FromValue();
                    break;
                case OptionType.Config:
                    response = new Option<ConfigOption>().FromValue();
                    break;
                case OptionType.Empty:
                    return null;
                default:
                    return null;
            }
            return response;
        }
    }
}