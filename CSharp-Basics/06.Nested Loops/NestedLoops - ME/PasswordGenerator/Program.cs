using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= l; k++)
                    {
                        for (int m = 1; m <= l; m++)
                        {
                            for (int p = 1; p <= n; p++)
                            {
                                if (p > i && p > j)
                                {
                                    Console.Write($"{i}{j}{(char)(96 + k)}{(char)(96 + m)}{p} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
