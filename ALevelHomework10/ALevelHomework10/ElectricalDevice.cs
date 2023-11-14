using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    internal class ElectricalDevice:IElectricalAppliances
    {
        public string Color { get; set; }
        public virtual string GetSize() 
        {
            return "Size";
        }
        public string Name { get; set; }
        public double PowerConsumption { get; set; }
    }
}
