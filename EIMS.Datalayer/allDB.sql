USE [master]
GO
/****** Object:  Database [EIMS]    Script Date: 09.03.2016 22:57:22 ******/
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
ALTER DATABASE [EIMS] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [EIMS] SET  DISABLE_BROKER 
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
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCourse]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Course WHERE dbo.Course.courseID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteCourseFill]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCourseFill]
	-- Add the parameters for the stored procedure here
	@courseID int,
	@subjectID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.CourseFill WHERE dbo.CourseFill.courseID = @courseID and dbo.CourseFill.subjectID = @subjectID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteDayOfWeek]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDayOfWeek]
	-- Add the parameters for the stored procedure here
	@ID tinyint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.DayOfWeek WHERE dbo.DayOfWeek.ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteFaculty]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFaculty]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Faculty WHERE dbo.Faculty.facultyID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteGroupCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGroupCourse]
	-- Add the parameters for the stored procedure here
	@courseID int,
	@groupID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.GroupCourse WHERE dbo.GroupCourse.courseID = @courseID and dbo.GroupCourse.groupID = @groupID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteLesson]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLesson]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Lesson WHERE dbo.Lesson.lessonID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteLessonDate]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLessonDate]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.LessonDate WHERE dbo.LessonDate.lessonDateID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteLessonOrder]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLessonOrder]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.LessonOrder WHERE dbo.LessonOrder.ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteLessonPresence]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLessonPresence]
	-- Add the parameters for the stored procedure here
	@lessonDateID int,
	@studentID bigint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.LessonPresence WHERE dbo.LessonPresence.lessonDateID = @lessonDateID and dbo.LessonPresence.studentID = @studentID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteRoom]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRoom]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Room WHERE dbo.Room.roomID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteStudentGroup]
	-- Add the parameters for the stored procedure here
	@groupID int,
	@studentID bigint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.StudentGroup WHERE dbo.StudentGroup.groupID = @groupID and dbo.StudentGroup.studentID = @studentID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteSubject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSubject]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Subject WHERE dbo.Subject.subjectID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteTask]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTask]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Task WHERE dbo.Task.taskID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherSubject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTeacherSubject]
	-- Add the parameters for the stored procedure here
	@subjectID int,
	@teacherID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.TeacherSubject WHERE dbo.TeacherSubject.subjectID = @subjectID and dbo.TeacherSubject.teacherID = @teacherID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteUniversityGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUniversityGroup]
	-- Add the parameters for the stored procedure here
	@ID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.UniversityGroup WHERE dbo.UniversityGroup.groupID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@ID bigint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.UserInfo WHERE dbo.UserInfo.ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[GetCourseByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCourseByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Course
	WHERE courseID=@ID
	END



GO
/****** Object:  StoredProcedure [dbo].[GetDayOfWeekByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDayOfWeekByID] 
	-- Add the parameters for the stored procedure here
	@dayOfWeek int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.DayOfWeek WHERE dbo.DayOfWeek.ID = @dayOfWeek
END


GO
/****** Object:  StoredProcedure [dbo].[GetFacultyByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFacultyByID]
	-- Add the parameters for the stored procedure here
	@facultyID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Faculty WHERE dbo.Faculty.facultyID = @facultyID
END


GO
/****** Object:  StoredProcedure [dbo].[GetGroupByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetGroupByID] 
	-- Add the parameters for the stored procedure here
	@ID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM UniversityGroup
	WHERE groupID = @ID
END



GO
/****** Object:  StoredProcedure [dbo].[GetLessonByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLessonByID]
	-- Add the parameters for the stored procedure here
	@lessonID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Lesson WHERE dbo.Lesson.lessonID = @lessonID
END


GO
/****** Object:  StoredProcedure [dbo].[GetLessonOrderByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLessonOrderByID] 
	-- Add the parameters for the stored procedure here
	@orderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.LessonOrder WHERE dbo.LessonOrder.ID = @orderID
END


GO
/****** Object:  StoredProcedure [dbo].[GetLessonPreesenceByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLessonPreesenceByID] 
	-- Add the parameters for the stored procedure here
	@lessonPresenceID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.LessonPresence WHERE dbo.LessonPresence.lessonDateID = @lessonPresenceID
END


GO
/****** Object:  StoredProcedure [dbo].[GetRoleByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoleByID] 
	-- Add the parameters for the stored procedure here
	@role int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Role WHERE dbo.Role.ID = @role
END


GO
/****** Object:  StoredProcedure [dbo].[GetRoomByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoomByID]
	-- Add the parameters for the stored procedure here
	@roomID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Room WHERE dbo.Room.roomID = @roomID
END


GO
/****** Object:  StoredProcedure [dbo].[GetStudentByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentByID]
	-- Add the parameters for the stored procedure here
	@studentID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.UserInfo WHERE dbo.UserInfo.RoleID = '4'
END


GO
/****** Object:  StoredProcedure [dbo].[GetSubjectByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Subject
	WHERE subjectID=@ID
END



GO
/****** Object:  StoredProcedure [dbo].[GetSubjects]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjects] 
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Subject 
END



GO
/****** Object:  StoredProcedure [dbo].[GetSuperuserByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSuperuserByID]
	-- Add the parameters for the stored procedure here
	@superuserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.UserInfo WHERE dbo.UserInfo.RoleID = '2'
END


GO
/****** Object:  StoredProcedure [dbo].[GetTaskByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskByID]
	-- Add the parameters for the stored procedure here
	@taskID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Task WHERE dbo.Task.taskID = @taskID
END


GO
/****** Object:  StoredProcedure [dbo].[GetTeacherByID]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacherByID]
	-- Add the parameters for the stored procedure here
	@teacherID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.UserInfo WHERE dbo.UserInfo.RoleID = '3'
END


GO
/****** Object:  StoredProcedure [dbo].[GetUsersByRole]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersByRole] 
	-- Add the parameters for the stored procedure here
	@Role tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM UserInfo
	WHERE RoleID=@Role
END



GO
/****** Object:  StoredProcedure [dbo].[InsertCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCourse]
	-- Add the parameters for the stored procedure here
	@coursename nvarchar(100)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Course(courseName)
	VALUES (@coursename)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertCourseFill]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCourseFill]
	-- Add the parameters for the stored procedure here
	@courseID int,
	@subjectID int,
	@subjectHPW int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.CourseFill(courseID, subjectID, subjectHoursPerWeek)
	VALUES (@courseID, @subjectID, @subjectHPW)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertDayOfWeek]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertDayOfWeek]
	-- Add the parameters for the stored procedure here
	@dayName nvarchar(10)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.DayOfWeek(Name)
	VALUES (@dayName)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertFaculty]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertFaculty]
	-- Add the parameters for the stored procedure here
	@facultyName nvarchar(100)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Faculty(Name)
	VALUES (@facultyName)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertGroupCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertGroupCourse]
	-- Add the parameters for the stored procedure here
	@groupID int,
	@startDate datetime,
	@endDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.GroupCourse(groupID, startDate, endDate)
	VALUES (@groupID, @startDate, @endDate)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertLesson]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLesson]
	-- Add the parameters for the stored procedure here
	@subjectID int,
	@groupID int,
	@teacherID bigint,
	@roomID int,
	@lessonOrder int,
	@dayOfWeek tinyint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Lesson(subjectID, groupID, teacherID, roomID, LessonOrder, DayOfWeek)
	VALUES (@subjectID, @groupID, @teacherID, @roomID, @lessonOrder, @dayOfWeek)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertLessonDate]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLessonDate]
	-- Add the parameters for the stored procedure here
	@lessonID bigint,
	@date datetime
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.LessonDate(lessonID, date)
	VALUES (@lessonID, @date)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertLessonPresence]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLessonPresence]
	-- Add the parameters for the stored procedure here
	@lessonDateID bigint,
	@studentID bigint,
	@presence bit,
	@mark tinyint
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.LessonPresence(lessonDateID, studentID, presence, mark)
	VALUES (@lessonDateID, @studentID, @presence, @mark)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertRoom]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertRoom]
	-- Add the parameters for the stored procedure here
	@roomNo nvarchar(20),
	@features binary(15),
	@capacity smallint,
	@isAvialable bit
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Room(roomNo, features, capacity, isAvailable)
	VALUES (@roomNo, @features, @capacity, @isAvialable)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertStudentGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertStudentGroup]
	-- Add the parameters for the stored procedure here
	@groupID int,
	@studentID int,
	@enrollmentDate datetime,
	@graduationDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.StudentGroup(groupID, studentID, enrollmentDate, graduationDate)
	VALUES (@groupID, @studentID, @enrollmentDate, @graduationDate)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertSubject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertSubject]
	-- Add the parameters for the stored procedure here
	@subjectname nvarchar(1024),
	@requirements binary(15)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Subject(subjectName, requirements)
	VALUES (@subjectname, @requirements)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTask]
	-- Add the parameters for the stored procedure here
	@lessonDateID bigint,
	@homeTask nvarchar(3072),
	@expiryDate date
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Task(lessonDateID, homeTask, expiryDate)
	VALUES (@lessonDateID, @homeTask, @expiryDate)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertTeacherSubject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTeacherSubject]
	-- Add the parameters for the stored procedure here
	@subjectID int,
	@teacherID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.TeacherSubject(teacherID, subjectID)
	VALUES (@subjectID, @teacherID)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertUniversityGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertUniversityGroup]
	-- Add the parameters for the stored procedure here
	@groupName nvarchar(50),
	@supervisorID bigint,
	@creationDate date,
	@elderID bigint,
	@facultyID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.UniversityGroup(groupName, supervisorID, creationDate, elderID, facultyID)
	VALUES (@groupName, @supervisorID, @creationDate, @elderID, @facultyID)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertUser] 
	-- Add the parameters for the stored procedure here
	@username nvarchar(63),
	@email nvarchar(512),
	@password nvarchar(1024),
	@roleID tinyint,
	@creationDate date,
	@name nvarchar(100),
	@surname nvarchar(150),
	@middlename nvarchar(100),
	@photoLink nvarchar(1024),
	@address nvarchar(1024),
	@sex bit,
	@lastEdit datetime


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.UserInfo (Username, Email, Password, RoleID, CreationDate, Name, Surname, MiddleName, photoLink, address, sex, LastEdit)
	VALUES (@username, @email, @password, @roleID, @creationDate, @name, @surname, @middlename, @photoLink, @address, @sex, @lastEdit)
END


GO
/****** Object:  Table [dbo].[Course]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[CourseFill]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseFill](
	[courseID] [int] NOT NULL,
	[subjectID] [int] NOT NULL,
	[subjectHoursPerWeek] [int] NOT NULL,
 CONSTRAINT [PK_CourseFill] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[subjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DayOfWeek]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[EIMSUser]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[Faculty]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[GroupCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupCourse](
	[courseID] [int] NOT NULL,
	[groupID] [int] NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NULL,
 CONSTRAINT [PK_GroupCourse_1] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[groupID] ASC,
	[startDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[LessonDate]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[LessonOrder]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[LessonPresence]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonPresence](
	[lessonDateID] [bigint] NOT NULL,
	[studentID] [bigint] NOT NULL,
	[presence] [bit] NOT NULL,
	[mark] [tinyint] NULL,
 CONSTRAINT [PK_LessonPresence] PRIMARY KEY CLUSTERED 
(
	[lessonDateID] ASC,
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[roomID] [int] IDENTITY(1,1) NOT NULL,
	[roomNo] [nvarchar](20) NOT NULL,
	[features] [binary](10) NOT NULL,
	[capacity] [smallint] NOT NULL,
	[isAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentGroup](
	[groupID] [int] NOT NULL,
	[studentID] [bigint] NOT NULL,
	[enrollmentDate] [datetime] NOT NULL,
	[graduationDate] [datetime] NULL,
 CONSTRAINT [PK_StudentGroup_1] PRIMARY KEY CLUSTERED 
(
	[groupID] ASC,
	[studentID] ASC,
	[enrollmentDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[subjectID] [int] IDENTITY(1,1) NOT NULL,
	[subjectName] [nvarchar](1024) NOT NULL,
	[requirements] [binary](10) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[subjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Task]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[UniversityGroup]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 09.03.2016 22:57:22 ******/
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
/****** Object:  View [dbo].[LessonDateDay]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LessonDateDay]
AS
SELECT        dbo.LessonDate.date, dbo.DayOfWeek.Name, dbo.Subject.subjectName
FROM            dbo.Lesson INNER JOIN
                         dbo.DayOfWeek ON dbo.Lesson.DayOfWeek = dbo.DayOfWeek.ID INNER JOIN
                         dbo.LessonDate ON dbo.Lesson.lessonID = dbo.LessonDate.lessonID INNER JOIN
                         dbo.Subject ON dbo.Lesson.subjectID = dbo.Subject.subjectID


GO
/****** Object:  View [dbo].[StudentsGroup]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentsGroup]
AS
SELECT        dbo.UserInfo.Surname, dbo.UserInfo.Name, dbo.UniversityGroup.groupName
FROM            dbo.UserInfo INNER JOIN
                         dbo.Role ON dbo.UserInfo.RoleID = dbo.Role.ID AND dbo.UserInfo.RoleID = '4' INNER JOIN
                         dbo.StudentGroup ON dbo.UserInfo.ID = dbo.StudentGroup.studentID INNER JOIN
                         dbo.UniversityGroup ON dbo.StudentGroup.groupID = dbo.UniversityGroup.groupID


GO
/****** Object:  View [dbo].[StudentView]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentView]
AS
SELECT        dbo.UserInfo.Name, dbo.UserInfo.Surname, dbo.UserInfo.address, dbo.UniversityGroup.groupName, dbo.UserInfo.sex, dbo.UserInfo.Email, 
                         dbo.UniversityGroup.elderID
FROM            dbo.UserInfo INNER JOIN
                         dbo.Role ON dbo.UserInfo.RoleID = dbo.Role.ID AND dbo.UserInfo.RoleID = '4' INNER JOIN
                         dbo.StudentGroup ON dbo.UserInfo.ID = dbo.StudentGroup.studentID INNER JOIN
                         dbo.UniversityGroup ON dbo.UserInfo.ID = dbo.UniversityGroup.elderID AND dbo.UserInfo.ID = dbo.UniversityGroup.supervisorID AND 
                         dbo.StudentGroup.groupID = dbo.UniversityGroup.groupID


GO
/****** Object:  View [dbo].[SubjectCourse]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SubjectCourse]
AS
SELECT        dbo.Course.courseName, dbo.Subject.subjectName
FROM            dbo.CourseFill INNER JOIN
                         dbo.Course ON dbo.CourseFill.courseID = dbo.Course.courseID INNER JOIN
                         dbo.Subject ON dbo.CourseFill.subjectID = dbo.Subject.subjectID


GO
/****** Object:  View [dbo].[TeacherAndSubject]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TeacherAndSubject]
AS
SELECT        dbo.UserInfo.Surname, dbo.UserInfo.Name, dbo.Subject.subjectName
FROM            dbo.Subject INNER JOIN
                         dbo.TeacherSubject ON dbo.Subject.subjectID = dbo.TeacherSubject.subjectID INNER JOIN
                         dbo.UserInfo ON dbo.TeacherSubject.teacherID = dbo.UserInfo.ID INNER JOIN
                         dbo.Role ON dbo.UserInfo.RoleID = dbo.Role.ID AND dbo.UserInfo.RoleID = '3'


GO
/****** Object:  View [dbo].[TeacherView]    Script Date: 09.03.2016 22:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TeacherView]
AS
SELECT        dbo.UserInfo.Name, dbo.UserInfo.Surname, dbo.UserInfo.Email, dbo.UserInfo.sex, dbo.UniversityGroup.groupName
FROM            dbo.UserInfo INNER JOIN
                         dbo.Role ON dbo.UserInfo.RoleID = dbo.Role.ID AND dbo.UserInfo.RoleID = '3' INNER JOIN
                         dbo.UniversityGroup ON dbo.UserInfo.ID = dbo.UniversityGroup.supervisorID


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
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Table_2_roomFeatures]  DEFAULT ((0)) FOR [features]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_isAvailable]  DEFAULT ((1)) FOR [isAvailable]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF_Subject_requirements]  DEFAULT ((0)) FOR [requirements]
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
ALTER TABLE [dbo].[StudentGroup]  WITH CHECK ADD  CONSTRAINT [FK_StudentGroup_Group] FOREIGN KEY([groupID])
REFERENCES [dbo].[UniversityGroup] ([groupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentGroup] CHECK CONSTRAINT [FK_StudentGroup_Group]
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Lesson"
            Begin Extent = 
               Top = 0
               Left = 241
               Bottom = 129
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DayOfWeek"
            Begin Extent = 
               Top = 0
               Left = 476
               Bottom = 95
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LessonDate"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 112
               Right = 170
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Subject"
            Begin Extent = 
               Top = 101
               Left = 476
               Bottom = 213
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LessonDateDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LessonDateDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 101
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StudentGroup"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 625
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UniversityGroup"
            Begin Extent = 
               Top = 6
               Left = 663
               Bottom = 135
               Right = 833
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentsGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentsGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentsGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 101
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StudentGroup"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 625
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UniversityGroup"
            Begin Extent = 
               Top = 6
               Left = 663
               Bottom = 135
               Right = 833
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CourseFill"
            Begin Extent = 
               Top = 0
               Left = 270
               Bottom = 112
               Right = 475
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 95
               Right = 170
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Subject"
            Begin Extent = 
               Top = 0
               Left = 557
               Bottom = 112
               Right = 727
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SubjectCourse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SubjectCourse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Subject"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 118
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TeacherSubject"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 101
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 101
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherAndSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherAndSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherAndSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 174
               Left = 68
               Bottom = 269
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UniversityGroup"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherView'
GO
USE [master]
GO
ALTER DATABASE [EIMS] SET  READ_WRITE 
GO
