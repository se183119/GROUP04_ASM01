using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class QuitPlanDAO : IQuitPlanDAO
    {
        public void CreateQuitPlan(QuitPlan plan)
        {
            using var context = new SmokingCessationContext();
            context.QuitPlans.Add(plan);
            context.SaveChanges();
        }

        public void DeleteQuitPlan(int planId)
        {
            using var context = new SmokingCessationContext();
            var plan = context.QuitPlans.FirstOrDefault(x => x.QuitPlanId == planId);
            if (plan != null)
            {
                plan.Status = QuitPlanStatus.Cancelled;
                context.QuitPlans.Update(plan);
                context.SaveChanges();
            }
        }

        public QuitPlan GetActiveQuitPlanByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.QuitPlans
                .Where(x => x.CustomerId == customerId && x.Status == QuitPlanStatus.Active)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefault();
        }

        public QuitPlan GetQuitPlanById(int planId)
        {
            using var context = new SmokingCessationContext();
            return context.QuitPlans.FirstOrDefault(x => x.QuitPlanId == planId);
        }

        public List<QuitPlan> GetQuitPlansByCustomerId(int customerId)
        {
            using var context = new SmokingCessationContext();
            return context.QuitPlans
                .Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<QuitPlan> GetQuitPlansByStatus(QuitPlanStatus status)
        {
            using var context = new SmokingCessationContext();
            return context.QuitPlans
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public void UpdateQuitPlan(QuitPlan plan)
        {
            using var context = new SmokingCessationContext();
            plan.ModifiedDate = DateTime.Now;
            context.QuitPlans.Update(plan);
            context.SaveChanges();
        }
    }
}