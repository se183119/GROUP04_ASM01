using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class BadgeDAO : IBadgeDAO
    {
        public void CreateBadge(Badge badge)
        {
            using var context = new SmokingCessationContext();
            context.Badges.Add(badge);
            context.SaveChanges();
        }

        public void DeleteBadge(int badgeId)
        {
            using var context = new SmokingCessationContext();
            var badge = context.Badges.FirstOrDefault(x => x.BadgeId == badgeId);
            if (badge != null)
            {
                context.Badges.Remove(badge);
                context.SaveChanges();
            }
        }

        public Badge GetBadgeById(int badgeId)
        {
            using var context = new SmokingCessationContext();
            return context.Badges.FirstOrDefault(x => x.BadgeId == badgeId);
        }

        public List<Badge> GetBadgesByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.Badges
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.EarnedDate)
                .ToList();
        }

        public List<Badge> GetSharedBadges()
        {
            using var context = new SmokingCessationContext();
            return context.Badges
                .Where(x => x.IsShared)
                .OrderByDescending(x => x.EarnedDate)
                .ToList();
        }

        public bool HasBadge(int customerId, int achievementId)
        {
            using var context = new SmokingCessationContext();
            return context.Badges
                .Any(x => x.CustomerId == customerId && x.AchievementId == achievementId);
        }

        public void UpdateBadge(Badge badge)
        {
            using var context = new SmokingCessationContext();
            context.Badges.Update(badge);
            context.SaveChanges();
        }
    }
}