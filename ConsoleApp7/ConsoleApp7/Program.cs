/*Дан массив, содержащий 2018 положительных целых чисел, не превышающих 30 000.
 * Необхо-димо найти в этом массиве количество элементов, которые кратны 3,
 * а их десятичная запись за-канчивается цифрой 1, и заменить каждый из таких
 * элементов на это количество. Напишите про-грамму для решения этой задачи.
 * В качестве результата программа должна вывести изменён-ный массив, по одному элементу в строке. Например, для исходного массива из 5 элементов 
15 71 21 111 41 
программа должна вывести (по одному числу в строке) числа 
15 71 2 2 41. */


int[] array = new int[2018];
var random = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(0, 30000);
}

bool checknumber(int num)
{
    if (num % 3 == 0)
    {
        if (num.ToString()[^1] == '1')
        {
            Console.WriteLine(num);
            return true;
        }
        return false;
    }
    return false;
}

int count = 0;
for (int i = 0; i< array.Length; i++)
{
    if (checknumber(array[i]))
    {
        count++;
    }
}
Console.WriteLine(count);
for (int i = 0;i < array.Length; i++)
{
    if (!checknumber(array[i]))
    {
        array[i] = count;
    }
}

Console.WriteLine(String.Join(',', array));