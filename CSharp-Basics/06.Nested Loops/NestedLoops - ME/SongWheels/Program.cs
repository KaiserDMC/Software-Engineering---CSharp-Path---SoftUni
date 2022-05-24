using System;

namespace SongWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNumber = int.Parse(Console.ReadLine());

            int count = 0;
            bool noNumbers = false;
            string pass = string.Empty;
            bool passwordCheck = false;
            bool needOfRow = false;


            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int m = 1; m <= 9; m++)
                        {
                            if ((i * j) + (k * m) == controlNumber)
                            {
                                if (i < j && k > m)
                                {
                                    count++;
                                    Console.Write($"{i}{j}{k}{m} ");

                                    if (count == 4)
                                    {
                                        pass = i.ToString() + j.ToString() + k.ToString() + m.ToString();
                                        passwordCheck = true;
                                    }
                                    else
                                    {
                                        noNumbers = true;
                                        needOfRow = true;
                                    }
                                }

                            }
                            else
                            {
                                noNumbers = true;
                            }
                        }
                    }
                }
            }

            if (passwordCheck)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {pass}");
                noNumbers = false;
                needOfRow = false;
            }

            if (needOfRow)
            {
                Console.WriteLine();
            }

            if (noNumbers)
            {
                Console.WriteLine($"No!");
            }

        }
    }
}
