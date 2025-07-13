using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface IRatingDAO
    {
        List<Rating> GetRatingsByRaterId(int raterId);
        List<Rating> GetRatingsByRatedUserId(int ratedUserId);
        List<Rating> GetRatingsByCoachSessionId(int sessionId);
        Rating GetRatingById(int ratingId);
        void CreateRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int ratingId);
        List<Rating> GetRatingsByType(RatingType type);
        double GetAverageRatingForUser(int userId);
        double GetAverageRatingForCoach(int coachId);
    }
}