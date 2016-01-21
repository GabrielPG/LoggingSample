using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.CommonServices
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }
        void WriteLine(string line);
    }
}
