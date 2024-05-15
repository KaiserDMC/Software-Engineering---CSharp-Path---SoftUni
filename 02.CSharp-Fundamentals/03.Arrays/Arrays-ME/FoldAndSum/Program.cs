using System;
using System.Linq;

public class FoldAndSum
{
    public static void Main()
    {
        int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int foldPosition = inputArray.Length / 4;
        int[] foldedBottom = new int[inputArray.Length / 2];
        int[] foldedTopFront = new int[inputArray.Length / 4];
        int[] foldedTopBack = new int[inputArray.Length / 4];

        for (int i = 0; i < foldPosition; i++)
        {
            foldedTopFront[i] = inputArray[i];
        }

        Array.Reverse(foldedTopFront);

        int counter = 0;
        for (int j = inputArray.Length - 1 - foldPosition; j >= foldPosition; j--)
        {
            foldedBottom[counter] = inputArray[j];
            counter++;
        }

        Array.Reverse(foldedBottom);

        int counterIndex = 0;
        for (int k = inputArray.Length - foldPosition; k < inputArray.Length; k++)
        {
            foldedTopBack[counterIndex] = inputArray[k];
            counterIndex++;
        }

        Array.Reverse(foldedTopBack);

        int[] foldedTopFull = new int[inputArray.Length / 2];
        foldedTopFull = foldedTopFront.Concat(foldedTopBack).ToArray();

        int[] sumToPrint = new int[inputArray.Length / 2];

        for (int index = 0; index < sumToPrint.Length; index++)
        {
            sumToPrint[index] = foldedTopFull[index] + foldedBottom[index];
        }

        Console.WriteLine(string.Join(" ", sumToPrint));
    }
}