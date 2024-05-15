using System;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);

            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());

            int[] arr = list.ToArray();

            list.ForEach(i => Console.WriteLine(i));

            Console.WriteLine(list.Count);


            DoublyLinkedList<string> listString = new DoublyLinkedList<string>();

            listString.AddFirst("sad");
            listString.AddFirst("dsf");
            listString.AddFirst("frg");
            listString.AddLast("fdgfdg");

            listString.ForEach(i => Console.WriteLine(i));
        }
    }
}