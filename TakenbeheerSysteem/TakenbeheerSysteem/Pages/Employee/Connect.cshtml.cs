using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;

namespace TakenbeheerSysteem.Pages.Employee
{
    public class ConnectModel : PageModel
    {
        public WorkerEmployee employee { get; set; }
        public List<Worktask> tasks { get; set; }

        public void OnGet()
        {
        }
    }
}
