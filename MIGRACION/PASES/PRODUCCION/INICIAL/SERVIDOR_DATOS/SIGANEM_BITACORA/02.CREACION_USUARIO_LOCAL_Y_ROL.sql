
USE [SIGANEM_BITACORA]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'RAP_AccesoSIGANEM' AND type = 'R')
CREATE ROLE [RAP_AccesoSIGANEM] AUTHORIZATION [dbo]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AccesoSIGANEM')
CREATE USER [AccesoSIGANEM] FOR LOGIN [AccesoSICAD] WITH DEFAULT_SCHEMA=[dbo]
GO

sys.sp_addrolemember @rolename = N'RAP_AccesoSIGANEM', @membername = N'AccesoSIGANEM'
GO