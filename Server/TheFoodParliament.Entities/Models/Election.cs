using System;

namespace TheFoodParliament.Entities.Models
{
    public class Election : BaseEntity
    {
        public int WinnerId { get; set; }

        public int Votes { get; set; }

        public DateTime WinningDate { get; set; }
    }
}