using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Employee
{
    public class WorkerEmployee
    {
        #region parameters

        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name { get { return _name; } }
        #endregion

        public WorkerEmployee(WorkerEmployeeDTO entry)
        {
            _id = entry.Id;
            _name = entry.Name;
        }
    }
}
