using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Employee
{
    public class WorkerEmployeeDTO
    {
        #region parameters
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        public WorkerEmployeeDTO()
        {

        }

        public WorkerEmployeeDTO(WorkerEmployee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
        }
    }
}
