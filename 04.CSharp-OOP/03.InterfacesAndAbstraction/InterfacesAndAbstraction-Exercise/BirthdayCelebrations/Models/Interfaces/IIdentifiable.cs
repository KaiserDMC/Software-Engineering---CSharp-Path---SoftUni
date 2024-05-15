using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models.Interfaces
{
   public interface IIdentifiable
    {
        public string Id { get; }
        public string Name { get; }

        string CheckForFakeID(string idString);
    }
}
