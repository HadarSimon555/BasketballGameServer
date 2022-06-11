--מאמן 1

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
           ,'נקבה'
           ,'הדר סיימון')
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
           ,'הפועל חולון')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '1'
 WHERE Coach.id = 1
GO

--מאמן 2

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
           ,'זכר'
           ,'עידו סיימון')
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
           ,'מכבי תל אביב')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '2'
 WHERE Coach.id = 2
GO

--מאמן 3

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
           ,'נקבה'
           ,'מאיה בר יוסף')
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
           ,'הפועל כפר סבא')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '3'
 WHERE Coach.id = 3
GO

--מאמן 4

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
           ,'נקבה'
           ,'יולי לוי')
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
           ,'מכבי חיפה')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '4'
 WHERE Coach.id = 4
GO

--מאמן 5

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
           ,'נקבה'
           ,'נועה היילפרין')
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
           ,'הפועל אילת')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '5'
 WHERE Coach.id = 5
GO

--מאמן 6

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
           ,'זכר'
           ,'יובל לוי')
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
           ,'הפועל תל אביב')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '6'
 WHERE Coach.id = 6
GO

--מאמן 7

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
           ,'נקבה'
           ,'שירה לוי')
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
           ,'הפועל באר שבע')
GO

USE [BasketballGameDB]
GO

UPDATE [dbo].[Coach]
   SET [teamId] = '7'
 WHERE Coach.id = 7
GO




