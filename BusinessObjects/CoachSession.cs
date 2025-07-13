using System;

namespace BusinessObjects
{
    public enum SessionStatus
    {
        Scheduled = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4,
        NoShow = 5
    }

    public partial class CoachSession
    {
        public int CoachSessionId { get; set; }

        public int MemberId { get; set; }

        public int CoachId { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public SessionStatus Status { get; set; } = SessionStatus.Scheduled;

        public string? Notes { get; set; }

        public string? CoachNotes { get; set; }

        public string? Recommendations { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Customer Member { get; set; } = null!;

        public virtual Customer Coach { get; set; } = null!;
    }
}