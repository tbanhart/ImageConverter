using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ImageConverter.BrighterTools;

namespace ImageConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //var options = GhostScript.DeviceOptions.DefaultOptions();

            string GSFolder = Properties.GhostscriptInstall;
            string InputFolder = Properties.InputFolder;
            string TempFolder = Properties.TempFolder;
            string OutputFolder = Properties.OutputFolder;

            //Get image location
            //location = GetPath(".pdf location");

            //Get image destination
            //destination = GetPath(".tiff location");

            //Get all images from location

            //Convert each image and store in destination
            Converter.ConvertAllInFolder(GSFolder, InputFolder, OutputFolder);

            Console.ReadLine();
        }

        static string GetPath(string prompt)
        {
            string path;

            do
            {
                Output.PromptInput(prompt);
                path = Input.GetInput();
            } 
            while (Directory.Exists(path));

            return path + "\\";
        }
    }
}
