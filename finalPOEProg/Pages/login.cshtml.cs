
using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace finalPOEProg.Pages
{
    public class loginModel : PageModel
    {
        // creating an object object
#pragma warning disable CS0436 // Type conflicts with imported type
        Class1 details = new Class1();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User userdetails { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS0436 // Type conflicts with imported type
        //declaring the variable
        public string user = "", pass = "";
        public string message = "";
        public Boolean check = false;
      
        public void OnGet()
        {

        }
        
        public void OnPost()
        {
            // getting the values from the form
            user = Request.Form["username"];
            pass = Request.Form["password"];

#pragma warning disable CS0436 // Type conflicts with imported type
            userdetails = new User { username = user, password = pass };
#pragma warning restore CS0436 // Type conflicts with imported type
                              //getting ther user  info from the librarty class

            if (details.login(userdetails.username, userdetails.password))
            {
                details.check = true;
                Response.Redirect("/dashboard?username=" + userdetails.username);
            }
            else
            {


                message = "user not found please enter the correct details";

            }
        }
    }
}
