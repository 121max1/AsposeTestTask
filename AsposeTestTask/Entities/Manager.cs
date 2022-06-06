using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public class Manager : Worker
    {
        public IList<Worker> Subordinates { get; set;}

        public override double CalculateSalary()
        {
            var basePayment = Salary + (Experience >= 8 ? Salary * 0.05 * 8 : Salary * Experience * 0.05);
            var additionalPayment = 0.0;

            foreach(var subordinate in Subordinates) // salary only for the first layer
            {
                additionalPayment += subordinate.CalculateSalary();
            }

            return basePayment + additionalPayment * 0.005;
        }
    }
}
