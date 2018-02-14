using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> pair = new Dictionary<string, string>();
            string name = "";
            string mail = "";
            int count = 1;
            do
            {
                if (count % 2 == 1)
                {
                    name = Console.ReadLine();
                    if (name == "stop")
                        break;
                }
                else if (count % 2 == 0)
                {
                    mail = Console.ReadLine();
                    if (pair.ContainsKey(name))
                    {

                    }
                    else
                    {

                        pair.Add(name, mail);
                        if (mail.Contains(".us")|| mail.Contains(".uk"))
                            pair.Remove(name);
                    }

                }
                count++;
            } while (true);
            
            foreach (var item in pair)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
