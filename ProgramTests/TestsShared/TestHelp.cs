using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestsShared
{
    public class TestHelp
    {
        /// <summary>
        /// Parses a string to a double regardless if it uses a comma or a dot as decimal seperator
        /// </summary>
        /// <param name="s">String to parse</param>
        /// <returns>Parsed double</returns>
        public static double ParseDouble(string s)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return double.Parse(s.Replace(",", "."));
            }
            else
            {
                return double.Parse(s.Replace(".", ","));
            }

        }
    }
}
