using System;

namespace BusinessObjects
{
    public partial class SmokingStatus
    {
        public int SmokingStatusId { get; set; }

        public int CustomerId { get; set; }

        public int CigarettesPerDay { get; set; }

        public decimal MoneySpentPerDay { get; set; }

        public string? SmokingTriggers { get; set; }

        public string? SmokingTimes { get; set; }

        public string? FrequencyPattern { get; set; }

        public DateTime RecordedDate { get; set; } = DateTime.Now;

        public string? Notes { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}