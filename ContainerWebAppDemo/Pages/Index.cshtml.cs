using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContainerWebAppDemo.Extentions;
using ContainerWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ContainerWebAppDemo.Pages
{
    public class IndexModel : PageModel
    {
        private DelayOptions _options;

        public bool UseDelay => _options.UseDelay;
        public int DelayInMilliseconds => _options.DelayInMilliseconds;

        public IndexModel(IOptions<DelayOptions> options)
        {
            _options = options.Value;
        }

        public void OnGet()
        {
            var optionsFromSession = HttpContext.Session.Get<DelayOptions>("DelayOptions");

            if (optionsFromSession != null)
            {
                _options = optionsFromSession;
            }
        }
    }
}
