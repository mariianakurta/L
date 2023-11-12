using ALevelHomework9;
using System;

class Program
{
    static void Main(string[] args)
    {
        ILogger consoleLogger = new Logger();
        IFileService fileService = new FileService();
        Actions actions = new Actions(consoleLogger);
        App app = new App(actions, consoleLogger, fileService);

        string logCollection = "LogFiles";
        Directory.CreateDirectory(logCollection);

        app.Run(100, logCollection);
    }
}