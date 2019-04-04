using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            List<Dictionary<string, double>> data = new List<Dictionary<string, double>>();

            Console.WriteLine(" How much");
            var count = int.Parse(Console.ReadLine());

            Console.WriteLine(" Name and feature");
            for (int i = 0; i < count; i++)
            {
                data.Add(new Dictionary<string, double>());
                var name = Console.ReadLine();
                var feature = double.Parse(Console.ReadLine());

                data[i].Add(name, feature);
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(data[i].Keys);
            }
        }
    }
}
