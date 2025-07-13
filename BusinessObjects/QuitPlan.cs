using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public enum QuitPlanStatus
    {
        Active = 1,
        Paused = 2,
        Completed = 3,
        Cancelled = 4
    }

    public partial class QuitPlan
    {
        public int QuitPlanId { get; set; }

        public int CustomerId { get; set; }

        public string PlanName { get; set; } = null!;

        public string? PersonalReasons { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime TargetQuitDate { get; set; }

        public string? Strategies { get; set; }

        public string? CopingMechanisms { get; set; }

        public QuitPlanStatus Status { get; set; } = QuitPlanStatus.Active;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public string? Notes { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<ProgressLog> ProgressLogs { get; set; } = new List<ProgressLog>();
    }
}