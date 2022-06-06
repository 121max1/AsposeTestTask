using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public class Company
    {
        public string Name { get; set; }

        public IList<Worker> Workers { get; set; }

        public double GetSalaryReport()
        {
            return Workers.Sum(w => w.CalculateSalary());
        }
    }
}
