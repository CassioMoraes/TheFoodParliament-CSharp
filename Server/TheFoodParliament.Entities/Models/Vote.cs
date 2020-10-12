using System;

namespace TheFoodParliament.Entities.Models
{
    public class Vote : BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime Date { get; set; }
    }
}