using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("ABC");
            list.Add("123");
            list.Add("XYZ");

            Console.WriteLine(list.RandomString());
        }
    }
}
