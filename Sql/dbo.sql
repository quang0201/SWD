/*
 Navicat Premium Data Transfer

 Source Server         : sql
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : localhost:1433
 Source Catalog        : Party
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 01/02/2024 15:32:22
*/


-- ----------------------------
-- Table structure for Account
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type IN ('U'))
	DROP TABLE [dbo].[Account]
GO

CREATE TABLE [dbo].[Account] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_number] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [username] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [password] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [role] tinyint  NOT NULL,
  [status] tinyint  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Account] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Account
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Account] ON
GO

SET IDENTITY_INSERT [dbo].[Account] OFF
GO


-- ----------------------------
-- Table structure for Decor
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Decor]') AND type IN ('U'))
	DROP TABLE [dbo].[Decor]
GO

CREATE TABLE [dbo].[Decor] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [price] money  NOT NULL,
  [type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [status] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Decor] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Decor
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Decor] ON
GO

SET IDENTITY_INSERT [dbo].[Decor] OFF
GO


-- ----------------------------
-- Table structure for FeedBack
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[FeedBack]') AND type IN ('U'))
	DROP TABLE [dbo].[FeedBack]
GO

CREATE TABLE [dbo].[FeedBack] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [content] ntext COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [id_party] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[FeedBack] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of FeedBack
-- ----------------------------
SET IDENTITY_INSERT [dbo].[FeedBack] ON
GO

SET IDENTITY_INSERT [dbo].[FeedBack] OFF
GO


-- ----------------------------
-- Table structure for Food
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Food]') AND type IN ('U'))
	DROP TABLE [dbo].[Food]
GO

CREATE TABLE [dbo].[Food] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [content] ntext COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [quality] int  NOT NULL,
  [type] tinyint  NOT NULL,
  [status] tinyint  NOT NULL,
  [price] money  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Food] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Food
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Food] ON
GO

SET IDENTITY_INSERT [dbo].[Food] OFF
GO


-- ----------------------------
-- Table structure for Order
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type IN ('U'))
	DROP TABLE [dbo].[Order]
GO

CREATE TABLE [dbo].[Order] (
  [id] int  NOT NULL,
  [id_number] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [list_food] text COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [list_decor] text COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [room] text COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [pre_price] money  NOT NULL,
  [actual_price] money  NOT NULL,
  [status] tinyint  NOT NULL,
  [type] tinyint  NOT NULL,
  [note] ntext COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Order] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Order
-- ----------------------------

-- ----------------------------
-- Table structure for Package
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Package]') AND type IN ('U'))
	DROP TABLE [dbo].[Package]
GO

CREATE TABLE [dbo].[Package] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [content] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [status] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [price] money  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Package] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Package
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Package] ON
GO

SET IDENTITY_INSERT [dbo].[Package] OFF
GO


-- ----------------------------
-- Table structure for Party
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Party]') AND type IN ('U'))
	DROP TABLE [dbo].[Party]
GO

CREATE TABLE [dbo].[Party] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [content] ntext COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [status] tinyint  NOT NULL,
  [type] tinyint  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Party] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Party
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Party] ON
GO

SET IDENTITY_INSERT [dbo].[Party] OFF
GO


-- ----------------------------
-- Table structure for Payment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Payment]') AND type IN ('U'))
	DROP TABLE [dbo].[Payment]
GO

CREATE TABLE [dbo].[Payment] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_payment] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [money] decimal(18)  NOT NULL,
  [content] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [status] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Payment] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Payment
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Payment] ON
GO

SET IDENTITY_INSERT [dbo].[Payment] OFF
GO


-- ----------------------------
-- Table structure for Room
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Room]') AND type IN ('U'))
	DROP TABLE [dbo].[Room]
GO

CREATE TABLE [dbo].[Room] (
  [int] int  IDENTITY(1,1) NOT NULL,
  [number] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [status] tinyint  NOT NULL,
  [type] tinyint  NOT NULL,
  [size] tinyint  NOT NULL,
  [max_capacity] int  NOT NULL,
  [price] money  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Room] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Room
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Room] ON
GO

SET IDENTITY_INSERT [dbo].[Room] OFF
GO


-- ----------------------------
-- Table structure for Trans
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Trans]') AND type IN ('U'))
	DROP TABLE [dbo].[Trans]
GO

