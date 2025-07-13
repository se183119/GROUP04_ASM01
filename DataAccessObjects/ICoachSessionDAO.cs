using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface ICoachSessionDAO
    {
        List<CoachSession> GetSessionsByMemberId(int memberId);
        List<CoachSession> GetSessionsByCoachId(int coachId);
        CoachSession GetSessionById(int sessionId);
        void CreateSession(CoachSession session);
        void UpdateSession(CoachSession session);
        void DeleteSession(int sessionId);
        List<CoachSession> GetSessionsByStatus(SessionStatus status);
        List<CoachSession> GetSessionsByDateRange(DateTime startDate, DateTime endDate);
    }
}