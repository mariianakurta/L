using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Potatoes : Vegetables
{
    const string potatName = "Potatoes";
    const int potatCalories = 100;

    public Potatoes(string color) : base(potatName, potatCalories, color)
    {

    }
}
