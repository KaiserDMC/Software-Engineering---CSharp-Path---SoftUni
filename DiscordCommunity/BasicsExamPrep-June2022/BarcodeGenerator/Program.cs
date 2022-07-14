using System;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int barcodeStart = int.Parse(Console.ReadLine());
            int barcodeEnd = int.Parse(Console.ReadLine());

            for (int i = barcodeStart / 1000; i <= barcodeEnd / 1000; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = barcodeStart / 100 % 10; j <= barcodeEnd / 100 % 10; j++)
                    {
                        if (j % 2 != 0)
                        {
                            for (int k = barcodeStart / 10 % 10; k <= barcodeEnd / 10 % 10; k++)
                            {
                                if (k % 2 != 0)
                                {
                                    for (int m = barcodeStart % 10; m <= barcodeEnd % 10; m++)
                                    {
                                        if (m % 2 != 0)
                                        {
                                            Console.Write($"{i}{j}{k}{m} ");
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
