using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class RatingDAO : IRatingDAO
    {
        public void CreateRating(Rating rating)
        {
            using var context = new SmokingCessationContext();
            context.Ratings.Add(rating);
            context.SaveChanges();
        }

        public void DeleteRating(int ratingId)
        {
            using var context = new SmokingCessationContext();
            var rating = context.Ratings.FirstOrDefault(x => x.RatingId == ratingId);
            if (rating != null)
            {
                context.Ratings.Remove(rating);
                context.SaveChanges();
            }
        }

        public double GetAverageRatingForCoach(int coachId)
        {
            using var context = new SmokingCessationContext();
            var ratings = context.Ratings
                .Where(x => x.RatedUserId == coachId && x.Type == RatingType.Coach)
                .Select(x => x.Score)
                .ToList();
            
            return ratings.Any() ? ratings.Average() : 0.0;
        }

        public double GetAverageRatingForUser(int userId)
        {
            using var context = new SmokingCessationContext();
            var ratings = context.Ratings
                .Where(x => x.RatedUserId == userId)
                .Select(x => x.Score)
                .ToList();
            
            return ratings.Any() ? ratings.Average() : 0.0;
        }

        public Rating GetRatingById(int ratingId)
        {
            using var context = new SmokingCessationContext();
            return context.Ratings.FirstOrDefault(x => x.RatingId == ratingId);
        }

        public List<Rating> GetRatingsByCoachSessionId(int sessionId)
        {
            using var context = new SmokingCessationContext();
            return context.Ratings
                .Where(x => x.CoachSessionId == sessionId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<Rating> GetRatingsByRatedUserId(int ratedUserId)
        {
            using var context = new SmokingCessationContext();
            return context.Ratings
                .Where(x => x.RatedUserId == ratedUserId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<Rating> GetRatingsByRaterId(int raterId)
        {
            using var context = new SmokingCessationContext();
            return context.Ratings
                .Where(x => x.RaterId == raterId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<Rating> GetRatingsByType(RatingType type)
        {
            using var context = new SmokingCessationContext();
            return context.Ratings
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public void UpdateRating(Rating rating)
        {
            using var context = new SmokingCessationContext();
            context.Ratings.Update(rating);
            context.SaveChanges();
        }
    }
}