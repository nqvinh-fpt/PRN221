USE [EventManagementDB0]
GO
/****** Object:  Table [dbo].[Attendees]    Script Date: 3/11/2024 3:38:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendees](
	[AttendeeID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[UserID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[RegistrationTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCategories]    Script Date: 3/11/2024 3:38:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 3/11/2024 3:38:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [text] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Location] [nvarchar](100) NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/11/2024 3:38:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attendees] ON 

INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (21, 8, 1, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-04T23:34:38.993' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (22, 9, 1, N'Attendee 1', N'attendee1@example.com', CAST(N'2024-05-01T08:30:00.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (23, 10, 3, N'Attendee 2', N'attendee2@example.com', CAST(N'2024-05-02T09:15:00.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (24, 8, 2, N'Attendee 3', N'attendee3@example.com', CAST(N'2024-04-15T12:00:00.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (25, 10, 4, N'Attendee 4', N'attendee4@example.com', CAST(N'2024-06-01T10:30:00.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (26, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-05T16:21:18.630' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (27, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-05T16:22:18.957' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (28, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:23:43.323' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (29, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:24:53.880' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (30, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:26:02.033' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (31, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:26:48.140' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (32, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:29:42.893' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (33, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:29:53.203' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (34, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:31:48.120' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (35, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:33:42.787' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (36, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:35:01.143' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (37, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:35:43.500' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (38, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:39:53.710' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (39, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:45:21.700' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (40, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T16:59:50.223' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (41, 8, NULL, N'Dang Thu Ha1', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-05T17:03:30.207' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1002, 12, NULL, N'Cuaaaaa', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-07T23:55:38.257' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1003, 13, NULL, N'Thu', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:00:34.360' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1004, 11, NULL, N'Thu', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:27:21.560' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1005, 14, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:28:03.467' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1006, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:31:19.240' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1007, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:42:33.617' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1008, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:44:36.953' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1009, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:48:29.257' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1010, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:54:14.127' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1011, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:55:00.397' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1012, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T00:56:33.707' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1013, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T01:05:47.887' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1014, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T01:09:05.687' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1015, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T01:13:55.210' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1016, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T01:19:12.567' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1017, 8, NULL, N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T01:24:01.920' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1018, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:12:07.160' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1019, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:46:22.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1020, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:50:21.847' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1021, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:52:42.093' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1022, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:58:03.180' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1023, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:58:45.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1024, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T12:59:35.063' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1025, 8, NULL, N'Cuaaaaa', N'Hadthe161680@fpt.edu.vn', CAST(N'2024-03-08T13:00:45.367' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1026, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T13:02:15.493' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1027, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T13:02:47.863' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1028, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T15:03:46.000' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1029, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T15:36:03.083' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1030, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T15:37:18.557' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1031, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T15:57:41.603' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1032, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T16:14:24.067' AS DateTime))
INSERT [dbo].[Attendees] ([AttendeeID], [EventID], [UserID], [Name], [Email], [RegistrationTime]) VALUES (1033, 8, NULL, N'Dinh Dai Nam', N'dangthhuha2622002@gmail.com', CAST(N'2024-03-08T16:35:39.633' AS DateTime))
SET IDENTITY_INSERT [dbo].[Attendees] OFF
GO
SET IDENTITY_INSERT [dbo].[EventCategories] ON 

INSERT [dbo].[EventCategories] ([CategoryID], [CategoryName]) VALUES (1, N'Conference')
INSERT [dbo].[EventCategories] ([CategoryID], [CategoryName]) VALUES (2, N'Seminar')
INSERT [dbo].[EventCategories] ([CategoryID], [CategoryName]) VALUES (3, N'Workshop')
INSERT [dbo].[EventCategories] ([CategoryID], [CategoryName]) VALUES (4, N'Webinar')
INSERT [dbo].[EventCategories] ([CategoryID], [CategoryName]) VALUES (5, N'Networking Event')
SET IDENTITY_INSERT [dbo].[EventCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (8, N'Conference', N'Annual conference for professionals', CAST(N'2024-05-15T09:00:00.000' AS DateTime), CAST(N'2024-05-17T17:00:00.000' AS DateTime), N'Conference Center A', 2)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (9, N'Seminar on Marketing Trends', N'Explore the latest trends in marketing', CAST(N'2024-04-20T14:00:00.000' AS DateTime), CAST(N'2024-04-20T18:00:00.000' AS DateTime), N'Seminar Hall BA', 2)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (10, N'Workshop on Data Analysis', N'Hands-on workshop on data analysis techniques', CAST(N'2024-06-10T10:00:00.000' AS DateTime), CAST(N'2024-06-10T16:00:00.000' AS DateTime), N'Training Room C', 3)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (11, N'Webinar on Artificial Intelligence', N'Introduction to AI and its applications', CAST(N'2024-03-05T11:00:00.000' AS DateTime), CAST(N'2024-03-05T12:30:00.000' AS DateTime), N'Online', 4)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (12, N'Networking Mixer', N'An informal gathering for professionals to network', CAST(N'2024-07-08T18:00:00.000' AS DateTime), CAST(N'2024-07-08T20:00:00.000' AS DateTime), N'Restaurant XYZ', 5)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (13, N'Ha11111111', N'Gaaa', CAST(N'2024-03-05T22:18:00.000' AS DateTime), CAST(N'2024-03-07T22:18:00.000' AS DateTime), N'Ha Noi', 2)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (14, N'Ha', N'Gaaa', CAST(N'2024-03-05T22:19:00.000' AS DateTime), CAST(N'2024-03-12T22:19:00.000' AS DateTime), N'Ha Noi', 5)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (16, N'Ha1111', N'Hoang', CAST(N'2024-03-07T15:36:00.000' AS DateTime), CAST(N'2024-03-16T15:36:00.000' AS DateTime), N'Ha Noi', 1)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1003, N'Hong', N'ga', CAST(N'2024-03-04T23:30:00.000' AS DateTime), CAST(N'2024-03-07T23:30:00.000' AS DateTime), N'Ha Noi', 1)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1004, N'Hong', N'ga', CAST(N'2024-03-07T00:44:00.000' AS DateTime), CAST(N'2024-03-16T00:44:00.000' AS DateTime), N'Ha Noi', 1)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1005, N'Thu', N'aaaaaaa', CAST(N'2024-03-06T02:57:00.000' AS DateTime), CAST(N'2024-03-16T02:57:00.000' AS DateTime), N'Ha Noi', 2)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1007, N'Tân', N'ga', CAST(N'2024-03-08T22:27:00.000' AS DateTime), CAST(N'2024-03-16T22:27:00.000' AS DateTime), N'Ha Noi', 3)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1008, N'haaaaa', N'ga', CAST(N'2024-03-08T22:45:00.000' AS DateTime), CAST(N'2024-03-09T22:45:00.000' AS DateTime), N'Ha Noi', 3)
INSERT [dbo].[Events] ([EventID], [Title], [Description], [StartTime], [EndTime], [Location], [CategoryID]) VALUES (1010, N'Ha11111111', N'ga', CAST(N'2024-03-09T16:33:00.000' AS DateTime), CAST(N'2024-03-23T16:33:00.000' AS DateTime), N'Ha Noi', 3)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1, N'Viet', N'Ha123', NULL, NULL, N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (2, N'Ha', N'Ha123', N'Dang Thu Ha', N'dangthuha@fpt.com', N'Admin')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (3, N'Lan', N'Lan123', N'Cat Ba Lan', N'catbalan@fpt.com', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (4, N'Tam', N'Tam123', N'Hoang Duc Tam', N'hoangductam@fpt.com', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (5, N'Nam', N'Nam123', N'Dinh Dai Nam', N'dinhdainam@fpt.com', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (6, N'Dat', N'Dat123', N'Tran Tien Dat', N'trantiendat@fpt.com', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (7, N'Ha', N'Ha123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (8, N'Ha', N'Nam123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (9, N'Ha', N'123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (10, N'Ha1', N'123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (11, N'Ha', N'111', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1002, N'thu', N'123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1003, N'Cua', N'123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1004, N'Tan 111', N'111', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Admin')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1005, N'thuuuuu', N'111', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Admin')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1006, N'Ha', N'111', N'Cuaaaaa', N'Hadthe161680@fpt.edu.vn', N'Client')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [Role]) VALUES (1007, N'Ha', N'Ha123', N'Dang Thu Ha', N'Hadthe161680@fpt.edu.vn', N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[EventCategories] ([CategoryID])
GO
