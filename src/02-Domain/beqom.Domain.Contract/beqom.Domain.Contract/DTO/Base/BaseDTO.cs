using System;
using System.Runtime.Serialization;

namespace beqom.Domain.Contract.DTO.Base
{
    [DataContract]
    public class BaseDTO
    {
        [DataMember] public Guid Id { get; set; }

        [DataMember] public string Name { get; set; }

        [DataMember] public bool Status { get; set; }

        [DataMember] public bool IsActive { get; set; }
    }
}
