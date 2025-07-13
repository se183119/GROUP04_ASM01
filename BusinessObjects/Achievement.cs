using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public enum AchievementType
    {
        SmokeFree = 1,
        MoneySaved = 2,
        HealthImprovement = 3,
        Streak = 4,
        Community = 5
    }

    public partial class Achievement
    {
        public int AchievementId { get; set; }

        public string AchievementName { get; set; } = null!;

        public string? Description { get; set; }

        public AchievementType Type { get; set; }

        public string? Criteria { get; set; }

        public int RequiredValue { get; set; }

        public string? BadgeIcon { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Badge> Badges { get; set; } = new List<Badge>();
    }
}