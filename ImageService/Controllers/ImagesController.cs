using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly List<string> _imagesList = new List<string>();

        public ImagesController()
        {
            _imagesList.AddRange(Directory.EnumerateFiles("wwwroot/Images/"));
        }

        [HttpGet]
        public FileResult Get()
        {
            var random = new Random();
            var randomNumber = random.Next(1, _imagesList.Count() + 1);

            return File(System.IO.File.OpenRead($"wwwroot/Images/cat_{randomNumber:D2}.jpeg"), "image/jpeg");
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 1 || id > _imagesList.Count())
            {
                return NotFound();
            }
            return File(System.IO.File.OpenRead($"wwwroot/Images/cat_{id:D2}.jpeg"), "image/jpeg");
        }
    }
}