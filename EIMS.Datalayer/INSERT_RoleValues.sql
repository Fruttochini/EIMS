USE [EIMS]
GO

INSERT INTO [dbo].[Role]
           ([Name])
     VALUES
           ('Admin'),
		   ('Superuser'),
		   ('Teacher'),
		   ('Student')

GO

INSERT INTO [dbo].[LessonOrder]
           ([TimeStart]
           ,[TimeEnd])
     VALUES
           ('08:30','10:00'),
		   ('10:15','11:45'),
		   ('12:00','13:30'),
		   ('13:45','15:15'),
		   ('15:30','17:00'),
		   ('17:15','18:45')
GO

INSERT INTO [dbo].[DayOfWeek]
           ([Name])
     VALUES
           ('Monday'),
		   ('Tuesday'),
		   ('Wednesday'),
		   ('Thursday'),
		   ('Friday')
GO