using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class DeleteModel : PageModel
    {
        public EmployeeService service;
        public void OnGet()
		{

		}

        public DeleteModel(IEmployeeRepository irepo) 
        {
            service = new EmployeeService(irepo);
        }

        public ActionResult OnPost()
        {
            if (Request.Form["submit"] == "Delete")
			{
				try
				{
                    
					service.DeleteEmployee(HttpContext.Session.GetInt32("deleteTarget") ?? default(int));
				}
                catch(Exception)
                {
					//Log what exactly went wrong and show custom error page
				}
				return Redirect("Index");
			}
            else
			{
				return Redirect("Index");
			}
        }
    }
}
