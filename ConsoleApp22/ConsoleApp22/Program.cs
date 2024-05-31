using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите IP-адрес");
        string ipAddress = Console.ReadLine();
        if (IsValidIpAddress(ipAddress))
        {
            Console.WriteLine("IP-адрес действителен.");
        }
        else
        {
            Console.WriteLine("IP-адрес недействителен.");
        }
    }

    static bool IsValidIpAddress(string ipAddress)
    {
        string pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        return Regex.IsMatch(ipAddress, pattern);
    }
}

