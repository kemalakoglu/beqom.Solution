using beqom.Domain.Aggregate.Base;
using System;

namespace beqom.Domain.Aggregate.Option.Entities
{
    public class Option<T> where T : class 
    {
        public Option FromValue()
        {
            if (typeof(T) == typeof(EmptyOption))
                throw new InvalidOperationException();

            if (typeof(T) != typeof(ConfigOption) && typeof(T) != typeof(Option))
                return null;

            var response = Extensions.GetOption(typeof(T).Name);
            return response;
        }
    }

    public class Option : BaseEntity
    {
        public static Option Empty<T>() where T: class
        {
            if (typeof(T) == typeof(EmptyOption))
                return null;

            if (typeof(T) == typeof(ConfigOption))
                throw new InvalidOperationException();

            return Extensions.GetOption(typeof(T).Name);
        }
    }
}
