using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using ClassLibrary;


namespace finalPOEProg.Pages
{
    public class registerModel : PageModel
    {
        //declaring variables
        public string  username = "", password = "", message = "";
        public Boolean check = false;

        // creating an object object
#pragma warning disable CS0436 // Type conflicts with imported type
        Class1 detail = new Class1();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User userdetails { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS0436 // Type conflicts with imported type

        public void OnGet()
        {
        }
        public void OnPost() {
            // getting the values from the form
            username = Request.Form["username"];
            password = Request.Form["password"];

#pragma warning disable CS0436 // Type conflicts with imported type
            userdetails = new User { username = username, password = username };
#pragma warning restore CS0436 // Type conflicts with imported type


            //calling the user method from the the library class
            detail.users(userdetails.username, userdetails.password);
            if (message != " found")
            {
                //assiging boolean to true
                check = true;
                Response.Redirect("/dashboard?username=" + userdetails.username + "");

            }
            else
            {
                //assiging boolean to false
                check = false;
                message = " user not found";
            }
        }    
    }
}
