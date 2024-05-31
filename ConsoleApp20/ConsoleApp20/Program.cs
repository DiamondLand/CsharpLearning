using System;
using System.Collections.Generic;

abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract string FormDescription();
}

class Fish : Animal
{
    public bool IsDeepwater { get; set; }
    public bool IsPredator { get; set; }
    public Fish(string name, bool isDeepwater, bool isPredator) : base(name)
    {
        IsDeepwater = isDeepwater;
        IsPredator = isPredator;
    }

    public override string FormDescription()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        var description = $"Класс: {(IsDeepwater ? "глубоководная" : "не глубоководная")} рыба\nНазвание: {Name}\nХищник: {(IsPredator ? "да" : "нет")}";
        return description;
    }
}

class Bird : Animal
{
    public int FlightSpeed { get; set; }

    public Bird(string name, int flightSpeed) : base(name)
    {
        FlightSpeed = flightSpeed;
    }

    public override string FormDescription()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        var description = $"\nКласс: птица\nНазвание: {Name}\nСкорость полета: {FlightSpeed}";
        return description;
    }
}

class Beast : Animal
{
    public string Habitat { get; set; }

    public Beast(string name, string habitat) : base(name)
    {
        Habitat = habitat;
    }

    public override string FormDescription()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        var description = $"\nКласс: зверь\nНазвание: {Name}\nСреда обитания: {Habitat}";
        return description;
    }
}

class Zoo : Animal
{
    public List<Enclosure> Enclosures { get; set; }

    public Zoo(string name) : base(name)
    {
        Enclosures = new List<Enclosure>();
    }

    public void AddEnclosure(Enclosure enclosure)
    {
        Enclosures.Add(enclosure);
    }

    public override string FormDescription()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"Зоопарк: {Name}";
    }
}

class Enclosure
{
    public int Number { get; set; }
    public int MaxAnimalCount { get; set; }
    public List<Animal> Animals { get; set; }

    public Enclosure(int number, int maxAnimalCount)
    {
        Number = number;
        MaxAnimalCount = maxAnimalCount;
        Animals = new List<Animal>();
    }

    public void AddAnimal(Animal animal)
    {
        // Проверка, что в вольере могут содержаться только животные одного класса
        if (Animals.Count > 0 && animal.GetType() != Animals[0].GetType())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: В клетке могут содержаться только животные одного класса.");
            Console.ResetColor();
            return;
        }

        // Проверка, что если в вольере есть хищная рыба, то добавление нехищной рыбы невозможно и наоборот
        if (Animals.Count > 0)
        {
            if (Animals[0] is Fish firstFish && animal is Fish newFish)
            {
                if (firstFish.IsPredator != newFish.IsPredator)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: Нельзя добавить хищную рыбу и нехищную рыбу в один вольер.");
                    Console.ResetColor();
                    return;
                }
            }
        }

        // Проверка на максимальное количество животных
        if (Animals.Count < MaxAnimalCount)
        {
            Animals.Add(animal);
            Console.WriteLine($"Животное {animal.Name} добавлено в клетку {Number}.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: Клетка полна. Нельзя добавить больше животных.");
            Console.ResetColor();
        }
    }

    public string FormDescription()
    {
        return $"Вольер {Number}\nМаксимальное количество животных: {MaxAnimalCount}\nТекущее количество животных: {Animals.Count}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите название зоопарка: ");
            string zooName = Console.ReadLine();

            Zoo myZoo = new Zoo(zooName);

            Console.Write("Введите количество вольеров: ");
            if (int.TryParse(Console.ReadLine(), out int enclosureCount))
            {
                for (int i = 1; i <= enclosureCount; i++)
                {
                    Console.Write($"Введите максимальное количество животных в вольере {i}: ");
                    if (int.TryParse(Console.ReadLine(), out int maxAnimalCount))
                    {
                        Enclosure enclosure = new Enclosure(i, maxAnimalCount);
                        myZoo.AddEnclosure(enclosure);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: Некорректное количество животных.");
                        Console.ResetColor();
                        i--; // Перекидываем на предыдущую ступень
                    }
                }

                while (true)
                {
                    Console.WriteLine("Выберите тип животного для добавления в вольер:");
                    Console.WriteLine("1. Рыба");
                    Console.WriteLine("2. Птица");
                    Console.WriteLine("3. Зверь");
                    Console.WriteLine("4. Завершить");
                    Console.Write("Ваш выбор: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 4)
                        {
                            break;
                        }

                        if (choice >= 1 && choice <= 3)
                        {
                            Console.Write("Введите животное: ");
                            string animalName = Console.ReadLine();

                            switch (choice)
                            {
                                case 1: // Рыба
                                    Console.Write("Это глубоководная рыба (да/нет)? ");
                                    bool isDeepwater = Console.ReadLine().Equals("да", StringComparison.OrdinalIgnoreCase);
                                    Console.Write("Это хищник (да/нет)? ");
                                    bool isPredator = Console.ReadLine().Equals("да", StringComparison.OrdinalIgnoreCase);
                                    Fish fish = new Fish(animalName, isDeepwater, isPredator);
                                    AddAnimalToEnclosure(myZoo, fish);
                                    break;

                                case 2: // Птица
                                    Console.Write("Введите скорость полета: ");
                                    if (int.TryParse(Console.ReadLine(), out int flightSpeed))
                                    {
                                        Bird bird = new Bird(animalName, flightSpeed);
                                        AddAnimalToEnclosure(myZoo, bird);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка: Некорректная скорость полета.");
                                        Console.ResetColor();
                                    }
                                    break;

                                case 3: // Зверь
                                    Console.Write("Введите среду обитания: ");
                                    string habitat = Console.ReadLine();
                                    Beast beast = new Beast(animalName, habitat);
                                    AddAnimalToEnclosure(myZoo, beast);
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: Некорректный выбор.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: Некорректный выбор.");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{myZoo.FormDescription()}\n");

                foreach (Enclosure enclosure in myZoo.Enclosures)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{enclosure.FormDescription()}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (Animal animal in enclosure.Animals)
                    {
                        Console.WriteLine(animal.FormDescription());
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Некорректное количество вольеров.");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void AddAnimalToEnclosure(Zoo zoo, Animal animal)
    {
        Console.WriteLine("Выберите вольер для добавления животного:");
        for (int i = 0; i < zoo.Enclosures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Вольер {zoo.Enclosures[i].Number}");
        }
        Console.Write("Ваш выбор: ");

        if (int.TryParse(Console.ReadLine(), out int enclosureChoice))
        {
            if (enclosureChoice >= 1 && enclosureChoice <= zoo.Enclosures.Count)
            {
                Enclosure selectedEnclosure = zoo.Enclosures[enclosureChoice - 1];
                selectedEnclosure.AddAnimal(animal);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Некорректный выбор вольера.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: Некорректный выбор вольера.");
            Console.ResetColor();
        }
    }
}
