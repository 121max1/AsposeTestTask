using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public class Sales : WorkerWithSubordinates
    {
        public override double CalculateSalary()
        {
            var basePayment = Salary + (Experience >= 35 ? Salary * 0.01 * 35 : Salary * Experience * 0.01);
            var additionalPayment = 0.0;

            var workersQueue = new Queue<Worker>();
            foreach(var subordinate in Subordinates)
            {
                workersQueue.Enqueue(subordinate);
            }

            //algorithm below provides calculation of salaries on each level of tree;
            while(workersQueue.Count > 0)
            {
                var n = workersQueue.Count;

                while (n > 0)
                {
                    var worker = workersQueue.Dequeue();
                    additionalPayment += worker.CalculateSalary();

                    if (worker is WorkerWithSubordinates)
                    {
                        var workerWithSubordinates = worker as WorkerWithSubordinates;
                        foreach (var subordinate in workerWithSubordinates.Subordinates)
                        {
                            workersQueue.Enqueue(subordinate);
                        }
                    } 
                    n--;
                }
            }

            return basePayment + additionalPayment * 0.003;
        }
    }
}
