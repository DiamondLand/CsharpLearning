/*
 * На вход программы подаются произвольные алфавитно-цифровые символы.
 * Требуется написать программу, которая будет печатать последовательность 
 * строчных английских букв ('a' 'b'... 'z') из входной последовательности и 
 * частот их повторения. Печать должна происходить в алфавитном порядке. 
 * Например, пусть на вход подаются следующие символы:
fhb5kbfыshfm.
В этом случае программа должна вывести
b2
f3
h2
kl
ml
s1
 */

int get_count(string str, char sym)
{
    int count = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == sym)
        {
            count++;
        }
    }
    return count;
}

string str = Console.ReadLine();
if (str != null)
{
    char[] sumbols = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    for (int i = 0; i < sumbols.Length; i++)
    {
        int count = get_count(str, sumbols[i]);
        if (count > 0)
        {
            Console.WriteLine(sumbols[i] +" " + count);
        }
    }
}