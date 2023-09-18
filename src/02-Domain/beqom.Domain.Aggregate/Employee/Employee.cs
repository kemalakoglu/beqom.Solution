using beqom.Domain.Aggregate.Base;

namespace beqom.Domain.Aggregate.Employee
{
    public class Employee : BaseEntity
    {
        private string _surname;

        public EmployeeType Type { get; set; }
        public int Years { get; set; }
        public decimal Salary { get; set; }
        public string Surname { get { return _surname; } set { _surname = Mask(value); } }

        public string Mask(string param)
        {
            if (param.Length < 3)
                return param;

            var firstChars = param.Substring(0, 3);
            var length = param.Length - 3;

            for (int i = 0; i < length; i++)
            {
                firstChars += "*";
            }

            return firstChars;
        }
    }

    public enum EmployeeType
    {
        Trainee,
        Junior,
        Senior,
        Manager
    }
}
