using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] names = File.ReadAllLines("rus_names.txt");
        string text = File.ReadAllText("voina-i-mir.txt");

        var namesWithIndexes = names
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Select((name, index) => new { Name = name, Index = index + 1 })
            .ToDictionary(item => item.Name, item => item.Index);

        foreach (var pair in namesWithIndexes.Take(100))
        {
            string pattern = $@"\b{Regex.Escape(pair.Key)}\b";
            text = Regex.Replace(text, pattern, pair.Value.ToString(), RegexOptions.IgnoreCase);
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        Console.WriteLine($"Количество уникальных имен: {namesWithIndexes.Count}");
    }
}
