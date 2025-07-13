using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface INotificationDAO
    {
        List<Notification> GetNotificationsByCustomerId(int customerId);
        Notification GetNotificationById(int notificationId);
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(int notificationId);
        List<Notification> GetPendingNotifications();
        List<Notification> GetNotificationsByType(NotificationType type);
        void MarkAsRead(int notificationId);
    }
}