using System;

namespace SafePasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            int count = 0;
            bool stop1 = false;
            int i = 35;
            int j = 64;

            for (int k = 1; k <= a; k++)
            {
                for (int m = 1; m <= b; m++)
                {
                    count++;

                    if (count > maxPasswords)
                    {
                        stop1 = true;
                        break;
                    }

                    Console.Write($"{(char)i}{(char)j}{k}{m}{(char)j}{(char)i}|");

                    i++;
                    j++;

                    if (i > 55)
                    {
                        i = 35;
                    }

                    if (j > 96)
                    {
                        j = 64;
                    }

                    if (k == a && m == b)
                    {
                        stop1 = true;
                        break;
                    }
                }

                if (stop1)
                {
                    break;
                }
            }
        }
    }
}
