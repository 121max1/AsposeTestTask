using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTestTask.Logic.Entities
{
    public abstract class WorkerWithSubordinates : Worker
    {
        public IList<Worker> Subordinates { get; set; }
    }
}
