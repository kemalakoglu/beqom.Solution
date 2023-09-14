using beqom.Core.Helper;
using System.Threading.Tasks;

namespace beqom.Domain.Aggregate.Base
{
    public interface IBaseService<T> where T : class
    {
        ResponseDTO<T> GetByKey(long key);
    }
}