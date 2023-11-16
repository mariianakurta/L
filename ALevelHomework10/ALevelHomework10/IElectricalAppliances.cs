using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    interface IElectricalAppliances
    {
        string Color { get; set; }
        string GetSize();
        string Name { get; set; }
        double PowerConsumption { get; set; }
    }

}
