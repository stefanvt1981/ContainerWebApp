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

        public string MessageSeriveLocation { get; set; } = "localhost:10001";
        public string ImageSeriveLocation { get; set; } = "localhost:10002";
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
            var jsonMessage = await _client.DownloadStringTaskAsync($"http://{MessageSeriveLocation}/api/testmessage");

            if (!string.IsNullOrWhiteSpace(jsonMessage))
            {
                HttpContext.Session.SetString("jsonMessage", jsonMessage);
            }

            return RedirectToPage("./Message");
        }
    }
}