using System;
using System.Collections.Generic;
using System.IO;

public class Registration
{
    public void Run()
    {
        Action action = new Action();

        for (int i = 0; i < 100; i++)
        {
            int randomExample = new Random().Next(1, 4);
            Result result;

            switch (randomExample)
            {
                case 1:
                    result = action.InfoMethod();
                    break;
                case 2:
                    result = action.WarningMethod();
                    break;
                default:
                    result = action.ErrorMethod();
                    break;
            }

            if (!result.Condition)
            {
                Logger.LoggerSample.Log(LogType.Error, $"Action failed by a reason: {result.Error2}");
            }
        }
    }
}
