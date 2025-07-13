using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BusinessObjects;

public partial class SmokingCessationContext : DbContext
{
    public SmokingCessationContext()
    {
    }

    public SmokingCessationContext(DbContextOptions<SmokingCessationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<BookingReservation> BookingReservations { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<RoomInformation> RoomInformations { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    // New entities for smoking cessation platform
    public virtual DbSet<MembershipPackage> MembershipPackages { get; set; }

    public virtual DbSet<SmokingStatus> SmokingStatuses { get; set; }

    public virtual DbSet<QuitPlan> QuitPlans { get; set; }

    public virtual DbSet<ProgressLog> ProgressLogs { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<CoachSession> CoachSessions { get; set; }

    public virtual DbSet<CommunityPost> CommunityPosts { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => new { e.BookingReservationId, e.RoomId });

            entity.ToTable("BookingDetail");

            entity.Property(e => e.BookingReservationId).HasColumnName("BookingReservationID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.ActualPrice).HasColumnType("money");

            entity.HasOne(d => d.BookingReservation).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingReservationId)
                .HasConstraintName("FK_BookingDetail_BookingReservation");

            entity.HasOne(d => d.Room).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_BookingDetail_RoomInformation");
        });

        modelBuilder.Entity<BookingReservation>(entity =>
        {
            entity.ToTable("BookingReservation");

            entity.Property(e => e.BookingReservationId)
                .ValueGeneratedNever()
                .HasColumnName("BookingReservationID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.BookingReservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_BookingReservation_Customer");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.EmailAddress, "UQ__Customer__49A147400A55F085").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerFullName).HasMaxLength(50);
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(12);
            entity.Property(e => e.Role).HasConversion<int>();

            entity.HasOne(d => d.MembershipPackage).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MembershipPackageId)
                .HasConstraintName("FK_Customer_MembershipPackage");
        });

        modelBuilder.Entity<RoomInformation>(entity =>
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("RoomInformation");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.RoomDetailDescription).HasMaxLength(220);
            entity.Property(e => e.RoomNumber).HasMaxLength(50);
            entity.Property(e => e.RoomPricePerDay).HasColumnType("money");
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

            entity.HasOne(d => d.RoomType).WithMany(p => p.RoomInformations)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_RoomInformation_RoomType");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
            entity.Property(e => e.RoomTypeName).HasMaxLength(50);
            entity.Property(e => e.TypeDescription).HasMaxLength(250);
            entity.Property(e => e.TypeNote).HasMaxLength(250);
        });

        // Configuration for new smoking cessation entities
        modelBuilder.Entity<MembershipPackage>(entity =>
        {
            entity.ToTable("MembershipPackage");

            entity.Property(e => e.MembershipPackageId).HasColumnName("MembershipPackageID");
            entity.Property(e => e.PackageName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Features).HasMaxLength(1000);
        });

        modelBuilder.Entity<SmokingStatus>(entity =>
        {
            entity.ToTable("SmokingStatus");

            entity.Property(e => e.SmokingStatusId).HasColumnName("SmokingStatusID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.MoneySpentPerDay).HasColumnType("money");
            entity.Property(e => e.SmokingTriggers).HasMaxLength(500);
            entity.Property(e => e.SmokingTimes).HasMaxLength(500);
            entity.Property(e => e.FrequencyPattern).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(d => d.Customer).WithMany(p => p.SmokingStatuses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_SmokingStatus_Customer");
        });

        modelBuilder.Entity<QuitPlan>(entity =>
        {
            entity.ToTable("QuitPlan");

            entity.Property(e => e.QuitPlanId).HasColumnName("QuitPlanID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PlanName).HasMaxLength(100);
            entity.Property(e => e.PersonalReasons).HasMaxLength(1000);
            entity.Property(e => e.Strategies).HasMaxLength(1000);
            entity.Property(e => e.CopingMechanisms).HasMaxLength(1000);
            entity.Property(e => e.Status).HasConversion<int>();
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(d => d.Customer).WithMany(p => p.QuitPlans)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_QuitPlan_Customer");
        });

        modelBuilder.Entity<ProgressLog>(entity =>
        {
            entity.ToTable("ProgressLog");

            entity.Property(e => e.ProgressLogId).HasColumnName("ProgressLogID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.QuitPlanId).HasColumnName("QuitPlanID");
            entity.Property(e => e.MoodLevel).HasConversion<int>();
            entity.Property(e => e.StressLevel).HasConversion<int>();
            entity.Property(e => e.CravingIntensity).HasConversion<int>();
            entity.Property(e => e.HealthImprovements).HasMaxLength(1000);
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(d => d.Customer).WithMany(p => p.ProgressLogs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ProgressLog_Customer");

            entity.HasOne(d => d.QuitPlan).WithMany(p => p.ProgressLogs)
                .HasForeignKey(d => d.QuitPlanId)
                .HasConstraintName("FK_ProgressLog_QuitPlan");
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.AchievementName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Type).HasConversion<int>();
            entity.Property(e => e.Criteria).HasMaxLength(500);
            entity.Property(e => e.BadgeIcon).HasMaxLength(200);
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.ToTable("Badge");

            entity.Property(e => e.BadgeId).HasColumnName("BadgeID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Badge_Customer");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Badges)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK_Badge_Achievement");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Message).HasMaxLength(1000);
            entity.Property(e => e.Type).HasConversion<int>();
            entity.Property(e => e.Status).HasConversion<int>();

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Notification_Customer");
        });

        modelBuilder.Entity<CoachSession>(entity =>
        {
            entity.ToTable("CoachSession");

            entity.Property(e => e.CoachSessionId).HasColumnName("CoachSessionID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.Status).HasConversion<int>();
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.CoachNotes).HasMaxLength(1000);
            entity.Property(e => e.Recommendations).HasMaxLength(1000);

            entity.HasOne(d => d.Member).WithMany(p => p.CoachSessions)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_CoachSession_Member");

            entity.HasOne(d => d.Coach).WithMany(p => p.CoachedSessions)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK_CoachSession_Coach");
        });

        modelBuilder.Entity<CommunityPost>(entity =>
        {
            entity.ToTable("CommunityPost");

            entity.Property(e => e.CommunityPostId).HasColumnName("CommunityPostID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.Type).HasConversion<int>();

            entity.HasOne(d => d.Author).WithMany(p => p.CommunityPosts)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_CommunityPost_Author");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");

            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.RaterId).HasColumnName("RaterID");
            entity.Property(e => e.RatedUserId).HasColumnName("RatedUserID");
            entity.Property(e => e.CoachSessionId).HasColumnName("CoachSessionID");
            entity.Property(e => e.Type).HasConversion<int>();
            entity.Property(e => e.Comment).HasMaxLength(1000);

            entity.HasOne(d => d.Rater).WithMany(p => p.GivenRatings)
                .HasForeignKey(d => d.RaterId)
                .HasConstraintName("FK_Rating_Rater");

            entity.HasOne(d => d.RatedUser).WithMany(p => p.ReceivedRatings)
                .HasForeignKey(d => d.RatedUserId)
                .HasConstraintName("FK_Rating_RatedUser");

            entity.HasOne(d => d.CoachSession).WithMany()
                .HasForeignKey(d => d.CoachSessionId)
                .HasConstraintName("FK_Rating_CoachSession");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
