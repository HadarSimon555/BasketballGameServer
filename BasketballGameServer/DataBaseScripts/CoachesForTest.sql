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
           ('hadar@gmail.com'
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
           ('ido@gmail.com'
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

--���� 3

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('maya@gmail.com'
           ,'123456'
           ,'07/10/2004'
           ,'����'
           ,'���� �� ����')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('3')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('3'
           ,'����� ��� ���')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '3'
 WHERE Coach.id = 3
GO

--���� 4

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('yuli@gmail.com'
           ,'123456'
           ,'02/07/2004'
           ,'����'
           ,'���� ���')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('4')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('4'
           ,'���� ����')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '4'
 WHERE Coach.id = 4
GO

--���� 5

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('noa@gmail.com'
           ,'123456'
           ,'12/31/2003'
           ,'����'
           ,'���� ��������')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('5')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('5'
           ,'����� ����')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '5'
 WHERE Coach.id = 5
GO

--���� 6

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('yuval@gmail.com'
           ,'123456'
           ,'02/20/2004'
           ,'���'
           ,'���� ���')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('6')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('6'
           ,'����� �� ����')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '6'
 WHERE Coach.id = 6
GO

--���� 7

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[pass]
           ,[birthDate]
           ,[gender]
           ,[name])
     VALUES
           ('shira@gmail.com'
           ,'123456'
           ,'05/30/2005'
           ,'����'
           ,'���� ���')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Coach]
           ([userId])
     VALUES
           ('7')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Team]
           ([coachId]
           ,[name])
     VALUES
           ('7'
           ,'����� ��� ���')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '7'
 WHERE Coach.id = 7
GO




