using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            bool innerEnd = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {

                    while (true)
                    {
                        string guestCame = Console.ReadLine();

                        if (guestCame == "END")
                        {
                            innerEnd = true;
                            break;
                        }

                        if (Char.IsDigit(guestCame[0]))
                        {
                            vipGuests.Remove(guestCame);
                        }
                        else
                        {
                            regularGuests.Remove(guestCame);
                        }
                    }

                }
                else
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }

                if (innerEnd)
                {
                    break;
                }
            }

            Console.WriteLine($"{vipGuests.Count + regularGuests.Count}");

            if (vipGuests.Count > 0)
            {
                foreach (var vip in vipGuests)
                {
                    Console.WriteLine(vip);
                }
            }

            if (regularGuests.Count > 0)
            {
                foreach (var regular in regularGuests)
                {
                    Console.WriteLine(regular);
                }
            }
        }
    }
}
