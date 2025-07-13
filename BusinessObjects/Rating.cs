using System;

namespace BusinessObjects
{
    public enum RatingType
    {
        Coach = 1,
        Platform = 2,
        CoachSession = 3
    }

    public partial class Rating
    {
        public int RatingId { get; set; }

        public int RaterId { get; set; }

        public int? RatedUserId { get; set; }

        public int? CoachSessionId { get; set; }

        public RatingType Type { get; set; }

        public int Score { get; set; } // 1-5 stars

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Customer Rater { get; set; } = null!;

        public virtual Customer? RatedUser { get; set; }

        public virtual CoachSession? CoachSession { get; set; }
    }
}