using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImageConverter
{
    public static class Properties
    {
        public static string Install { get => "C:\\Users\\T-money\\Desktop\\Install\\"; }

        public static string GhostscriptInstall { get => Install + "\\Ghostscript\\bin\\"; }

        public static string TempFolder { get => Install + "Temp\\"; }

        public static string InputFolder { get => Install + "Input\\"; }

        public static string OutputFolder { get => Install + "Output\\"; }
    }
}
