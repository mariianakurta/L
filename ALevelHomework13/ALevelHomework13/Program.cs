using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelHomework13;

public class Program
{
    public static void DisplayResult(bool result)
    {
        Console.WriteLine($"Result: {result}");
    }

    public static void DisplayListResult(List<bool> listsResult)
    {
        Console.WriteLine("Results List:");
        foreach (var result in listsResult)
        {
            Console.WriteLine($" - {result}");
        }
    }

    public static void Main()
    {
        FirstClass firstClass = new FirstClass();
        SecondClass secondClass = new SecondClass();

        firstClass.Show = DisplayResult;

        SecondClass.DelegatesResult delegatesFirstResult = secondClass.Calc(firstClass.Show, 1, 2);
        SecondClass.DelegatesResult delegatesSecondResult = secondClass.Calc(firstClass.Show, 3, 4);

        bool displayingFirstResult = delegatesFirstResult(2);
        bool displayingSecondResult = delegatesSecondResult(4);

        firstClass.Show(displayingFirstResult);
        firstClass.Show(displayingSecondResult);

        DisplayListResult(secondClass.ListResult);
    }
}