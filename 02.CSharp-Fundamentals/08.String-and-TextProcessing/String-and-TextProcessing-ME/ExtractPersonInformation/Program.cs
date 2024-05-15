using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string personInformation = Console.ReadLine();

                int indexStartName = personInformation.IndexOf('@') + 1;
                int indexEndName = personInformation.IndexOf('|');

                int indexStartAge = personInformation.IndexOf('#') + 1;
                int indexEndAge = personInformation.IndexOf('*');

                string personName = personInformation.Substring(indexStartName, indexEndName - indexStartName);
                int personAge = int.Parse(personInformation.Substring(indexStartAge, indexEndAge - indexStartAge));

                Console.WriteLine($"{personName} is {personAge} years old.");
            }
        }
    }
}
