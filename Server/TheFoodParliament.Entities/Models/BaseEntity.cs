using System;

namespace TheFoodParliament.Entities.Models
{
    public  class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}