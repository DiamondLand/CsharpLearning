using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var russianNames = File.ReadAllLines("rus_names.txt");
        var documentText = File.ReadAllText("voina-i-mir.txt");

        var wordCounts = russianNames.ToDictionary(name => name, name => 0);

        var words = documentText.Split(new[] { ' ', ',', '.', ';', ':', '!', '?', '-', '/', '*', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
        }

        var mostFrequentName = wordCounts.OrderByDescending(pair => pair.Value).First();

        Console.WriteLine($"{mostFrequentName.Key}: {mostFrequentName.Value}");
    }
}