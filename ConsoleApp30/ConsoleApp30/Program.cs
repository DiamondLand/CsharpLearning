using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] temperatures = Enumerable.Range(0, 30).Select(x => rand.Next(-20, 21)).ToArray();

            int maxTemperature = temperatures.Where(t => t < 0).Max();
            Console.WriteLine("Максимальная температура среди дней с заморозками: " + maxTemperature);
        }
    }
}
