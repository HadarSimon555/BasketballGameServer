USE [master]
GO

/****** Object:  Database [BasketballGameDB]    Script Date: 19/09/2021 08:52:07 ******/
CREATE DATABASE [BasketballGameDB]
 
Use BasketballGameDB
Go

Create Table Users (
ID int Identity primary key,
Email nvarchar(100) not null UNIQUE,
Pswd nvarchar(30) not null UNIQUE,
)
Go