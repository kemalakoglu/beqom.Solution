using System.Collections.Generic;

namespace beqom.Presentation.API
{
    public class EmployeeProcessor
    {
        //public decimal CalculateNewSalary(int type, int years, decimal salary)
        //{
        //    decimal newSalary = 0;
        //    if (type == 1) // Trainee
        //    {
        //        newSalary = salary / 100 + salary;
        //    }
        //    if (type == 2) // Junior
        //    {
        //        newSalary = (salary * 5 / 100) + (salary * years > 5 ? 5 : years) / 100 + salary;
        //    }
        //    if (type == 3) // Senior
        //    {
        //        newSalary = (salary * years > 5 ? 5 : years) / 100 + 1.1 * salary;
        //    }
        //    if (type == 4) // Manager
        //    {
        //        newSalary = (salary * years > 5 ? 5 : years) / 100 + salary + (salary * 15 / 100);
        //    }
        //    return newSalary;
        //}

        //public string GenerateEmployeeReport(Employee employee)
        //{
        //    var newSalary = CalculateNewSalary(employee.Type, employee.Years, employee.Salary);
        //    var report = $"Employee Name: {employee.MaskName()}, Type: {employee.Type.ToString()}, Years: {employee.Years}, Salary: {employee.Salary}, New Salary: {newSalary}";
        //    return reportSpan;
        //}

        //public string GenerateReport(List<Employee> employees)
        //{
        //    var report = "";
        //    foreach (var employee in employees)
        //    {
        //        report += GenerateEmployeeReport(employee);
        //    }
        //    return report;
        //}

        //public class Employee
        //{
        //    public string Name { get; set; }
        //    public int Type { get; set; }
        //    public int Years { get; set; }
        //    public decimal Salary { get; set; }

        //    public string MaskName()
        //    {
        //        var firstChars = Name.Substring(0, 3);
        //        var length = Name.Length - 3;

        //        for (int i = 0; i < length; i++)
        //        {
        //            firstChars += "*";
        //        }

        //        return firstChars;
        //    }
        //}
    }
}
