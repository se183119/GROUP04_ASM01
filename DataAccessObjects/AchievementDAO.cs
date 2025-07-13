using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class AchievementDAO : IAchievementDAO
    {
        public void CreateAchievement(Achievement achievement)
        {
            using var context = new SmokingCessationContext();
            context.Achievements.Add(achievement);
            context.SaveChanges();
        }

        public void DeleteAchievement(int achievementId)
        {
            using var context = new SmokingCessationContext();
            var achievement = context.Achievements.FirstOrDefault(x => x.AchievementId == achievementId);
            if (achievement != null)
            {
                achievement.IsActive = false;
                context.Achievements.Update(achievement);
                context.SaveChanges();
            }
        }

        public Achievement GetAchievementById(int achievementId)
        {
            using var context = new SmokingCessationContext();
            return context.Achievements.FirstOrDefault(x => x.AchievementId == achievementId);
        }

        public List<Achievement> GetAchievementsByType(AchievementType type)
        {
            using var context = new SmokingCessationContext();
            return context.Achievements
                .Where(x => x.Type == type && x.IsActive)
                .OrderBy(x => x.RequiredValue)
                .ToList();
        }

        public List<Achievement> GetActiveAchievements()
        {
            using var context = new SmokingCessationContext();
            return context.Achievements
                .Where(x => x.IsActive)
                .OrderBy(x => x.Type)
                .ThenBy(x => x.RequiredValue)
                .ToList();
        }

        public List<Achievement> GetAllAchievements()
        {
            using var context = new SmokingCessationContext();
            return context.Achievements.ToList();
        }

        public void UpdateAchievement(Achievement achievement)
        {
            using var context = new SmokingCessationContext();
            context.Achievements.Update(achievement);
            context.SaveChanges();
        }
    }
}