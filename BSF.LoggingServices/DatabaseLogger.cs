using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using BSF.BusinessEntities;
using BSF.BusinessServices;

namespace BSF.LoggingServices
{
    public class DatabaseLogger : ILogger
    {
        private IEntityManager<Log> _logManager;

        public DatabaseLogger(IEntityManager<Log> manager)
        {
            _logManager = manager;
        }

        public void Log(string message, LogType logType)
        {
            if (string.IsNullOrWhiteSpace(message)) 
            {
                return;
            }

            _logManager.Add(new Log() { Message = message.Trim(), LogType = (int)logType });
        }
    }
}