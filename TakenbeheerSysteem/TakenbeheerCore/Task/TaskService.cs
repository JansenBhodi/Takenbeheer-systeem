using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public List<Worktask> ReturnAllTasks(int empId)
        {
            List<Worktask> tasks = new List<Worktask>();

            List<TaskDTO> tasksDTO = _taskRepository.ReturnAllTasks(empId);

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

        public List<Worktask> GetTasksByEmployee(int empId)
        {
            List<Worktask> result = new List<Worktask>();

            try
            {
                List<TaskDTO> input = _taskRepository.GetTasksByEmployee(empId);
                foreach (TaskDTO item in input)
                {
                    result.Add(new Worktask(item));
                }
            }
            catch (Exception)
            {

                return result;
            }


            return result;
        }

        public Worktask? GetTaskById(int id)
        {
            try
            {
                return new Worktask(_taskRepository.GetTaskById(id));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
