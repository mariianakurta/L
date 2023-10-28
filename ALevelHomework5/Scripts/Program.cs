using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static void Main()
    {
       Registration registry = new Registration();
        registry.Run();

        string logs = string.Join("\n", Logger.LoggerSample.GetLogs());
        File.WriteAllText("log.txt", logs);
    }
}
