--���� 1

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('hadarsimon555@gmail.com'
           ,'123456'
           ,'04/11/2004'
           ,'����'
           ,'��� ������')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('1')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('1'
           ,'����� �����')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '1'
 WHERE Coach.id = 1
GO

--���� 2

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('idosimon@gmail.com'
           ,'123456'
           ,'06/30/2005'
           ,'���'
           ,'���� ������')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('2')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('2'
           ,'���� �� ����')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '2'
 WHERE Coach.id = 2
GO




