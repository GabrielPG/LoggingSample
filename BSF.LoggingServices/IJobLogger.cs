using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.LoggingServices
{
    public interface IJobLogger
    {
        void LogError(string error);
        void LogWarning(string warning);
        void LogMessage(string message);
    }
}
