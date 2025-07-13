using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProgressLogRepository
    {
        List<ProgressLog> GetProgressLogsByCustomerId(int customerId);
        List<ProgressLog> GetProgressLogsByQuitPlanId(int quitPlanId);
        ProgressLog GetProgressLogById(int logId);
        void CreateProgressLog(ProgressLog log);
        void UpdateProgressLog(ProgressLog log);
        void DeleteProgressLog(int logId);
        List<ProgressLog> GetProgressLogsByDateRange(int customerId, DateTime startDate, DateTime endDate);
        ProgressLog GetLatestProgressLogByCustomerId(int customerId);
    }
}