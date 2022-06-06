using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public abstract class Worker
    {
        public double Salary { get; set; }

        public int Experience { get; set; }

        public Worker Chief { get; set; }

        public abstract double CalculateSalary();
    }
}
