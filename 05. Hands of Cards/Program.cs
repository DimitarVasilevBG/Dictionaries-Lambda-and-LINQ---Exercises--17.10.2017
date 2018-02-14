using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> people = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                var CommonArgs = input.Split(':').ToArray();
                var name = CommonArgs[0];
                var cards = CommonArgs[1].Trim().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, int>());
                    AddCardsToPlayer(people[name], cards);
                }
                else
                {
                    AddCardsToPlayer(people[name], cards);
                }
                input = Console.ReadLine();


            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Key + ": " + person.Value.Values.Sum());
            }


        }

        private static void AddCardsToPlayer(Dictionary<string, int> person, string[] cards)
        {
            foreach (var card in cards)
            {
                if (!person.ContainsKey(card))
                {
                    person.Add(card, GetCardValue(card));
                }
            }
        }

        private static int GetCardValue(string v)
        {
            int power = 0;
            switch (v[0])
            {
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    power += (int)v[0] - 48;
                    break;
                case '1':
                    power += 10;
                    break;
                case 'J':
                    power += 11;
                    break;
                case 'Q':
                    power += 12;
                    break;
                case 'K':
                    power += 13;
                    break;
                case 'A':
                    power += 14;
                    break;
            }
            switch (v[v.Length-1])
            {
                case 'S':
                    power *= 4;
                    break;
                case 'H':
                    power *= 3;
                    break;
                case 'D':
                    power *= 2;
                    break;
                case 'C':
                    power *= 1;
                    break;
            }
            return power;
        }
    }
}
