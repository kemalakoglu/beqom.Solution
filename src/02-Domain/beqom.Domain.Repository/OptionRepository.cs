using beqom.Domain.Aggregate;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.Enum.OptionType;
using beqom.Domain.Contract.Interface;

namespace beqom.Domain.Repository
{
    public class OptionRepository : IOptionRepository
    {
        /// <summary>
        /// GetOptionAsync
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task<Option> GetOptionAsync(OptionType option)
        {
            Option response;
            switch (option)
            {
                case OptionType.Default:
                    response = new Option<DefaultOption>(new DefaultOption()).FromValue();
                    break;
                case OptionType.NonEmptyOption:
                    response = Extensions.GetValue(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue(), typeof(NonEmptyOption).Name);
                    break;
                case OptionType.Empty:
                    return null;
                default:
                    return null;
            }
            return await Task.FromResult(response);
        }
    }
}