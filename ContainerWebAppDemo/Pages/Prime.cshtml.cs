using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerWebAppDemo.Pages
{
    public class PrimeModel : PageModel
    {
        public void OnGet()
        {

        }

        public ActionResult OnPostUnhandled()
        {
            //throw new ApplicationException("Unhandled Exception!");

            Program.Shutdown();

            return new EmptyResult();
        }
    }
}