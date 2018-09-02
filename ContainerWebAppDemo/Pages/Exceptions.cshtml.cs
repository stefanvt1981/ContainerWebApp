using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerWebAppDemo.Pages
{
    public class ExceptionsModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Op deze pagina kunnen (fatal) exceptions gesimuleerd worden";
        }

        public ActionResult OnPostUnhandled()
        {
            throw new ApplicationException("Unhandled Exception!");

            //return new EmptyResult();
        }
    }
}
