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
           ('�����������'),
		   ('�������'),
		   ('�����'),
		   ('�������'),
		   ('�������')
GO

INSERT INTO [dbo].[Subject]
           ([subjectName])
     VALUES
           ('�����'),
		   ('��������'),
		   ('�������'),
		   ('���������'),
		   ('������'),
		   ('������� �������'),
		   ('��������� �������'),
		   ('�����������'),
		   ('���������'),
		   ('�������������� �������������'),
		   ('���������������� �� C'),
		   ('������ C++'),
		   ('C#'),
		   ('WPF'),
		   ('ADO.NET'),
		   ('ASP.NET'),
		   ('������ Web-����������'),
		   ('Java'),
		   ('Javascript + JQuery'),
		   ('���������� ��� Android')
GO

INSERT INTO [dbo].[Course]
           ([courseName])
     VALUES
           ('���������� ������������ �����������'),
		   ('.NET ����������'),
		   ('���������� ������������ ����������� ��� Android'),
		   ('�������� ���������'),
		   ('������������ ����')
GO

INSERT INTO [dbo].[Faculty]
           ([Name])
     VALUES
           ('��������� �������������� ����������'),
		   ('��������� �����')
		   
GO

INSERT INTO [dbo].[Room]
           ([roomNo]
           ,[capacity]
           ,[isAvailable])
     VALUES
           ('100',20,1),
		   ('101',30,1),
		   ('102',50,1),
		   ('103',10,1),
		   ('104 ����',100,1),
		   ('105',20,1),
		   ('106',25,1),
		   ('107',12,1),
		   ('108',20,1),
		   ('109',20,1)
		   
GO

INSERT INTO [dbo].[SRRequirement]
           ([Requirement])
     VALUES
           ('��������'),
		   ('�������'),
		   ('���������� �����������'),
		   ('������������ �����'),
		   ('����������� �������'),
		   ('��������')
GO
INSERT INTO [dbo].[UniversityGroup]
           ([groupName]
           ,[supervisorID]
           ,[creationDate]
           ,[elderID]
           ,[facultyID])
     VALUES
           ('��01'
           ,null
           ,'22-03-2016'
           ,null
           ,1),
		   ('��02'
           ,null
           ,'22-03-2016'
           ,null
           ,1),
		   ('2203��'
           ,null
           ,'22-03-2016'
           ,null
           ,2)
GO