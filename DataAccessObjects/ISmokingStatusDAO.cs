using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface ISmokingStatusDAO
    {
        List<SmokingStatus> GetSmokingStatusesByCustomerId(int customerId);
        SmokingStatus GetSmokingStatusById(int statusId);
        void CreateSmokingStatus(SmokingStatus status);
        void UpdateSmokingStatus(SmokingStatus status);
        void DeleteSmokingStatus(int statusId);
        SmokingStatus GetLatestSmokingStatusByCustomerId(int customerId);
    }
}