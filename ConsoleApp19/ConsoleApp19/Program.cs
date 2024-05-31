using System;
using System.Linq;

class Warrior
{
    public string Name { get; set; }
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value >= 0 ? value : 0; }
    }
    public int Damage { get; set; }

    public Warrior(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public int Attack(Random random)
    {
        return random.Next(0, Damage + 1);
    }

    public int ReceiveDamage
    {
        set
        {
            Health -= value;
        }
    }
}

static class Battle
{
    public static Warrior Fight(Warrior warriorA, Warrior warriorB)
    {
        Random random = new Random();

        while (warriorA.Health > 0 && warriorB.Health > 0)
        {
            int damageA = warriorA.Attack(random);
            int damageB = warriorB.Attack(random);

            warriorB.ReceiveDamage = damageA;
            warriorA.ReceiveDamage = damageB;

            Console.WriteLine($"{warriorA.Name} атакует {warriorB.Name}.");
            Console.WriteLine($"{warriorA.Name} наносит {damageA} урона, у {warriorB.Name} осталось {warriorB.Health} здоровья.");
            Console.WriteLine($"{warriorB.Name} наносит {damageB} урона, у {warriorA.Name} осталось {warriorA.Health} здоровья.");
            Console.WriteLine();
        }

        if (warriorA.Health > 0)
            return warriorA;
        else if (warriorB.Health > 0)
            return warriorB;
        else
            return null;
    }
}

class Program
{
    static string[] GenerateRandomNames(int count)
    {
        string[] names = {
            "Артур", "Игорь", "Алексей", "Иван", "Дмитрий", "Михаил",
            "Сергей", "Максим", "Павел", "Виктор", "Николай", "Андрей"
        };
        Random random = new Random();
        return names.OrderBy(x => random.Next()).Take(count).ToArray();
    }

    static ConsoleColor[] GenerateRandomColors(int count)
    {
        ConsoleColor[] colors = {
            ConsoleColor.Yellow, ConsoleColor.Cyan,
            ConsoleColor.Magenta, ConsoleColor.Red
        };
        Random random = new Random();
        return colors.OrderBy(x => random.Next()).Take(count).ToArray();
    }

    static void Main()
    {
        Random random = new Random();
        string[] randomNames = GenerateRandomNames(6);
        ConsoleColor[] randomColors = GenerateRandomColors(3);

        Warrior[] warriors = new Warrior[6];

        for (int i = 0; i < 6; i++)
        {
            warriors[i] = new Warrior(randomNames[i], random.Next(80, 120), random.Next(15, 30));
        }

        for (int i = 0; i < warriors.Length; i += 2)
        {
            Console.WriteLine($"Бой между {warriors[i].Name} и {warriors[i + 1].Name}");
            Console.ForegroundColor = randomColors[i / 2];
            Warrior winner = Battle.Fight(warriors[i], warriors[i + 1]);
            if (winner != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Победитель: {winner.Name} ({winner.Health} здоровья)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ничья!");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
