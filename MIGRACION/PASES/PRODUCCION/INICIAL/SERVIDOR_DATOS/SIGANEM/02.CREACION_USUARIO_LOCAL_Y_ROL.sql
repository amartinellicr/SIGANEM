USE [SIGANEM]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'RAP_AccesoSIGANEM' AND type = 'R')
CREATE ROLE [RAP_AccesoSIGANEM] AUTHORIZATION [dbo]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AccesoSIGANEM')
CREATE USER [AccesoSIGANEM] FOR LOGIN [AccesoSIGANEM] WITH DEFAULT_SCHEMA=[dbo]
GO

sys.sp_addrolemember @rolename = N'RAP_AccesoSIGANEM', @membername = N'AccesoSIGANEM'
GO

sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'AccesoSIGANEM' 
GO


IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'RAP_AccesoReportes' AND type = 'R')
CREATE ROLE [RAP_AccesoReportes] AUTHORIZATION [dbo]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AccesoReportes')
CREATE USER [AccesoReportes] FOR LOGIN [AccesoReportes] WITH DEFAULT_SCHEMA=[dbo]
GO

sys.sp_addrolemember @rolename = N'RAP_AccesoReportes', @membername = N'AccesoReportes'
GO

sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'AccesoReportes' 
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'RAP_AccesoIntegracion' AND type = 'R')
CREATE ROLE [RAP_AccesoIntegracion] AUTHORIZATION [dbo]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AccesoIntegracion')
CREATE USER [AccesoIntegracion] FOR LOGIN [AccesoIntegracion] WITH DEFAULT_SCHEMA=[dbo]
GO

sys.sp_addrolemember @rolename = N'RAP_AccesoIntegracion', @membername = N'AccesoIntegracion'
GO

sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'AccesoIntegracion' 
GO

sys.sp_addrolemember @rolename = N'db_datawriter', @membername = N'AccesoIntegracion' 
GO
