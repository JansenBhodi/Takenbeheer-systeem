using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private EmployeeService _employeeService;
        public WorkerEmployee employee;

        public DetailsModel([FromServices] IEmployeeRepository repo)
        {
            _employeeService = new EmployeeService(repo);
        }

        public void OnGet()
        {
            employee = _employeeService.GetEmployee(HttpContext.Session.GetInt32("employeeId") ?? 0);
        }


    }
}
