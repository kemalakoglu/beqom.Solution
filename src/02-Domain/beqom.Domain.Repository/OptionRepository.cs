using beqom.Domain.Aggregate.Option;
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
                    response = new Option<DefaultOption>(new DefaultOption()).FromValue();
                    break;
                case OptionType.Config:
                    response = new Option<NonEmptyOption>(new NonEmptyOption()).FromValue();
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