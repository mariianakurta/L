using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    interface ILogger
    {
        void Log(string logType, string message);
        void LogError(string errorMessage);
        void LogInfo(string infoMessage);
        void LogWarning(string warningMessage);
        void LoggerMaintenance();
    }
}
