using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                string[] com = command.Split(" ").ToArray();

                string value = com[2];

                Predicate<string> criteriaStarts = x => x.StartsWith(value);
                Predicate<string> criteriaEnds = x => x.EndsWith(value);
                Predicate<string> criteriaLength = x => x.Length == int.Parse(value);

                switch (com[0])
                {
                    case "Double":
                        switch (com[1])
                        {
                            case "Length":
                                UpdateList(peopleList, criteriaLength, com[0], value);

                                break;
                            case "StartsWith":
                                UpdateList(peopleList, criteriaStarts, com[0], value);
                                break;
                            case "EndsWith":
                                UpdateList(peopleList, criteriaEnds, com[0], value);
                                break;

                        }
                        break;
                    case "Remove":
                        switch (com[1])
                        {
                            case "Length":
                                UpdateList(peopleList, criteriaLength, com[0], value);
                                break;
                            case "StartsWith":
                                UpdateList(peopleList, criteriaStarts, com[0], value);
                                break;
                            case "EndsWith":
                                UpdateList(peopleList, criteriaEnds, com[0], value);
                                break;

                        }
                        break;
                }
            }

            if (peopleList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", peopleList)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        public static void UpdateList(List<string> partyPeople, Predicate<string> condition, string command, string value)
        {
            int maxLoop = partyPeople.Count;

            bool temp = false;

            for (int i = 0; i < maxLoop; i++)
            {
                if (partyPeople.Count == 0 || partyPeople.Count - 1 < i)
                {
                    break;
                }

                string person = partyPeople[i];

                if (temp)
                {
                    person = partyPeople[i + 1];
                    temp = false;
                }

                if (condition(person) && command == "Double")
                {
                    int index = i;
                    partyPeople.Insert(index, person);
                    temp = true;
                }
                else if (condition(person) && command == "Remove")
                {
                    int index = i;
                    partyPeople.RemoveAt(index);
                    i = -1;
                }
            }
        }
    }
}
