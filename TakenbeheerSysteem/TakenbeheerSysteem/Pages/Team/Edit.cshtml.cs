using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Team
{
    public class EditModel : PageModel
    {
        private TeamService _service;
        public TeamModel input;

        public EditModel(ITeamRepository repo)
        {
            _service = new TeamService(repo);
        }

        public void OnGet()
        {
            input = _service.GetTeamForEmployee(HttpContext.Session.GetInt32("uId") ?? default(int));
        }


        public ActionResult OnPost()
        {
            if (Request.Form["Submit"] == "Update")
            {
                TeamModel result = new TeamModel(
                    input.Id,
                    Request.Form["Name"],
                    Request.Form["Address"],
                    Request.Form["PostalCode"]
                    );
                if (_service.UpdateTeam(result))
                {
                    return Redirect("Details");
                }
                else
                {
                    return Redirect("Create");
                }
            }
            else
            {
                return Redirect("Details");
            }
        }
    }
}
