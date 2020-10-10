using System;

namespace TheFoodParliament.Entities.Models
{
    public class User : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}