using beqom.Domain.Aggregate.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetListAsync();
    }
}
