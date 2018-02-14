using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();
            
            do
            {
                string[] input = Console.ReadLine().Split('|').ToArray();
                if (input[0] == "report")
                    break;
                else
                {
                    string city = input[0];
                    string country = input[1];
                    int population = int.Parse(input[2]);
                    if (!dict.ContainsKey(country))
                    {
                        dict.Add(country, new Dictionary<string, long>());
                        dict[country].Add(city, population);
                    }
                    else
                    {
                        dict[country].Add(city, population);
                    }
                    
                }

                
            }
            while (true);
            Dictionary<string, long> mergeDict = new Dictionary<string, long>();
            foreach (var item in dict)
            {
                mergeDict[item.Key] = item.Value.Values.Sum();
            }
            foreach (var item in mergeDict.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine(item.Key+item.Value);
                foreach (var county in dict[item.Key].OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine(county.Key+county.Value);
                }
            }
        }
    }
}
