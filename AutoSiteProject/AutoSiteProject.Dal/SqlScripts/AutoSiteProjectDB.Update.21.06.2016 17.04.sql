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
IF OBJECT_ID (N'dbo.AspNetRoles', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[AspNetRoles] (
		[Id]   NVARCHAR (128) NOT NULL,
		[Name] NVARCHAR (256) NOT NULL,
		CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
		);

		CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
		ON [dbo].[AspNetRoles]([Name] ASC);
	END
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
IF OBJECT_ID (N'dbo.AspNetUsers', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[AspNetUsers] (
		[Id]                   NVARCHAR (128) NOT NULL,
		[Email]                NVARCHAR (256) NULL,
		[EmailConfirmed]       BIT            NOT NULL,
		[PasswordHash]         NVARCHAR (MAX) NULL,
		[SecurityStamp]        NVARCHAR (MAX) NULL,
		[PhoneNumber]          NVARCHAR (MAX) NULL,
		[PhoneNumberConfirmed] BIT            NOT NULL,
		[TwoFactorEnabled]     BIT            NOT NULL,
		[LockoutEndDateUtc]    DATETIME       NULL,
		[LockoutEnabled]       BIT            NOT NULL,
		[AccessFailedCount]    INT            NOT NULL,
		[UserName]             NVARCHAR (256) NOT NULL,
		CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
		);

		CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
		ON [dbo].[AspNetUsers]([UserName] ASC);
	END
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
IF OBJECT_ID (N'dbo.AspNetUserClaims', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[AspNetUserClaims] (
		[Id]         INT            IDENTITY (1, 1) NOT NULL,
		[UserId]     NVARCHAR (128) NOT NULL,
		[ClaimType]  NVARCHAR (MAX) NULL,
		[ClaimValue] NVARCHAR (MAX) NULL,
		CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
		);

		CREATE NONCLUSTERED INDEX [IX_UserId]
		ON [dbo].[AspNetUserClaims]([UserId] ASC);
	END
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
IF OBJECT_ID (N'dbo.AspNetUserLogins', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[AspNetUserLogins] (
		[LoginProvider] NVARCHAR (128) NOT NULL,
		[ProviderKey]   NVARCHAR (128) NOT NULL,
		[UserId]        NVARCHAR (128) NOT NULL,
		CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
		CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
		);


		CREATE NONCLUSTERED INDEX [IX_UserId]
		ON [dbo].[AspNetUserLogins]([UserId] ASC);
	END
END

IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
IF OBJECT_ID (N'dbo.AspNetUserRoles', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[AspNetUserRoles] (
		[UserId] NVARCHAR (128) NOT NULL,
		[RoleId] NVARCHAR (128) NOT NULL,
		CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
		CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
		CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
		);

		CREATE NONCLUSTERED INDEX [IX_UserId]
		ON [dbo].[AspNetUserRoles]([UserId] ASC);

		CREATE NONCLUSTERED INDEX [IX_RoleId]
		ON [dbo].[AspNetUserRoles]([RoleId] ASC);
	END
END
IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
USE AutoSiteProjectDB
IF OBJECT_ID (N'dbo.__MigrationHistory', N'U') IS NULL  
	BEGIN
		CREATE TABLE [dbo].[__MigrationHistory] (
		[MigrationId]    NVARCHAR (150)  NOT NULL,
		[ContextKey]     NVARCHAR (300)  NOT NULL,
		[Model]          VARBINARY (MAX) NOT NULL,
		[ProductVersion] NVARCHAR (32)   NOT NULL,
		CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
		);
	END
END

