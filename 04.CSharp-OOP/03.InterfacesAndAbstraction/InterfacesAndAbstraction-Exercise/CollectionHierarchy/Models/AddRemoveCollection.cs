using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
   public class AddRemoveCollection :IAddRemove
   {
       private List<string> collection;

       public AddRemoveCollection()
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
            int lastIndex = this.collection.Count - 1;
            string tempString = this.collection[lastIndex];

            this.collection.RemoveAt(lastIndex);

            return tempString;
        }
    }
}
