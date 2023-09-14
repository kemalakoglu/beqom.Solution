using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Repository
{
    public class OptionGenericRepository<T> : IOptionGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<T> Get()
        {
            if (typeof(T) == typeof(EmptyOption))
                return (T)(object)Convert.ChangeType(new EmptyOption(), typeof(T));
            else if (typeof(T) == typeof(ConfigOption))
                return (T)(object)Convert.ChangeType(new ConfigOption(), typeof(T));
            else return null;
        }
    }
}
