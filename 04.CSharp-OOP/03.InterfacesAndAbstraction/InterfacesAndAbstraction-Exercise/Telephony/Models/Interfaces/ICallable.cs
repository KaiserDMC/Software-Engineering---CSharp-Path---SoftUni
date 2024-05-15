using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Interfaces
{
    public interface ICallable
    {
        string Call(string phoneNumber);
    }
}
