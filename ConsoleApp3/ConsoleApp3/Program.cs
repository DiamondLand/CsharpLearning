int Number = 78;
int Base = 13;
int res;
int[] systemNumbers = new int[36];

char[] systems = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZХ{|}~".ToCharArray();
for (int i = 0; i < systems.Length; i++)
{
    if (i == 36)
    {
        break;
    }
    Console.WriteLine(i);
    systemNumbers[i] = i;
}

if (Number < Base)
{
    res = Array.IndexOf(systemNumbers, Number);
    Console.WriteLine(systems[res]);
}
else
{
    int f;
    f = Array.IndexOf(systemNumbers, Number / Base);
    int s;
    s = Array.IndexOf(systemNumbers, Number % Base);
    Console.WriteLine(systems[f]);
    Console.WriteLine(systems[s]);

}

char[] sumbols = "abcdefghijklmnopqrstuvwxyz".ToCharArray();