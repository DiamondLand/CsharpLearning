using System;

class Program
{
    // Словарь для хранения значений F(n)
    static System.Collections.Generic.Dictionary<int, long> memo = new System.Collections.Generic.Dictionary<int, long>();
    // Без него F(50) может вызывать множество рекурсивных вызовов и ошибочка будет... Проверено))

    // Функция для вычисления F(n)
    static long F(int n)
    {
        if (memo.ContainsKey(n))
            return memo[n];

        long result;
        if (n == 0)
        {
            result = 1;
        }
        else if (n > 0)
        {
            result = 2 * F(1 - n) + 3 * F(n - 1) + 2;
        }
        else
        {
            result = -F(-n);
        }

        memo[n] = result;
        return result;
    }

    // Функция для подсчета суммы цифр числа
    static int SumOfDigits(long number)
    {
        int sum = 0;
        while (number != 0)
        {
            sum += (int)(number % 10);
            number /= 10;
        }
        return sum;
    }

    static void Main()
    {
        long result = F(50);

        // Вычисляем сумму цифр значения F(50)
        int digitSum = SumOfDigits(result);

        Console.WriteLine("F(50) = " + result);
        Console.WriteLine("Сумма цифр F(50) = " + digitSum);
        Console.ReadLine();
    }
}
