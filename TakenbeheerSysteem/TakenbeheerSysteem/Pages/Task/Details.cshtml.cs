using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Task
{
    public class DetailsModel : PageModel
    {
        private EmployeeService _empService;
        private TaskService _taskService;

        public List<WorkerEmployee> team;
        public Worktask task;

        public void OnGet()
        {
            team = _empService.GetEmployeesByTaskId(HttpContext.Session.GetInt32("taskId") ?? default(int));
            task = _taskService.GetTaskById(HttpContext.Session.GetInt32("taskId") ?? default(int));
		}

        public DetailsModel(IEmployeeRepository empRepo, ITaskRepository taskRepo)
        {
            _empService = new EmployeeService(empRepo);
            _taskService = new TaskService(taskRepo);
        }

        public ActionResult OnPost()
        {
            switch (Request.Form["Submit"])
            {
                case "View Employee":
                    HttpContext.Session.SetInt32("employeeId", int.Parse(Request.Form["Checker"]));
					return RedirectToPage("/Employee/Details");
				case "Edit":
					HttpContext.Session.SetInt32("taskId", task.Id);
					return RedirectToPage("/Task/Edit");
				case "Delete":
					HttpContext.Session.SetInt32("taskId", task.Id);
					return RedirectToPage("/Task/Delete");
				case "View Subtask":
                    HttpContext.Session.SetInt32("subtaskId", int.Parse(Request.Form["Checker"]));
                    return RedirectToPage("/Subtask/Index");
                    break;
                default:
                    return RedirectToPage("/Task/Index");
                    break;
            }
        }
    }
}
