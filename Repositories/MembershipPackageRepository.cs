using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class MembershipPackageRepository : IMembershipPackageRepository
    {
        private readonly IMembershipPackageDAO _membershipPackageDao;

        public MembershipPackageRepository()
        {
            _membershipPackageDao = new MembershipPackageDAO();
        }

        public void CreateMembershipPackage(MembershipPackage package)
        {
            _membershipPackageDao.CreateMembershipPackage(package);
        }

        public void DeleteMembershipPackage(int packageId)
        {
            _membershipPackageDao.DeleteMembershipPackage(packageId);
        }

        public List<MembershipPackage> GetActiveMembershipPackages()
        {
            return _membershipPackageDao.GetActiveMembershipPackages();
        }

        public List<MembershipPackage> GetAllMembershipPackages()
        {
            return _membershipPackageDao.GetAllMembershipPackages();
        }

        public MembershipPackage GetMembershipPackageById(int packageId)
        {
            return _membershipPackageDao.GetMembershipPackageById(packageId);
        }

        public void UpdateMembershipPackage(MembershipPackage package)
        {
            _membershipPackageDao.UpdateMembershipPackage(package);
        }
    }
}