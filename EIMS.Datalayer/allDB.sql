drop database EIMS
go

USE [master]
GO
/****** Object:  Database [EIMS]    Script Date: 18.03.2016 0:10:35 ******/
CREATE DATABASE [EIMS]

GO
ALTER DATABASE [EIMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EIMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EIMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EIMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EIMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EIMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EIMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [EIMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EIMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EIMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EIMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EIMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EIMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EIMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EIMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EIMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EIMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EIMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EIMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EIMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EIMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EIMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EIMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EIMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EIMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EIMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EIMS] SET  MULTI_USER 
GO
ALTER DATABASE [EIMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EIMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EIMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EIMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EIMS]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseFill]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseFill](
	[courseFillID] [int] IDENTITY(1,1) NOT NULL,
	[courseID] [int] NOT NULL,
	[subjectID] [int] NOT NULL,
	[subjectHoursPerWeek] [int] NOT NULL,
 CONSTRAINT [PK_CourseFill] PRIMARY KEY CLUSTERED 
(
	[courseFillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DayOfWeek]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayOfWeek](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_DayOfWeek] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EIMSUser]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIMSUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime2](7) NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_EIMSUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UX_User_EMail] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[facultyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[facultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupCourse]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupCourse](
	[groupCourseID] [int] IDENTITY(1,1) NOT NULL,
	[courseID] [int] NOT NULL,
	[groupID] [int] NOT NULL,
	[startDate] [datetime] NULL,
	[endDate] [datetime] NULL,
 CONSTRAINT [PK_GroupCourse] PRIMARY KEY CLUSTERED 
(
	[groupCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[lessonID] [bigint] IDENTITY(1,1) NOT NULL,
	[subjectID] [int] NOT NULL,
	[groupID] [int] NOT NULL,
	[teacherID] [bigint] NOT NULL,
	[roomID] [int] NOT NULL,
	[LessonOrder] [int] NOT NULL,
	[DayOfWeek] [tinyint] NOT NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[lessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LessonDate]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonDate](
	[lessonDateID] [bigint] IDENTITY(1,1) NOT NULL,
	[lessonID] [bigint] NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_LessonDate] PRIMARY KEY CLUSTERED 
(
	[lessonDateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LessonOrder]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TimeStart] [time](7) NOT NULL,
	[TimeEnd] [time](7) NOT NULL,
 CONSTRAINT [PK_LessonOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LessonPresence]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonPresence](
	[lessonPresenceID] [bigint] NOT NULL IDENTITY,
	[lessonDateID] [bigint] NOT NULL,
	[studentID] [bigint] NOT NULL,
	[presence] [bit] NOT NULL,
	[mark] [tinyint] NULL,
 CONSTRAINT [PK_LessonPresence] PRIMARY KEY CLUSTERED 
(
	[lessonPresenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomID] [int] IDENTITY(1,1) NOT NULL,
	[roomNo] [nvarchar](20) NOT NULL,
	[capacity] [smallint] NOT NULL,
	[isAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomPossibility]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomPossibility](
	[RoomId] [int] NOT NULL,
	[ReqID] [int] NOT NULL,
 CONSTRAINT [PK_RoomPossibility] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC,
	[ReqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SRRequirement]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SRRequirement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Requirement] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SRRequirement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentGroup]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentGroup](
	[studentGroupID] [int] IDENTITY(1,1) NOT NULL,
	[groupID] [int] NOT NULL,
	[studentID] [bigint] NOT NULL,
	[enrollmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentGroup_1] PRIMARY KEY CLUSTERED 
(
	[studentGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[subjectID] [int] IDENTITY(1,1) NOT NULL,
	[subjectName] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[subjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectRequirements]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectRequirements](
	[SubjectID] [int] NOT NULL,
	[ReqID] [int] NOT NULL,
 CONSTRAINT [PK_SubjectRequirements] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC,
	[ReqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[taskID] [bigint] IDENTITY(1,1) NOT NULL,
	[lessonDateID] [bigint] NOT NULL,
	[homeTask] [nvarchar](3072) NULL,
	[expiryDate] [date] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[taskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[subjectID] [int] NOT NULL,
	[teacherID] [bigint] NOT NULL,
 CONSTRAINT [PK_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[subjectID] ASC,
	[teacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UniversityGroup]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UniversityGroup](
	[groupID] [int] IDENTITY(1,1) NOT NULL,
	[groupName] [nvarchar](50) NOT NULL,
	[supervisorID] [bigint] NULL,
	[creationDate] [date] NOT NULL,
	[elderID] [bigint] NULL,
	[facultyID] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[groupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [bigint] NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 18.03.2016 0:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CourseFill] ADD  CONSTRAINT [DF_CourseFill_subjectHoursPerWeek]  DEFAULT ((1)) FOR [subjectHoursPerWeek]
GO
ALTER TABLE [dbo].[EIMSUser] ADD  CONSTRAINT [DF_User_AccessFailCount]  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[EIMSUser] ADD  CONSTRAINT [DF_User_EmailConfirmed]  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[EIMSUser] ADD  CONSTRAINT [DF_User_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[EIMSUser] ADD  CONSTRAINT [DF_User_PhoneNumberConfirmed]  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
GO
ALTER TABLE [dbo].[EIMSUser] ADD  CONSTRAINT [DF_User_TwoFactorEnabled]  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[LessonPresence] ADD  CONSTRAINT [DF_LessonPresence_presence]  DEFAULT ((0)) FOR [presence]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_isAvailable]  DEFAULT ((1)) FOR [isAvailable]
GO
ALTER TABLE [dbo].[CourseFill]  WITH CHECK ADD  CONSTRAINT [FK_Course_Subject] FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subject] ([subjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseFill] CHECK CONSTRAINT [FK_Course_Subject]
GO
ALTER TABLE [dbo].[CourseFill]  WITH CHECK ADD  CONSTRAINT [FK_CourseFill_Course] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([courseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseFill] CHECK CONSTRAINT [FK_CourseFill_Course]
GO
ALTER TABLE [dbo].[GroupCourse]  WITH CHECK ADD  CONSTRAINT [FK_GroupCourse_Course] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([courseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupCourse] CHECK CONSTRAINT [FK_GroupCourse_Course]
GO
ALTER TABLE [dbo].[GroupCourse]  WITH CHECK ADD  CONSTRAINT [FK_GroupCourse_Group] FOREIGN KEY([groupID])
REFERENCES [dbo].[UniversityGroup] ([groupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupCourse] CHECK CONSTRAINT [FK_GroupCourse_Group]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_DayOfWeek] FOREIGN KEY([DayOfWeek])
REFERENCES [dbo].[DayOfWeek] ([ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_DayOfWeek]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_EIMSUser] FOREIGN KEY([teacherID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_EIMSUser]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Group] FOREIGN KEY([groupID])
REFERENCES [dbo].[UniversityGroup] ([groupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Group]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_LessonOrder] FOREIGN KEY([LessonOrder])
REFERENCES [dbo].[LessonOrder] ([ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_LessonOrder]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Room] FOREIGN KEY([roomID])
REFERENCES [dbo].[Room] ([roomID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Room]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Subject] FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subject] ([subjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Subject]
GO
ALTER TABLE [dbo].[LessonDate]  WITH CHECK ADD  CONSTRAINT [FK_LessonDate_Lesson] FOREIGN KEY([lessonID])
REFERENCES [dbo].[Lesson] ([lessonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LessonDate] CHECK CONSTRAINT [FK_LessonDate_Lesson]
GO
ALTER TABLE [dbo].[LessonPresence]  WITH CHECK ADD  CONSTRAINT [FK_LessonPresence_EIMSUser] FOREIGN KEY([studentID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[LessonPresence] CHECK CONSTRAINT [FK_LessonPresence_EIMSUser]
GO
ALTER TABLE [dbo].[LessonPresence]  WITH CHECK ADD  CONSTRAINT [FK_LessonPresence_LessonDate] FOREIGN KEY([lessonDateID])
REFERENCES [dbo].[LessonDate] ([lessonDateID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LessonPresence] CHECK CONSTRAINT [FK_LessonPresence_LessonDate]
GO
ALTER TABLE [dbo].[RoomPossibility]  WITH CHECK ADD  CONSTRAINT [FK_RoomPossibility_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([roomID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomPossibility] CHECK CONSTRAINT [FK_RoomPossibility_Room]
GO
ALTER TABLE [dbo].[RoomPossibility]  WITH CHECK ADD  CONSTRAINT [FK_RoomPossibility_SRRequirement] FOREIGN KEY([ReqID])
REFERENCES [dbo].[SRRequirement] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomPossibility] CHECK CONSTRAINT [FK_RoomPossibility_SRRequirement]
GO
ALTER TABLE [dbo].[StudentGroup]  WITH CHECK ADD  CONSTRAINT [FK_StudentGroup_EIMSUser] FOREIGN KEY([studentID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[StudentGroup] CHECK CONSTRAINT [FK_StudentGroup_EIMSUser]
GO
ALTER TABLE [dbo].[StudentGroup]  WITH CHECK ADD  CONSTRAINT [FK_StudentGroup_Group] FOREIGN KEY([groupID])
REFERENCES [dbo].[UniversityGroup] ([groupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentGroup] CHECK CONSTRAINT [FK_StudentGroup_Group]
GO
ALTER TABLE [dbo].[SubjectRequirements]  WITH CHECK ADD  CONSTRAINT [FK_SubjectRequirements_SRRequirement] FOREIGN KEY([ReqID])
REFERENCES [dbo].[SRRequirement] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectRequirements] CHECK CONSTRAINT [FK_SubjectRequirements_SRRequirement]
GO
ALTER TABLE [dbo].[SubjectRequirements]  WITH CHECK ADD  CONSTRAINT [FK_SubjectRequirements_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([subjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectRequirements] CHECK CONSTRAINT [FK_SubjectRequirements_Subject]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_LessonDate] FOREIGN KEY([lessonDateID])
REFERENCES [dbo].[LessonDate] ([lessonDateID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_LessonDate]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_EIMSUser] FOREIGN KEY([teacherID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_EIMSUser]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_Subject] FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subject] ([subjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_Subject]
GO
ALTER TABLE [dbo].[UniversityGroup]  WITH CHECK ADD  CONSTRAINT [FK_Group_Faculty] FOREIGN KEY([facultyID])
REFERENCES [dbo].[Faculty] ([facultyID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UniversityGroup] CHECK CONSTRAINT [FK_Group_Faculty]
GO
ALTER TABLE [dbo].[UniversityGroup]  WITH CHECK ADD  CONSTRAINT [FK_UniversityGroup_EIMSUser] FOREIGN KEY([supervisorID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[UniversityGroup] CHECK CONSTRAINT [FK_UniversityGroup_EIMSUser]
GO
ALTER TABLE [dbo].[UniversityGroup]  WITH CHECK ADD  CONSTRAINT [FK_UniversityGroup_EIMSUser1] FOREIGN KEY([elderID])
REFERENCES [dbo].[EIMSUser] ([Id])
GO
ALTER TABLE [dbo].[UniversityGroup] CHECK CONSTRAINT [FK_UniversityGroup_EIMSUser1]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_EIMSUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[EIMSUser] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_EIMSUser]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_EIMSUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[EIMSUser] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_EIMSUser]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_EIMSUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[EIMSUser] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_EIMSUser]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
USE [master]
GO
ALTER DATABASE [EIMS] SET  READ_WRITE 
GO

USE [EIMS]
GO

INSERT INTO EIMS.dbo.Role
           ([Name])
     VALUES
           ('Admin'),
		   ('Superuser'),
		   ('Teacher'),
		   ('Student')

GO

INSERT INTO EIMS.dbo.EIMSUser
		([Email],[Login],[PhoneNumber])
		VALUES
		('admin@eims.com','admin','0')
GO

INSERT INTO EIMS.DBO.UserRole
		(RoleId,UserId)
		VALUES
		(1,1)
		GO



