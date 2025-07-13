using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class MembershipPackageDAO : IMembershipPackageDAO
    {
        public void CreateMembershipPackage(MembershipPackage package)
        {
            using var context = new SmokingCessationContext();
            context.MembershipPackages.Add(package);
            context.SaveChanges();
        }

        public void DeleteMembershipPackage(int packageId)
        {
            using var context = new SmokingCessationContext();
            var package = context.MembershipPackages.FirstOrDefault(x => x.MembershipPackageId == packageId);
            if (package != null)
            {
                package.IsActive = false;
                context.MembershipPackages.Update(package);
                context.SaveChanges();
            }
        }

        public List<MembershipPackage> GetActiveMembershipPackages()
        {
            using var context = new SmokingCessationContext();
            return context.MembershipPackages
                .Where(x => x.IsActive)
                .OrderBy(x => x.Price)
                .ToList();
        }

        public List<MembershipPackage> GetAllMembershipPackages()
        {
            using var context = new SmokingCessationContext();
            return context.MembershipPackages.ToList();
        }

        public MembershipPackage GetMembershipPackageById(int packageId)
        {
            using var context = new SmokingCessationContext();
            return context.MembershipPackages.FirstOrDefault(x => x.MembershipPackageId == packageId);
        }

        public void UpdateMembershipPackage(MembershipPackage package)
        {
            using var context = new SmokingCessationContext();
            package.ModifiedDate = DateTime.Now;
            context.MembershipPackages.Update(package);
            context.SaveChanges();
        }
    }
}