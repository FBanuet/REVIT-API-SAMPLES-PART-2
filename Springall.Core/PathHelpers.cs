using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Springall.Core
{
    public static class PathHelpers
    {
        public static string GetFileName(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
                return string.Empty;


            var lastIndex = fullPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return fullPath;

            return Path.GetFileNameWithoutExtension(fullPath.Substring(lastIndex + 1));
        }

    }
}
