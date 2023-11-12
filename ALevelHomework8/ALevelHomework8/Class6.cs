using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pumpkin : Vegetables
{
    const string pumpName = "Pumpkin";
    const int pumpCalories = 120;

    public Pumpkin(string color) : base(pumpName, pumpCalories, color)
    {

    }
}
