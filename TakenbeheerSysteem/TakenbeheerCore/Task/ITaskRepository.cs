using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Task
{
    public interface ITaskRepository
    {
        public List<TaskDTO> ReturnAllTasks();
        public List<TaskDTO> GetTasksByEmployee(int empId);

	}
}
