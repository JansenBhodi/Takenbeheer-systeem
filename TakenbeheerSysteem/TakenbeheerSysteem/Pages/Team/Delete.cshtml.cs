using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;

namespace TakenbeheerSysteem.Pages.Team
{
    public class DeleteModel : PageModel
    {
		private TeamService _service;
		public void OnGet()
		{

		}

		public DeleteModel(ITeamRepository irepo)
		{
			_service = new TeamService(irepo);
		}


		public ActionResult OnPost()
		{
			if (Request.Form["submit"] == "Delete")
			{
				try
				{

					_service.DeleteTeam(HttpContext.Session.GetInt32("deleteTarget") ?? default(int));
				}
				catch (Exception)
				{
					//Log what exactly went wrong and show custom error page
				}
				return RedirectToPage("/Team/Index");
			}
			else
			{
				return RedirectToPage("/Team/Details");
			}
		}
	}
}
