using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContainerWebAppDemo.Extentions;
using ContainerWebAppDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ContainerWebAppDemo.Pages
{
    public class DelayModel : PageModel
    {
        private readonly DelayOptions _delayOptions;
        private DelayOptions _delayOptionsFromSession;

        [BindProperty]
        public DelayOptions DelayOptions { get; set; }

        public DelayModel(IOptions<DelayOptions> delayOptions)
        {
            _delayOptions = delayOptions.Value;
        }

        public void OnGet()
        {
            _delayOptionsFromSession = HttpContext.Session.Get<DelayOptions>("DelayOptions");

            DelayOptions = _delayOptionsFromSession ?? _delayOptions;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            HttpContext.Session.Set<DelayOptions>("DelayOptions", DelayOptions);

            return RedirectToPage("./Delay");
        }
    }
}