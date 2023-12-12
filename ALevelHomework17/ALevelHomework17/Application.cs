using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework17
{
    public class Application
    {
        public async Task StartAsync()
        {
            JsonConfig config = JsonConfig.Load("config1.json");

            if (config == null)
            {
                Console.WriteLine("Error");
                return;
            }

            Logger logger = new Logger("log.txt");
            logger.ThisBackupPart += BackupHandler;

            BackupConfig.Instance.EntriesFromBackup = config.BackNumber;

            await Task.WhenAll(LogEntryAsync(logger), LogEntryAsync(logger));
        }

        private async Task LogEntryAsync(Logger logger)
        {
            for (int i = 0; i < 50; i++)
            {
                await logger.LogAsync($"Log entry {i}");
            }
        }

        private void BackupHandler(int logCount)
        {
            string backupFolder = "Backup";
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            string backupFileName = $"{DateTime.Now:yyyyMMddHHmmss}_Backup.txt";
            string backupFiles = Path.Combine(backupFolder, backupFileName);

            File.Copy("log.txt", backupFiles);

            Console.WriteLine($"Backup created: {backupFiles}");
        }
    }
}
