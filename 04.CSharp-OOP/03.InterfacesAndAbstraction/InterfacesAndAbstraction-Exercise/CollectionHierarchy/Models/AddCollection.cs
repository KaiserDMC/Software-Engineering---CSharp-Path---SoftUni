using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
