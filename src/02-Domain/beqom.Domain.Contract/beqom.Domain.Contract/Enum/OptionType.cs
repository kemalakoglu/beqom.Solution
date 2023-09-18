using beqom.Domain.Aggregate.Option;
using System;

namespace beqom.Domain.Contract.Enum.OptionType
{
    public enum OptionType
    {
        [OptionClass(typeof(DefaultOption))]
        Default,

        [OptionClass(typeof(NonEmptyOption))]
        NonEmptyOption,

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
