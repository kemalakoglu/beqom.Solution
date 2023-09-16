using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using System;

namespace beqom.Domain.Contract.Enum.OptionType
{
    public enum OptionType
    {
        [OptionClass(typeof(Option))]
        Default,

        [OptionClass(typeof(ConfigOption))]
        Config,

        [OptionClass(typeof(EmptyOption))]
        Empty,
    }

    public class OptionClassAttribute : System.Attribute
    {
        public Type Type { get; }

        public OptionClassAttribute(Type type)
        {
            Type = type;
        }
    }
}
