using beqom.Domain.Aggregate.Base;
using System;

namespace beqom.Domain.Aggregate.Option
{
    public class Option<T> : IOption<T>
    {
        private T option;

        public Option(T option)
        {
            this.option = option;
        }

        public T FromValue()
        {
            if (typeof(T) == typeof(EmptyOption))
                throw new InvalidOperationException();
            return option;
        }
    }

    public class Option : BaseEntity
    {
        public static Option Empty<T>() where T: class
        {
            if (typeof(T) == typeof(EmptyOption))
                return null;

            if (typeof(T) == typeof(NonEmptyOption))
                throw new InvalidOperationException();

            return new Option();
        }
    }
}
