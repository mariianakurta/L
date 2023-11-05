using System;

class Program
{
    static void Main()
    {
        Sweets[] sweets = {
            new Candies("Chocolate", "Round", "Mint"),
            new Candies("Pastries", "Triangle", "Cherry"),
            new Cookies("Cakes", "Square", "Dark"),
            new Cookies("Biscuits", "Hexagon", "Milk")
        };

        Gift newYearsGift = new Gift(sweets);

        newYearsGift.GiftExistance();

        newYearsGift.CandiesShape();
        Console.WriteLine("Gift contains the following shapes::");
        Console.WriteLine();
        newYearsGift.GiftExistance();

        string candyShape = "Round";
        Sweets foundCandies = newYearsGift.CandiesLocation(candyShape);

        if (foundCandies != null)
        {
            Console.WriteLine($"Gift contains candies of the following shape: '{candyShape}': {foundCandies.Name}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"No candies found with shape '{candyShape}'.");
            Console.WriteLine();
        }
    }
}
