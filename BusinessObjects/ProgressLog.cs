using System;

namespace BusinessObjects
{
    public enum MoodLevel
    {
        VeryBad = 1,
        Bad = 2,
        Neutral = 3,
        Good = 4,
        VeryGood = 5
    }

    public enum StressLevel
    {
        VeryLow = 1,
        Low = 2,
        Moderate = 3,
        High = 4,
        VeryHigh = 5
    }

    public enum CravingIntensity
    {
        None = 0,
        VeryLow = 1,
        Low = 2,
        Moderate = 3,
        High = 4,
        VeryHigh = 5
    }

    public partial class ProgressLog
    {
        public int ProgressLogId { get; set; }

        public int CustomerId { get; set; }

        public int? QuitPlanId { get; set; }

        public DateTime LogDate { get; set; }

        public int SmokingIncidents { get; set; } = 0;

        public MoodLevel MoodLevel { get; set; }

        public StressLevel StressLevel { get; set; }

        public CravingIntensity CravingIntensity { get; set; }

        public string? HealthImprovements { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Customer Customer { get; set; } = null!;

        public virtual QuitPlan? QuitPlan { get; set; }
    }
}