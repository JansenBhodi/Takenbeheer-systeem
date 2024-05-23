using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private EmployeeService _employeeService;
        private TaskService _taskService;

        public List<Worktask> Tasks;
        public WorkerEmployee employee;

        public DetailsModel([FromServices] IEmployeeRepository repo, [FromServices] ITaskRepository taskRepo)
        {
            _employeeService = new EmployeeService(repo);
            _taskService = new TaskService(taskRepo);

		}

        public void OnGet()
        {
            employee = _employeeService.GetEmployee(HttpContext.Session.GetInt32("employeeId") ?? default(int));
            Tasks = _taskService.GetTasksByEmployee(HttpContext.Session.GetInt32("employeeId") ?? default(int));
        }


        public ActionResult OnPost()
        {
            switch (Request.Form["Submit"])
            {
                case "View":
                    return Redirect("~/Task/Details");
                    break;
                case "Edit":
                    return Redirect("Edit");
                    break;
                case "Add task":
                    break;
            }
            return Redirect("Details");
        }

    }
}
