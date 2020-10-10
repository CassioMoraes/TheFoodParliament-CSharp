using System;

namespace TheFoodParliament.Models
{
    public interface IVote
    {
        int Id { get; set; }

        int UserId { get; set; }

        int RestaurantId { get; set; }

        DateTime Date { get; set; }
    }
}