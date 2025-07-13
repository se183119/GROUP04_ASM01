using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IMembershipPackageRepository
    {
        List<MembershipPackage> GetAllMembershipPackages();
        MembershipPackage GetMembershipPackageById(int packageId);
        void CreateMembershipPackage(MembershipPackage package);
        void UpdateMembershipPackage(MembershipPackage package);
        void DeleteMembershipPackage(int packageId);
        List<MembershipPackage> GetActiveMembershipPackages();
    }
}