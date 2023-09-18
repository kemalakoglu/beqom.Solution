using AutoMapper;
using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Contract.Interface;
using beqom.Presentation.API.Extensions;
using Moq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace beqom.Repository.Test
{
    public class ReportRepositoryTest
    {
        private List<Employee> employees;
        private List<Report> reports;

        private readonly IMapper mapper;

        public ReportRepositoryTest()
        {
            //auto mapper configuration
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, Report>().ForMember(x => x.NewSalary, act => act.Ignore());
            }).CreateMapper();

            this.employees = new List<Employee>();
            this.reports = new List<Report>();

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
            Report report1 = mapper.Map<Report>(employee1);
            report1.NewSalary = (report1.Salary / 100) + report1.Salary;
            this.reports.Add(report1);

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
            Report report2 = mapper.Map<Report>(employee2);
            report2.NewSalary = ((report2.Salary * 5) / 100) + (report2.Salary * report2.Years > 5 ? 5 : report2.Years) / 100 + report2.Salary;
            this.reports.Add(report2);

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
            Report report3 = mapper.Map<Report>(employee3);
            report3.NewSalary = ((report3.Salary * report3.Years > 5 ? 5 : report3.Years) / 100) + ((decimal)1.1 * report3.Salary);
            this.reports.Add(report3);

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
            Report report4 = mapper.Map<Report>(employee4);
            report4.NewSalary = ((report4.Salary * report4.Years > 5 ? 5 : report4.Years) / 100) + report4.Salary + ((report4.Salary * 15) / 100);
            this.reports.Add(report4);

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

        [Fact]
        public async Task GetReportAsync_Should_Return_List_Value()
        {
            //Arrange
            var reportRepository = new Mock<IReportRepository>();
            reportRepository.Setup(x => x.GetReportAsync()).ReturnsAsync(this.reports);

            //Act
            var actual = await reportRepository.Object.GetReportAsync();

            //Assert
            Assert.Equal(this.reports, actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public async Task GetReportAsync_Should_Return_Empty_List()
        {
            //Arrange
            var reportRepository = new Mock<IReportRepository>();
            reportRepository.Setup(x => x.GetReportAsync()).ReturnsAsync(new List<Report>());

            //Act
            var actual = await reportRepository.Object.GetReportAsync();

            //Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetReportAsync_Should_Throws_BusinessException()
        {
            //Arrange
            var reportRepository = new Mock<IReportRepository>();
            reportRepository.Setup(x => x.GetReportAsync()).ThrowsAsync(new BusinessException());

            //Assert
            Assert.ThrowsAsync<BusinessException>(() => reportRepository.Object.GetReportAsync());
        }

        [Fact]
        public void GetReportAsync_Should_Throws_Exception()
        {
            //Arrange
            var reportRepository = new Mock<IReportRepository>();
            reportRepository.Setup(x => x.GetReportAsync()).ThrowsAsync(new Exception());

            //Assert
            Assert.ThrowsAsync<Exception>(() => reportRepository.Object.GetReportAsync());
        }

        #region private class tests

        [Fact]
        public async Task GetEmployeeList_Should_Return_List_Value()
        {
            //Act
            var actual = await this.GetEmployeeList();

            //Assert
            Assert.Equal(this.employees.Where(x => x.IsActive == true), actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public async Task GetEmployeeList_Should_Return_List_Value_By_IsActive_True()
        {
            //Act
            var actual = await this.GetEmployeeList();

            //Assert
            Assert.Equal(this.employees.Where(x => x.IsActive == true), actual);
            Assert.NotEmpty(actual);
            Assert.Collection(actual,
                    elem1 =>
                    {
                        Assert.True(elem1.IsActive);
                    },
                    elem2 =>
                    {
                        Assert.True(elem2.IsActive);
                    },
                    elem3 =>
                    {
                        Assert.True(elem3.IsActive);
                    },
                    elem4 =>
                    {
                        Assert.True(elem4.IsActive);
                    });
        }

        [Fact]
        public async Task GetEmployeeList_Should_Return_Empty_List()
        {
            //Act
            var actual = await this.GetEmployeeEmptyList();

            //Assert
            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetEmployeeList_Should_Throws_BusinessException()
        {
            //Assert
            await Assert.ThrowsAsync<BusinessException>(() => this.GetEmployeeListThrowsBusinessException());
        }

        [Fact]
        public async Task GetEmployeeList_Should_Throws_Exception()
        {
            //Assert
            await Assert.ThrowsAsync<Exception>(() => this.GetEmployeeListThrowsException());
        }

        [Fact]
        public async Task GenerateReport_Should_Return_Value()
        {
            //Arrange
            var expected = this.reports.OrderBy(x => x.Name).ToList();

            //Act
            var actual = (await this.GenerateReport(this.employees.Where(x => x.IsActive == true))).OrderBy(x => x.Name).ToList();

            //Assert
            Assert.Equal(expected.Count, actual.Count);
            Assert.Collection(actual,
                    elem1 =>
                    {
                        Assert.Equal(expected[0].Name, elem1.Name);
                        Assert.Equal(expected[0].Surname, elem1.Surname);
                        Assert.Equal(expected[0].Id, elem1.Id);
                        Assert.Equal(expected[0].Status, elem1.Status);
                        Assert.Equal(expected[0].IsActive, elem1.IsActive);
                        Assert.Equal(expected[0].Salary, elem1.Salary);
                        Assert.Equal(expected[0].NewSalary, elem1.NewSalary);
                        Assert.Equal(expected[0].Years, elem1.Years);
                        Assert.Equal(expected[0].Type, elem1.Type);
                    },
                    elem2 =>
                    {
                        Assert.Equal(expected[1].Name, elem2.Name);
                        Assert.Equal(expected[1].Surname, elem2.Surname);
                        Assert.Equal(expected[1].Id, elem2.Id);
                        Assert.Equal(expected[1].Status, elem2.Status);
                        Assert.Equal(expected[1].IsActive, elem2.IsActive);
                        Assert.Equal(expected[1].Salary, elem2.Salary);
                        Assert.Equal(expected[1].NewSalary, elem2.NewSalary);
                        Assert.Equal(expected[1].Years, elem2.Years);
                        Assert.Equal(expected[1].Type, elem2.Type);
                    },
                    elem3 =>
                    {
                        Assert.Equal(expected[2].Name, elem3.Name);
                        Assert.Equal(expected[2].Surname, elem3.Surname);
                        Assert.Equal(expected[2].Id, elem3.Id);
                        Assert.Equal(expected[2].Status, elem3.Status);
                        Assert.Equal(expected[2].IsActive, elem3.IsActive);
                        Assert.Equal(expected[2].Salary, elem3.Salary);
                        Assert.Equal(expected[2].NewSalary, elem3.NewSalary);
                        Assert.Equal(expected[2].Years, elem3.Years);
                        Assert.Equal(expected[2].Type, elem3.Type);
                    },
                    elem4 =>
                    {
                        Assert.Equal(expected[3].Name, elem4.Name);
                        Assert.Equal(expected[3].Surname, elem4.Surname);
                        Assert.Equal(expected[3].Id, elem4.Id);
                        Assert.Equal(expected[3].Status, elem4.Status);
                        Assert.Equal(expected[3].IsActive, elem4.IsActive);
                        Assert.Equal(expected[3].Salary, elem4.Salary);
                        Assert.Equal(expected[3].NewSalary, elem4.NewSalary);
                        Assert.Equal(expected[3].Years, elem4.Years);
                        Assert.Equal(expected[3].Type, elem4.Type);
                    });
        }

        [Fact]
        public async Task GenerateReport_Should_Return_EmptyList()
        {
            //Arrange
            var expected = new List<Report>();

            //Act
            var actual = (await this.GenerateReport(new List<Employee>())).OrderBy(x => x.Name).ToList();

            //Assert
            Assert.Equal(expected.Count, actual.Count);

        }

        [Fact]
        public async Task CalculateNewSalary_Should_Return_Value()
        {
            //Act
            var actualTrainee = await this.CalculateNewSalary(EmployeeType.Trainee, 1, 9000);
            var actualJunior = await this.CalculateNewSalary(EmployeeType.Junior, 1, 11000);
            var actualSenior = await this.CalculateNewSalary(EmployeeType.Senior, 1, 14000);
            var actualManager = await this.CalculateNewSalary(EmployeeType.Manager, 1, 19000);

            //Assert
            Assert.Equal(9090, actualTrainee);
            Assert.Equal(11550, actualJunior);
            Assert.Equal(15400, actualSenior);
            Assert.Equal(21850, actualManager);
        }

        [Fact]
        public async Task GenerateEmployeeReport_Should_Return_Value()
        {
            //Arrange
            Employee employee1 = new Employee();
            employee1.Id = System.Guid.NewGuid();
            employee1.Name = employee1.Mask("Franz");
            employee1.Surname = "Kafka";
            employee1.Years = 1;
            employee1.Type = EmployeeType.Trainee;
            employee1.Salary = 9000;
            employee1.Status = true;
            employee1.IsActive = true;

            //Act
            var actual = await this.GenerateEmployeeReport(employee1);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task GenerateEmployeeReport_Should_Return_Null()
        {
            //Arrange
            Employee employee1 = new Employee();
            employee1.Id = System.Guid.NewGuid();
            employee1.Name = employee1.Mask("Franz");
            employee1.Surname = "Kafka";
            employee1.Years = 0;
            employee1.Type = EmployeeType.Trainee;
            employee1.Salary = 0;
            employee1.Status = true;
            employee1.IsActive = true;

            //Act
            var actual = await this.GenerateEmployeeReport(employee1);

            //Assert
            Assert.Null(actual);
        }

        #endregion

        #region private classes

        private async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetListAsync()).ReturnsAsync(this.employees.Where(x => x.IsActive == true));

            return await employeeRepository.Object.GetListAsync();
        }

        private async Task<IEnumerable<Employee>> GetEmployeeEmptyList()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetListAsync()).ReturnsAsync(new List<Employee>());

            return await employeeRepository.Object.GetListAsync();
        }

        private async Task<IEnumerable<Employee>> GetEmployeeListThrowsBusinessException()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetListAsync()).ThrowsAsync(new BusinessException());

            return await employeeRepository.Object.GetListAsync();
        }

        private async Task<IEnumerable<Employee>> GetEmployeeListThrowsException()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetListAsync()).ThrowsAsync(new System.Exception());

            return await employeeRepository.Object.GetListAsync();
        }

        private async Task<Report> GenerateEmployeeReport(Employee employee)
        {
            var report = this.mapper.Map(employee, new Report());
            if (employee.Years <= 0 || employee.Salary <= 0)
                return null;
            report.NewSalary = await CalculateNewSalary(employee.Type, employee.Years, employee.Salary);
            return report;
        }

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
        #endregion
    }
}