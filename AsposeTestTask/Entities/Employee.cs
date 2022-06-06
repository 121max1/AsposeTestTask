using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public class Employee : Worker
    {
        public override double CalculateSalary()
        {
            return Salary + (Experience >= 10 ? Salary * 0.03 * 10 : Salary * Experience * 0.03);
        }
    }
}
