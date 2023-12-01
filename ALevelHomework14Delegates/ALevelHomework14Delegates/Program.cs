using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ALevelHomework14Delegates;


public class Program
{
    public static void Main()
    {
        Counter counter = new Counter();

        counter.CalsulationsResult += FirstExecution;
        counter.CalsulationsResult += SecondExecution;

        counter.Count(72, 23, (x, y) => x + y);

        counter.CalsulationsResult -= FirstExecution;

        counter.Count(11, 424, (x, y) => x * y);
    }

    static void FirstExecution(object reference, MyEventArgs eventArgs)
    {
        Console.WriteLine($"Case 1: {eventArgs.EventData}");
    }

    static void SecondExecution(object reference, MyEventArgs eventArgs)
    {
        Console.WriteLine($"Case 2: {eventArgs.EventData}");
    }
}