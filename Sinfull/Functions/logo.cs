using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinfull.Functions
{
    internal class logo
    {
        public static void logoo()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine(@"
 ╔═╗┬┌┐┌┌─┐┬ ┬┬  ┬  
 ╚═╗││││├┤ │ ││  │  
 ╚═╝┴┘└┘└  └─┘┴─┘┴─┘
");
        }
    }
}
