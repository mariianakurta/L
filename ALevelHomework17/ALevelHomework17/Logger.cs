using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework17
{
    public class Logger
    {
        public event Action<int> ThisBackupPart;

        private int logCount;
        private readonly string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
            logCount = 0;
        }

        public async Task LogAsync(string message)
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                await writer.WriteLineAsync($"{DateTime.Now}: {message}");
            }

            logCount++;

            if (logCount % BackupConfig.Instance.EntriesFromBackup == 0)
            {
                BackupPart(logCount);
            }
        }

        private void BackupPart(int logCount)
        {
            ThisBackupPart?.Invoke(logCount);
        }
    }
}
