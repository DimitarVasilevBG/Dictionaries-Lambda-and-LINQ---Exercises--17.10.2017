using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, List<string>>> username = new SortedDictionary<string, Dictionary<string, List<string>>>();
            
            string input = Console.ReadLine();
            while(input!="end")
            {
                string[] Inputargs = input.Split(' ').ToArray();
                string user = Inputargs[2].Split('=')[1];
                string ip = Inputargs[0].Split('=')[1]; ;
                string message = Inputargs[1].Split('=')[1]; ;
                if(!username.ContainsKey(user))
                {
                    username.Add(user, new Dictionary<string, List<string>>());
                    AddInfo(username[user], ip, message);
                }
                else
                {
                    AddInfo(username[user], ip, message);
                }

                input = Console.ReadLine();
            }
            
            string copy = "";
            foreach (var value in username.Values)
            {
                
                foreach (var item in value)
                {
                    var myKey = username.FirstOrDefault(x => x.Value == value).Key;
                    if (copy != myKey)
                    {
                        Console.WriteLine(myKey+": ");
                        copy = myKey;
                    }
                    if (value.Keys.Last() == item.Key)
                    {
                        Console.Write(item.Key + " => "+string.Join("", item.Value.Count) + ".");
                    }
                    else
                        Console.Write(item.Key + " => " + string.Join(", ", item.Value.Count) + ", ");
                }
                Console.WriteLine();
            }



        }

        private static void AddInfo(Dictionary<string,List<string>> dictionary, string ip, string message)
        {
            if(!dictionary.ContainsKey(ip))
            {
                dictionary.Add(ip,new List<string>());
                dictionary[ip].Add(message);
            }
            else
            {
                dictionary[ip].Add(message);
            }

        }
    }
}
