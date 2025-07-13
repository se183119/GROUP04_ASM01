using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class NotificationDAO : INotificationDAO
    {
        public void CreateNotification(Notification notification)
        {
            using var context = new SmokingCessationContext();
            context.Notifications.Add(notification);
            context.SaveChanges();
        }

        public void DeleteNotification(int notificationId)
        {
            using var context = new SmokingCessationContext();
            var notification = context.Notifications.FirstOrDefault(x => x.NotificationId == notificationId);
            if (notification != null)
            {
                context.Notifications.Remove(notification);
                context.SaveChanges();
            }
        }

        public Notification GetNotificationById(int notificationId)
        {
            using var context = new SmokingCessationContext();
            return context.Notifications.FirstOrDefault(x => x.NotificationId == notificationId);
        }

        public List<Notification> GetNotificationsByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.Notifications
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.ScheduledDate)
                .ToList();
        }

        public List<Notification> GetNotificationsByType(NotificationType type)
        {
            using var context = new SmokingCessationContext();
            return context.Notifications
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.ScheduledDate)
                .ToList();
        }

        public List<Notification> GetPendingNotifications()
        {
            using var context = new SmokingCessationContext();
            return context.Notifications
                .Where(x => x.Status == NotificationStatus.Pending && 
                           x.ScheduledDate <= DateTime.Now)
                .OrderBy(x => x.ScheduledDate)
                .ToList();
        }

        public void MarkAsRead(int notificationId)
        {
            using var context = new SmokingCessationContext();
            var notification = context.Notifications.FirstOrDefault(x => x.NotificationId == notificationId);
            if (notification != null)
            {
                notification.Status = NotificationStatus.Read;
                notification.ReadDate = DateTime.Now;
                context.Notifications.Update(notification);
                context.SaveChanges();
            }
        }

        public void UpdateNotification(Notification notification)
        {
            using var context = new SmokingCessationContext();
            context.Notifications.Update(notification);
            context.SaveChanges();
        }
    }
}