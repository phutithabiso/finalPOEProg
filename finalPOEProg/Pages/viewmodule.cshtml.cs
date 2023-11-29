using ADO.Net.Client.Annotations;
using ClassLibrary;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Reflection;

namespace finalPOEProg.Pages
{
    public class viewmoduleModel : PageModel
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        Class1 detail = new Class1();
#pragma warning restore CS0436 // Type conflicts with imported type
        public List<string> id  = new List<string>();
        public List<string> Code  = new List<string>();
        public List<string> Name  = new List<string>();
        public List<string> Credits = new List<string>();
        public List<string> ClassHour  = new List<string>();
        public List<string> SelfStudyHours  = new List<string>();
        public List<string> Startdate  = new List<string>();
        public string username = "";
     


        public void OnGet()
        {

            username = Request.Query["username"];

            detail.get_module(id, Code, Name, Credits, ClassHour, SelfStudyHours, Startdate, username);

        }
     

        public void OnPost() {

            string onHours = Request.Form["hours"];
            string idS = Request.Form["id"];
          



            //
            detail.minusHour(idS, onHours);

            //


            username = Request.Query["username"];

            detail.get_module(id, Code, Name, Credits, ClassHour, SelfStudyHours, Startdate, username);


        }

    }
}
