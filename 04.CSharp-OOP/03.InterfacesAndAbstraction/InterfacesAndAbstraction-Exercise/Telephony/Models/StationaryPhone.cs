using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
            => $"Dialing... {phoneNumber}";
    }
}
