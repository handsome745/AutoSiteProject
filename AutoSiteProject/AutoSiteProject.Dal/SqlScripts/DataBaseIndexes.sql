IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='CarBodyTypeNameIndex' AND object_id = OBJECT_ID('CarBodyType'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].CarBodyType
	ALTER COLUMN Name nvarchar(100) NOT NULL

	CREATE INDEX CarBodyTypeNameIndex
	ON [dbo].CarBodyType(Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='CarItemDescriptionIndex' AND object_id = OBJECT_ID('CarItem'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].CarItem
	ALTER COLUMN Description nvarchar(100) 
	CREATE INDEX CarItemDescriptionIndex
	ON dbo.CarItem(Description);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='CarModelNameIndex' AND object_id = OBJECT_ID('CarModel'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].CarModel
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX CarModelNameIndex
	ON dbo.CarModel(Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='CarOptionNameIndex' AND object_id = OBJECT_ID('CarOption'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].CarOption
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX CarOptionNameIndex
	ON dbo.CarOption (Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='CountryNameIndex' AND object_id = OBJECT_ID('Country'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].Country
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX CountryNameIndex
	ON dbo.Country (Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='FuelTypeNameIndex' AND object_id = OBJECT_ID('FuelType'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].FuelType
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX FuelTypeNameIndex
	ON dbo.FuelType (Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='ManufacturerNameIndex' AND object_id = OBJECT_ID('Manufacturer'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].Manufacturer
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX ManufacturerNameIndex
	ON dbo.Manufacturer (Name);
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='TransmitionTypeNameIndex' AND object_id = OBJECT_ID('TransmitionType'))
BEGIN
	USE AutoSiteProjectDB
	ALTER TABLE [dbo].TransmitionType
	ALTER COLUMN Name nvarchar(100) NOT NULL
	CREATE INDEX TransmitionTypeNameIndex
	ON dbo.TransmitionType (Name);
END