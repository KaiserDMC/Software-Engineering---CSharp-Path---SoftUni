using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            char[] usernameToChar = username.ToCharArray();
            Array.Reverse(usernameToChar);
            string reversedUsername = new string(usernameToChar);

            int blockCounter = 0;

            while (password != reversedUsername)
            {
                blockCounter++;

                if (blockCounter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");

                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                password = Console.ReadLine();
            }

            if (password == reversedUsername)
            {
                Console.WriteLine($"User {username} logged in.");
            }

        }
    }
}
