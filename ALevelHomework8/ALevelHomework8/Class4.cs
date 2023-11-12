using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var broccoli = new Broccoli("Green");
        var tomatoes = new Tomatoes("Red");
        var cucumbers = new Cucumbers("Green");
        var pumpkin = new Pumpkin("Orange");
        var potatoes = new Potatoes("Brown");


        var components = new Vegetables[] { broccoli, tomatoes, cucumbers, pumpkin, potatoes };
        var salad = new Salad(components);

        salad.VegetablesDisplay();

        var totalCalories = salad.CaloriesAmount();
        Console.WriteLine();
        Console.WriteLine($"Total amount of calories in salad: {totalCalories}");

        salad.SumCalories();
        Console.WriteLine();
        salad.VegetablesDisplay();


        Console.WriteLine();
        Console.WriteLine("Green vegetables in salad:");
        var greenVegetables = salad.GreenVegetables(vegetables => vegetables.Color == "Green");
        foreach (var vegetables in greenVegetables)
        {
            Console.WriteLine(vegetables);
        }







        salad.SumCalories();
        Console.WriteLine();
        salad.VegetablesColors();


    }
}

