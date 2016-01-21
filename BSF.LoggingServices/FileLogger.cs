using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using BSF.CommonServices;


namespace BSF.LoggingServices
{
    public class FileLogger : ILogger
    {
        private IFileSystem _fileSystem;
        private string _logFilePath;
        private string _logBaseFileName;

        public FileLogger(IFileSystem fileSystem, string logFilePath, string logBaseFileName)
        {
            _fileSystem = fileSystem;
            _logFilePath = logFilePath;
            _logBaseFileName = logBaseFileName;
        }

        private string GetLogFileName()
        {
            return _logFilePath + _logBaseFileName + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
        }

        private string GetLogMessage(string message, LogType logType)
        {
            return string.Format("{0} {1}: {2}", DateTime.Now.ToShortDateString(), logType.ToString(), message.Trim());
        }

        public void Log(string message, LogType logType)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            var logFileName = GetLogFileName();

            if (!_fileSystem.FileExists(logFileName))
            {
                _fileSystem.CreateFile(logFileName);
            }

            _fileSystem.AppendLine(logFileName, GetLogMessage(message, logType));
        }
    }
}
