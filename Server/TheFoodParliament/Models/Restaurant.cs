using System;

namespace TheFoodParliament.Models
{
    public class Restaurant
    {
        public Restaurant(string name, string address, float distance)
        {
            this.Name = name;
            this.Address = address;
            this.Distance = distance;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public float Distance { get; private set; }
    }
}
