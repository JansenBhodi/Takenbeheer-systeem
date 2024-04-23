using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private EmployeeService _employeeService;
        private TeamService _teamService;

        public void OnGet([FromServices] IEmployeeRepository employeeRepo, [FromServices] ITeamRepository teamRepo)
        {
            _employeeService = new EmployeeService(employeeRepo);
            _teamService = new TeamService(teamRepo);
        }

        public ActionResult OnPost()
        {
            Team team = _teamService.GetTeamForEmployee(HttpContext.Session.GetInt32("uId") ?? 0);
            WorkerEmployee employee = new WorkerEmployee(
                team.Id,
                Request.Form["Name"],
                Request.Form["Email"],
                Request.Form["Password"],
                Request.Form["Address"],
                Request.Form["PostalCode"]
                );
            if(_employeeService.CreateEmployee(employee))
            {
                return Redirect("Employee/Index");
            }
            else
            {
                return Redirect("Employee/Create");
            }
        }
    }
}
