using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    internal class Kettle:ElectricalDevice, IPluggedIn
    {
        public bool IsActive { get; set; }

        public Kettle(string kettle, double powerConsumption, bool isActive, string color)
        {
            Name = kettle;
            PowerConsumption = powerConsumption;
            IsActive = isActive;
            Color = color;
        }

        public void PlugIn()
        {
            IsActive = true;
        }

        public void PlugOut()
        {
            IsActive = false;
        }

        public override string GetSize()
        {
            return "Small";
        }
    }
}
