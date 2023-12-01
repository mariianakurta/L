using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelHomework14LINQ;


public class Program
{
    public static void Main(string[] args)
    {
        List<string> allNumbers = new List<string>
        {
            "+380189103243",
            "+380832439176",
            "+380431673224",
            "+380943723443",
            "+380943723476",
            "0943738428"
        };


        // FIRST OR DEFAULT
        var first = allNumbers.First();
        Console.WriteLine($"First: {first}");

        // FIRST
        var firstOrDefault = allNumbers.FirstOrDefault();
        Console.WriteLine($"First or default: {firstOrDefault}");

        // WHERE
        var where = allNumbers.Where(number => number.Contains("723"));
        Console.WriteLine("Where:");
        foreach (var number in where)
        {
            Console.WriteLine(number);
        }

        // SELECT
        var select = allNumbers.Select(number =>
        {
            if (number.StartsWith("0"))
            {
                return number;
            }
            else
            {
                return number.Replace("+", "");
            }
        });

        Console.WriteLine("Select:");
        foreach (var number in select)
        {
            Console.WriteLine(number);
        }


        // COUNT
        var count = allNumbers.Count();
        Console.WriteLine($"Number of contacts: {count}");

        // LAST
        var last = allNumbers.Last();
        Console.WriteLine($"Last number: {last}");

        // LAST OR DEFAULT
        var lastOrDefault = allNumbers.LastOrDefault();
        Console.WriteLine($"Last or default: {lastOrDefault}");

        // ANY
        bool any = allNumbers.Any();
        Console.WriteLine($"Any? {any}");

        // ALL
        bool allPlus = allNumbers.All(number => number.StartsWith("+"));
        Console.WriteLine($"All (starting with '+'): {allPlus}");


        // SKIP
        var skip = allNumbers.Skip(2);
        Console.WriteLine("Skip:");
        foreach (var number in skip)
        {
            Console.WriteLine(number);
        }

        int totalLength = allNumbers.Sum(number => number.Length);
        Console.WriteLine($"Sum: {totalLength}");
    }
}