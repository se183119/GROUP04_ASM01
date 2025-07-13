using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class ProgressLogDAO : IProgressLogDAO
    {
        public void CreateProgressLog(ProgressLog log)
        {
            using var context = new SmokingCessationContext();
            context.ProgressLogs.Add(log);
            context.SaveChanges();
        }

        public void DeleteProgressLog(int logId)
        {
            using var context = new SmokingCessationContext();
            var log = context.ProgressLogs.FirstOrDefault(x => x.ProgressLogId == logId);
            if (log != null)
            {
                context.ProgressLogs.Remove(log);
                context.SaveChanges();
            }
        }

        public ProgressLog GetLatestProgressLogByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.ProgressLogs
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.LogDate)
                .FirstOrDefault();
        }

        public ProgressLog GetProgressLogById(int logId)
        {
            using var context = new SmokingCessationContext();
            return context.ProgressLogs.FirstOrDefault(x => x.ProgressLogId == logId);
        }

        public List<ProgressLog> GetProgressLogsByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.ProgressLogs
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.LogDate)
                .ToList();
        }

        public List<ProgressLog> GetProgressLogsByDateRange(int customerId, DateTime startDate, DateTime endDate)
        {
            using var context = new SmokingCessationContext();
            return context.ProgressLogs
                .Where(x => x.CustomerId == customerId && 
                           x.LogDate >= startDate && 
                           x.LogDate <= endDate)
                .OrderBy(x => x.LogDate)
                .ToList();
        }

        public List<ProgressLog> GetProgressLogsByQuitPlanId(int quitPlanId)
        {
            using var context = new SmokingCessationContext();
            return context.ProgressLogs
                .Where(x => x.QuitPlanId == quitPlanId)
                .OrderByDescending(x => x.LogDate)
                .ToList();
        }

        public void UpdateProgressLog(ProgressLog log)
        {
            using var context = new SmokingCessationContext();
            context.ProgressLogs.Update(log);
            context.SaveChanges();
        }
    }
}