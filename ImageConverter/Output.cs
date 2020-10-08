using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    class Output
    {
        public static void DisplayError(string invalidText)
        {
            Console.WriteLine($"Error processing {invalidText}.");
        }

        public static void PromptInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}.");
        }
    }
}
