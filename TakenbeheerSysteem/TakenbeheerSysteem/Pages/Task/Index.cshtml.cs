using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Task;


namespace TakenbeheerSysteem.Pages.Task
{
    public class IndexModel : PageModel
    {
        TaskService taskService;
        public List<TakenbeheerCore.Task.Worktask> taskList;
        public string TestString;

        public IndexModel(ITaskRepository taskRepository)
        {
            taskService = new TaskService(taskRepository);
        }
        public void OnGet()
        {
            taskList = taskService.ReturnAllTasks(HttpContext.Session.GetInt32("uId") ?? default(int));
        }

        public ActionResult OnPost()
        {
            if (Request.Form["Submit"] == "View")
            {
                HttpContext.Session.SetInt32("taskId", int.Parse(Request.Form["Checker"]));
                return RedirectToPage("/Task/Details");
            }

            return RedirectToPage("/Task/Index");
        }
    }
}
