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
            
        }

        private string _textFilePath = @"/Data/VolumeData.txt";

        public string GetSavedString()
        {
            try
            {
                return File.OpenText(_textFilePath).ReadToEnd();
            }
            catch (Exception ex)
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
