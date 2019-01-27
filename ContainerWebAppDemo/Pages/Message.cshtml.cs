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
        public string MessageServiceLocation { get; set; } 

        [BindProperty]
        public string ImageServiceLocation { get; set; } 

        [BindProperty]
        public BusinessEntities.MessageModel Message { get; set; }

        [BindProperty]
        public int ImageSize { get; set; }

        public MessageModel()
        {
            _client = new WebClient();
        }

        public void OnGet()
        {
            var service1 = HttpContext.Session.GetString("service1") ?? "messageservice";
            var service2 = HttpContext.Session.GetString("service2") ?? "imagesservice";
            var imageSize = HttpContext.Session.GetInt32("imageSize") ?? 0;

            MessageServiceLocation = service1;
            ImageServiceLocation = service2;
            ImageSize = imageSize;

            var jsonMessage = HttpContext.Session.GetString("jsonMessage");

            if (!string.IsNullOrWhiteSpace(jsonMessage))
            {
                Message = JsonConvert.DeserializeObject<BusinessEntities.MessageModel>(jsonMessage);
            }
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                HttpContext.Session.SetString("service1", MessageServiceLocation);
                HttpContext.Session.SetString("service2", ImageServiceLocation);

                var jsonMessage =
                    await _client.DownloadStringTaskAsync($"http://{MessageServiceLocation}/api/testmessage");

                if (!string.IsNullOrWhiteSpace(jsonMessage))
                {
                    HttpContext.Session.SetString("jsonMessage", jsonMessage);
                }

                var image =
                    await _client.DownloadDataTaskAsync($"http://{ImageServiceLocation}/api/testmessage");

                HttpContext.Session.Set("image", image);

                if (image != null)
                {
                    HttpContext.Session.SetInt32("imageSize", image.Length);
                }
                else
                {
                    HttpContext.Session.SetInt32("imageSize", 1234);
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