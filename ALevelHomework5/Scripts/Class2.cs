using System;
using System.Collections.Generic;
using System.IO;

public class Action
{
    Random random = new Random();

    public Result InfoMethod()
    {
        return Logging(true, LogType.Info, "Start method");
    }

    public Result WarningMethod()
    {
        return Logging(true, LogType.Warning, "Skipped logic in method");
    }

    public Result ErrorMethod()
    {
        return Logging(false, LogType.Error, "I broke a logic");
    }

    private Result Logging(bool status, LogType logType, string message)
    {
        Logger.LoggerSample.Log(logType, $"Start method: {message}");
        return new Result {Condition = status, Error2 = status? null : message };
    }
}
