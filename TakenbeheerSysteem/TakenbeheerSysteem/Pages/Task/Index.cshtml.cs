using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Task;


namespace TakenbeheerSysteem.Pages.Task
{
    public class IndexModel : PageModel
    {
        TaskService taskService;
        public List<TakenbeheerCore.Task.Task> taskList;
        public string TestString;

        public IndexModel(ITaskRepository taskRepository)
        {
            taskService = new TaskService(taskRepository);
        }
        public void OnGet()
        {
            taskList = taskService.ReturnAllTasks();
        }
    }
}
