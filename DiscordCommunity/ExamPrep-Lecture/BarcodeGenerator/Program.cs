using System;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int barcordeStart = int.Parse(Console.ReadLine());
            int barcordeEnd = int.Parse(Console.ReadLine());

            int firstNumberStart = barcordeStart / 1000;
            int firstNumberEnd = barcordeEnd / 1000;

            int secondNumberStart = (barcordeStart / 100) % 10; 
            int secondNumberEnd = (barcordeEnd / 100) % 10;

            int thirdNumberStart = (barcordeStart / 10) % 10;
            int thirdNumberEnd = (barcordeEnd / 10) % 10;

            int fourthNumberStart = barcordeStart % 10;
            int fourthNumberEnd = barcordeEnd % 10;


            for (int i = firstNumberStart; i <= firstNumberEnd; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = secondNumberStart; j <= secondNumberEnd; j++)
                    {
                        if (j % 2 != 0)
                        {
                            for (int k = thirdNumberStart; k <= thirdNumberEnd; k++)
                            {
                                if (k % 2 != 0)
                                {
                                    for (int l = fourthNumberStart; l <= fourthNumberEnd; l++)
                                    {
                                        if (l % 2 != 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l} ");
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

            }
        }
    }
}
