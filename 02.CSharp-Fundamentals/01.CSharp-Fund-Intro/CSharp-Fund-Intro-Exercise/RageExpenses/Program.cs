using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            float priceHeadset = float.Parse(Console.ReadLine());
            float priceMouse = float.Parse(Console.ReadLine());
            float priceKeyboard = float.Parse(Console.ReadLine());
            float priceDisplay = float.Parse(Console.ReadLine());

            int headsetTrashCounter = 0;
            int mouseTrashCounter = 0;
            int keyboardTrashCounter = 0;
            int displayTrashCounter = 0;
            bool headset = false;
            bool mouse = false;

            float totalExpenses = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrashCounter++;
                    headset = true;
                }

                if (i % 3 == 0)
                {
                    mouseTrashCounter++;
                    mouse = true;
                }

                if (headset && mouse)
                {
                    keyboardTrashCounter++;

                    if (keyboardTrashCounter % 2 == 0)
                    {
                        if (keyboardTrashCounter == 0)
                        {

                        }
                        else
                        {
                            displayTrashCounter++;
                        }
                    }
                }

                headset = false;
                mouse = false;
            }

            totalExpenses = headsetTrashCounter * priceHeadset + mouseTrashCounter * priceMouse + keyboardTrashCounter * priceKeyboard + displayTrashCounter * priceDisplay;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
