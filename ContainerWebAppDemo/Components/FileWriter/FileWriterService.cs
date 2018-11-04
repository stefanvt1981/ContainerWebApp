using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ContainerWebAppDemo.Components.FileWriter
{
    public class FileWriterService : IFileWriterService
    {
        public FileWriterService()
        {
            if (!Directory.Exists(@"/Data/"))
            {
                Directory.CreateDirectory(@"/Data/");
            }
        }

        private string _textFilePath = @"/Data/VolumeData.txt";

        public string GetSavedString()
        {
            try
            {
                if (!File.Exists(_textFilePath))
                {
                    return "";
                }

                using (var reader = File.OpenText(_textFilePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void SaveString(string text)
        {
            try
            {
                using (var writer = File.AppendText(_textFilePath))
                {
                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public void Clear()
        {
            try
            {
                using (var writer = File.CreateText(_textFilePath))
                {
                    writer.Write("");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
