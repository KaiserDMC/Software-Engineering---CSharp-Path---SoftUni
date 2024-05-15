using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            int highest = 0;
            int middle = 0;
            int lowest = 0;

            if (numberOne > numberTwo && numberOne > numberThree)
            {
                highest = numberOne;
            }
            else if (numberTwo > numberOne && numberTwo > numberThree)
            {
                highest = numberTwo;
            }
            else
            {
                highest = numberThree;
            }

            if (numberThree < numberTwo && numberThree < numberOne)
            {
                lowest = numberThree;
            }
            else if (numberTwo < numberOne && numberTwo < numberThree)
            {
                lowest = numberTwo;
            }
            else if ((numberTwo < numberOne && numberThree < numberOne) && (numberTwo == numberThree))
            {
                lowest = numberTwo;
            }
            else
            {
                lowest = numberOne;
            }

            if ((numberOne == lowest || numberOne == highest) && (numberTwo == lowest || numberTwo == highest))
            {
                middle = numberThree;
            }
            else if ((numberOne == lowest || numberOne == highest) && (numberThree == lowest || numberThree == highest))
            {
                middle = numberTwo;
            }
            else
            {
                middle = numberOne;
            }

            Console.WriteLine($"{highest}");
            Console.WriteLine($"{middle}");
            Console.WriteLine($"{lowest}");
        }
    }
}
