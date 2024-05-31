string S1, S2;
S1 = Console.ReadLine();
S2 = Console.ReadLine();
int n1 = S1.Length;
int n2 = S2.Length;

char[] chars1 = S1.ToCharArray();
char[] chars2 = S2.ToCharArray();

List<string> unique = new List<string>();

double get_count(char[] chars, string s)
{
    double count = 0;
    for (int i = 0; i < chars.Length; i++)
    {
        if (chars[i].ToString() == s)
        {
            count++;
        }
    }
    return count;
}

List<string> index = new List<string>();

for (int i = 0; i < n1; i++)
{
    if (!unique.Contains(chars1[i].ToString()))
    {
        unique.Add(chars1[i].ToString());
        double count1, count2;
        count1 = get_count(chars1, chars1[i].ToString());
        count2 = get_count(chars2, chars1[i].ToString());
        double res;
        res = (count1 * count2) / (n1 * n2);
        index.Add(res.ToString());
    }
    
}

Console.WriteLine(String.Join('\n', index));
double sum=0;
for (int i=0; i<index.Count; i++)
{
    sum += Double.Parse(index[i]);
}
Console.WriteLine($"Sum: {sum}");