using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Worker
{
    public class Employee : IWorker
    {
        private string _name;
        public string Name { get { return _name; } }

        public Employee(string name)
        {
            _name = name;
        }
    }
}
