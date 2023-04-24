using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(int indexOne, int indexTwo)
        {
            T tempItem = Items[indexOne];
            Items[indexOne] = Items[indexTwo];
            Items[indexTwo] = tempItem;
        }

        public int Count(T itemComparable)
        {
            int count = 0;

            foreach (var item in Items)
            {
                if (item.CompareTo(itemComparable) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}