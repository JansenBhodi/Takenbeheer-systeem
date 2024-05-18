using TakenbeheerCore.Employee;
using TakenbeheerCore.Subtask;

namespace TakenbeheerCore.Task
{
    public class Worktask
    {
        #region Parameters
        private int _id;
        public int Id { get { return _id; } }

        private string _title;
        public string Title { get { return _title; } }

        private string _description;
        public string Description { get { return _description; } }

        private ProgressState _progress;
        public ProgressState Progress { get { return _progress; } }

        private DateOnly _deadline;
        public DateOnly Deadline { get { return _deadline; } }

        private bool _isVisible;
        public bool IsVisible { get { return _isVisible; } }

        private List<Subtask.Subtask>? _subtasks;
        public List<Subtask.Subtask>? Subtasks { get { return _subtasks; } }

        private List<WorkerEmployee>? _employees;
        public List<WorkerEmployee>? Employees { get { return _employees; } }

        #endregion

        public Worktask(int id, string title, string desc, int progress, DateOnly deadline, bool isvisible)
        {
            _id = id;
            _title = title;
            _description = desc;
            _progress = (ProgressState)progress;
            _deadline = deadline;
            _isVisible = isvisible;
        }

        public Worktask(TaskDTO taskDto)
        {
            _id = taskDto.Id;
            _title = taskDto.Title;
            _description = taskDto.Description;
            _progress = (ProgressState)taskDto.Progress;
            _deadline = (DateOnly)taskDto.Deadline;
            _isVisible = taskDto.IsVisible;
            if(taskDto.Subtasks != null)
			{
				foreach (SubtaskDTO subtask in taskDto.Subtasks)
				{
					_subtasks.Add(new Subtask.Subtask(subtask));
				}
			}
            if(taskDto.Employees != null)
			{
				foreach (WorkerEmployeeDTO employee in taskDto.Employees)
				{
					_employees.Add(new WorkerEmployee(employee));
				}
			}
        }
    }
}
