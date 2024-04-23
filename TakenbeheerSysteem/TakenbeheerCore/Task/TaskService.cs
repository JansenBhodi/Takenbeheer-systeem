using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Subtask;
using TakenbeheerCore.SubTask;


namespace TakenbeheerCore.Task
{
    public class TaskService
    {
        private ITaskRepository _taskRepository;
        
        public TaskService(ITaskRepository repo) 
        {
            _taskRepository = repo;
        }

        public List<Worktask> ReturnAllTasks()
        {
            List<Worktask> tasks = new List<Worktask>();

            List<TaskDTO> tasksDTO = _taskRepository.ReturnAllTasks();

            foreach (TaskDTO taskDTO in tasksDTO)
            {
                Worktask entry = new Worktask(
                    taskDTO.Id,
                    taskDTO.Title,
                    taskDTO.Description,
                    taskDTO.Progress,
                    taskDTO.Deadline,
                    taskDTO.IsVisible
                    );
                tasks.Add(entry);
            }

            return tasks;
        }

        public List<Subtask.Subtask> GetSubtasks(int id)
        {
            List<Subtask.Subtask> subtasks = new List<Subtask.Subtask>();

            return subtasks;
        }

        public List<WorkerEmployee> GetWorkers(int id)
        {
            List<WorkerEmployee> workers = new List<WorkerEmployee>();

            return workers;
        }


    }
}
