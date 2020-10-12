using System;

namespace TheFoodParliament.Entities.Models
{
    public class Restaurant : Entity
    {
        public Restaurant(string placesApiId, string name, string address, float distance)
        {
            this.PlacesApiId = placesApiId;
            this.Name = name;
            this.Address = address;
            this.Distance = distance;
        }
        public string PlacesApiId { get; set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public float Distance { get; private set; }
    }
}
