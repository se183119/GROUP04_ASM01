using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class MembershipPackage
    {
        public int MembershipPackageId { get; set; }

        public string PackageName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int DurationInDays { get; set; }

        public string? Features { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}