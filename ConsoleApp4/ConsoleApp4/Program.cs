int[] array = new int[30];
var rand = new Random();

for (int i = 0; i < array.Length; i++)
{
    array[i] = rand.Next(1, 1000);
}



int[] maxs = new int[30];
int sum = 0;
for (int i = 0; i < array.Length; i++)
{
    if (sum == 0)
    {
        sum += array[i];
    } else
    {
        if (array[i] > array[i - 1])
        {
            sum += array[i];
        } else
        {
            for (int k = 0; k < maxs.Length; k++)
            {
                if (maxs[k] == 0)
                {
                    maxs[k] = sum;
                    break;
                }

            }
            Console.WriteLine("add");
            sum = 0;
        }

    }
    Console.WriteLine(sum);
}
if (maxs.Length == 0)
{
    maxs.Append(sum);
}
Console.WriteLine(maxs.Length);
Console.WriteLine("LENGHT");
int max = maxs.Max();
int[] main_array = new int[30];
for (int i = 0; i < array.Length; i++)
{
    if (main_array.Length == 0)
    {
        main_array.Append(array[i]);
    } else
    {
        if (main_array[-1] < array[i])
        {
            main_array.Append(array[i]);
        } else
        {
            if (main_array.Sum() == max)
            {
                for (int j = 0; j<main_array.Length; j++)
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}
Console.WriteLine(max);
