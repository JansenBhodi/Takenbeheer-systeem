using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Linq.Expressions;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class ConnectModel : PageModel
    {
        public WorkerEmployee employee { get; set; }
        public List<Worktask> tasks { get; set; }

        public TaskService taskService { get; set; }
        public EmployeeService employeeService { get; set; }


        public ConnectModel(ITaskRepository taskRepo, IEmployeeRepository empRepo)
        {
            taskService = new TaskService(taskRepo);
            employeeService = new EmployeeService(empRepo);
        }


        public void OnGet()
        {
            tasks = taskService.ReturnAllTasksByTeamExcludingEmployee(HttpContext.Session.GetInt32("TeamId") ?? 0, HttpContext.Session.GetInt32("employeeTarget") ?? 0);
        }

        public ActionResult OnPost()
        {
            switch (Request.Form["Validator"])
            {
                case "Connect":
                    try
                    {
                        if (employeeService.ConnectEmployeeWithTask(HttpContext.Session.GetInt32("EmployeeId") ?? 0, int.Parse(Request.Form["Input"])))
                        {
                            return RedirectToPage("/Employee/Details");
                        }
                        else
                        {
                            return RedirectToPage("/Employee/Connect");
                        }
                    }
                    catch (Exception)
                    {
                        return RedirectToPage("/Employee/Connect");
                    }
                    break;
                case "Cancel":
                    return RedirectToPage("/Employee/Details");
                    break;
                default:

                    return RedirectToPage("/Employee/Connect");
                    break;
            }
        }
    }
}
