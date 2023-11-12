using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Broccoli : Vegetables
{
    const string brocName = "Broccoli";
    const int brocCalories = 20;

    public Broccoli(string color) : base(brocName, brocCalories, color)
    {

    }
}


