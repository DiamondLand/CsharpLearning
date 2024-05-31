/*
 * Дан целочисленный массив из 30 элементов.
 * Элементы массива могут принимать произвольные целые значения. 
 * Опишите на русском языке или на одном из языков программирования алго-ритм,
 * который находит и выводит сумму наибольшей по длине возрастающей последователь-ности 
 * подряд идущих элементов. Если таких последовательностей несколько, можно вывести любую из них.
 * Исходные данные объявлены так, как показано ниже.
*/

int[] array = new int[30];
var random = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(1, 100);
}

List<int> arr1 = new List<int>();
int sum=-1;
Boolean flag = false;

for (int i=0; i<array.Length; i++)
{
    if (flag == false)
    {
        flag = true;
        arr1.Add(array[i]);
    }
    else
    {
        if (arr1[^1] < array[i])
        {
            arr1.Add(array[i]);
        }
        else
        {  
            if (sum < arr1.Sum())
            {
                sum = arr1.Sum();
            }
            arr1.Clear();
            arr1.Add(array[i]);
        }
    }
}
Console.WriteLine(sum);
List<int> main = new List<int>();
for (int i=0; i<array.Length; i++)
{
    if (main.Sum() == sum)
    {
        Console.WriteLine(String.Join(',', main));
        break;
    } else
    {
        if (main.Count() == 0)
        {
            main.Add(array[i]);
        } else
        {
            if (main[^1] < array[i])
            {
                main.Add(array[i]);
            } else
            {
                main.Clear();
                main.Add(array[i]);
            }
        }
    }
}