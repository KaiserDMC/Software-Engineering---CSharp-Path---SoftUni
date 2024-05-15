using System;
using System.Runtime.InteropServices.ComTypes;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string dateStart;
        private string dateEnd;

        public DateModifier()
        {
        }
        
        public DateModifier(string dateStart, string dateEnd)
        {
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }

        public string DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        public string DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        public TimeSpan DateDifference(string dateStart, string dateEnd)
        {
            DateTime start = DateTime.Parse(dateStart);
            DateTime end = DateTime.Parse(dateEnd);

            TimeSpan difference = end - start;

            return difference;
        }
    }
}