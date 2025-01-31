USE [master]
GO
/****** Object:  Database [SignalRCrudDB]    Script Date: 8/18/2023 2:06:39 PM ******/
CREATE DATABASE [SignalRCrudDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SignalRCrudDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\SignalRCrudDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SignalRCrudDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\SignalRCrudDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SignalRCrudDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SignalRCrudDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SignalRCrudDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SignalRCrudDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SignalRCrudDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SignalRCrudDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SignalRCrudDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SignalRCrudDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SignalRCrudDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SignalRCrudDB] SET  MULTI_USER 
GO
ALTER DATABASE [SignalRCrudDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SignalRCrudDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SignalRCrudDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SignalRCrudDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SignalRCrudDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SignalRCrudDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SignalRCrudDB] SET QUERY_STORE = OFF
GO
USE [SignalRCrudDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/18/2023 2:06:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProdId] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[StockQty] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProdId], [ProdName], [Category], [UnitPrice], [StockQty]) VALUES (2, N'Name', N'Name', CAST(60000.00 AS Decimal(18, 2)), 43)
INSERT [dbo].[Products] ([ProdId], [ProdName], [Category], [UnitPrice], [StockQty]) VALUES (3, N'Helo', N'Nam', CAST(6000.00 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
USE [master]
GO
ALTER DATABASE [SignalRCrudDB] SET  READ_WRITE 
GO
