USE [master]
GO
/****** Object:  Database [TEST-DB]    Script Date: 10/23/2023 7:08:22 AM ******/
CREATE DATABASE [TEST-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TEST-DB', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS2\MSSQL\DATA\TEST-DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TEST-DB_log', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS2\MSSQL\DATA\TEST-DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TEST-DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TEST-DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TEST-DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TEST-DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TEST-DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TEST-DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TEST-DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TEST-DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TEST-DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TEST-DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TEST-DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TEST-DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TEST-DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TEST-DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TEST-DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TEST-DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TEST-DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TEST-DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TEST-DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TEST-DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TEST-DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TEST-DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TEST-DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TEST-DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TEST-DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TEST-DB] SET  MULTI_USER 
GO
ALTER DATABASE [TEST-DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TEST-DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TEST-DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TEST-DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TEST-DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TEST-DB]
GO
/****** Object:  User [adminDBA]    Script Date: 10/23/2023 7:08:23 AM ******/
CREATE USER [adminDBA] FOR LOGIN [adminDBA] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [adminDBA]
GO
/****** Object:  Table [dbo].[College]    Script Date: 10/23/2023 7:08:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[CollegeID] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCode] [nvarchar](50) NULL,
	[CollegeName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED 
(
	[CollegeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/23/2023 7:08:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[CollegeID] [int] NULL,
	[DepartmentCode] [nvarchar](50) NULL,
	[DepartmentName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[College] ON 

INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (1, N'CCS', N'College of Information and Computer Studies', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (2, N'CHM', N'College of Hospitality Management', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (3, N'COEd', N'College of Education', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (4, N'COE', N'College of Engineering', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (5, N'CN', N'College of Nursing', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeCode], [CollegeName], [IsActive]) VALUES (6, N'COPSL', N'College of Political Science and Law', 1)
SET IDENTITY_INSERT [dbo].[College] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [CollegeID], [DepartmentCode], [DepartmentName], [IsActive]) VALUES (1, 1, N'InfoTech', N'Information Technology', 1)
INSERT [dbo].[Department] ([DepartmentID], [CollegeID], [DepartmentCode], [DepartmentName], [IsActive]) VALUES (2, 1, N'CompSci', N'Computer Science', 1)
INSERT [dbo].[Department] ([DepartmentID], [CollegeID], [DepartmentCode], [DepartmentName], [IsActive]) VALUES (3, 3, N'BA', N'Business Administration', 1)
INSERT [dbo].[Department] ([DepartmentID], [CollegeID], [DepartmentCode], [DepartmentName], [IsActive]) VALUES (4, 1, N'InfoSys', N'Information Systems', 1)
INSERT [dbo].[Department] ([DepartmentID], [CollegeID], [DepartmentCode], [DepartmentName], [IsActive]) VALUES (10, 4, N'CpE', N'Computer Engineering', 1)
SET IDENTITY_INSERT [dbo].[Department] OFF
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_College_Department] FOREIGN KEY([CollegeID])
REFERENCES [dbo].[College] ([CollegeID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_College_Department]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [CK_DepartmentID] CHECK  (([DepartmentID]>(0) AND [DepartmentID]<(11)))
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [CK_DepartmentID]
GO
USE [master]
GO
ALTER DATABASE [TEST-DB] SET  READ_WRITE 
GO
