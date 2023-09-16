using System;
using System.ComponentModel.DataAnnotations;

namespace beqom.Domain.Aggregate.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public bool IsActive { get; set; }
    }
}
