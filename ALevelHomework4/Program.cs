using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of your array: ");
        int N = int.Parse(Console.ReadLine());

        int[] numbersArray = new int[N];
        char[] lettersArray = new char[N];

        char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int i = 0; i < N; i++)
        {
            char letter = letters[i % 26];
            if ("aeidhj".Contains(letter.ToString()))
            {
                letter = char.ToUpper(letter);
            }

            numbersArray[i] = i + 1;
            lettersArray[i] = letter;
        }

        int[] evenNumbersArray = new int[N];
        int[] oddNumbersArray = new int[N];
        char[] evenLettersArray = new char[N];
        char[] oddLettersArray = new char[N];

        int evenOrder = 0;
        int oddOrder = 0;
        for (int i = 0; i < N; i++)
        {
            if (numbersArray[i] % 2 == 0)
            {
                evenNumbersArray[evenOrder] = numbersArray[i];
                evenLettersArray[evenOrder] = lettersArray[i];
                evenOrder++;
            }
            else
            {
                oddNumbersArray[oddOrder] = numbersArray[i];
                oddLettersArray[oddOrder] = lettersArray[i];
                oddOrder++;
            }
        }

        Console.WriteLine("Array of even numbers: " + ArrayDisplay(evenNumbersArray, evenOrder));
        Console.WriteLine("Array of odd numbers: " + ArrayDisplay(oddNumbersArray, oddOrder));
        Console.WriteLine("Array of letters for even numbers: " + new string(evenLettersArray, 0, evenOrder));
        Console.WriteLine("Array of letters for odd numbers: " + new string(oddLettersArray, 0, oddOrder));

        int evenUppercaseSign = new string(evenLettersArray, 0, evenOrder).Count(char.IsUpper);
        int oddUppercaseSign = new string(oddLettersArray, 0, oddOrder).Count(char.IsUpper);

        if (evenUppercaseSign > oddUppercaseSign)
        {
            Console.WriteLine("An array of even numbers contains more capital letters.");
        }
        else if (oddUppercaseSign > evenUppercaseSign)
        {
            Console.WriteLine("An array of odd numbers contains more capital letters.");
        }
        else
        {
            Console.WriteLine("Both arrays contain the same number of capital letters.");
        }
    }

    static string ArrayDisplay(int[] myArray, int myLength)
    {
        string result = "";
        for (int i = 0; i < myLength; i++)
        {
            result += myArray[i];
            if (i < myLength - 1)
                result += ", ";
        }
        return result;
    }
}
