using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface IBadgeDAO
    {
        List<Badge> GetBadgesByCustomerId(int customerId);
        Badge GetBadgeById(int badgeId);
        void CreateBadge(Badge badge);
        void UpdateBadge(Badge badge);
        void DeleteBadge(int badgeId);
        List<Badge> GetSharedBadges();
        bool HasBadge(int customerId, int achievementId);
    }
}