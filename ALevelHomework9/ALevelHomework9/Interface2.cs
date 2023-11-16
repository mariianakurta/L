using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    interface IFileService
    {
        void WriteToFile(string directory, string fileName, string content);
        void FilesControl(string directory);
    }
}
