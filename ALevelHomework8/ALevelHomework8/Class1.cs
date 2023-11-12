using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cucumbers : Vegetables
{
    const string cucumbName = "Cucumbers";
    const int cucumbCalories = 30;

    public Cucumbers (string color) : base(cucumbName, cucumbCalories, color)
    {

    }
}