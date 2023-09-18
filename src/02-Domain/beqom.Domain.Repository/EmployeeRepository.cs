using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Contract.Interface;

namespace beqom.Domain.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeRepository()
        {
            this.employees = new List<Employee>();

            Employee employee1 = new Employee();
            employee1.Id = System.Guid.NewGuid();
            //Name can be encapsulated but this field comes from base that's why MaskName method is called seperately
            employee1.Name = employee1.Mask("Franz");
            employee1.Surname = "Kafka";
            employee1.Years = 1;
            employee1.Type = EmployeeType.Trainee;
            employee1.Salary = 9000;
            employee1.Status = true;
            employee1.IsActive = true;
            this.employees.Add(employee1);

            Employee employee2 = new Employee();
            employee2.Id = System.Guid.NewGuid();
            //Name can be encapsulated but this field comes from base that's why MaskName method is called seperately
            employee2.Name = employee2.Mask("Jose");
            //Surname is masked by default
            employee2.Surname = "Saramago";
            employee2.Years = 3;
            employee2.Type = EmployeeType.Junior;
            employee2.Salary = 11000;
            employee2.Status = true;
            employee2.IsActive = true;
            this.employees.Add(employee2);

            Employee employee3 = new Employee();
            employee3.Id = System.Guid.NewGuid();
            //Name can be encapsulated but this field comes from base that's why MaskName method is called seperately
            employee3.Name = employee3.Mask("Paul");
            //Surname is masked by default
            employee3.Surname = "Auster";
            employee3.Years = 7;
            employee3.Type = EmployeeType.Senior;
            employee3.Salary = 14000;
            employee3.Status = true;
            employee3.IsActive = true;
            this.employees.Add(employee3);

            Employee employee4 = new Employee();
            employee4.Id = System.Guid.NewGuid();
            //Name can be encapsulated but this field comes from base that's why MaskName method is called seperately
            employee4.Name = employee4.Mask("Michael");
            //Surname is masked by default
            employee4.Surname = "Faucault";
            employee4.Years = 9;
            employee4.Type = EmployeeType.Manager;
            employee4.Salary = 19000;
            employee4.Status = true;
            employee4.IsActive = true;
            this.employees.Add(employee4);

            Employee employee5 = new Employee();
            employee5.Id = System.Guid.NewGuid();
            //Name can be encapsulated but this field comes from base that's why MaskName method is called seperately
            employee5.Name = employee4.Mask("Samuel");
            //Surname is masked by default
            employee5.Surname = "Beckett";
            employee5.Years = 9;
            employee5.Type = EmployeeType.Manager;
            employee5.Salary = 21000;
            employee5.Status = true;
            employee5.IsActive = false;
            this.employees.Add(employee5);
        }

        /// <summary>
        /// GetListAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetListAsync()
        {
            return await Task.FromResult(this.employees.Where(x => x.IsActive == true));
        }
    }
}
