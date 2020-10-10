using System;

namespace TheFoodParliament.Entities.Models
{
    public class Restaurant : Entity
    {
        public Restaurant(string name, string address, float distance)
        {
            this.Name = name;
            this.Address = address;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public float Distance { get; private set; }
        public DateTime CreationDate { get; set; }
    }
}
