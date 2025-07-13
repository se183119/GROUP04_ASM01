using System;

namespace BusinessObjects
{
    public enum NotificationType
    {
        Daily = 1,
        Weekly = 2,
        Motivational = 3,
        Achievement = 4,
        CravingSupport = 5,
        QuitReminder = 6
    }

    public enum NotificationStatus
    {
        Pending = 1,
        Sent = 2,
        Read = 3,
        Dismissed = 4
    }

    public partial class Notification
    {
        public int NotificationId { get; set; }

        public int CustomerId { get; set; }

        public string Title { get; set; } = null!;

        public string Message { get; set; } = null!;

        public NotificationType Type { get; set; }

        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

        public DateTime ScheduledDate { get; set; }

        public DateTime? SentDate { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Customer Customer { get; set; } = null!;
    }
}