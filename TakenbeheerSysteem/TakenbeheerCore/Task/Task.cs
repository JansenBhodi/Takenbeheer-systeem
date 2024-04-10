using TakenbeheerCore.SubTask;
using TakenbeheerCore.Worker;

namespace TakenbeheerCore.Task
{
    public class Task : ITask
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

        private Subtask[] _subtasks;
        public Subtask[] Subtasks { get { return _subtasks; } }
        private Employee[] _employees;
        public Employee[] Employees { get { return _employees; } }

        #endregion

        public Task()
        {

        }

        public List<Task> ReturnAllTasks()
        {
            return new List<Task>()
            {
                new Task()
                {
                    _title = "Title1",
                    _description = "desc1"
                },
                new Task()
                {
                    _title = "Title2",
                    _description = "desc2"
                },
                new Task()
                {
                    _title = "Title3",
                    _description = "desc3"
                }
            };
        }

        public Subtask[] GetSubtasks()
        {
            return new Subtask[0];
        }

        public string test()
        {
            return "This is a test";
        }
    }
}
