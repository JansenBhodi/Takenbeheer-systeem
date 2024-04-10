using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerDAL.Task;

namespace TakenbeheerCore.Task
{
    public interface ITaskRepository
    {
        public List<TaskDTO> ReturnAllTasks();
    }
}
