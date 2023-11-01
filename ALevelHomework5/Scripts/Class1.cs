using System;
using System.Collections.Generic;
using System.IO;

public enum LogType
{
    Error,
    Info,
    Warning
}

public class Logger
{
    private static Logger log;
    private List<string> logList;

    private Logger()
    {
        logList = new List<string>();
    }

    public static Logger LoggerSample
    {
        get
        {
            if (log == null)
            {
                log = new Logger();
            }
            return log;
        }
    }

    public void Log(LogType logType, string message)
    {
        string log = $"{DateTime.Now}:{logType}:{message}";
        logList.Add(log);
        Console.WriteLine(log);
    }

    public List<string> GetLogs()
    {
        return logList;
    }
}

