using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace finalPOEProg.Pages
{
    public class dashboardModel : PageModel
    {
        public string username = "";
        public void OnGet()
        {
            // getting the user from email
            username = Request.Query["username"];
        }
    }
}
