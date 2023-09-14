using beqom.Core.Contract;
using beqom.Domain.Aggregate.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.Interface
{
    public interface IOptionGenericRepository<T> where T : class
    {
        Task<T> Get();
    }
}
