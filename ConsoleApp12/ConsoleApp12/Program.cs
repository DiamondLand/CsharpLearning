/*
 * На вход программе подается последовательность символов,
 * среди которых могут быть и цифры, заканчивающаяся точкой.
 * Требуется написать программу, которая составляет и выводит 
 * мини-мальное число из тех цифр, которые не встречаются во входных данных.
 * Ноль не используется. Если во входных данных встречаются все цифры от 1 до 9,
 * то следует вывести «0». Например, ес-ли исходная последовательность была такая:
1A734B39. 
то результат должен быть следующий:
2568
 */

string input = Console.ReadLine();
string res = "";
if (!(input == null))
{
    string numbers = "";
    string[] nums = new string[9] {"1","2","3", "4", "5", "6", "7", "8", "9"};
    for (int i = 0; i < input.Length; i++)
    {
        if (nums.Contains(input[i].ToString()))
        {
            numbers += input[i];
        }
    }
    for (int i = 0;i < nums.Length; i++) 
    {
        bool flag = false;

        for (int j = 0; j<numbers.Length; j++)
        {
            if (nums[i] == numbers[j].ToString())
            {
                flag = true;
            }
        }
        if (!flag)
        {
            res += nums[i].ToString();
        }
    }
}
if (res == "0")
{
    Console.WriteLine("0");
} else
{
    Console.WriteLine(res);
}