using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    interface IPluggedIn
    {
        bool IsActive { get; set; }
        void PlugIn();
        void PlugOut();
    }
}
