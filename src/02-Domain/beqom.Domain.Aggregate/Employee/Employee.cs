using beqom.Domain.Aggregate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Aggregate.Employee
{
    public class Employee : BaseEntity
    {
        public int Type { get; set; }
        public int Years { get; set; }
        public decimal Salary { get; set; }

        public string MaskName()
        {
            var firstChars = Name.Substring(0, 3);
            var length = Name.Length - 3;

            for (int i = 0; i < length; i++)
            {
                firstChars += "*";
            }

            return firstChars;
        }
    }
}
