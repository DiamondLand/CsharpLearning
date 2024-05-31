using System;

public interface IGlobe
{
    double GetTemperature();
    double GetRadius();
    bool IsPlanet();
}

public class Planet : IGlobe
{
    private static Planet instance;

    private Planet()
    {
        
        Random random = new Random();
        Temperature = random.Next(-100, 100);
        Radius = random.Next(1000, 50000);
    }

    public static Planet GetInstance()
    {
        if (instance == null)
        {
            instance = new Planet();
        }
        return instance;
    }


    public double GetTemperature()
    {
        return Temperature;
    }

    public double GetRadius()
    {
        return Radius;
    }

    public bool IsPlanet()
    {
        return true;
    }

    private double Temperature { get; set; }
    private double Radius { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите название планеты:");
        string planetName = Console.ReadLine();

        Planet planet = Planet.GetInstance();

        Console.WriteLine($"Информация о планете {planetName}:");
        Console.WriteLine($"Температура: {planet.GetTemperature()} градусов Цельсия");
        Console.WriteLine($"Радиус: {planet.GetRadius()} км");
        Console.WriteLine($"Это планета: {planet.IsPlanet()}");
    }
}
