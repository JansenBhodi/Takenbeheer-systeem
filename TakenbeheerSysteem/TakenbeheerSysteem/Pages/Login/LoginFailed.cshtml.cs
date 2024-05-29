using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;

namespace TakenbeheerSysteem.Pages.Login
{
    public class LoginModelFailed : PageModel
    {
        private EmployeeService _service;

        public void OnGet()
        {

        }

        public LoginModelFailed(IEmployeeRepository repo)
        {
            _service = new EmployeeService(repo);
        }

        public IActionResult OnPost()
        {

            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            try
            {
                int[] input = _service.AttemptLogin(email, password);
                if (input != null)
                {
                    HttpContext.Session.SetInt32("uId", input[0]);
                    HttpContext.Session.SetInt32("role", input[1]);
                    return Redirect("../Index");
                }
                else
                {
                    return Redirect("LoginFailed");
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
