using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class DeleteModel : PageModel
    {
        public EmployeeService service;
        public int target;
        public void OnGet()
        {
        }

        public DeleteModel(IEmployeeRepository irepo) 
        {
            service = new EmployeeService(irepo);
            target = HttpContext.Session.GetInt32("deleteTarget") ?? 0;
        }

        public ActionResult OnPost()
        {
            try
            {
                service.DeleteEmployee(target);
            }
            finally
            {

            }
            return Redirect("Employee/Index");
        }
    }
}
