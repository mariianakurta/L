using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    internal class Microwave:ElectricalDevice, IPluggedIn
    {
        public bool IsActive { get; set; }

        public Microwave(string microwave, double powerConsumption, bool isActive, string color)
        {
            Name = microwave;
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
            return "Large";
        }
    }
}
