using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Telephony.Exceptions
{
    public class InvalidPhonesNumberException : Exception
    {
        private const string DEFAUL_EXCEPTIION_MSG = "Invalid number!";

        public InvalidPhonesNumberException() : base(DEFAUL_EXCEPTIION_MSG)
        {

        }

        public InvalidPhonesNumberException(string message) : base(message)
        {

        }
    }
}