CREATE TABLE [dbo].[Trans] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_number] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [id_payment] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [status] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [created_time] datetime2(7)  NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Trans] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Trans
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Trans] ON
GO

SET IDENTITY_INSERT [dbo].[Trans] OFF
GO


-- ----------------------------
-- Table structure for Voucher
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Voucher]') AND type IN ('U'))
	DROP TABLE [dbo].[Voucher]
GO

CREATE TABLE [dbo].[Voucher] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [type] tinyint  NOT NULL,
  [discount] float(53)  NOT NULL,
  [status] tinyint  NOT NULL,
  [name] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [created_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [created_time] datetime2(7)  NOT NULL,
  [updated_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [updated_time] datetime2(7)  NULL,
  [deleted_by] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [deleted_time] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Voucher] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Voucher
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Voucher] ON
GO

SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO


-- ----------------------------
-- procedure structure for sp_upgraddiagrams
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_upgraddiagrams]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_upgraddiagrams]
GO

CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
GO


-- ----------------------------
-- procedure structure for sp_helpdiagrams
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagrams]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_helpdiagrams]
GO

CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO


-- ----------------------------
-- procedure structure for sp_helpdiagramdefinition
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagramdefinition]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_helpdiagramdefinition]
GO

CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_creatediagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_creatediagram]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_creatediagram]
GO

CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
GO


-- ----------------------------
-- procedure structure for sp_renamediagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_renamediagram]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_renamediagram]
GO

CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_alterdiagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_alterdiagram]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_alterdiagram]
GO

CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_dropdiagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_dropdiagram]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[sp_dropdiagram]
GO

CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO


-- ----------------------------
-- function structure for fn_diagramobjects
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_diagramobjects]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP FUNCTION[dbo].[fn_diagramobjects]
GO

CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
GO


-- ----------------------------
-- Auto increment value for Account
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Account]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table Account
-- ----------------------------
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [number] UNIQUE NONCLUSTERED ([id_number] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account] ADD CONSTRAINT [username] UNIQUE NONCLUSTERED ([username] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Account
-- ----------------------------
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [PK__Account__3213E83F2BDA6CF1] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Decor
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Decor]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Decor
-- ----------------------------
ALTER TABLE [dbo].[Decor] ADD CONSTRAINT [PK__Decor__3213E83FA0308936] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for FeedBack
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[FeedBack]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table FeedBack
-- ----------------------------
ALTER TABLE [dbo].[FeedBack] ADD CONSTRAINT [PK__FeedBack__3213E83F6043647A] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Food
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Food]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Food
-- ----------------------------
ALTER TABLE [dbo].[Food] ADD CONSTRAINT [PK__Food__3213E83F0641FA08] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Uniques structure for table Order
-- ----------------------------
ALTER TABLE [dbo].[Order] ADD CONSTRAINT [number_order] UNIQUE NONCLUSTERED ([id_number] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Order
-- ----------------------------
ALTER TABLE [dbo].[Order] ADD CONSTRAINT [PK__Order__3213E83F14AF5DB6] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Package
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Package]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Package
-- ----------------------------
ALTER TABLE [dbo].[Package] ADD CONSTRAINT [PK__Package__3213E83FA519874B] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Party
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Party]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Party
-- ----------------------------
ALTER TABLE [dbo].[Party] ADD CONSTRAINT [PK__Party__3213E83F57A5724C] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Payment
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Payment]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Payment
-- ----------------------------
ALTER TABLE [dbo].[Payment] ADD CONSTRAINT [PK__Payment__3213E83F15738CFD] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Room
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Room]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table Room
-- ----------------------------
ALTER TABLE [dbo].[Room] ADD CONSTRAINT [numberr] UNIQUE NONCLUSTERED ([number] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Room
-- ----------------------------
ALTER TABLE [dbo].[Room] ADD CONSTRAINT [PK__Room__DC50F6D88CA75E56] PRIMARY KEY CLUSTERED ([int])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Trans
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Trans]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Trans
-- ----------------------------
ALTER TABLE [dbo].[Trans] ADD CONSTRAINT [PK__Trans__3213E83F3CBCFE47] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Voucher
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Voucher]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Voucher
-- ----------------------------
ALTER TABLE [dbo].[Voucher] ADD CONSTRAINT [PK__Voucher__3213E83F372D42F3] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

