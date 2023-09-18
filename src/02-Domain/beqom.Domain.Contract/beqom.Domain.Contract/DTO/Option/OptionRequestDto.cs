using beqom.Domain.Contract.Enum.OptionType;
using MediatR;
using System.Runtime.Serialization;

namespace beqom.Domain.Contract.DTO.Option
{
    [DataContract]
    public class OptionRequestDto : IRequest<OptionResponseDto>
    {
        [DataMember]
        public OptionType Option;
    }
}
