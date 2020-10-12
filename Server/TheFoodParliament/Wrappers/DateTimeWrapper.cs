using System;

namespace TheFoodParliament.Wrappers
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
    }
}