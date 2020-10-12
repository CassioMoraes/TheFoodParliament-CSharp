using System;

namespace TheFoodParliament.Entities.Models
{
    public class Vote : Entity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime Date { get; set; }
    }
}