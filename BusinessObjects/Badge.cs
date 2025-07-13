using System;

namespace BusinessObjects
{
    public partial class Badge
    {
        public int BadgeId { get; set; }

        public int CustomerId { get; set; }

        public int AchievementId { get; set; }

        public DateTime EarnedDate { get; set; } = DateTime.Now;

        public string? Notes { get; set; }

        public bool IsShared { get; set; } = false;

        public virtual Customer Customer { get; set; } = null!;

        public virtual Achievement Achievement { get; set; } = null!;
    }
}