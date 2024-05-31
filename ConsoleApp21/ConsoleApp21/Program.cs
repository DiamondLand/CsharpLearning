using System;
using System.Linq;

class Program
{
    static bool IsVowel(char c)
    {
        return "aeiou".Contains(c);
    }

    static bool IsGoodSubstring(string stroka, int k)
    {
        for (int i = 0; i < stroka.Length - k + 1; i++)
        {
            int consecutiveVowels = 0;
            int consecutiveConsonants = 0;

            for (int j = 0; j < k; j++)
            {
                char currentChar = stroka[i + j];
                if (IsVowel(currentChar))
                {
                    consecutiveVowels++;
                    consecutiveConsonants = 0;
                }
                else
                {
                    consecutiveConsonants++;
                    consecutiveVowels = 0;
                }

                if (consecutiveVowels >= k || consecutiveConsonants >= k)
                {
                    return false;
                }
            }
        }

        return true;
    }

    static int FindLongestGoodSubstring(string stroka, int k)
    {
        int maxGoodLength = 0;

        for (int i = 0; i < stroka.Length; i++)
        {
            for (int j = i + 1; j <= stroka.Length; j++)
            {
                string substring = stroka.Substring(i, j - i);
                if (IsGoodSubstring(substring, k) && substring.Length > maxGoodLength)
                {
                    maxGoodLength = substring.Length;
                }
            }
        }

        return maxGoodLength;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string stroka = Console.ReadLine();

        Console.WriteLine("\nВведите k:");
        int k = int.Parse(Console.ReadLine());

        int result = FindLongestGoodSubstring(stroka, k);
        Console.WriteLine($"\nДлинна: {result}");
    }
}
