using System;

namespace TheFoodParliament.Wrappers
{
    public interface IDateTimeWrapper
    {
        DateTime Now();

        DateTime Parse(string dateString);
    }
}