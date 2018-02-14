using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resource = new Dictionary<string, double>();
            string inp = "";
            int value = 0;
            int count = 1;
            do
            {
                if (count % 2 == 1)
                {
                    inp = Console.ReadLine();
                    if (inp == "stop")
                        break;
                }
                else if (count % 2 == 0)
                {
                    value = int.Parse(Console.ReadLine());
                    if (resource.ContainsKey(inp))
                    {

                        resource[inp] += value;
                    }
                    else
                        resource.Add(inp, value);

                }
                count++;
            } while (true);
                   
            

            foreach (var item in resource)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

        }
    }
}
