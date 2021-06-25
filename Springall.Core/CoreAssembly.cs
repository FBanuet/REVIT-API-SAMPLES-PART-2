using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Springall.Core
{
    public class CoreAssembly
    {
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}
