using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tomatoes : Vegetables
{

    const string tomName = "Tomatoes";
    const int tomCalories = 50;

    public Tomatoes(string color) : base(tomName, tomCalories, color)
    {

    }
}
