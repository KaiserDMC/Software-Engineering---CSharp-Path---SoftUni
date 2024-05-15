using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private List<string> collection;
        public int Used => this.collection.Count;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string tempString = this.collection[0];
            this.collection.RemoveAt(0);

            return tempString;
        }

    }
}
