using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите последовательность символов: ");
        string inputSequence = Console.ReadLine();

        string result = FindMinimalNumber(inputSequence);

        Console.WriteLine(result);
    }

    static string FindMinimalNumber(string inputStr)
    {
        var allDigits = "123456789".ToHashSet();
        var inputDigits = inputStr.Where(char.IsDigit).ToHashSet();
        var missingDigits = allDigits.Except(inputDigits);

        return missingDigits.Any() ? string.Join("", missingDigits.OrderBy(c => c)) : "0";
    }
}
