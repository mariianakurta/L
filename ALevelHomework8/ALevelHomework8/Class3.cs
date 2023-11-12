using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Salad
{
    Vegetables[] components;



    public Salad(Vegetables[] vegetables)
    {
        components = vegetables;
    }

    public int CaloriesAmount()
    {
        var amtCalories = 0;

        foreach (var vegetables in components)
        {
            amtCalories += vegetables.Calories;
        }

        return amtCalories;


    }
    public void VegetablesColors()
    {
        Console.WriteLine("Salad components sorted by colors:");
        var sortedComponents = components.OrderBy(vegetables => vegetables.Color);

        foreach (var vegetables in sortedComponents)
        {
            Console.WriteLine($"{vegetables.Name} ({vegetables.Calories} calories, Color: {vegetables.Color})");
        }
    }






    public Vegetables[] GreenVegetables(Func<Vegetables, bool> value)
    {
        return components.Where(value).ToArray();
    }

    public void VegetablesDisplay()
    {
        Console.WriteLine("Salad consists of:");
        foreach (var vegetables in components)
        {
            Console.WriteLine(vegetables);
        }
    }


    public void SumCalories()
    {
        Array.Sort(components, (firstVeg, secondVeg) => firstVeg.Calories.CompareTo(secondVeg.Calories));
    }


}
