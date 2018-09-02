using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContainerWebAppDemo.Components.FileWriter;
using ContainerWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerWebAppDemo.Pages
{
    public class VolumeDemoModel : PageModel
    {
        private IFileWriterService _fileWriter;

        public VolumeDemoModel(IFileWriterService fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public string Message { get; set; }

        [BindProperty]
        public VolumeModel VolumeData { get; set; }

        public void OnGet()
        {
            Message = "Geef hieronder de tekst op om op te slaan.";
        }
    }
}
