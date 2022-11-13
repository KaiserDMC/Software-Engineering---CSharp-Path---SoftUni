using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
