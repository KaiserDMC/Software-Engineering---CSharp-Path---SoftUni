using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            int countInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countInputs; i++)
            {
                string name = Console.ReadLine();

                usernames.Add(name);
            }

            foreach (var user in usernames)
            {
                Console.WriteLine($"{user}");
            }
        }
    }
}
