using System;
using beqom.Domain.Aggregate.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace beqom.Domain.Aggregate.RefTypeValue
{
    public class Option:BaseEntity
    {
        private readonly ILazyLoader lazyLoader;

        public Option(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public Option(bool status, DateTime? insertDate, string name, bool isActive)
        {
            this.Status = status;
            this.InsertDate = insertDate;
            this.Name = name;
            this.IsActive = isActive;
        }

        public Option(DateTime? insertDate, string name, bool isActive)
        {
            this.Status = true;
            this.InsertDate = insertDate;
            this.Name = name;
            this.IsActive = isActive;
        }

        public string Name { get; protected set; }

        public Option Parent
        {
            get => lazyLoader.Load(this, ref parent);
            set => parent = value;
        }

        public Option parent;

        public void SetParent(Option parent)
        {
            this.Parent = parent;
        }

        public void Update(string name, bool isActive, DateTime updateDate)
        {
            this.UpdateDate = updateDate;
            this.Name = name;
            this.IsActive = isActive;
        }

        public void SetStatus(bool status)
        {
            this.Status = status;
        }

        public void Update(bool status, string name, bool isActive, DateTime? updateDate)
        {
            this.Status = status;
            this.UpdateDate = updateDate;
            this.Name = name;
            this.IsActive = isActive;
        }
    }
}
