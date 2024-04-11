using TakenbeheerCore.Employee;
using TakenbeheerCore.SubTask;

namespace TakenbeheerCore.Task
{
    public class Task
    {
        #region Parameters
        private int _id;

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

        private List<Subtask> _subtasks;
        public List<Subtask> Subtasks { get { return _subtasks; } }

        private List<WorkerEmployee> _employees;
        public List<WorkerEmployee> Employees { get { return _employees; } }

        #endregion

        public Task(int id, string title, string desc, int progress, DateOnly deadline, bool isvisible, List<Subtask> subtasks, List<WorkerEmployee> employees)
        {
            _id = id;
            _title = title;
            _description = desc;
            _progress = (ProgressState)progress;
            _deadline = deadline;
            _isVisible = isvisible;
            _employees = employees;
            _subtasks = subtasks;

            //Fetch all subtasks involved with this task
            //Fetch all Employees involved with this task
        }
        public Task(int id, string title, string desc, int progress, DateOnly deadline, bool isvisible)
        {
            _id = id;
            _title = title;
            _description = desc;
            _progress = (ProgressState)progress;
            _deadline = deadline;
            _isVisible = isvisible;


            //Fetch all subtasks involved with this task
            //Fetch all Employees involved with this task
        }

        public Task(TaskDTO taskDto)
        {
            
        }

    }
}
