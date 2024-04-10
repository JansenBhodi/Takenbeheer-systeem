using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Task;
using TakenbeheerDAL.Task;

namespace TakenbeheerSysteem.Pages.Task
{
    public class IndexModel : PageModel
    {
        ITaskRepository _taskRepository;
        public List<TaskDTO> taskList = new List<TaskDTO>();
        public string TestString;

        public void OnGet([FromServices] ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            taskList = _taskRepository.ReturnAllTasks();
        }
    }
}
