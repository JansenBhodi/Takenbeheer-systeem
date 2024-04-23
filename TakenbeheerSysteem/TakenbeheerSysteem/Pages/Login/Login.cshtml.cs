using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TakenbeheerSysteem.Pages.Login
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            try
            {
                int id = 1;
                if (id != null)
                {
                    HttpContext.Session.SetInt32("uId", id);
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
