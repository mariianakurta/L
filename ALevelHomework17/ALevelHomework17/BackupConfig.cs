using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework17
{
    public class BackupConfig
    {
        private static BackupConfig instance;

        public static BackupConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BackupConfig();
                }

                return instance;
            }
        }

        public int EntriesFromBackup { get; set; }
    }
}
