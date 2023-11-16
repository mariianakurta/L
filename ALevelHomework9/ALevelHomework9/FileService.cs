using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    class FileService : IFileService
    {
        public void WriteToFile(string collection, string fileName, string collect)
        {
            string fileStore = Path.Combine(collection, $"{fileName}.txt");
            File.WriteAllText(fileStore, collect);
        }

        public void FilesControl(string collection)
        {
            var files = Directory.GetFiles(collection)
                                 .Select(data => new FileInfo(data))
                                 .OrderBy(data => data.CreationTime)
                                 .ToList();

            if (files.Count > 3)
            {
                files[0].Delete();
            }
        }
    }
}
