using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onnxware.Components.Tools
{
    internal class FileHelper
    {
        // Checks for Full-Path
        public static bool IsPath(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (!Path.IsPathRooted(input))
                return false;

            if (input.Length <= 2)
                return false;

            // Check if windows drive is in path (not linux supported)
            if (!(char.IsLetter(input[0]) && input[1] == ':'))
                return false;

            return true;
        }
    }
}
