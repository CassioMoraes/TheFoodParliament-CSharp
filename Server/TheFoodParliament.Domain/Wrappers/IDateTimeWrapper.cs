using System;

namespace TheFoodParliament.Domain.Wrappers
{
    public interface IDateTimeWrapper
    {
        DateTime Now();
        DateTime Parse(string dateString);
        DateTime Parse(string dateString, string format);
    }
}