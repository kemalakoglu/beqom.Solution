using System;
using System.ComponentModel.DataAnnotations;

namespace beqom.Domain.Aggregate.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; protected set; }

        public bool Status { get; protected set; }

        public DateTime? InsertDate { get; protected set; }

        public DateTime? UpdateDate { get; protected set; }

        public bool IsActive { get; protected set; }
    }
}
