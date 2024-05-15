using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int startPokePower = int.Parse(Console.ReadLine());
            int targetDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokeCounter = 0;
            int pokePower = startPokePower;
            int exactlyHalfPower = startPokePower / 2;

            while (pokePower >= targetDistance)
            {
                pokePower -= targetDistance;
                pokeCounter++;

                if (pokePower == exactlyHalfPower)
                {
                    if (exhaustionFactor != 0)
                    {
                        if (pokePower / exhaustionFactor > 0)
                        {
                            pokePower /= exhaustionFactor;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCounter);
        }
    }
}
