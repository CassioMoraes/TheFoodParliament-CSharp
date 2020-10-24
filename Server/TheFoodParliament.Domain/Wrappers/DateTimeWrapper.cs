using System;
using System.Globalization;

namespace TheFoodParliament.Domain.Wrappers
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime Parse(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        public DateTime Parse(string dateString, string format)
        {
            return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        }
    }
}