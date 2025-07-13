using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class SmokingStatusDAO : ISmokingStatusDAO
    {
        public void CreateSmokingStatus(SmokingStatus status)
        {
            using var context = new SmokingCessationContext();
            context.SmokingStatuses.Add(status);
            context.SaveChanges();
        }

        public void DeleteSmokingStatus(int statusId)
        {
            using var context = new SmokingCessationContext();
            var status = context.SmokingStatuses.FirstOrDefault(x => x.SmokingStatusId == statusId);
            if (status != null)
            {
                context.SmokingStatuses.Remove(status);
                context.SaveChanges();
            }
        }

        public SmokingStatus GetLatestSmokingStatusByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.SmokingStatuses
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.RecordedDate)
                .FirstOrDefault();
        }

        public SmokingStatus GetSmokingStatusById(int statusId)
        {
            using var context = new SmokingCessationContext();
            return context.SmokingStatuses.FirstOrDefault(x => x.SmokingStatusId == statusId);
        }

        public List<SmokingStatus> GetSmokingStatusesByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.SmokingStatuses
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.RecordedDate)
                .ToList();
        }

        public void UpdateSmokingStatus(SmokingStatus status)
        {
            using var context = new SmokingCessationContext();
            context.SmokingStatuses.Update(status);
            context.SaveChanges();
        }
    }
}