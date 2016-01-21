using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.CommonServices
{
    public class AppConsole : IConsole
    {
        public ConsoleColor ForegroundColor
        {
            get
            {
                return Console.ForegroundColor;
            }

            set
            {
                Console.ForegroundColor = value;
            }
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
