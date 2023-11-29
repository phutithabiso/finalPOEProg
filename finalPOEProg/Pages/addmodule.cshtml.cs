using ClassLibrary;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace finalPOEProg.Pages
{
    public class addmoduleModel : PageModel
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        Class1 details = new Class1();
        modules module = new modules();

#pragma warning restore CS0436 // Type conflicts with imported type
        public string message = "";
        public Boolean check = false;

        public void OnGet()
        {
        }
        public void OnPost()
        {
            module.Code = Request.Form["Code"];
            module.Code = Request.Form["Code"];
            module.Name = Request.Form["Name"];
            module.Credits = int.Parse(Request.Form["Credits"]);
            module.ClassHour = int.Parse(Request.Form["ClassHour"]);
            module.SelfStudy = int.Parse(Request.Form["SelfStudy"]);
            module.Startdate = Request.Form["Startdate"];
            module.username = Request.Query["username"];

            int SelfStudyHours = (module.Credits * 10) / module.SelfStudy - module.ClassHour;




            details.Module(module.Code, module.Name, module.Credits, module.ClassHour, SelfStudyHours, module.Startdate, module.username);

            if (message.StartsWith("Error"))
            {
                // There was an error adding the module
                check = false;
            }
            else
            {
                // Module was added successfully
                check = true;
                Response.Redirect("/dashboard?username=" + module.username);
            }
        }
    }
}