using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IAchievementRepository
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