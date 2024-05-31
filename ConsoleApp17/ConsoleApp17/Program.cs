int n = Int32.Parse(Console.ReadLine());

int[] res = new int[n];

for (int i = 0; i < n; i++)
{
    res[i] = Int32.Parse(Console.ReadLine());
}

int min1 = 30001;
int min2 = 0;

for (int i = 0;i < n; i++)
{
    for (int j =1; j < n; j++)
    {
        if (res[i] + res[j] < min1)
        {
            if ((res[i]+ res[j]) % 2 == 0)
            {
                min1 = res[i] + res[j];
            }
        }
    }
}
if (min1 == 30001)
{
    Array.Sort(res);
    Console.WriteLine(res[0] + res[1]);
}
else
{
    Console.WriteLine(min1);
}

