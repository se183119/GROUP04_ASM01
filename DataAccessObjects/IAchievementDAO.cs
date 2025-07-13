using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface IAchievementDAO
    {
        List<Achievement> GetAllAchievements();
        Achievement GetAchievementById(int achievementId);
        void CreateAchievement(Achievement achievement);
        void UpdateAchievement(Achievement achievement);
        void DeleteAchievement(int achievementId);
        List<Achievement> GetAchievementsByType(AchievementType type);
        List<Achievement> GetActiveAchievements();
    }
}