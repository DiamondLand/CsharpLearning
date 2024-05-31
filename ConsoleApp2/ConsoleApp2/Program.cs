int[] array;
array = new int[30];
var rnd = new Random();

for (int i = 0; i < array.Length; i++)
{
    array[i] = rnd.Next(0, 10000);
}

int sum=0;
for (int i=0; i<array.Length; i++)
{
    sum += array[i];
}
double median = sum / array.Length;

int max = 0;

for (int i=0; i < array.Length; i++)
{
    if (median - Math.Abs(array[i]) < max)
    {
        max = i;
    }
}


Console.WriteLine($"Median: {median}");
Console.WriteLine($"Element: {array[max]}");
Console.WriteLine($"Index: {max}");
Console.WriteLine("Array:");
for (int i = 0; i< array.Length; i++)
{
    Console.WriteLine(array[i]);
}