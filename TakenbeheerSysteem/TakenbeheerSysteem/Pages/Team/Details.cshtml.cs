using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Team
{
    public class DetailsModel : PageModel
    {
        private TeamService _service;
        public TeamModel team;

        public DetailsModel([FromServices] ITeamRepository repo)
        {
            _service = new TeamService(repo);
        }

        public void OnGet()
        {
            team = _service.GetTeamForEmployee(HttpContext.Session.GetInt32("uId") ?? default(int));
        }

        public ActionResult OnPost()
        {
            switch (Request.Form["Submit"])
            {
                case "Edit":
                    return Redirect("Edit");
                    break;
                case "Delete":
                    return Redirect("Delete");
                    break;

            }

            return Redirect("Details");
        }
    }
}
