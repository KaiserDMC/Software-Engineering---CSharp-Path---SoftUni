using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Interfaces
{
    public interface IMyList : IAddRemove
    {
        public int Used { get; }
    }
}
