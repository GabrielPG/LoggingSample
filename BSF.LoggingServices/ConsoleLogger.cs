using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BSF.CommonServices;

namespace BSF.LoggingServices
{
    public class ConsoleLogger : ILogger
    {
        private IConsole _console;

        public ConsoleLogger(IConsole console)
        {
            _console = console;
        }

        private ConsoleColor GetForegroundColor(LogType logType)
        {
            switch (logType) {
                case LogType.Error:
                    return ConsoleColor.Red;                    

                case LogType.Warning:
                    return ConsoleColor.Yellow;
                    
                case LogType.Message:
                    return ConsoleColor.White;

                default:
                    throw new Exception("Unexpected LogType value");            
            }
        }

        private string GetLogMessage(string message)
        {
            return string.Format("{0} {1}", DateTime.Now.ToShortDateString(), message.Trim());
        }

        public void Log(string message, LogType logType)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            _console.ForegroundColor = GetForegroundColor(logType);
            _console.WriteLine(GetLogMessage(message));
        }
    }
}
