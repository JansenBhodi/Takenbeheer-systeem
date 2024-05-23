using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Subtask;

namespace TakenbeheerCore.Task
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public DateOnly Deadline { get; set; }
        public bool IsVisible { get; set; }
        public List<SubtaskDTO>? Subtasks { get; set; }
        public List<WorkerEmployeeDTO>? Employees { get; set; }

        //Detail page Task/Employee
        public TaskDTO(int id, string title, string desc, int progress, DateOnly date, bool isVisible)
        {
            Id = id;
            Title = title;
            Description = desc;
            Progress = progress;
            Deadline = date;
            IsVisible = isVisible;
            Subtasks = null;
            Employees = null;
        }

        //Create task
        public TaskDTO(string title, string desc, int progress, DateOnly date, bool isVisible)
        {
            Title = title;
            Description = desc;
            Progress = progress;
            Deadline = date;
            IsVisible = isVisible;
        }

        //Update task
        public TaskDTO(Worktask task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Progress = (int)task.Progress;
            Deadline = task.Deadline;
            IsVisible = task.IsVisible;
        }
    }
}
