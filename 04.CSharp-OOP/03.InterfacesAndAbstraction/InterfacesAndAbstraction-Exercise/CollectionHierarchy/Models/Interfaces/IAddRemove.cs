using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Interfaces
{
    public interface IAddRemove : IAdd
    {
        string Remove();
    }
}
