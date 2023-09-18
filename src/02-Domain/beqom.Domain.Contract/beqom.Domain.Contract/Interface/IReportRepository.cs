using beqom.Domain.Aggregate.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beqom.Domain.Contract.Interface
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReportAsync();
    }
}
