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
	WHERE [dbo].CarItem.Id = [dbo].CarItemImages.CarId and [dbo].CarImages.Id = [dbo].CarItemImages.ImageId and [dbo].CarItem.MainImageId IS NULL)
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'EditDate'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD EditDate datetime 
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	
	UPDATE [dbo].CarItem
	SET EditDate = GETDATE();
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'EditDate'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ALTER COLUMN EditDate datetime NOT NULL
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'LastEditorId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD LastEditorId nvarchar(128)
		CONSTRAINT fk_CarItemLastEditorId FOREIGN KEY (LastEditorId) REFERENCES dbo.AspNetUsers(Id) 
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'LastEditor'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		DROP COLUMN LastEditor;
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'LastEditorId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		UPDATE dbo.CarItem
		SET LastEditorId = OwnerId
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'LastEditorId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ALTER COLUMN LastEditorId nvarchar(128) NOT NULL
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'Price'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD Price int NOT NULL
		CONSTRAINT priceDef DEFAULT 0;
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'Status'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD Status int NOT NULL
		CONSTRAINT statudDef DEFAULT 0;
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'ReleaseYear'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD ReleaseYear int NOT NULL DEFAULT 2000;
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF NOT EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'Volume'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD Volume int NOT NULL DEFAULT 0;
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.TransmitionType', N'U') IS NULL  
	BEGIN
		CREATE TABLE dbo.TransmitionType(
		Id int IDENTITY(1,1) PRIMARY KEY,
		Name varchar(max) NOT NULL
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
		WHERE Name      = N'TransmitionTypeId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD TransmitionTypeId int 
		CONSTRAINT fk_CarItemTransmitionType FOREIGN KEY (TransmitionTypeId) REFERENCES TransmitionType(Id)
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
	IF OBJECT_ID (N'dbo.FuelType', N'U') IS NULL  
	BEGIN
		CREATE TABLE dbo.FuelType(
		Id int IDENTITY(1,1) PRIMARY KEY,
		Name varchar(max) NOT NULL
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
		WHERE Name      = N'FuelTypeId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN
		ALTER TABLE dbo.CarItem
		ADD FuelTypeId int 
		CONSTRAINT fk_CarItemFuelType FOREIGN KEY (FuelTypeId) REFERENCES FuelType(Id)
	END
END
GO

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	USE AutoSiteProjectDB
	IF  EXISTS(
		SELECT *
		FROM sys.columns 
		WHERE Name      = N'FuelTypeId'
		  AND Object_ID = Object_ID(N'CarItem'))
	BEGIN

		ALTER TABLE dbo.CarItem
		DROP CONSTRAINT fk_CarItemFuelType 

		ALTER TABLE dbo.CarItem
		DROP COLUMN FuelTypeId

		ALTER TABLE dbo.CarItem
		ADD FuelTypeId int 
		CONSTRAINT fk_CarItemFuelType FOREIGN KEY (FuelTypeId) REFERENCES FuelType(Id)

		UPDATE dbo.CarItem
		SET FuelTypeId = (SELECT TOP(1) Id FROM dbo.FuelType)

		ALTER TABLE dbo.CarItem
		ALTER COLUMN FuelTypeId int NOT NULL

		
		ALTER TABLE dbo.CarItem
		DROP CONSTRAINT fk_CarItemTransmitionType 

		ALTER TABLE dbo.CarItem
		DROP COLUMN TransmitionTypeId

		ALTER TABLE dbo.CarItem
		ADD TransmitionTypeId int 
		CONSTRAINT fk_CarItemTransmitionType FOREIGN KEY (TransmitionTypeId) REFERENCES TransmitionType(Id)

		UPDATE dbo.CarItem
		SET TransmitionTypeId = (SELECT TOP(1) Id FROM dbo.TransmitionType)

		ALTER TABLE dbo.CarItem
		ALTER COLUMN TransmitionTypeId int NOT NULL
		
	END
END
GO