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

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'OwnerId'
      AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD OwnerId nvarchar(128)

		ALTER TABLE dbo.CarItem
		ADD CONSTRAINT fk_CarItemOwner FOREIGN KEY (OwnerId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
	END
END
GO

--IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
--BEGIN 
--USE AutoSiteProjectDB
--	IF EXISTS(
--    SELECT *
--    FROM sys.columns 
--    WHERE Name      = N'OwnerId'
--      AND Object_ID = Object_ID(N'CarItem'))
--	BEGIN
--		UPDATE dbo.CarItem 
--		SET OwnerId = (SELECT TOP(1) Id FROM AspNetUsers)
--		WHERE 1=1;

--		ALTER TABLE dbo.CarItem
--		ALTER COLUMN OwnerId nvarchar(128) NOT NULL
--	END
--END
--GO

USE AutoSiteProjectDB
IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'MainImageId'
      AND Object_ID = Object_ID(N'CarItem'))
BEGIN
    ALTER TABLE dbo.CarItem
	ADD MainImageId int NULL

	ALTER TABLE dbo.CarItem
	ADD CONSTRAINT fk_CarItemMainImage FOREIGN KEY (MainImageId) REFERENCES CarImages(Id) ON DELETE SET NULL
END
GO

USE AutoSiteProjectDB
IF  EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'MainImageId'
      AND Object_ID = Object_ID(N'CarItem'))
BEGIN
    UPDATE [dbo].CarItem
	SET MainImageId =
	(SELECT TOP(1) [dbo].CarImages.Id
	FROM [dbo].CarImages,  [dbo].CarItemImages 
	WHERE [dbo].CarItem.Id = [dbo].CarItemImages.CarId and [dbo].CarImages.Id = [dbo].CarItemImages.ImageId)
END