using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.SubTask;

namespace TakenbeheerCore.Task
{
    public interface ITask
    {
        Subtask[] GetSubtasks();
        public List<Task> ReturnAllTasks();
    }
}
