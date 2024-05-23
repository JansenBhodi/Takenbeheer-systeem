using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;

namespace TakenbeheerSysteem.Pages.Login
{
    public class LoginModel : PageModel
    {
        private EmployeeService _service;

        public void OnGet()
        {

        }

        public LoginModel(IEmployeeRepository repo)
        {
            _service = new EmployeeService(repo);
        }

        public IActionResult OnPost()
        {

            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            try
            {
                WorkerEmployee emp = _service.AttemptLogin(email, password);
                if (emp.Id != 0)
                {
                    HttpContext.Session.SetInt32("uId", emp.Id);
                    HttpContext.Session.SetInt32("role", (int)emp.Role);
                    return Redirect("../Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Redirect("Login");
        }
    }
}
