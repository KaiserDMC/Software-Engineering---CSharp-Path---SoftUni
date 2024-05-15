using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string DEFAULT_EXCEPTION_MSG = "Invalid URL!";

        public InvalidURLException() : base(DEFAULT_EXCEPTION_MSG)
        {

        }

        public InvalidURLException(string message) : base(message)
        {

        }
    }
}
