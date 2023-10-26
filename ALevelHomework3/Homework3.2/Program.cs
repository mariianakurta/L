using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number with a virgule: ");
        double number;

        if (double.TryParse(Console.ReadLine(), out number))
        {
            if (number == 0)
            {
                Console.WriteLine("You entered a zero number.");
            }
            else if (number % 1 == 0)
            {
                Console.WriteLine("This number doesn't contain a virgule.");
            }
            else
            {
                switch (Math.Sign(number))
                {
                    case 1:
                        Console.WriteLine("You entered a positive number.");
                        break;
                    case -1:
                        Console.WriteLine("You entered a negative number.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("This number doesn't contain a virgule.");
        }
    }
}
