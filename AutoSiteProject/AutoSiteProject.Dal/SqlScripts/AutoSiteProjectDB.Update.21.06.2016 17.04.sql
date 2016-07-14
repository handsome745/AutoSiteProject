﻿USE master
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
	IF OBJECT_ID (N'dbo.CarImages', N'U') IS NOT NULL  
	BEGIN
		DROP TABLE dbo.CarImages;
	END
END
GO
IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.CarImages', N'U') IS NULL  
	BEGIN
		CREATE TABLE dbo.CarImages(
		Id int IDENTITY(1,1) PRIMARY KEY
		);
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

USE AutoSiteProjectDB
IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'ContentLength'
      AND Object_ID = Object_ID(N'CarImages'))
BEGIN
    ALTER TABLE dbo.CarImages
	ADD ContentLength bigint NOT NULL DEFAULT 0
END

--USE AutoSiteProjectDB
--IF  EXISTS(
--    SELECT *
--    FROM sys.columns 
--    WHERE Name      = N'ContentLength'
--      AND Object_ID = Object_ID(N'CarImages'))
--BEGIN
--	ALTER TABLE dbo.CarImages 
--	ADD CONSTRAINT DF_ContentLength DEFAULT 0 FOR ContentLength;
	
--	ALTER TABLE dbo.CarImages
--	ALTER COLUMN ContentLength bigint NOT NULL 
--END

USE AutoSiteProjectDB
IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'ContentType'
      AND Object_ID = Object_ID(N'CarImages'))
BEGIN
    ALTER TABLE dbo.CarImages
	ADD ContentType varchar(max)
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

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.CarItemImages', N'U') IS NULL  
	BEGIN
		CREATE TABLE dbo.CarItemImages(
		CarId int NOT NULL,
		CONSTRAINT fk_CarIdFK FOREIGN KEY (CarId) REFERENCES CarItem(Id) ON DELETE CASCADE,
		ImageId int NOT NULL,
		CONSTRAINT fk_ImageIdFK FOREIGN KEY (ImageId) REFERENCES CarImages(Id) ON DELETE CASCADE,
		CONSTRAINT pk_CarImage PRIMARY KEY (CarId,ImageId)
		);
	END
END
GO
