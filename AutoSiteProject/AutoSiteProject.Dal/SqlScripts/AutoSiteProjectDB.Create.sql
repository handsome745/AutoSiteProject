USE master
GO
IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	alter database AutoSiteProjectDB set single_user with rollback immediate
	DROP DATABASE AutoSiteProjectDB
END
GO

CREATE DATABASE AutoSiteProjectDB
GO

USE AutoSiteProjectDB
GO
CREATE TABLE dbo.Country
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Name varchar(max) NOT NULL
);
GO

CREATE TABLE dbo.Manufacturer
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Name varchar(max) NOT NULL,
	CountryId int ,
	CONSTRAINT fk_ManufCountry FOREIGN KEY (CountryId) REFERENCES Country(Id) ON DELETE SET NULL
);
GO

CREATE TABLE CarModel
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Name varchar(max) NOT NULL,
	ManufacturerId int ,
	CONSTRAINT fk_ModelManuf FOREIGN KEY (ManufacturerId) REFERENCES Manufacturer(Id) ON DELETE SET NULL
);
GO

CREATE TABLE CarBodyType
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Name varchar(max) NOT NULL
);
GO

CREATE TABLE ModelBodyTypes
(
	ModelId int NOT NULL,
	CONSTRAINT fk_ModelIdBodyTypes FOREIGN KEY (ModelId) REFERENCES CarModel(Id) ON DELETE CASCADE,
	BodyTypeId int NOT NULL,
	CONSTRAINT fk_BodyTypeIdBodyTypes FOREIGN KEY (BodyTypeId) REFERENCES CarBodyType(Id) ON DELETE CASCADE,
	CONSTRAINT pk_ModelBodyType PRIMARY KEY (ModelId,BodyTypeId)
);
GO

CREATE TABLE CarOption
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Name varchar(max) NOT NULL
);
GO

CREATE TABLE CarItem
(
	Id int IDENTITY(1,1) PRIMARY KEY ,
	Description varchar(max),
	ModelId int,
	BodyTypeId int,
	CONSTRAINT fk_CarItemModel FOREIGN KEY (ModelId) REFERENCES CarModel(Id) ON DELETE SET NULL,
	CONSTRAINT fk_CarItemBodyType FOREIGN KEY (BodyTypeId) REFERENCES CarBodyType(Id) ON DELETE SET NULL
);
GO

CREATE TABLE CarItemOptions
(
	CarItemId int NOT NULL,
	CONSTRAINT fk_CarItemIdCarItemOptions FOREIGN KEY (CarItemId) REFERENCES CarItem(Id) ON DELETE CASCADE,
	OptionId int NOT NULL,
	CONSTRAINT fk_CarItemOptionIdCarItemOptions FOREIGN KEY (OptionId) REFERENCES CarOption(Id) ON DELETE CASCADE,
	CONSTRAINT pk_CarItemOptions PRIMARY KEY (CarItemId,OptionId)
);
GO