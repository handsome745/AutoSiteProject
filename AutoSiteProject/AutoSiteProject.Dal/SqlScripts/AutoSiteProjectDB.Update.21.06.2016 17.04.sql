USE master
GO
IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.ModelBodyTypes', N'U') IS NOT NULL  
	BEGIN
		truncate table dbo.ModelBodyTypes
		drop table dbo.ModelBodyTypes
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.CarImages', N'U') IS NULL  
	BEGIN
		CREATE TABLE dbo.CarImages(Id int);
	END
END
GO

USE AutoSiteProjectDB
IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'Name'
      AND Object_ID = Object_ID(N'CarImages'))
BEGIN
    ALTER TABLE dbo.CarImages
	ADD Name varchar(max)
END

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'Data'
      AND Object_ID = Object_ID(N'CarImages'))
BEGIN
    ALTER TABLE dbo.CarImages
	ADD Data varbinary(max)
END
