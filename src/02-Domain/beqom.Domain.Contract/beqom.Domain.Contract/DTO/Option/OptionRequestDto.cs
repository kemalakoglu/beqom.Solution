using beqom.Core.Enumeration;
using beqom.Domain.Contract.DTO.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.DTO.Option
{
    [DataContract]
    public class OptionRequestDto : IRequest<OptionResponseDto>
    {
        [DataMember]
        public Options option { get; set; }
    }
}
