using System;

namespace TheFoodParliament.Models
{
    public class Vote : IVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime Date { get; set; }
    }
}