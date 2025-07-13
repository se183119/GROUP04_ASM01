USE [master]
GO

-- Create the Smoking Cessation Support Platform Database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SmokingCessationPlatform')
BEGIN
    CREATE DATABASE [SmokingCessationPlatform]
END
GO

USE [SmokingCessationPlatform]
GO

-- Create MembershipPackage table
CREATE TABLE [dbo].[MembershipPackage](
    [MembershipPackageID] [int] IDENTITY(1,1) NOT NULL,
    [PackageName] [nvarchar](100) NOT NULL,
    [Description] [nvarchar](500) NULL,
    [Price] [money] NOT NULL,
    [DurationInDays] [int] NOT NULL,
    [Features] [nvarchar](1000) NULL,
    [IsActive] [bit] NOT NULL DEFAULT 1,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime2] NULL,
    CONSTRAINT [PK_MembershipPackage] PRIMARY KEY CLUSTERED ([MembershipPackageID] ASC)
)
GO

-- Create enhanced Customer table (User table for the platform)
CREATE TABLE [dbo].[Customer](
    [CustomerID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerFullName] [nvarchar](50) NULL,
    [Telephone] [nvarchar](12) NULL,
    [EmailAddress] [nvarchar](50) NOT NULL,
    [CustomerBirthday] [date] NULL,
    [CustomerStatus] [tinyint] NULL DEFAULT 1,
    [Password] [nvarchar](50) NULL,
    [Role] [int] NOT NULL DEFAULT 0, -- 0=Guest, 1=Member, 2=Coach, 3=Admin
    [MembershipPackageID] [int] NULL,
    [MembershipStartDate] [datetime2] NULL,
    [MembershipEndDate] [datetime2] NULL,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [LastLoginDate] [datetime2] NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    CONSTRAINT [UQ_Customer_EmailAddress] UNIQUE ([EmailAddress]),
    CONSTRAINT [FK_Customer_MembershipPackage] FOREIGN KEY([MembershipPackageID]) REFERENCES [dbo].[MembershipPackage] ([MembershipPackageID])
)
GO

