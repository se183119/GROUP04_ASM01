using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateOnly? CustomerBirthday { get; set; }

    public byte? CustomerStatus { get; set; }

    public string? Password { get; set; }

    // New properties for smoking cessation platform
    public UserRole Role { get; set; } = UserRole.Guest;

    public int? MembershipPackageId { get; set; }

    public DateTime? MembershipStartDate { get; set; }

    public DateTime? MembershipEndDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? LastLoginDate { get; set; }

    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();

    // New navigation properties for smoking cessation features
    public virtual MembershipPackage? MembershipPackage { get; set; }

    public virtual ICollection<SmokingStatus> SmokingStatuses { get; set; } = new List<SmokingStatus>();

    public virtual ICollection<QuitPlan> QuitPlans { get; set; } = new List<QuitPlan>();

    public virtual ICollection<ProgressLog> ProgressLogs { get; set; } = new List<ProgressLog>();

    public virtual ICollection<CoachSession> CoachSessions { get; set; } = new List<CoachSession>();

    public virtual ICollection<CoachSession> CoachedSessions { get; set; } = new List<CoachSession>();

    public virtual ICollection<CommunityPost> CommunityPosts { get; set; } = new List<CommunityPost>();

    public virtual ICollection<Rating> GivenRatings { get; set; } = new List<Rating>();

    public virtual ICollection<Rating> ReceivedRatings { get; set; } = new List<Rating>();
}
