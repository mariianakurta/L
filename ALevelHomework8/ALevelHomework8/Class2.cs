using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vegetables : ISalad
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public string Color { get; set; }

    public Vegetables(string name, int calories, string color)
    {
        Name = name;
        Calories = calories;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Name} ({Calories} calories, Color: {Color})";
    }
}
