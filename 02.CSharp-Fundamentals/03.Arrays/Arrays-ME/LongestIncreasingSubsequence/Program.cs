using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] inputSequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] length = new int[inputSequence.Length];
        int[] previous = new int[inputSequence.Length];
        int[] longestSequence;

        int lastIndex = -1;
        int maxLength = 0;


        for (int i = 0; i < inputSequence.Length; i++)
        {
            length[i] = 1;
            previous[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (inputSequence[j] < inputSequence[i] && length[j] >= length[i])
                {
                    length[i] = 1 + length[j];
                    previous[i] = j;
                }
            }

            if (length[i] > maxLength)
            {
                maxLength = length[i];
                lastIndex = i;
            }
        }

        longestSequence = new int[maxLength];

        for (int index = 0; index < maxLength; index++)
        {
            longestSequence[index] = inputSequence[lastIndex];
            lastIndex = previous[lastIndex];
        }

        Array.Reverse(longestSequence);

        Console.WriteLine(string.Join(" ", longestSequence));

    }
}