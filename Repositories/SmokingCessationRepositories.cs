using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class QuitPlanRepository : IQuitPlanRepository
    {
        private readonly IQuitPlanDAO _quitPlanDao;

        public QuitPlanRepository()
        {
            _quitPlanDao = new QuitPlanDAO();
        }

        public void CreateQuitPlan(QuitPlan plan)
        {
            _quitPlanDao.CreateQuitPlan(plan);
        }

        public void DeleteQuitPlan(int planId)
        {
            _quitPlanDao.DeleteQuitPlan(planId);
        }

        public QuitPlan GetActiveQuitPlanByCustomerId(int customerId)
        {
            return _quitPlanDao.GetActiveQuitPlanByCustomerId(customerId);
        }

        public QuitPlan GetQuitPlanById(int planId)
        {
            return _quitPlanDao.GetQuitPlanById(planId);
        }

        public List<QuitPlan> GetQuitPlansByCustomerId(int customerId)
        {
            return _quitPlanDao.GetQuitPlansByCustomerId(customerId);
        }

        public List<QuitPlan> GetQuitPlansByStatus(QuitPlanStatus status)
        {
            return _quitPlanDao.GetQuitPlansByStatus(status);
        }

        public void UpdateQuitPlan(QuitPlan plan)
        {
            _quitPlanDao.UpdateQuitPlan(plan);
        }
    }

    public class ProgressLogRepository : IProgressLogRepository
    {
        private readonly IProgressLogDAO _progressLogDao;

        public ProgressLogRepository()
        {
            _progressLogDao = new ProgressLogDAO();
        }

        public void CreateProgressLog(ProgressLog log)
        {
            _progressLogDao.CreateProgressLog(log);
        }

        public void DeleteProgressLog(int logId)
        {
            _progressLogDao.DeleteProgressLog(logId);
        }

        public ProgressLog GetLatestProgressLogByCustomerId(int customerId)
        {
            return _progressLogDao.GetLatestProgressLogByCustomerId(customerId);
        }

        public ProgressLog GetProgressLogById(int logId)
        {
            return _progressLogDao.GetProgressLogById(logId);
        }

        public List<ProgressLog> GetProgressLogsByCustomerId(int customerId)
        {
            return _progressLogDao.GetProgressLogsByCustomerId(customerId);
        }

        public List<ProgressLog> GetProgressLogsByDateRange(int customerId, DateTime startDate, DateTime endDate)
        {
            return _progressLogDao.GetProgressLogsByDateRange(customerId, startDate, endDate);
        }

        public List<ProgressLog> GetProgressLogsByQuitPlanId(int quitPlanId)
        {
            return _progressLogDao.GetProgressLogsByQuitPlanId(quitPlanId);
        }

        public void UpdateProgressLog(ProgressLog log)
        {
            _progressLogDao.UpdateProgressLog(log);
        }
    }

    public class AchievementRepository : IAchievementRepository
    {
        private readonly IAchievementDAO _achievementDao;

        public AchievementRepository()
        {
            _achievementDao = new AchievementDAO();
        }

        public void CreateAchievement(Achievement achievement)
        {
            _achievementDao.CreateAchievement(achievement);
        }

        public void DeleteAchievement(int achievementId)
        {
            _achievementDao.DeleteAchievement(achievementId);
        }

        public Achievement GetAchievementById(int achievementId)
        {
            return _achievementDao.GetAchievementById(achievementId);
        }

        public List<Achievement> GetAchievementsByType(AchievementType type)
        {
            return _achievementDao.GetAchievementsByType(type);
        }

        public List<Achievement> GetActiveAchievements()
        {
            return _achievementDao.GetActiveAchievements();
        }

        public List<Achievement> GetAllAchievements()
        {
            return _achievementDao.GetAllAchievements();
        }

        public void UpdateAchievement(Achievement achievement)
        {
            _achievementDao.UpdateAchievement(achievement);
        }
    }
}