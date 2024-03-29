USE [SWD]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[account]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[email] [varchar](255) NULL,
	[role] [tinyint] NOT NULL,
	[status] [tinyint] NULL,
	[created_time] [datetime2](7) NULL,
	[updated_time] [datetime2](7) NULL,
	[deleted_time] [datetime2](7) NULL,
	[infomation] [ntext] NULL,
	[address] [nvarchar](1000) NULL,
	[dob] [datetime2](7) NULL,
	[fullname] [nvarchar](1000) NULL,
 CONSTRAINT [PK__Account__3213E83F2BDA6CF1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[decor]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[decor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[price] [money] NULL,
	[status] [tinyint] NULL,
	[created_by] [int] NULL,
	[created_time] [datetime2](7) NULL,
	[updated_time] [datetime2](7) NULL,
	[deleted_time] [datetime2](7) NULL,
 CONSTRAINT [PK__food__3213E83F0AE3A13E_copy_1_copy_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[created_date] [datetime] NULL,
	[stars] [int] NULL,
	[content] [nvarchar](1000) NULL,
	[created_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[food]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[price] [money] NULL,
	[status] [tinyint] NULL,
	[created_by] [int] NULL,
	[created_time] [datetime2](7) NULL,
	[updated_time] [datetime2](7) NULL,
	[deleted_time] [datetime2](7) NULL,
 CONSTRAINT [PK__food__3213E83F0AE3A13E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [money] NULL,
	[status] [tinyint] NULL,
	[created_by] [int] NULL,
	[created_time] [datetime2](7) NULL,
	[updated_time] [datetime2](7) NULL,
	[deleted_time] [datetime2](7) NULL,
	[note] [ntext] NULL,
 CONSTRAINT [PK__food__3213E83F0AE3A13E_copy_1_copy_1_copy_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_decor]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_decor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NULL,
	[id_decor] [int] NULL,
	[quality] [int] NOT NULL,
	[total_price] [money] NULL,
	[status ] [tinyint] NULL,
 CONSTRAINT [PK__order_de__3213E83FCF2C3A66] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_food]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_food] [int] NULL,
	[quality] [int] NOT NULL,
	[total_price] [money] NULL,
	[id_order] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK__order_fo__3213E83FBA641C1D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_room]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NULL,
	[id_room] [int] NULL,
	[start_date] [datetime2](7) NOT NULL,
	[end_date] [datetime2](7) NOT NULL,
	[total_price] [money] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK__order_ro__3213E83FF864F977] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[party_post]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[party_post](
	[party_post_id] [int] IDENTITY(1,1) NOT NULL,
	[party_post_title] [nvarchar](max) NOT NULL,
	[party_post_details] [nvarchar](max) NOT NULL,
	[created_time] [datetime] NULL,
	[created_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[party_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [tinyint] NOT NULL,
	[name] [varchar](255) NULL,
 CONSTRAINT [PK__role__3213E83F6E9CDBB5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[price] [money] NULL,
	[status] [tinyint] NULL,
	[created_by] [int] NULL,
	[created_time] [datetime2](7) NULL,
	[updated_time] [datetime2](7) NULL,
	[deleted_time] [datetime2](7) NULL,
 CONSTRAINT [PK__food__3213E83F0AE3A13E_copy_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 3/20/2024 12:02:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[id] [int] NOT NULL,
	[name] [varchar](255) NULL,
 CONSTRAINT [PK__status__3213E83FD3D5B31E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account] ON 

INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (3, N'quang1', N'string', N'quang020102@gmail.com', 0, 1, CAST(N'2024-03-17T11:02:42.5145334' AS DateTime2), CAST(N'2024-03-17T11:02:42.5145649' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (5, N'acd', N'ad', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T11:05:16.1969079' AS DateTime2), CAST(N'2024-03-17T11:05:16.1969104' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (6, N'a2', N'ad', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T11:05:22.2252464' AS DateTime2), CAST(N'2024-03-17T11:05:22.2252493' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (7, N'abcda', N'aa12321', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T17:58:23.5428411' AS DateTime2), CAST(N'2024-03-17T17:58:23.5428697' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (8, N'abcda1', N'aa12321', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T17:58:48.5454163' AS DateTime2), CAST(N'2024-03-17T17:58:48.5454185' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (9, N'abcdc12', N'123123', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:02:45.2363498' AS DateTime2), CAST(N'2024-03-17T18:02:45.2363526' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (10, N'q2131213', N'123123', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:04:45.0621671' AS DateTime2), CAST(N'2024-03-17T18:04:45.0621694' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (11, N'1321312', N'321312', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:06:11.2890325' AS DateTime2), CAST(N'2024-03-17T18:06:11.2890345' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (12, N'321312', N'312312', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:06:24.6244203' AS DateTime2), CAST(N'2024-03-17T18:06:24.6244237' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (13, N'21312312', N'2132132', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:12:50.4976450' AS DateTime2), CAST(N'2024-03-17T18:12:50.4976475' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (14, N'12312321', N'123213', N'mardgeertatarus113@gmail.com', 0, 1, CAST(N'2024-03-17T18:13:39.2488657' AS DateTime2), CAST(N'2024-03-17T18:13:39.2488682' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (16, N'string@gmail.com', N'string@gmail.com', N'string', 0, 0, CAST(N'2024-03-18T16:47:21.0620000' AS DateTime2), CAST(N'2024-03-18T16:47:21.0620000' AS DateTime2), CAST(N'2024-03-18T16:47:21.0620000' AS DateTime2), N'', N'', CAST(N'2024-03-18T16:47:21.0620000' AS DateTime2), N'')
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (17, N'aaa', N'aaa', N'aaa', 0, 0, CAST(N'2024-03-18T17:43:51.8470000' AS DateTime2), CAST(N'2024-03-18T17:43:51.8470000' AS DateTime2), CAST(N'2024-03-18T17:43:51.8470000' AS DateTime2), N'string', N'string', CAST(N'2024-03-18T17:43:51.8470000' AS DateTime2), N'string')
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (18, N'string', N'string', N'stringaaaa', 0, 0, CAST(N'2024-03-18T17:45:51.3660000' AS DateTime2), CAST(N'2024-03-18T17:45:51.3660000' AS DateTime2), CAST(N'2024-03-18T17:45:51.3660000' AS DateTime2), N'string', N'string', CAST(N'2024-03-18T17:45:51.3660000' AS DateTime2), N'string')
INSERT [dbo].[account] ([id], [username], [password], [email], [role], [status], [created_time], [updated_time], [deleted_time], [infomation], [address], [dob], [fullname]) VALUES (20, N'mardgeertatarus113@gmail.com', N'string', N'mardgeertatarus1@gmail.com', 0, 0, CAST(N'2024-03-18T17:55:13.8110000' AS DateTime2), CAST(N'2024-03-18T17:55:13.8110000' AS DateTime2), CAST(N'2024-03-18T17:55:13.8110000' AS DateTime2), N'string', N'string', CAST(N'2024-03-18T17:55:13.8110000' AS DateTime2), N'string')
SET IDENTITY_INSERT [dbo].[account] OFF
GO
SET IDENTITY_INSERT [dbo].[feedback] ON 

INSERT [dbo].[feedback] ([feedback_id], [created_date], [stars], [content], [created_by]) VALUES (1, CAST(N'2024-03-18T18:00:33.547' AS DateTime), 4, N'Food is really good', 3)
INSERT [dbo].[feedback] ([feedback_id], [created_date], [stars], [content], [created_by]) VALUES (2, CAST(N'2024-03-18T18:00:33.547' AS DateTime), 4, N'Food is really good', 3)
INSERT [dbo].[feedback] ([feedback_id], [created_date], [stars], [content], [created_by]) VALUES (3, CAST(N'2024-03-18T18:00:33.547' AS DateTime), 10, N'Decoration is really cool and beautiful', 3)
INSERT [dbo].[feedback] ([feedback_id], [created_date], [stars], [content], [created_by]) VALUES (4, CAST(N'2024-03-18T18:00:33.547' AS DateTime), 10, N'Room is quite big and comfortable', 3)
SET IDENTITY_INSERT [dbo].[feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[party_post] ON 

INSERT [dbo].[party_post] ([party_post_id], [party_post_title], [party_post_details], [created_time], [created_by]) VALUES (1, N'party post 1', N'party_post_details 1', CAST(N'2022-05-05T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[party_post] ([party_post_id], [party_post_title], [party_post_details], [created_time], [created_by]) VALUES (3, N'party post 2', N'party_post_details 2', CAST(N'2022-05-06T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[party_post] ([party_post_id], [party_post_title], [party_post_details], [created_time], [created_by]) VALUES (4, N'party post 3', N'party_post_details 3', CAST(N'2022-06-06T00:00:00.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[party_post] OFF
GO
INSERT [dbo].[role] ([id], [name]) VALUES (0, N'customer')
INSERT [dbo].[role] ([id], [name]) VALUES (1, N'admin')
INSERT [dbo].[role] ([id], [name]) VALUES (2, N'host')
GO
INSERT [dbo].[status] ([id], [name]) VALUES (0, N'Delete')
INSERT [dbo].[status] ([id], [name]) VALUES (1, N'Active')
INSERT [dbo].[status] ([id], [name]) VALUES (2, N'Waiting Approve Services')
INSERT [dbo].[status] ([id], [name]) VALUES (3, N'Do not Approve Services')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [username]    Script Date: 3/20/2024 12:02:04 AM ******/
ALTER TABLE [dbo].[account] ADD  CONSTRAINT [username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [id_order_unique]    Script Date: 3/20/2024 12:02:04 AM ******/
ALTER TABLE [dbo].[order_room] ADD  CONSTRAINT [id_order_unique] UNIQUE NONCLUSTERED 
(
	[id_order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[decor]  WITH CHECK ADD  CONSTRAINT [fk_decor_account_id] FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[decor] CHECK CONSTRAINT [fk_decor_account_id]
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[food]  WITH CHECK ADD  CONSTRAINT [fk_food_account_id] FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[food] CHECK CONSTRAINT [fk_food_account_id]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [fk_order_account_id] FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [fk_order_account_id]
GO
ALTER TABLE [dbo].[order_decor]  WITH CHECK ADD  CONSTRAINT [fk_order_decor_decor_id] FOREIGN KEY([id_decor])
REFERENCES [dbo].[decor] ([id])
GO
ALTER TABLE [dbo].[order_decor] CHECK CONSTRAINT [fk_order_decor_decor_id]
GO
ALTER TABLE [dbo].[order_decor]  WITH CHECK ADD  CONSTRAINT [fk_order_decor_order_id] FOREIGN KEY([id_order])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_decor] CHECK CONSTRAINT [fk_order_decor_order_id]
GO
ALTER TABLE [dbo].[order_food]  WITH CHECK ADD  CONSTRAINT [fk_order_food_food_id] FOREIGN KEY([id_food])
REFERENCES [dbo].[food] ([id])
GO
ALTER TABLE [dbo].[order_food] CHECK CONSTRAINT [fk_order_food_food_id]
GO
ALTER TABLE [dbo].[order_food]  WITH CHECK ADD  CONSTRAINT [fk_order_food_order_id] FOREIGN KEY([id_order])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_food] CHECK CONSTRAINT [fk_order_food_order_id]
GO
ALTER TABLE [dbo].[order_room]  WITH CHECK ADD  CONSTRAINT [fk_order_room_order_id] FOREIGN KEY([id_order])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_room] CHECK CONSTRAINT [fk_order_room_order_id]
GO
ALTER TABLE [dbo].[order_room]  WITH CHECK ADD  CONSTRAINT [fk_order_room_room_id] FOREIGN KEY([id_room])
REFERENCES [dbo].[room] ([id])
GO
ALTER TABLE [dbo].[order_room] CHECK CONSTRAINT [fk_order_room_room_id]
GO
ALTER TABLE [dbo].[party_post]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD  CONSTRAINT [fk_room_account_id] FOREIGN KEY([created_by])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[room] CHECK CONSTRAINT [fk_room_account_id]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 3/20/2024 12:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
