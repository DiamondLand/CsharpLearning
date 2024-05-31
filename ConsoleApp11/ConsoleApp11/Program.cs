/*
 * На вход программе подаются сведения о студентах некоторого вуза.
 * В первой строке сообщает-ся количество студентов N (не более 100).
 * Каждая из следующих строк имеет формат: 
<фамилия> <имя> <курс> <стипендия>
Все данные в строке разделяются одним пробелом.
Фамилия состоит не более, чем из 20 симво-лов,
имя – не более, чем из 15. Курс – целое число от 1 до 5,
стипендия – целое число. Требуется написать программу,
которая будет выводить фамилии и имена всех студентов,
имеющих мак-симальные стипендии на каждом курсе.
Пример входных строк:
25
Федорова Ирина 5 4500
Семенов Илья 3 2800
Пример выходных строк:
Курс 1
Петров Иван
Иванов Сидор
Курс 3
Смирнов Максим
 */

List<List<string>> array = new List<List<string>>();
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i < n; i++)
{
    string str = Console.ReadLine();
    string name = str.Split(' ', StringSplitOptions.TrimEntries)[0];
    string last_name = str.Split(' ', StringSplitOptions.TrimEntries)[1];
    string course = str.Split(' ', StringSplitOptions.TrimEntries)[2];
    string money = str.Split(' ', StringSplitOptions.TrimEntries)[3];
    array.Add(new List<string> { name, last_name, course, money });
}

for (int i=0; i <6; i++)
{
    int maxMoney = 0;
    for (int j = 0; j<array.Count; j++)
    {
        if (array[j][2] == i.ToString())
        {
            if (Convert.ToInt32(array[j][3]) > maxMoney)
            {
                maxMoney = Convert.ToInt32(array[j][3]);
            }
        }
    }
    Console.WriteLine($"Course: {i}");
    for (int j=0; j < array.Count; j++)
    {
        if (array[j][2] == i.ToString())
        {
            if (Convert.ToInt32(array[j][3]) == maxMoney){
                Console.WriteLine(array[j][0]+" "+ array[j][1]);
            }
        }
    }
}
