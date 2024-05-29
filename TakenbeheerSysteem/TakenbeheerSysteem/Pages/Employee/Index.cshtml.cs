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


        public IndexModel([FromServices] ITeamRepository teamRepo, [FromServices] IEmployeeRepository empRepo)
        {
            _employeeService = new EmployeeService(empRepo);
            _teamService = new TeamService(teamRepo);
        }

        public void OnGet()
        {
            Team = _teamService.GetTeamForEmployee(HttpContext.Session.GetInt32("uId") ?? 0);
            Workers = _employeeService.GetEmployees(Team.Id);
        }

        public ActionResult OnPost(string submit, int employeeId = 0)
        {
            try
            {
                submit = Request.Form["submit"];
            }
            catch
            {
                return Redirect("Employee/Index");
            }
            switch (submit)
            {
                case "View":
                    employeeId = int.Parse(Request.Form["employeeId"]);
                    HttpContext.Session.SetInt32("employeeId", employeeId);
                    return Redirect("Employee/Details");
                    break;
                case "Delete":
                    employeeId = int.Parse(Request.Form["employeeId"]);
                    HttpContext.Session.SetInt32("deleteTarget", employeeId);
                    return Redirect("Employee/Delete");
                    break;
                case "Create":
                    return Redirect("/Employee/Create");
                    break;
                case "Team Details":
                    return Redirect("~/Team/Details");
                    break;
                default:
                    return Redirect("Employee/Index");
                    break;
            }

            return Redirect("Employee/Index");
        }
    }
}