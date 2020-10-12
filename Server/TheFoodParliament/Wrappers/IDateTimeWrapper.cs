using System;

namespace TheFoodParliament.Wrappers
{
    public interface IDateTimeWrapper
    {
        DateTime Now();
        DateTime Parse(string dateString);
        DateTime Parse(string dateString, string format);
    }
}