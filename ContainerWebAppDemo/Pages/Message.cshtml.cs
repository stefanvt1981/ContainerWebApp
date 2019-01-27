using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ContainerWebAppDemo.Pages
{
    public class MessageModel : PageModel
    {
        private WebClient _client;

        [BindProperty]
        public string MessageServiceLocation { get; set; } = "messageservice";

        [BindProperty]
        public string ImageServiceLocation { get; set; } = "imagesservice";

        [BindProperty]
        public BusinessEntities.MessageModel Message { get; set; }

        public MessageModel()
        {
            _client = new WebClient();
        }

        public void OnGet()
        {
            var jsonMessage = HttpContext.Session.GetString("jsonMessage");

            if (!string.IsNullOrWhiteSpace(jsonMessage))
            {
                Message = JsonConvert.DeserializeObject<BusinessEntities.MessageModel>(jsonMessage);
            }
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            try{
                
                var jsonMessage =
                    await _client.DownloadStringTaskAsync($"http://{MessageServiceLocation}/api/testmessage");

                if (!string.IsNullOrWhiteSpace(jsonMessage))
                {
                    HttpContext.Session.SetString("jsonMessage", jsonMessage);
                }
            }
            catch
            {
                // do nothing
            }

            return RedirectToPage("./Message");

        }
    }
}