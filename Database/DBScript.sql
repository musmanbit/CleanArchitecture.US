USE [master]
GO
/****** Object:  Database [CleanArchitectureDB]    Script Date: 10/14/2020 2:41:55 PM ******/
CREATE DATABASE [CleanArchitectureDB]
 CONTAINMENT = NONE   
 ON  PRIMARY 
( NAME = N'CleanArchitectureDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CleanArchitectureDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CleanArchitectureDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CleanArchitectureDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CleanArchitectureDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CleanArchitectureDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CleanArchitectureDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CleanArchitectureDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CleanArchitectureDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CleanArchitectureDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CleanArchitectureDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CleanArchitectureDB] SET  MULTI_USER 
GO
ALTER DATABASE [CleanArchitectureDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CleanArchitectureDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CleanArchitectureDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CleanArchitectureDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CleanArchitectureDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CleanArchitectureDB', N'ON'
GO
USE [CleanArchitectureDB]
GO
/****** Object:  User [sa1]    Script Date: 10/14/2020 2:41:56 PM ******/
CREATE USER [sa1] FOR LOGIN [sa1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdminAccess]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccess](
	[admin_access_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_id] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[user_id] [int] NOT NULL CONSTRAINT [DF_AdminAccess_user_id]  DEFAULT ((1)),
 CONSTRAINT [PK_AdminAccess] PRIMARY KEY CLUSTERED 
(
	[admin_access_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[admin_id] [int] NOT NULL CONSTRAINT [DF_User_admin_id]  DEFAULT ((1)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (2, 2, N'US1')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (3, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (4, 1, N'US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (6, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (7, 1, N'US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (8, 2, N'US1')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (9, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (10, 1, N'US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (11, 2, N'US1')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (12, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (13, 2, N'US1')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (14, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (15, 1, N'US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (16, 2, N'US1')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (17, 3, N'US3')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (18, 1, N'US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (1002, 5, N'36 - US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (1005, 5, N'46 - US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (1009, 5, N'55 - US')
INSERT [dbo].[Admin] ([admin_id], [created_by], [first_name]) VALUES (1010, 5, N'26 - US')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[AdminAccess] ON 

INSERT [dbo].[AdminAccess] ([admin_access_id], [admin_id], [created_by], [first_name], [user_id]) VALUES (2, 2, 2, N'adser', 1)
SET IDENTITY_INSERT [dbo].[AdminAccess] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (1, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (2, 6, N'US3', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (3, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (4, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (6, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (7, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (8, 6, N'US3', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (9, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (10, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (11, 6, N'US3', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (12, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (13, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (14, 6, N'US3', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (15, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (16, 5, N'ABC', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (17, 6, N'US3', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (18, 7, N'AED', 2)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (1003, 5, N'46 - US', 1005)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (1007, 5, N'55 - US', 1009)
INSERT [dbo].[User] ([user_id], [created_by], [first_name], [admin_id]) VALUES (1008, 5, N'26 - US', 1010)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[AdminAccess]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccess_AdminAccess_userId] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[AdminAccess] CHECK CONSTRAINT [FK_AdminAccess_AdminAccess_userId]
GO
ALTER TABLE [dbo].[AdminAccess]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Table_adminid] FOREIGN KEY([admin_id])
REFERENCES [dbo].[Admin] ([admin_id])
GO
ALTER TABLE [dbo].[AdminAccess] CHECK CONSTRAINT [FK_Table_1_Table_adminid]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_adminId] FOREIGN KEY([admin_id])
REFERENCES [dbo].[Admin] ([admin_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_adminId]
GO
/****** Object:  StoredProcedure [dbo].[gen_Admin_Delete]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_Admin_Delete]
(
@AdminId Int
)
AS
delete from  [dbo].[Admin] 
WHERE
[admin_id]=@AdminId


GO
/****** Object:  StoredProcedure [dbo].[gen_Admin_GetAll]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_Admin_GetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT
[admin_id],[created_by],[first_name]
FROM
[dbo].[Admin] WITH(NOLOCK)
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_Admin_GetByadmin_id]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_Admin_GetByadmin_id]
(
@AdminId Int
)
AS
SELECT
[admin_id],[created_by],[first_name]
FROM
[dbo].[Admin] WITH(NOLOCK)
WHERE
[admin_id]=@AdminId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_Admin_Insert]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_Admin_Insert]
(
@AdminId Int OUTPUT,@CreatedBy Int,@FirstName NVarChar(50)
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
INSERT  INTO [dbo].[Admin]
(
[created_by],[first_name]
)
VALUES
(
@CreatedBy,@FirstName
);
SET @AdminId = SCOPE_IDENTITY();


GO
/****** Object:  StoredProcedure [dbo].[gen_Admin_Update]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_Admin_Update]
(
@AdminId Int,@CreatedBy Int,@FirstName NVarChar(50)
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
UPDATE [dbo].[Admin]
SET
[created_by]=@CreatedBy,[first_name]=@FirstName
WHERE
admin_id=@AdminId


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_Delete]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_Delete]
(
@AdminAccessId Int
)
AS
delete from  [dbo].[AdminAccess] 
WHERE
[admin_access_id]=@AdminAccessId


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_GetAll]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_GetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT
[admin_access_id],[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[AdminAccess] WITH(NOLOCK)
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_GetByadmin_access_id]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_GetByadmin_access_id]
(
@AdminAccessId Int
)
AS
SELECT
[admin_access_id],[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[AdminAccess] WITH(NOLOCK)
WHERE
[admin_access_id]=@AdminAccessId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_GetListByForeignKey_AdminId]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_GetListByForeignKey_AdminId]
(
@AdminId Int
)
AS
SELECT
[admin_access_id],[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[AdminAccess] WITH(NOLOCK)
WHERE
[admin_id]=@AdminId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_GetListByForeignKey_UserId]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_GetListByForeignKey_UserId]
(
@UserId Int
)
AS
SELECT
[admin_access_id],[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[AdminAccess] WITH(NOLOCK)
WHERE
[user_id]=@UserId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_Insert]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_Insert]
(
@AdminAccessId Int OUTPUT,@AdminId Int,@CreatedBy Int,@FirstName NVarChar(50),@UserId Int
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
INSERT  INTO [dbo].[AdminAccess]
(
[admin_id],[created_by],[first_name],[user_id]
)
VALUES
(
@AdminId,@CreatedBy,@FirstName,@UserId
);
SET @AdminAccessId = SCOPE_IDENTITY();


GO
/****** Object:  StoredProcedure [dbo].[gen_AdminAccess_Update]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_AdminAccess_Update]
(
@AdminAccessId Int,@AdminId Int,@CreatedBy Int,@FirstName NVarChar(50),@UserId Int
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
UPDATE [dbo].[AdminAccess]
SET
[admin_id]=@AdminId,[created_by]=@CreatedBy,[first_name]=@FirstName,[user_id]=@UserId
WHERE
admin_access_id=@AdminAccessId


GO
/****** Object:  StoredProcedure [dbo].[gen_User_Delete]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_Delete]
(
@UserId Int
)
AS
delete from  [dbo].[User] 
WHERE
[user_id]=@UserId


GO
/****** Object:  StoredProcedure [dbo].[gen_User_GetAll]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_GetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT
[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[User] WITH(NOLOCK)
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_User_GetByuser_id]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_GetByuser_id]
(
@UserId Int
)
AS
SELECT
[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[User] WITH(NOLOCK)
WHERE
[user_id]=@UserId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_User_GetListByForeignKey_AdminId]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_GetListByForeignKey_AdminId]
(
@AdminId Int
)
AS
SELECT
[admin_id],[created_by],[first_name],[user_id]
FROM
[dbo].[User] WITH(NOLOCK)
WHERE
[admin_id]=@AdminId
SELECT @@ROWCOUNT


GO
/****** Object:  StoredProcedure [dbo].[gen_User_Insert]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_Insert]
(
@UserId Int OUTPUT,@AdminId Int,@CreatedBy Int,@FirstName NVarChar(50)
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
INSERT  INTO [dbo].[User]
(
[admin_id],[created_by],[first_name]
)
VALUES
(
@AdminId,@CreatedBy,@FirstName
);
SET @UserId = SCOPE_IDENTITY();


GO
/****** Object:  StoredProcedure [dbo].[gen_User_Update]    Script Date: 10/14/2020 2:41:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gen_User_Update]
(
@UserId Int,@AdminId Int,@CreatedBy Int,@FirstName NVarChar(50)
)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
UPDATE [dbo].[User]
SET
[admin_id]=@AdminId,[created_by]=@CreatedBy,[first_name]=@FirstName
WHERE
user_id=@UserId


GO
USE [master]
GO
ALTER DATABASE [CleanArchitectureDB] SET  READ_WRITE 
GO
