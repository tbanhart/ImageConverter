using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImageConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var propFileDir = Directory.GetCurrentDirectory() + "\\properties.json";

            //var options = GhostScript.DeviceOptions.DefaultOptions();
            Initializer init = new Initializer(propFileDir);
            if (init.IsInitialized == false)
            {
                init.UpdateRecords(GetFilePaths(), propFileDir);
            }

            Properties properties = init.ReadFile<Properties>(propFileDir);

            string InputFolder = properties.Input;
            string OutputFolder = properties.Output;

            //Get image location
            //location = GetPath(".pdf location");

            //Get image destination
            //destination = GetPath(".tiff location");

            //Get all images from location

            //Convert each image and store in destination
            Converter.ConvertAllInFolder(InputFolder, OutputFolder);

            Console.ReadLine();
        }

        static Properties GetFilePaths()
        {
            var returnprop = new Properties();

            returnprop.Input = GetPath("the path to where you will place .pdf's.");
            returnprop.Output = GetPath("the path to where converted .tiff's will go.");

            return returnprop;
        }

        static string GetPath(string prompt)
        {
            string path;

            do
            {
                Output.PromptInput(prompt);
                path = Input.GetInput();
            } 
            while (!Directory.Exists(path));

            return path;
        }

    }
}
