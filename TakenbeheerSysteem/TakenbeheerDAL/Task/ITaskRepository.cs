using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerDAL.Task
{
    public interface ITaskRepository
    {
        public List<TaskDTO> ReturnAllTasks();
    }
}
