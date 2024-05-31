using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "voina-i-mir.txt";
        string fileContents = File.ReadAllText(filePath);
        string[] words = fileContents.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var wordCounts = words.GroupBy(word => word)
                              .ToDictionary(group => group.Key, group => group.Count());

        foreach (var pair in wordCounts)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
}