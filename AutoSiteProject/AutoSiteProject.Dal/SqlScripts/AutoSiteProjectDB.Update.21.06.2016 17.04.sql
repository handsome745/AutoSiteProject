USE master
GO
IF EXISTS(select * from sys.databases where name='AutoSiteProjectDB')
BEGIN 
	IF NOT EXISTS (SELECT * FROM sys.objects 
					WHERE object_id = OBJECT_ID(N'[dbo].[ModelBodyTypes]') AND type in (N'U'))
	BEGIN
		USE AutoSiteProjectDB
		truncate table dbo.ModelBodyTypes
		drop table dbo.ModelBodyTypes
	END
END
GO
