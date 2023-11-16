using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelHomework10;

class Program
{
    private static void Main(string[] args)
    {
        Computer computer = new Computer("Computer", 2000, true, "Black");
        Kettle kettle = new Kettle("Kettle", 500, false, "White");
        Microwave microwave = new Microwave("Microwave", 1200, true, "White");

        ElectricalDevice[] allDevices = { computer, kettle, microwave };

        string largeSize = "Large";
        var devicesSize = allDevices.Where(appliance => appliance.GetSize() == largeSize).ToArray();

        double totalCharge = allDevices.CalculatePowerConsumption();
        Console.WriteLine($"Total power consumption of appliances: {totalCharge} electric charge");

        allDevices = allDevices.PowerArrangement();
        Console.WriteLine("Appliances sorted by power consumption:");

        foreach (var appliance in allDevices)
        {
            Console.WriteLine($"{appliance.Name} - Power: {appliance.PowerConsumption} electric charge - Size: {appliance.GetSize()}");
        }

        double minLimit = 1500;
        double maxLimit = 3000;

        var appliancesLimit = allDevices.PowerDetect(minLimit, maxLimit);

        if (appliancesLimit != null)
        {
            Console.WriteLine($"Appliances matching the power range of {minLimit} to {maxLimit} electric charge were found: {appliancesLimit.Name}");
        }
        else
        {
            Console.WriteLine($"No appliances matching the power range of {minLimit} to {maxLimit} electric charge were found");
        }

        allDevices.DisplayWhiteDevices();
    }
}