using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public Random Random
        {
            get { return random; }
            set { random = value; }
        }

        public string RandomString()
        {
            int index = random.Next(0, Count);
            string removed = this[index];
            this.RemoveAt(index);

            return removed;
        }
    }
}
