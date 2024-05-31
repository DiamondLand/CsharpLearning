/* На вход программе подается набор символов.
 * Напишите программу, которая сначала будет
 * определять, есть ли в этом наборе символы,
 * соответствующие десятичным цифрам.
 * Если такие символы есть, то можно ли переставить их так,
 * чтобы полученное число было симметричным 
 * (читалось одинаково как слева направо, так и справа налево).
 * Ведущих нулей в числе быть не должно, исключение – число 0,
 * запись которого содержит ровно один ноль. Если требуемое число 
 * составить невозмож-но, то программа должна вывести на экран слово “NO”.
 * А если возможно, то в первой строке следует вывести слово “YES”, 
 * а во второй – искомое симметричное число. Если таких чисел не-сколько, 
 * то программа должна выводить максимальное из них. Например, пусть на вход
 * пода-ются следующие символы: 
Do not 911 to 09 do.
В данном случае программа должна вывести
YES
91019
*/

using System.Security.Cryptography.X509Certificates;

string str;
str = Console.ReadLine();
char[] numList = "0123456789".ToCharArray();
List<string> list = new List<string>();

bool ckeck_count(List<string> Array, string number)
{
    int count = 0;
    for (int i = 0; i<Array.Count; i++)
    {
        if (Array[i] == number)
        {
            count++;
        }
    }
    if (count % 2 ==0) { return true; }
    return false;
}

for (int i = 0; i<str.Length; i++)
{
    if (numList.Contains(str[i]))
    {
        list.Add(str[i].ToString());
    }
}
if (list.Count == 0)
{
    Console.WriteLine("NO!");
} else
{
    if (list.Count == 1)
    {
        Console.WriteLine("YES!");
        Console.WriteLine(list[0]);
    } else
    {
        if (list.Count == 2)
        {
            if (list[0] == list[1])
            {
                Console.WriteLine("Yes!");
                Console.WriteLine(String.Join ("", list));
            } else
            {
                Console.WriteLine("No!");
            }
        } else
        {
            
            bool flag = false;
            string fs = "null";
            for (int i = 0; i<list.Count;i++)
            {
                if (ckeck_count(list, list[i]) == false)
                {
                    if (flag == false)
                    {
                        flag = true;
                        fs = list[i].ToString();
                    }
                    else
                    {
                        Console.WriteLine("NO!");
                        System.Environment.Exit(-1);
                    }
                }
            }
            List<string> list2 = new List<string>();
            if (fs != "null")
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i] == fs)
                    {
                        list[i] = "None";
                        break;
                    }
                }
            }
            for (int i = 0;i < list.Count; i++)
            {
                if (list[i] != "None")
                {
                    if (!list2.Contains(list[i]))
                    {
                        list2.Add(list[i]);
                    }
                }
            }
            if (fs != "null")
            {
                string answer = String.Join("", list2);
                answer += fs;
                list2.Reverse();
                answer += String.Join("", list2);
                Console.WriteLine("Yes!");
                Console.WriteLine(answer);

            }
            else
            {
                string answer = String.Join("", list2);
                list2.Reverse();
                answer += String.Join("", list2);
                Console.WriteLine("Yes!");
                Console.WriteLine(answer);
            }


        }
    }
}