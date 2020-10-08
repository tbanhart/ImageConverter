using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Ghostscript.NET.Rasterizer;
using System.Drawing.Imaging;

namespace ImageConverter
{
    public class Converter
    {
        public static void ConvertAllInFolder(string programPath, string inputPath, string outputPath)
        {
            foreach (var file in Directory.GetFiles(inputPath))
            {
                PdfToPng(file, outputPath);
            }
        }

        private static void PdfToPng(string inputFile, string outputPath)
        {
            var xDpi = 300; var yDpi = 300;

            if (Path.GetExtension(inputFile) != ".pdf") return;

            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.Open(inputFile);
                int pages = rasterizer.PageCount;


                for (int pageNumber = 1; pageNumber <= pages; pageNumber++)
                {
                    var outputPNGPath = Path.Combine(outputPath, 
                        Path.GetFileNameWithoutExtension(inputFile) + "00" + pageNumber.ToString() + ".tif");
                    Console.WriteLine(outputPNGPath);

                    var pdf2PNG = rasterizer.GetPage(xDpi, yDpi, pageNumber);

                    pdf2PNG.Save(outputPNGPath, ImageFormat.Tiff);
                }
            }
        }
    }
}
