using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your text ending with a period:");
        string userInput = Console.ReadLine();

        string longestStatement = LongestStatement(userInput);
        Console.WriteLine($"The longest sentence: {longestStatement}");

        string shortestStatement = ShortestStatement(userInput);
        string reversedStatement = ReverseString(shortestStatement);
        Console.WriteLine($"The shortest sentence upside down: {reversedStatement}");
    }

    static string LongestStatement(string text)
    {
        string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        string longestStatement = "";
        int maxLength = 0;

        foreach (string sentence in sentences)
        {
            string longSentence = sentence.Trim();
            if (longSentence.Length > maxLength)
            {
                maxLength = longSentence.Length;
                longestStatement = longSentence;
            }
        }

        return longestStatement;
    }

    static string ShortestStatement(string text)
    {
        string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        string shortestStatement = sentences[0];

        foreach (string sentence in sentences)
        {
            string shortSentence = sentence.Trim();
            if (shortSentence.Length < shortestStatement.Length)
            {
                shortestStatement = shortSentence;
            }
        }

        return shortestStatement;
    }

    static string ReverseString(string input)
    {
        char[] myArray = input.ToCharArray();
        Array.Reverse(myArray);
        return new string(myArray);
    }
}