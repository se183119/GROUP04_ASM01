using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IQuitPlanRepository
    {
        List<QuitPlan> GetQuitPlansByCustomerId(int customerId);
        QuitPlan GetQuitPlanById(int planId);
        void CreateQuitPlan(QuitPlan plan);
        void UpdateQuitPlan(QuitPlan plan);
        void DeleteQuitPlan(int planId);
        QuitPlan GetActiveQuitPlanByCustomerId(int customerId);
        List<QuitPlan> GetQuitPlansByStatus(QuitPlanStatus status);
    }
}