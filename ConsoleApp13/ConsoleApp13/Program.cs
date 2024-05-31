/*
 * Имеется список учеников разных школ,
 * сдававших экзамен по информатике, с указанием их фа-милии, имени,
 * школы и набранного балла. Напишите эффективную по времени работы и
 * по ис-пользуемой памяти программу , которая будет определять номера школ, в которых средний балл выше,
 * чем средний по району. Если такая школа одна, нужно вывести и средний балл (в следу-ющей строчке).
 * Известно, что информатику сдавали не менее 5 учеников. Кроме того, школ с некоторыми номерами не существует.
На вход программе в первой строке подается количество учеников списке N. В каждой из после-дующих
N строк находится информация в следующем формате:
<Фамилия> <Имя> <Школа> <Балл>
где <Фамилия> – строка, состоящая не более, чем из 20 символов без пробелов, <Имя> – строка,
состоящая не более, чем из 20 символов без пробелов, <Школа> – целое число от 1 до 99, <Балл> – целое число от 1 до 100.
Пример входной строки:
Иванов Сергей 50 87
Пример выходных данных, когда найдено три школы:
50 87 23
Пример вывода в том случае, когда найдена одна школа:
18
Средний балл = 85
 */

double meanScore = 0;
int allScore = 0;
List<List<string>> users = new List<List<string>>();

int n = Int32.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    string school = input.Split(' ', StringSplitOptions.TrimEntries)[2];
    string score = input.Split(' ', StringSplitOptions.TrimEntries)[3];
    users.Add(new List<string>() { school, score });
}

for  (int i = 0;i < users.Count; i++)
{
    allScore += Int32.Parse(users[i][1]);
}
meanScore = allScore / users.Count;

Console.WriteLine($"Mean: {meanScore}");

List<List<string>> schools = new List<List<string>>();

double get_score(string num, List<List<string>> sc)
{   
    int score = 0;
    int count = 0;
    for (int i=0; i<sc.Count; i++)
    {
        if (sc[i][0] == num)
        {
            count++;
            score += Int32.Parse(sc[i][1]);
        }
    }
    if (count != 0)
    {
        return score / count;
    }
    return -1;
}
List<string> writen = new List<string>();
for (int j=0; j < users.Count; j++)
{
    if (get_score(users[j][0], users) > meanScore)
    {
        if (!(writen.Contains(users[j][0]))) {
            Console.WriteLine(users[j][0]);
            writen.Add(users[j][0]);
        }
    }
}