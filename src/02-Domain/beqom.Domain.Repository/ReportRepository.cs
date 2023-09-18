using AutoMapper;
using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Contract.Interface;
using System.Collections.Concurrent;

namespace beqom.Domain.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="mapper"></param>
        public ReportRepository(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// GetReportAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Report>> GetReportAsync()
        {
            var employees = await GetEmployeeList();
            return await GenerateReport(employees);
        }

        /// <summary>
        /// GetEmployeeList
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await employeeRepository.GetListAsync();
        }

        /// <summary>
        /// GenerateEmployeeReport
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private async Task<Report> GenerateEmployeeReport(Employee employee)
        {
            var report = this.mapper.Map(employee, new Report());
            if (employee.Years <= 0 || employee.Salary <= 0)
                return null;
            report.NewSalary = await CalculateNewSalary(employee.Type, employee.Years, employee.Salary);
            return report;
        }

        /// <summary>
        /// GenerateReport
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Report>> GenerateReport(IEnumerable<Employee> employees)
        {

            var reportList = new ConcurrentBag<Report>();

            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = 4
            };

            await Parallel.ForEachAsync(employees, parallelOptions, async (employee, cancellationToken) =>
            {
                reportList.Add(await GenerateEmployeeReport(employee));
            });

            return reportList;
        }

        /// <summary>
        /// CalculateNewSalary
        /// </summary>
        /// <param name="type"></param>
        /// <param name="years"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        private async Task<decimal> CalculateNewSalary(EmployeeType type, int years, decimal salary)
        {
            switch (type)
            {
                case EmployeeType.Trainee:
                    return await Task.FromResult(salary / 100 + salary);
                case EmployeeType.Junior:
                    return await Task.FromResult((salary * 5 / 100) + (salary * years > 5 ? 5 : years) / 100 + salary);
                case EmployeeType.Senior:
                    return await Task.FromResult(((salary * years > 5 ? 5 : years) / 100) + (decimal)1.1 * salary);
                case EmployeeType.Manager:
                    return await Task.FromResult((salary * years > 5 ? 5 : years) / 100 + salary + (salary * 15 / 100));
                default:
                    return 0;
            }
        }
    }
}
