using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models.Interfaces
{
    public interface IIdentifiable
    {
        public string Id { get;}

        public string Name { get; }

        string CheckForFakeID(string idString);
    }
}
