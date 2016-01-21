using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.LoggingServices
{
    public class JobLogger : IJobLogger
    {
        private List<ILogger> _loggers;

        public JobLogger(List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void LogError(string error)
        {
            _loggers.ForEach(logger => logger.Log(error, LogType.Error));
        }

        public void LogWarning(string warning)
        {
            _loggers.ForEach(logger => logger.Log(warning, LogType.Warning));
        }

        public void LogMessage(string message)
        {
            _loggers.ForEach(logger => logger.Log(message, LogType.Message));
        }
    }
}
