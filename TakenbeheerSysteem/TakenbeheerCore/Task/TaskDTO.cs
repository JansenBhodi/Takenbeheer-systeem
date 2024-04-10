using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Employee;
using TakenbeheerDAL.Subtask;

namespace TakenbeheerDAL.Task
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public DateOnly Deadline { get; set; }
        public bool IsVisible { get; set; }
        public List<SubtaskDTO>? Subtasks { get; set; }
        public List<WorkerEmployeeDTO>? Workers { get; set; }

        public TaskDTO(int id, string title, string desc, int progress, DateOnly date, bool isVisible)
        {
            Id = id;
            Title = title;
            Description = desc;
            Progress = progress;
            Deadline = date;
            IsVisible = isVisible;
        }

    }
}
