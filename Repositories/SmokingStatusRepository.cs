using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class SmokingStatusRepository : ISmokingStatusRepository
    {
        private readonly ISmokingStatusDAO _smokingStatusDao;

        public SmokingStatusRepository()
        {
            _smokingStatusDao = new SmokingStatusDAO();
        }

        public void CreateSmokingStatus(SmokingStatus status)
        {
            _smokingStatusDao.CreateSmokingStatus(status);
        }

        public void DeleteSmokingStatus(int statusId)
        {
            _smokingStatusDao.DeleteSmokingStatus(statusId);
        }

        public SmokingStatus GetLatestSmokingStatusByCustomerId(int customerId)
        {
            return _smokingStatusDao.GetLatestSmokingStatusByCustomerId(customerId);
        }

        public SmokingStatus GetSmokingStatusById(int statusId)
        {
            return _smokingStatusDao.GetSmokingStatusById(statusId);
        }

        public List<SmokingStatus> GetSmokingStatusesByCustomerId(int customerId)
        {
            return _smokingStatusDao.GetSmokingStatusesByCustomerId(customerId);
        }

        public void UpdateSmokingStatus(SmokingStatus status)
        {
            _smokingStatusDao.UpdateSmokingStatus(status);
        }
    }
}