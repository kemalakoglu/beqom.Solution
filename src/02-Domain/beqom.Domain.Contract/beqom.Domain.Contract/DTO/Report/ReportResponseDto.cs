using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Contract.DTO.Base;

namespace beqom.Domain.Contract.DTO
{
    public class ReportResponseDto : BaseDTO
    {
        public decimal NewSalary { get; set; }
        public EmployeeType Type { get; set; }
        public int Years { get; set; }
        public decimal Salary { get; set; }
        public string Surname { get; set; }
    }
}
