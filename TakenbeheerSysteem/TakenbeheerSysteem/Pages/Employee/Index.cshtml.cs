using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;
using TakenbeheerDAL;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class IndexModel : PageModel
    {

        private EmployeeService _employeeService;
        private TeamService _teamService;
        public List<WorkerEmployee> Workers;
        public TeamModel Team;

        public IndexModel([FromServices] ITeamRepository teamRepo)
        {
            _employeeService = new EmployeeService(new EmployeeRepository());
            _teamService = new TeamService(teamRepo);
        }

        public void OnGet()
        {
            Team = _teamService.GetTeamForEmployee(HttpContext.Session.GetInt32("uId") ?? 0);
            Workers = _employeeService.GetEmployees(Team.Id);
        }

        public ActionResult OnPost(int employeeId = 0)
        {
            try
            {
                employeeId = int.Parse(Request.Form["employeeId"]);
            }
            catch
            {

            }
            if (employeeId != 0)
            {
                HttpContext.Session.SetInt32("employeeId", employeeId);
                return Redirect("Employee/Details");
            }
            else
            {
                return Redirect("Employee/Create");
            }
        }
    }
}