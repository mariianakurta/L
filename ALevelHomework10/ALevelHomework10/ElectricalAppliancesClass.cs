using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework10
{
    internal static class ElectricalAppliancesClass
    {
        public static double CalculatePowerConsumption(this ElectricalDevice[] appliances)
        {
            return appliances.Sum(appliance => appliance.PowerConsumption);
        }

        public static ElectricalDevice PowerDetect(this ElectricalDevice[] appliances, double minPower, double maxPower)
        {
            return appliances.FirstOrDefault(appliance => appliance.PowerConsumption >= minPower
            && appliance.PowerConsumption <= maxPower);
        }

        public static ElectricalDevice[] PowerArrangement(this ElectricalDevice[] appliances)
        {
            return appliances.OrderBy(appliance => appliance.PowerConsumption).ToArray();
        }

        public static void DisplayWhiteDevices(this ElectricalDevice[] appliances)
        {
            var whiteDevices = appliances.Where(appliance => appliance.Color == "White");
            if (whiteDevices.Any())
            {
                Console.WriteLine("White appliances are:");
                foreach (var device in whiteDevices)
                {
                    Console.WriteLine($"Appliance's name: {device.Name}, Color: {device.Color}");
                }
            }
            else
            {
                Console.WriteLine("No white appliances found.");
            }
        }
    }
}
