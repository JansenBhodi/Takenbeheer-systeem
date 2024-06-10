using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;
using TakenbeheerDAL;

namespace TakenbeheerSysteem.Pages.Team
{
    public class CreateModel : PageModel
    {
        private TeamService _teamService;
        private EmployeeService _employeeService;
        private int _employeeId;

        public CreateModel([FromServices] ITeamRepository teamRepo, [FromServices] IEmployeeRepository empRepo) 
        {
            _teamService = new TeamService(teamRepo);
            _employeeService = new EmployeeService(empRepo);
        }

        public void OnGet()
        {
            _employeeId = HttpContext.Session.GetInt32("uId") ?? default(int);
        }

        public IActionResult OnPost()
        {
            string input = Request.Form["Submit"];
            try
            {
                switch (input)
                {
                    case "Create":
                        TeamModel result = new TeamModel(
                            0,
                            Request.Form["Name"],
                            Request.Form["Address"],
                            Request.Form["PostalCode"]);

                        _employeeService.DecoupleTasksForEmployee(_employeeId);
                        _teamService.CreateTeam(result, _employeeId);
                        return RedirectToPage("/Team/Details");
                    case "Cancel":
                        return RedirectToPage("/Team/Index");
                }
            }
            catch (Exception)
            {

                return RedirectToPage("/Team/Create");
            }

            return RedirectToPage("/Team/Index");
        }
    }
}
