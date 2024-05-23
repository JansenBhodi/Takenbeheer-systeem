using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;

namespace TakenbeheerSysteem.Pages.Task
{
    public class DetailsModel : PageModel
    {
        private EmployeeService _empService;
        private TaskService _taskService;

        public void OnGet()
        {

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
                case "ViewEmployee":
                    HttpContext.Session.SetInt32("employeeId", int.Parse(Request.Form["Checker"]));
                    return Redirect("~/Employee/Details");
                case "ViewSubtask":
                    HttpContext.Session.SetInt32("subtaskId", int.Parse(Request.Form["Checker"]));
                    return Redirect("Index");
                    break;
                default:
                    return Redirect("Index");
                    break;
            }
        }
    }
}
