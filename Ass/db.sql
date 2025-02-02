USE [master]
GO
/****** Object:  Database [DebtCompany]    Script Date: 3/14/2024 10:45:46 AM ******/
CREATE DATABASE [DebtCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DebtCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DebtCompany.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DebtCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DebtCompany_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DebtCompany] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DebtCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DebtCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DebtCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DebtCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DebtCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DebtCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [DebtCompany] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DebtCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DebtCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DebtCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DebtCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DebtCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DebtCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DebtCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DebtCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DebtCompany] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DebtCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DebtCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DebtCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DebtCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DebtCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DebtCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DebtCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DebtCompany] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DebtCompany] SET  MULTI_USER 
GO
ALTER DATABASE [DebtCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DebtCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DebtCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DebtCompany] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DebtCompany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DebtCompany] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DebtCompany] SET QUERY_STORE = ON
GO
ALTER DATABASE [DebtCompany] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DebtCompany]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/14/2024 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](45) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Username] [varchar](45) NOT NULL,
	[Password] [varchar](45) NOT NULL,
	[Phone] [varchar](11) NULL,
	[DOB] [varchar](45) NULL,
	[Available] [float] NULL,
	[Debt] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/14/2024 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] NOT NULL,
	[Username] [varchar](45) NOT NULL,
	[Password] [varchar](45) NOT NULL,
	[Available] [float] NULL,
	[Debt] [float] NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRequire]    Script Date: 3/14/2024 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRequire](
	[RequireId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NULL,
	[ProductName] [nvarchar](45) NULL,
	[Weight] [float] NULL,
	[Cost] [float] NULL,
	[Date] [varchar](45) NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[RequireId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 3/14/2024 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MsgId] [int] NOT NULL,
	[Sender] [nvarchar](max) NULL,
	[Receiver] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[SendDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MsgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/14/2024 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](45) NOT NULL,
	[Price] [float] NULL,
	[Weight] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Name], [Address], [Username], [Password], [Phone], [DOB], [Available], [Debt]) VALUES (1, N'Chú Chuyên Cỏ', N'Viet Tri', N'a', N'abc', N'0912181156', N'2002-01-21', 3014000, 800)
INSERT [dbo].[Account] ([ID], [Name], [Address], [Username], [Password], [Phone], [DOB], [Available], [Debt]) VALUES (2, N'Bà Chuyên Rau', N'viet tri', N'b', N'b', N'0913308696', N'1998-10-31', 1500, 100)
INSERT [dbo].[Account] ([ID], [Name], [Address], [Username], [Password], [Phone], [DOB], [Available], [Debt]) VALUES (3, N'Ông Chuyên Cám', N'viet tri', N'c', N'c', N'0977414858', N'1972-11-26', 0, 2700)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Admin] ([ID], [Username], [Password], [Available], [Debt], [Name]) VALUES (1, N'admin', N'admin', 996985999, 0, N'admin')
GO
SET IDENTITY_INSERT [dbo].[AdminRequire] ON 

INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (1, 1, N'Grass', 10, 100, N'28-10-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (2, 1, N'Grass', 10, 100, N'28-10-2023', N'Rejected')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (3, 1, N'Grass', 10, 100, N'28-10-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (4, 2, N'Corn', 50, 1500, N'30-10-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (5, 1, N'Bran', 50, 1000, N'08-11-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (9, 1, N'Weed', 50, 15000, N'09-11-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (10, 1, N'Grass', 100, 1000, N'09-11-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (11, 1, N'Weed', 9990, 2997000, N'09-11-2023', N'Paid')
INSERT [dbo].[AdminRequire] ([RequireId], [SupplierId], [ProductName], [Weight], [Cost], [Date], [Status]) VALUES (12, 1, N'Bran', 50, 1000, N'10-11-2023', N'Pending')
SET IDENTITY_INSERT [dbo].[AdminRequire] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [ProductName], [Price], [Weight]) VALUES (1, N'Grass', 10, 1)
INSERT [dbo].[Product] ([ID], [ProductName], [Price], [Weight]) VALUES (2, N'Bran', 20, 1)
INSERT [dbo].[Product] ([ID], [ProductName], [Price], [Weight]) VALUES (3, N'Corn', 30, 1)
INSERT [dbo].[Product] ([ID], [ProductName], [Price], [Weight]) VALUES (11, N'Weed', 300, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [DebtCompany] SET  READ_WRITE 
GO
