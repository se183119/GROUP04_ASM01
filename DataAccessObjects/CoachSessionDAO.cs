using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class CoachSessionDAO : ICoachSessionDAO
    {
        public void CreateSession(CoachSession session)
        {
            using var context = new SmokingCessationContext();
            context.CoachSessions.Add(session);
            context.SaveChanges();
        }

        public void DeleteSession(int sessionId)
        {
            using var context = new SmokingCessationContext();
            var session = context.CoachSessions.FirstOrDefault(x => x.CoachSessionId == sessionId);
            if (session != null)
            {
                session.Status = SessionStatus.Cancelled;
                context.CoachSessions.Update(session);
                context.SaveChanges();
            }
        }

        public CoachSession GetSessionById(int sessionId)
        {
            using var context = new SmokingCessationContext();
            return context.CoachSessions.FirstOrDefault(x => x.CoachSessionId == sessionId);
        }

        public List<CoachSession> GetSessionsByCoachId(int coachId)
        {
            using var context = new SmokingCessationContext();
            return context.CoachSessions
                .Where(x => x.CoachId == coachId)
                .OrderByDescending(x => x.ScheduledDate)
                .ToList();
        }

        public List<CoachSession> GetSessionsByDateRange(DateTime startDate, DateTime endDate)
        {
            using var context = new SmokingCessationContext();
            return context.CoachSessions
                .Where(x => x.ScheduledDate >= startDate && x.ScheduledDate <= endDate)
                .OrderBy(x => x.ScheduledDate)
                .ToList();
        }

        public List<CoachSession> GetSessionsByMemberId(int memberId)
        {
            using var context = new SmokingCessationContext();
            return context.CoachSessions
                .Where(x => x.MemberId == memberId)
                .OrderByDescending(x => x.ScheduledDate)
                .ToList();
        }

        public List<CoachSession> GetSessionsByStatus(SessionStatus status)
        {
            using var context = new SmokingCessationContext();
            return context.CoachSessions
                .Where(x => x.Status == status)
                .OrderBy(x => x.ScheduledDate)
                .ToList();
        }

        public void UpdateSession(CoachSession session)
        {
            using var context = new SmokingCessationContext();
            context.CoachSessions.Update(session);
            context.SaveChanges();
        }
    }
}