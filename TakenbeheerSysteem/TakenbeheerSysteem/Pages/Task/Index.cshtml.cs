using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Task;
using TakenbeheerDAL.Task;

namespace TakenbeheerSysteem.Pages.Task
{
    public class IndexModel : PageModel
    {
        ITask _task;
        ITaskRepository _taskRepository;
        public List<TaskDTO> taskList = new List<TaskDTO>();
        public string TestString;

        public void OnGet([FromServices] ITask task,[FromServices] ITaskRepository taskRepository)
        {
            _task = task;
            _taskRepository = taskRepository;

            taskList = taskRepository.ReturnAllTasks();
        }
    }
}
