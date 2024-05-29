using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class EditModel : PageModel
    {
        private EmployeeService _employeeService;
        public WorkerEmployee Input;

        public EditModel([FromServices] IEmployeeRepository employeeRepo)
        {
            _employeeService = new EmployeeService(employeeRepo);
        }

        public void OnGet()
        {
            Input = _employeeService.GetEmployee(HttpContext.Session.GetInt32("employeeTarget") ?? 0);
        }

        public ActionResult OnPost()
        {
            WorkerEmployee employee = new WorkerEmployee(
                int.Parse(Request.Form["Id"]),
                int.Parse(Request.Form["Role"]),
                Request.Form["Name"],
                Request.Form["Email"],
                Request.Form["Password"],
                Request.Form["Address"],
                Request.Form["PostalCode"]
                );
            if (_employeeService.UpdateEmployee(employee))
            {
                return Redirect("Index");
            }
            else
            {
                return Redirect("Edit");
            }
        }

    }
}
