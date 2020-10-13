using System;

namespace TheFoodParliament.Entities.Models
{
    public class Election : BaseEntity
    {
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public int Votes { get; set; }

        public DateTime WinningDate { get; set; }
    }
}