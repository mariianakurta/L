using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    class Logger : ILogger
    {
        public void LogError(string errorMessage)
        {
            Log("Error", errorMessage);
        }

        public void LogInfo(string infoMessage)
        {
            Log("Info", infoMessage);
        }

        public void LogWarning(string warningMessage)
        {
            Log("Warning", warningMessage);
        }

        public void LoggerMaintenance()
        {
            Console.WriteLine();
        }

        public void Log(string logType, string message)
        {
            string logTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
            Console.WriteLine($"{logTime}: {logType}: {message}");
        }
    }
}
