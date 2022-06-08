USE [BasketballGameDB]
GO

INSERT INTO [dbo].[Game]
           ([homeTeamId]
           ,[awayTeamId]
           ,[gameStatusId]
           ,[scoreAwayTeam]
           ,[scoreHomeTeam]
           ,[date]
           ,[time]
           ,[position])
     VALUES
           ('1'
           ,'2'
           ,'3'
           ,'55'
           ,'70'
           ,'06/01/2022'
           ,'05:25:00'
           ,'Tel Aviv')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[GameStats]
           ([gameId]
           ,[playerShots]
           ,[playerId])
     VALUES
           ('1'
           ,'25'
           ,'1')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[GameStats]
           ([gameId]
           ,[playerShots]
           ,[playerId])
     VALUES
           ('1'
           ,'45'
           ,'2')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[GameStats]
           ([gameId]
           ,[playerShots]
           ,[playerId])
     VALUES
           ('1'
           ,'20'
           ,'3')
GO

USE [BasketballGameDB]
GO

INSERT INTO [dbo].[GameStats]
           ([gameId]
           ,[playerShots]
           ,[playerId])
     VALUES
           ('1'
           ,'35'
           ,'4')
GO


