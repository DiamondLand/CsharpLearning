int[] array;
array = new int[100];
var rnd = new Random();
int sum;
int maxSum = -1;
int maxNum = -1;
var num = 0;

for (int i = 0; i < array.Length; i++)
{
    array[i] = rnd.Next(0, 10000);
}
// сделали массив и заполнили его


string To8Sys(int number)
{
    string s = string.Empty;
    int num = number;
    for (; num > 0;)
    {
        var tmp = num % 8;
        s = (tmp == 0 ? "0" : tmp.ToString()) + s;
        num /= 8;
    }
    return s;
}

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(i);
    sum = 0;
    num = array[i];
    while (num != 0)
    {
        sum += num % 10;
        num /= 10;
    }
    if (sum > maxSum)
    {
        maxSum = sum;
        maxNum = array[i];
    }
}
Console.WriteLine($"max sum = {maxSum}");
Console.WriteLine($"max num = {maxNum}");

for (int i =0; i < array.Length;i++)
{
    if (To8Sys(array[i]).Length < 3)
    {
        array[i] += maxNum;
    }
}

for (int i = 0;i < array.Length;i++)
{
    Console.WriteLine(array[i]);
}