-- Create SmokingStatus table
CREATE TABLE [dbo].[SmokingStatus](
    [SmokingStatusID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerID] [int] NOT NULL,
    [CigarettesPerDay] [int] NOT NULL,
    [MoneySpentPerDay] [money] NOT NULL,
    [SmokingTriggers] [nvarchar](500) NULL,
    [SmokingTimes] [nvarchar](500) NULL,
    [FrequencyPattern] [nvarchar](200) NULL,
    [RecordedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [Notes] [nvarchar](1000) NULL,
    CONSTRAINT [PK_SmokingStatus] PRIMARY KEY CLUSTERED ([SmokingStatusID] ASC),
    CONSTRAINT [FK_SmokingStatus_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

-- Create QuitPlan table
CREATE TABLE [dbo].[QuitPlan](
    [QuitPlanID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerID] [int] NOT NULL,
    [PlanName] [nvarchar](100) NOT NULL,
    [PersonalReasons] [nvarchar](1000) NULL,
    [StartDate] [datetime2] NOT NULL,
    [TargetQuitDate] [datetime2] NOT NULL,
    [Strategies] [nvarchar](1000) NULL,
    [CopingMechanisms] [nvarchar](1000) NULL,
    [Status] [int] NOT NULL DEFAULT 1, -- 1=Active, 2=Paused, 3=Completed, 4=Cancelled
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime2] NULL,
    [Notes] [nvarchar](1000) NULL,
    CONSTRAINT [PK_QuitPlan] PRIMARY KEY CLUSTERED ([QuitPlanID] ASC),
    CONSTRAINT [FK_QuitPlan_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

-- Create ProgressLog table
CREATE TABLE [dbo].[ProgressLog](
    [ProgressLogID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerID] [int] NOT NULL,
    [QuitPlanID] [int] NULL,
    [LogDate] [datetime2] NOT NULL,
    [SmokingIncidents] [int] NOT NULL DEFAULT 0,
    [MoodLevel] [int] NOT NULL, -- 1=VeryBad, 2=Bad, 3=Neutral, 4=Good, 5=VeryGood
    [StressLevel] [int] NOT NULL, -- 1=VeryLow, 2=Low, 3=Moderate, 4=High, 5=VeryHigh
    [CravingIntensity] [int] NOT NULL, -- 0=None, 1=VeryLow, 2=Low, 3=Moderate, 4=High, 5=VeryHigh
    [HealthImprovements] [nvarchar](1000) NULL,
    [Notes] [nvarchar](1000) NULL,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_ProgressLog] PRIMARY KEY CLUSTERED ([ProgressLogID] ASC),
    CONSTRAINT [FK_ProgressLog_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_ProgressLog_QuitPlan] FOREIGN KEY([QuitPlanID]) REFERENCES [dbo].[QuitPlan] ([QuitPlanID])
)
GO

-- Create Achievement table
CREATE TABLE [dbo].[Achievement](
    [AchievementID] [int] IDENTITY(1,1) NOT NULL,
    [AchievementName] [nvarchar](100) NOT NULL,
    [Description] [nvarchar](500) NULL,
    [Type] [int] NOT NULL, -- 1=SmokeFree, 2=MoneySaved, 3=HealthImprovement, 4=Streak, 5=Community
    [Criteria] [nvarchar](500) NULL,
    [RequiredValue] [int] NOT NULL,
    [BadgeIcon] [nvarchar](200) NULL,
    [IsActive] [bit] NOT NULL DEFAULT 1,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED ([AchievementID] ASC)
)
GO

-- Create Badge table
CREATE TABLE [dbo].[Badge](
    [BadgeID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerID] [int] NOT NULL,
    [AchievementID] [int] NOT NULL,
    [EarnedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [Notes] [nvarchar](500) NULL,
    [IsShared] [bit] NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Badge] PRIMARY KEY CLUSTERED ([BadgeID] ASC),
    CONSTRAINT [FK_Badge_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_Badge_Achievement] FOREIGN KEY([AchievementID]) REFERENCES [dbo].[Achievement] ([AchievementID])
)
GO

-- Create Notification table
CREATE TABLE [dbo].[Notification](
    [NotificationID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerID] [int] NOT NULL,
    [Title] [nvarchar](200) NOT NULL,
    [Message] [nvarchar](1000) NOT NULL,
    [Type] [int] NOT NULL, -- 1=Daily, 2=Weekly, 3=Motivational, 4=Achievement, 5=CravingSupport, 6=QuitReminder
    [Status] [int] NOT NULL DEFAULT 1, -- 1=Pending, 2=Sent, 3=Read, 4=Dismissed
    [ScheduledDate] [datetime2] NOT NULL,
    [SentDate] [datetime2] NULL,
    [ReadDate] [datetime2] NULL,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationID] ASC),
    CONSTRAINT [FK_Notification_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

-- Create CoachSession table
CREATE TABLE [dbo].[CoachSession](
    [CoachSessionID] [int] IDENTITY(1,1) NOT NULL,
    [MemberID] [int] NOT NULL,
    [CoachID] [int] NOT NULL,
    [ScheduledDate] [datetime2] NOT NULL,
    [StartTime] [datetime2] NULL,
    [EndTime] [datetime2] NULL,
    [Status] [int] NOT NULL DEFAULT 1, -- 1=Scheduled, 2=InProgress, 3=Completed, 4=Cancelled, 5=NoShow
    [Notes] [nvarchar](1000) NULL,
    [CoachNotes] [nvarchar](1000) NULL,
    [Recommendations] [nvarchar](1000) NULL,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_CoachSession] PRIMARY KEY CLUSTERED ([CoachSessionID] ASC),
    CONSTRAINT [FK_CoachSession_Member] FOREIGN KEY([MemberID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_CoachSession_Coach] FOREIGN KEY([CoachID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

-- Create CommunityPost table
CREATE TABLE [dbo].[CommunityPost](
    [CommunityPostID] [int] IDENTITY(1,1) NOT NULL,
    [AuthorID] [int] NOT NULL,
    [Title] [nvarchar](200) NOT NULL,
    [Content] [nvarchar](2000) NOT NULL,
    [Type] [int] NOT NULL, -- 1=General, 2=SuccessStory, 3=Question, 4=Achievement, 5=Experience, 6=Advice
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime2] NULL,
    [IsActive] [bit] NOT NULL DEFAULT 1,
    [LikesCount] [int] NOT NULL DEFAULT 0,
    [CommentsCount] [int] NOT NULL DEFAULT 0,
    CONSTRAINT [PK_CommunityPost] PRIMARY KEY CLUSTERED ([CommunityPostID] ASC),
    CONSTRAINT [FK_CommunityPost_Author] FOREIGN KEY([AuthorID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

-- Create Rating table
CREATE TABLE [dbo].[Rating](
    [RatingID] [int] IDENTITY(1,1) NOT NULL,
    [RaterID] [int] NOT NULL,
    [RatedUserID] [int] NULL,
    [CoachSessionID] [int] NULL,
    [Type] [int] NOT NULL, -- 1=Coach, 2=Platform, 3=CoachSession
    [Score] [int] NOT NULL, -- 1-5 stars
    [Comment] [nvarchar](1000) NULL,
    [CreatedDate] [datetime2] NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED ([RatingID] ASC),
    CONSTRAINT [FK_Rating_Rater] FOREIGN KEY([RaterID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_Rating_RatedUser] FOREIGN KEY([RatedUserID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_Rating_CoachSession] FOREIGN KEY([CoachSessionID]) REFERENCES [dbo].[CoachSession] ([CoachSessionID]),
    CONSTRAINT [CK_Rating_Score] CHECK ([Score] >= 1 AND [Score] <= 5)
)
GO

-- Legacy tables for backward compatibility (keeping existing hotel management structure)
CREATE TABLE [dbo].[RoomType](
    [RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
    [RoomTypeName] [nvarchar](50) NOT NULL,
    [TypeDescription] [nvarchar](250) NULL,
    [TypeNote] [nvarchar](250) NULL,
    CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED ([RoomTypeID] ASC)
)
GO

CREATE TABLE [dbo].[RoomInformation](
    [RoomID] [int] IDENTITY(1,1) NOT NULL,
    [RoomNumber] [nvarchar](50) NOT NULL,
    [RoomDetailDescription] [nvarchar](220) NULL,
    [RoomMaxCapacity] [int] NULL,
    [RoomTypeID] [int] NOT NULL,
    [RoomStatus] [tinyint] NULL,
    [RoomPricePerDay] [money] NULL,
    CONSTRAINT [PK_RoomInformation] PRIMARY KEY CLUSTERED ([RoomID] ASC),
    CONSTRAINT [FK_RoomInformation_RoomType] FOREIGN KEY([RoomTypeID]) REFERENCES [dbo].[RoomType] ([RoomTypeID])
)
GO

CREATE TABLE [dbo].[BookingReservation](
    [BookingReservationID] [int] IDENTITY(1,1) NOT NULL,
    [BookingDate] [date] NULL,
    [TotalPrice] [money] NULL,
    [CustomerID] [int] NOT NULL,
    [BookingStatus] [tinyint] NULL,
    CONSTRAINT [PK_BookingReservation] PRIMARY KEY CLUSTERED ([BookingReservationID] ASC),
    CONSTRAINT [FK_BookingReservation_Customer] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
)
GO

CREATE TABLE [dbo].[BookingDetail](
    [BookingReservationID] [int] NOT NULL,
    [RoomID] [int] NOT NULL,
    [StartDate] [date] NOT NULL,
    [EndDate] [date] NOT NULL,
    [ActualPrice] [money] NULL,
    CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED ([BookingReservationID] ASC, [RoomID] ASC),
    CONSTRAINT [FK_BookingDetail_BookingReservation] FOREIGN KEY([BookingReservationID]) REFERENCES [dbo].[BookingReservation] ([BookingReservationID]),
    CONSTRAINT [FK_BookingDetail_RoomInformation] FOREIGN KEY([RoomID]) REFERENCES [dbo].[RoomInformation] ([RoomID])
)
GO

-- Insert default membership packages
INSERT INTO [dbo].[MembershipPackage] 
    ([PackageName], [Description], [Price], [DurationInDays], [Features], [IsActive]) 
VALUES 
    ('Basic Plan', 'Essential features for starting your quit smoking journey', 29.99, 30, 'Progress tracking, Basic notifications, Achievement system', 1),
    ('Premium Plan', 'Enhanced support with coach consultation', 79.99, 90, 'All Basic features, Coach consultation (2 sessions), Community access, Advanced analytics', 1),
    ('VIP Plan', 'Complete support system with unlimited coach access', 149.99, 180, 'All Premium features, Unlimited coach sessions, Priority support, Personalized meal plans', 1);

-- Insert default achievements
INSERT INTO [dbo].[Achievement] 
    ([AchievementName], [Description], [Type], [Criteria], [RequiredValue], [BadgeIcon], [IsActive]) 
VALUES 
    ('First Day Smoke-Free', 'Congratulations on your first day without smoking!', 1, 'Complete 1 day without smoking', 1, '🌟', 1),
    ('One Week Strong', 'You have successfully completed one week smoke-free!', 1, 'Complete 7 days without smoking', 7, '🏆', 1),
    ('One Month Champion', 'An amazing achievement - one month smoke-free!', 1, 'Complete 30 days without smoking', 30, '👑', 1),
    ('Money Saver Beginner', 'You have saved your first $100!', 2, 'Save $100 from not smoking', 100, '💰', 1),
    ('Money Saver Pro', 'You have saved $500 from not smoking!', 2, 'Save $500 from not smoking', 500, '💎', 1),
    ('Health Warrior', 'Your health improvements are showing!', 3, 'Log health improvements for 7 days', 7, '❤️', 1),
    ('Community Helper', 'You have helped fellow members with your posts!', 5, 'Create 5 helpful community posts', 5, '🤝', 1);

-- Insert default admin user
INSERT INTO [dbo].[Customer] 
    ([CustomerFullName], [EmailAddress], [Password], [Role], [CustomerStatus]) 
VALUES 
    ('System Administrator', 'admin@smokingcessation.com', '@@abc123@@', 3, 1);

-- Insert sample coach
INSERT INTO [dbo].[Customer] 
    ([CustomerFullName], [EmailAddress], [Password], [Role], [CustomerStatus], [Telephone]) 
VALUES 
    ('Dr. Sarah Johnson', 'coach.sarah@smokingcessation.com', 'coach123', 2, 1, '1234567890');

GO