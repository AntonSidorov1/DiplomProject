USE [master]
GO
/****** Object:  Database [MusicShop]    Script Date: 29.05.2023 13:01:55 ******/
CREATE DATABASE [MusicShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicShop', FILENAME = N'D:\Program Files\Microsoft SQL Server\x64\MSSQL15.SQLEXPRESS\MSSQL\DATA\MusicShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicShop_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\x64\MSSQL15.SQLEXPRESS\MSSQL\DATA\MusicShop_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MusicShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MusicShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MusicShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MusicShop] SET  MULTI_USER 
GO
ALTER DATABASE [MusicShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MusicShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MusicShop] SET QUERY_STORE = OFF
GO
USE [MusicShop]
GO
/****** Object:  Table [dbo].[Sity]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sity](
	[SityID] [int] IDENTITY(1,1) NOT NULL,
	[SityName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Sity] PRIMARY KEY CLUSTERED 
(
	[SityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[StockName] [nvarchar](50) NOT NULL,
	[StockAddress] [nvarchar](150) NOT NULL,
	[StockSityID] [int] NOT NULL,
	[StockTelephone] [nvarchar](50) NULL,
	[StockEmail] [nvarchar](250) NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pounkt]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pounkt](
	[PounktID] [int] IDENTITY(1,1) NOT NULL,
	[PounktAddress] [nvarchar](150) NOT NULL,
	[PounktOrganizationID] [int] NULL,
	[PounktName] [nvarchar](150) NULL,
	[PounktSchedule] [nvarchar](250) NULL,
	[PounktStockID] [int] NULL,
	[PounktTelephone] [nvarchar](50) NULL,
	[PounktEmail] [nvarchar](250) NULL,
	[SitePath] [nvarchar](350) NULL,
 CONSTRAINT [PK_Pounkt] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[OrganizationLogotip] [varbinary](max) NULL,
	[OrganizationTelephone] [nvarchar](50) NULL,
	[OrganizationEmail] [nvarchar](250) NULL,
	[OrgamizationAddress] [nvarchar](250) NOT NULL,
	[OrganizationSite] [nvarchar](350) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[SityPounkts]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SityPounkts]
AS
SELECT dbo.Pounkt.PounktID AS ID, dbo.Organization.OrganizationName AS Organization, dbo.Pounkt.PounktName AS Pounkt, dbo.Pounkt.PounktAddress AS Address, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress, 
                  dbo.Sity.SityName AS Sity, dbo.Organization.OrganizationID
FROM     dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[PounktID] [int] NOT NULL,
	[ShopName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Shop_1] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInShop]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInShop](
	[ShopID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[QuantityInShop] [int] NULL,
	[DateUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductInShop] PRIMARY KEY CLUSTERED 
(
	[ShopID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductArticle] [nchar](10) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCost] [decimal](18, 2) NOT NULL,
	[ProductDiscount] [tinyint] NULL,
	[ProductManufactureID] [int] NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductDescription] [ntext] NULL,
	[ProductSupplierID] [int] NOT NULL,
	[ProductPhoto] [varbinary](max) NULL,
	[ProductSounds] [varbinary](max) NULL,
	[ProductParameters] [nvarchar](500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ShopProducts]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ShopProducts]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInShop.QuantityInShop, dbo.Shop.ShopName AS Shop, dbo.Pounkt.PounktName AS Pounkt, 
                  dbo.Organization.OrganizationName AS Organization, dbo.Sity.SityName AS Sity, dbo.Pounkt.PounktAddress AS Address
FROM     dbo.ProductInShop INNER JOIN
                  dbo.Product ON dbo.ProductInShop.ProductID = dbo.Product.ProductID INNER JOIN
                  dbo.Shop ON dbo.ProductInShop.ShopID = dbo.Shop.PounktID INNER JOIN
                  dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID ON dbo.Shop.PounktID = dbo.Pounkt.PounktID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[RythmPounkts]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmPounkts]
AS
SELECT ID, Organization, Pounkt, Address, Stock, StockAddress, Sity
FROM     dbo.SityPounkts
WHERE  (OrganizationID = 13)
GO
/****** Object:  View [dbo].[RythmShop]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmShop]
AS
SELECT dbo.RythmPounkts.ID, dbo.Shop.ShopName AS Shop, dbo.RythmPounkts.Pounkt, dbo.RythmPounkts.Address, dbo.RythmPounkts.Stock, dbo.RythmPounkts.StockAddress, dbo.RythmPounkts.Organization, dbo.RythmPounkts.Sity
FROM     dbo.RythmPounkts INNER JOIN
                  dbo.Shop ON dbo.RythmPounkts.ID = dbo.Shop.PounktID
GO
/****** Object:  View [dbo].[ProductsInRythm]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductsInRythm]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInShop.QuantityInShop, dbo.RythmShop.Shop, dbo.RythmShop.Pounkt, dbo.RythmShop.Address, 
                  dbo.RythmShop.Organization, dbo.RythmShop.Sity, dbo.ProductInShop.ShopID
FROM     dbo.ProductInShop INNER JOIN
                  dbo.RythmShop ON dbo.ProductInShop.ShopID = dbo.RythmShop.ID INNER JOIN
                  dbo.Product ON dbo.ProductInShop.ProductID = dbo.Product.ProductID
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleNameEng] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](100) NOT NULL,
	[UserPassword] [nvarchar](100) NULL,
	[ChatUser] [bit] NOT NULL,
	[Encription_Algorithm] [nvarchar](50) NULL,
	[UserBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersRoles]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UsersRoles]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UsersRoles]    Script Date: 16.02.2023 22:30:23 ******/
 

CREATE VIEW [dbo].[UsersRoles]
AS
SELECT [User].UserID As UserID, dbo.Role.RoleName AS Role, dbo.[User].UserLogin AS [User], dbo.[User].UserPassword AS Password, dbo.[User].ChatUser AS Chat
FROM     dbo.Role INNER JOIN
                  dbo.UserRole ON dbo.Role.RoleID = dbo.UserRole.RoleID INNER JOIN
                  dbo.[User] ON dbo.UserRole.UserID = dbo.[User].UserID
GO
/****** Object:  Table [dbo].[UserInitials]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInitials](
	[UserID] [int] NOT NULL,
	[UserFamily] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserSurName] [nvarchar](100) NULL,
	[UserFIO]  AS (Trim(((([UserFamily]+' ')+[UserName])+' ')+[UserSurName])),
 CONSTRAINT [PK_UserInitials] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserHanding]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserHanding]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserHanding]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserHanding]
AS
SELECT dbo.[User].UserID, dbo.[User].UserLogin, dbo.UserInitials.UserFIO
FROM     dbo.[User] INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID
GO
/****** Object:  Table [dbo].[UserTelefon]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTelefon](
	[TelefonID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Telefon] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTelefon] PRIMARY KEY CLUSTERED 
(
	[TelefonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserTelefons]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserTelefons]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserTelefons]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserTelefons]
AS
SELECT dbo.[User].UserLogin, dbo.UserTelefon.Telefon
FROM     dbo.[User] INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserInitialsTelefon]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserTelefon.Telefon
FROM     dbo.[User] INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  Table [dbo].[UserEmail]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEmail](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserEmail] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserEmails]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserEmails]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserEmails]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserEmails]
AS
SELECT dbo.[User].UserLogin, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID
GO
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserInitialsEmail]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID
GO
/****** Object:  View [dbo].[UserData]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserData]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserData]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserData]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserTelefon.Telefon, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  Table [dbo].[Environtment]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Environtment](
	[EnvirontmentToken] [nvarchar](50) NOT NULL,
	[DateOpen] [datetime] NOT NULL,
	[DaysOpen] [int] NOT NULL,
	[HoursOpen] [int] NOT NULL,
	[MinutsOpen] [int] NOT NULL,
	[SecondsOpen] [int] NOT NULL,
	[DateClose]  AS (dateadd(second,[SecondsOpen],dateadd(minute,[MinutsOpen],dateadd(hour,[HoursOpen],dateadd(day,[DaysOpen],[DateOpen]))))),
	[DateLastActive] [datetime] NOT NULL,
	[DaysNoActive] [int] NOT NULL,
	[HoursNoActive] [int] NOT NULL,
	[MinutesNoActive] [int] NOT NULL,
	[SecondsNoActive] [int] NOT NULL,
	[DateNoActiveClose]  AS (dateadd(second,[SecondsNoActive],dateadd(minute,[MinutesNoActive],dateadd(hour,[HoursNoActive],dateadd(day,[DaysNoActive],[DateLastActive]))))),
	[OperationSystem] [nvarchar](250) NULL,
	[DeviceName] [nvarchar](250) NULL,
	[ProgramName] [nvarchar](250) NULL,
	[ProgramVersion] [nvarchar](250) NULL,
	[BrowserName] [nvarchar](250) NULL,
	[BrowserVersion] [nvarchar](250) NULL,
	[BrowserUse] [bit] NOT NULL,
 CONSTRAINT [PK_Environtment] PRIMARY KEY CLUSTERED 
(
	[EnvirontmentToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[LoginToken] [nvarchar](50) NOT NULL,
	[EnvirontmentToken] [nvarchar](50) NOT NULL,
	[UserLogin] [nvarchar](100) NOT NULL,
	[UserPassword] [nvarchar](100) NULL,
	[LoginSuccessfully] [bit] NOT NULL,
	[LoginActive] [bit] NOT NULL,
 CONSTRAINT [PK_LoginHistory] PRIMARY KEY CLUSTERED 
(
	[LoginToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[LoginHistoryView]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LoginHistoryView]
AS
SELECT dbo.Environtment.DateOpen, dbo.LoginHistory.LoginToken, dbo.LoginHistory.LoginActive, dbo.LoginHistory.UserLogin, dbo.LoginHistory.LoginSuccessfully
FROM     dbo.Environtment INNER JOIN
                  dbo.LoginHistory ON dbo.Environtment.EnvirontmentToken = dbo.LoginHistory.EnvirontmentToken
GO
/****** Object:  Table [dbo].[ProductSupplier]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductSupplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductManufacture]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductManufacture](
	[ManufactureID] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductManufacture] PRIMARY KEY CLUSTERED 
(
	[ManufactureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Subcategorie] [bit] NOT NULL,
	[RootCategoryID] [int] NULL,
	[CategoryParametersName] [nvarchar](500) NULL,
	[CategoryFilterID] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProductData]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[ProductData]    Script Date: 17.02.2023 14:55:52 *****
***** Object:  View [dbo].[ProductData]    Script Date: 16.02.2023 22:30:23 ******/
CREATE VIEW [dbo].[ProductData]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Name, dbo.Product.ProductCost AS Cost, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.Product.ProductDescription AS Description, dbo.Product.ProductParameters AS Parameters, 
                  dbo.Product.ProductPhoto AS Photo, dbo.Product.ProductSounds AS Sounds, dbo.ProductCategory.CategoryID, dbo.ProductCategory.CategoryName AS Category, dbo.ProductManufacture.ManufactureID, 
                  dbo.ProductManufacture.ManufactureName AS Manufacture, dbo.ProductSupplier.SupplierID, dbo.ProductSupplier.SupplierName AS Supplier
FROM     dbo.Product INNER JOIN
                  dbo.ProductCategory ON dbo.Product.ProductCategoryID = dbo.ProductCategory.CategoryID INNER JOIN
                  dbo.ProductManufacture ON dbo.Product.ProductManufactureID = dbo.ProductManufacture.ManufactureID INNER JOIN
                  dbo.ProductSupplier ON dbo.Product.ProductSupplierID = dbo.ProductSupplier.SupplierID
GO
/****** Object:  Table [dbo].[ProductInStock]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInStock](
	[StockID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
	[DateUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductInStock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StockProduct]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StockProduct]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInStock.QuantityInStock, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress AS Address, 
                  dbo.Sity.SityName AS Sity
FROM     dbo.Product INNER JOIN
                  dbo.ProductInStock ON dbo.Product.ProductID = dbo.ProductInStock.ProductID INNER JOIN
                  dbo.Stock ON dbo.ProductInStock.StockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[OrganizationStock]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrganizationStock]
AS
SELECT dbo.Stock.StockID AS ID, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress, dbo.Organization.OrganizationName AS Organization, dbo.Organization.OrganizationID, dbo.Pounkt.PounktName AS Pounkt, dbo.Pounkt.PounktID, 
                  dbo.Pounkt.PounktAddress, dbo.Sity.SityName AS Sity
FROM     dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[RitmStock]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RitmStock]
AS
SELECT dbo.OrganizationStock.*
FROM     dbo.OrganizationStock
WHERE  (OrganizationID = 13)
GO
/****** Object:  Table [dbo].[PounktOfIssue]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PounktOfIssue](
	[PounktID] [int] NOT NULL,
	[PounktOfIssoueName] [nvarchar](150) NULL,
 CONSTRAINT [PK_PounktOfIssue_1] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RythmPounktOfIssue]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmPounktOfIssue]
AS
SELECT dbo.RitmStock.*, dbo.PounktOfIssue.PounktOfIssoueName AS PounktOfIssue
FROM     dbo.RitmStock INNER JOIN
                  dbo.PounktOfIssue ON dbo.RitmStock.PounktID = dbo.PounktOfIssue.PounktID AND dbo.RitmStock.PounktID = dbo.PounktOfIssue.PounktID
GO
/****** Object:  Table [dbo].[UserSignIn]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSignIn](
	[LoginToken] [nvarchar](50) NOT NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_UserSignIn] PRIMARY KEY CLUSTERED 
(
	[LoginToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserSignInView]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserSignInView]
AS
SELECT dbo.Environtment.DateOpen, dbo.LoginHistory.LoginToken, dbo.UserSignIn.UserID
FROM     dbo.Environtment INNER JOIN
                  dbo.LoginHistory ON dbo.Environtment.EnvirontmentToken = dbo.LoginHistory.EnvirontmentToken INNER JOIN
                  dbo.UserSignIn ON dbo.LoginHistory.LoginToken = dbo.UserSignIn.LoginToken
WHERE  (dbo.LoginHistory.LoginActive = 1)
GO
/****** Object:  Table [dbo].[Order]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](20) NOT NULL,
	[OrderCostWithoutDiscount] [decimal](18, 2) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[OrderDateCreate] [datetime] NOT NULL,
	[OrderCostWithDiscount] [decimal](18, 2) NOT NULL,
	[OrderDateStatusChange] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OrderInfo]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrderInfo]
AS
SELECT dbo.[Order].OrderID AS ID, dbo.[Order].OrderNumber AS Number, dbo.[Order].OrderCostWithoutDiscount AS CostFull, dbo.[Order].OrderCostWithDiscount AS CostEnd, dbo.[Order].OrderDateCreate AS DateCreate, 
                  dbo.[Order].OrderDateStatusChange AS DateStatusChange, dbo.OrderStatus.StatusName AS Status, dbo.OrderStatus.StatusID
FROM     dbo.[Order] INNER JOIN
                  dbo.OrderStatus ON dbo.[Order].OrderStatusID = dbo.OrderStatus.StatusID
GO
/****** Object:  Table [dbo].[ClientOrder]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrder](
	[OrderID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK_ClientOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductCount] [int] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OrderClient]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrderClient]
AS
SELECT dbo.OrderInfo.ID, dbo.OrderInfo.Number, dbo.OrderInfo.CostFull, dbo.OrderInfo.CostEnd, dbo.OrderInfo.DateCreate, dbo.OrderInfo.DateStatusChange, dbo.OrderInfo.Status, dbo.OrderInfo.StatusID, dbo.ClientOrder.ClientID, 
                  COUNT(dbo.OrderProduct.ProductID) AS PositionsCount, SUM(dbo.OrderProduct.ProductCount) AS ProductsQuantity
FROM     dbo.OrderInfo INNER JOIN
                  dbo.ClientOrder ON dbo.OrderInfo.ID = dbo.ClientOrder.OrderID INNER JOIN
                  dbo.OrderProduct ON dbo.ClientOrder.OrderID = dbo.OrderProduct.OrderID
GROUP BY dbo.OrderInfo.ID, dbo.OrderInfo.Number, dbo.OrderInfo.CostFull, dbo.OrderInfo.CostEnd, dbo.OrderInfo.DateCreate, dbo.OrderInfo.DateStatusChange, dbo.OrderInfo.Status, dbo.OrderInfo.StatusID, dbo.ClientOrder.ClientID
GO
/****** Object:  Table [dbo].[CategoryFilter]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryFilter](
	[CategoryFilterID] [int] IDENTITY(1,1) NOT NULL,
	[categoryFilterName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryFilter] PRIMARY KEY CLUSTERED 
(
	[CategoryFilterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CategoriesWithFilter]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CategoriesWithFilter]
AS
SELECT dbo.ProductCategory.CategoryID AS ID, dbo.ProductCategory.CategoryName AS Category, dbo.CategoryFilter.categoryFilterName AS Filter, dbo.CategoryFilter.CategoryFilterID AS FilterID, dbo.ProductCategory.RootCategoryID
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
GO
/****** Object:  View [dbo].[CategoriesView]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CategoriesView]
AS
SELECT dbo.ProductCategory.*
FROM     dbo.ProductCategory
GO
/****** Object:  View [dbo].[OrderPositionsQuantity]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrderPositionsQuantity]
AS
SELECT dbo.[Order].OrderID AS ID, dbo.[Order].OrderNumber AS Number, dbo.OrderStatus.StatusName AS Status, dbo.OrderStatus.StatusID, dbo.[Order].OrderCostWithoutDiscount AS CostFull, dbo.[Order].OrderCostWithDiscount AS CostEnd, 
                  dbo.[Order].OrderDateCreate AS DateCreate, dbo.[Order].OrderDateStatusChange AS DateStatusChange, COUNT(dbo.OrderProduct.ProductID) AS PositionsCount, SUM(dbo.OrderProduct.ProductCount) AS ProductsQuantity
FROM     dbo.[Order] INNER JOIN
                  dbo.OrderStatus ON dbo.[Order].OrderStatusID = dbo.OrderStatus.StatusID INNER JOIN
                  dbo.OrderProduct ON dbo.[Order].OrderID = dbo.OrderProduct.OrderID
GROUP BY dbo.[Order].OrderID, dbo.[Order].OrderNumber, dbo.OrderStatus.StatusName, dbo.OrderStatus.StatusID, dbo.[Order].OrderCostWithoutDiscount, dbo.[Order].OrderCostWithDiscount, dbo.[Order].OrderDateCreate, 
                  dbo.[Order].OrderDateStatusChange
GO
/****** Object:  View [dbo].[FiltersOfCategories]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FiltersOfCategories]
AS
SELECT TOP (100) PERCENT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
ORDER BY Filter
GO
/****** Object:  View [dbo].[AssortimentsCategories]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AssortimentsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 1)
GO
/****** Object:  View [dbo].[GoodsCategories]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GoodsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 2)
GO
/****** Object:  View [dbo].[KitsCategories]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[KitsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 3)
GO
/****** Object:  View [dbo].[ProductsInStocksInfo]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductsInStocksInfo]
AS
SELECT dbo.ProductData.*, dbo.ProductInStock.StockID, dbo.ProductInStock.QuantityInStock
FROM     dbo.ProductInStock INNER JOIN
                  dbo.ProductData ON dbo.ProductInStock.ProductID = dbo.ProductData.ID
GO
/****** Object:  View [dbo].[ProductsInShopsInfo]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductsInShopsInfo]
AS
SELECT TOP (100) PERCENT dbo.ProductData.ID, dbo.ProductData.Article, dbo.ProductData.Name, dbo.ProductData.Cost, dbo.ProductData.Discount, dbo.ProductData.CostWithDiscount, dbo.ProductData.Description, 
                  dbo.ProductData.Parameters, dbo.ProductData.Photo, dbo.ProductData.Sounds, dbo.ProductData.CategoryID, dbo.ProductData.Category, dbo.ProductData.ManufactureID, dbo.ProductData.Manufacture, dbo.ProductData.SupplierID, 
                  dbo.ProductData.Supplier, dbo.ProductInShop.ShopID, dbo.ProductInShop.QuantityInShop
FROM     dbo.ProductData INNER JOIN
                  dbo.ProductInShop ON dbo.ProductData.ID = dbo.ProductInShop.ProductID
ORDER BY dbo.ProductData.ID
GO
/****** Object:  Table [dbo].[CopyMessage]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CopyMessage](
	[IDMesaage] [int] NOT NULL,
	[IDRecipient] [int] NOT NULL,
	[CloseCopy] [bit] NOT NULL,
 CONSTRAINT [PK_CopyMessage] PRIMARY KEY CLUSTERED 
(
	[IDMesaage] ASC,
	[IDRecipient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageText] [ntext] NULL,
	[MessageSender] [nvarchar](100) NULL,
	[MessageTopic] [nvarchar](450) NULL,
	[MessageDateTimeSent] [datetime] NOT NULL,
	[MessageDelayedSend] [bit] NOT NULL,
	[MessageDelayedTime] [datetime] NULL,
	[MessageStatusID] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageRecipient]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageRecipient](
	[RecipientID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_MessageRecipient] PRIMARY KEY CLUSTERED 
(
	[RecipientID] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageRecipientsList]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageRecipientsList](
	[MessageID] [int] NOT NULL,
	[MessageRecipients] [nvarchar](max) NOT NULL,
	[MessageCopies] [nvarchar](max) NOT NULL,
	[MessageCloseCopies] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageRecipientsList] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageSender]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageSender](
	[MessageID] [int] NOT NULL,
	[SenderID] [int] NOT NULL,
 CONSTRAINT [PK_MessageSender] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageStatus]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MessageStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderAttachment]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderAttachment](
	[OrderID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_OrderAttachment] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInPounktOfIssue]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInPounktOfIssue](
	[OrderID] [int] NOT NULL,
	[PounktOfIssoeID] [int] NULL,
 CONSTRAINT [PK_OrderInPounktOfIssue] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInShop]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInShop](
	[OrderID] [int] NOT NULL,
	[OrderShopID] [int] NOT NULL,
 CONSTRAINT [PK_OrderInShop] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderSaleMan]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSaleMan](
	[OrderSaleManID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_OrderSaleMan_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttachment]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttachment](
	[ProductID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttachment] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNikName]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNikName](
	[UserID] [int] NOT NULL,
	[NikName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserNikName] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPsevdonim]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPsevdonim](
	[PsevdonimID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PsevdonimName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserPsevdonim] PRIMARY KEY CLUSTERED 
(
	[PsevdonimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryFilter] ON 

INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (1, N'Ассортименты')
INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (2, N'Товары')
INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (3, N'Наборы')
SET IDENTITY_INSERT [dbo].[CategoryFilter] OFF
GO
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (18, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (19, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (20, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (21, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (22, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (23, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (24, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (25, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (26, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (27, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (28, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (29, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (30, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (31, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (32, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (33, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (34, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (35, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (36, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (37, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (38, 1060)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (39, 1060)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (40, 1060)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (41, 6)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (49, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (50, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (51, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (52, 1056)
INSERT [dbo].[ClientOrder] ([OrderID], [ClientID]) VALUES (53, 1056)
GO
INSERT [dbo].[Environtment] ([EnvirontmentToken], [DateOpen], [DaysOpen], [HoursOpen], [MinutsOpen], [SecondsOpen], [DateLastActive], [DaysNoActive], [HoursNoActive], [MinutesNoActive], [SecondsNoActive], [OperationSystem], [DeviceName], [ProgramName], [ProgramVersion], [BrowserName], [BrowserVersion], [BrowserUse]) VALUES (N'P8CBPFBYMTQSMZA4ZU97', CAST(N'2023-05-29T12:33:11.777' AS DateTime), 0, 1, 0, 0, CAST(N'2023-05-29T12:59:22.937' AS DateTime), 0, 0, 30, 0, N'Win32NT 6.2.9200.0', N'DESKTOP-OLHVHM0', N'MusicShopDesktopApp', N'2.13.0.0', NULL, NULL, 0)
GO
INSERT [dbo].[LoginHistory] ([LoginToken], [EnvirontmentToken], [UserLogin], [UserPassword], [LoginSuccessfully], [LoginActive]) VALUES (N'PSFXK23H8VLD3BOY4AP0', N'P8CBPFBYMTQSMZA4ZU97', N'Goest', NULL, 1, 1)
INSERT [dbo].[LoginHistory] ([LoginToken], [EnvirontmentToken], [UserLogin], [UserPassword], [LoginSuccessfully], [LoginActive]) VALUES (N'XMA2JNCNWTR36Q4LM42J', N'P8CBPFBYMTQSMZA4ZU97', N'sys admin', N'', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[MessageStatus] ON 

INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (1, N'Черновик')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (2, N'Исходящее')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (3, N'Отправленное')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (4, N'Полученное')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (5, N'Готовое к получению вложение')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (6, N'В процессе передачи вложений')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (7, N'Записывается')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (8, N'Отложено')
SET IDENTITY_INSERT [dbo].[MessageStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (18, N'84729109524383353726', CAST(104999.94 AS Decimal(18, 2)), 6, CAST(N'2023-05-19T11:47:03.653' AS DateTime), CAST(88099.94 AS Decimal(18, 2)), CAST(N'2023-05-24T23:54:00.797' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (19, N'44226731903075430694', CAST(249999.90 AS Decimal(18, 2)), 6, CAST(N'2023-05-19T11:51:12.220' AS DateTime), CAST(215799.90 AS Decimal(18, 2)), CAST(N'2023-05-25T11:31:29.743' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (20, N'75945712173151400889', CAST(99999.95 AS Decimal(18, 2)), 6, CAST(N'2023-05-19T11:52:17.570' AS DateTime), CAST(68999.95 AS Decimal(18, 2)), CAST(N'2023-05-24T23:27:38.900' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (21, N'72706808624389068746', CAST(139999.90 AS Decimal(18, 2)), 6, CAST(N'2023-05-19T11:53:09.260' AS DateTime), CAST(120799.90 AS Decimal(18, 2)), CAST(N'2023-05-24T20:01:27.130' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (22, N'78686423665011809451', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-19T14:24:38.843' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-19T14:24:38.843' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (23, N'16155524770124232956', CAST(166999.89 AS Decimal(18, 2)), 1, CAST(N'2023-05-19T14:27:46.217' AS DateTime), CAST(135539.89 AS Decimal(18, 2)), CAST(N'2023-05-19T14:27:46.217' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (24, N'76867910023126556967', CAST(166999.89 AS Decimal(18, 2)), 1, CAST(N'2023-05-19T14:28:50.390' AS DateTime), CAST(135539.89 AS Decimal(18, 2)), CAST(N'2023-05-19T14:28:50.390' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (25, N'77227848437005685348', CAST(18800.00 AS Decimal(18, 2)), 6, CAST(N'2023-05-19T15:16:40.577' AS DateTime), CAST(15800.00 AS Decimal(18, 2)), CAST(N'2023-05-24T20:01:57.407' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (26, N'90793029324202489988', CAST(38400.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T19:38:59.300' AS DateTime), CAST(31200.00 AS Decimal(18, 2)), CAST(N'2023-05-22T19:38:59.300' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (27, N'31888425360744145811', CAST(52800.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T19:51:42.733' AS DateTime), CAST(43200.00 AS Decimal(18, 2)), CAST(N'2023-05-22T19:51:42.733' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (28, N'60000368427304596066', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T20:06:00.787' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-22T20:06:00.787' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (29, N'12740009391552303749', CAST(16000.00 AS Decimal(18, 2)), 6, CAST(N'2023-05-22T20:11:57.997' AS DateTime), CAST(13120.00 AS Decimal(18, 2)), CAST(N'2023-05-25T14:54:31.667' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (30, N'13930118201294342163', CAST(99999.90 AS Decimal(18, 2)), 6, CAST(N'2023-05-22T20:25:22.850' AS DateTime), CAST(87999.90 AS Decimal(18, 2)), CAST(N'2023-05-22T20:25:22.850' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (31, N'10287215269621188869', CAST(79500.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-22T20:27:59.660' AS DateTime), CAST(72790.00 AS Decimal(18, 2)), CAST(N'2023-05-25T14:52:43.827' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (32, N'24188546333061825878', CAST(40000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T20:35:34.803' AS DateTime), CAST(32800.00 AS Decimal(18, 2)), CAST(N'2023-05-22T20:35:34.803' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (33, N'72347162598459556050', CAST(75000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T20:36:25.480' AS DateTime), CAST(37500.00 AS Decimal(18, 2)), CAST(N'2023-05-22T20:36:25.480' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (34, N'77220579744445511237', CAST(5000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T20:37:15.633' AS DateTime), CAST(2500.00 AS Decimal(18, 2)), CAST(N'2023-05-22T20:37:15.633' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (35, N'85061886570895035566', CAST(40000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-22T20:56:53.457' AS DateTime), CAST(36800.00 AS Decimal(18, 2)), CAST(N'2023-05-22T20:56:53.457' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (36, N'64280640885747907580', CAST(154999.85 AS Decimal(18, 2)), 6, CAST(N'2023-05-22T20:59:24.047' AS DateTime), CAST(134499.85 AS Decimal(18, 2)), CAST(N'2023-05-25T14:53:22.817' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (37, N'76843514821578680333', CAST(154999.85 AS Decimal(18, 2)), 6, CAST(N'2023-05-23T22:02:42.477' AS DateTime), CAST(134499.85 AS Decimal(18, 2)), CAST(N'2023-05-23T22:02:42.477' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (38, N'46933404871048220284', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T12:52:40.253' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T12:52:40.253' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (39, N'44238658081782356731', CAST(4800.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:05:07.020' AS DateTime), CAST(3840.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:05:07.020' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (40, N'08498083774759675458', CAST(16000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:06:44.653' AS DateTime), CAST(13120.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:06:44.653' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (41, N'99979301237990854850', CAST(18000.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-25T13:45:50.197' AS DateTime), CAST(11560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T14:33:41.970' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (42, N'46948405548051905025', CAST(16000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:46:09.713' AS DateTime), CAST(13120.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:46:09.713' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (43, N'42395193241359404555', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:46:44.330' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:46:44.330' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (44, N'26704479499649636446', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:47:15.577' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:47:15.577' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (45, N'56838577344612380541', CAST(13000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:47:29.390' AS DateTime), CAST(9060.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:47:29.390' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (46, N'47853578322526484728', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:47:49.920' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:47:49.920' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (47, N'66145033542351702177', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:53:50.593' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:53:50.593' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (48, N'53572972025445411287', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T13:57:51.870' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T13:57:51.870' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (49, N'67900491390227063415', CAST(64999.97 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T16:40:51.230' AS DateTime), CAST(60699.97 AS Decimal(18, 2)), CAST(N'2023-05-25T16:40:51.230' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (50, N'76416078626580853982', CAST(92999.95 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T16:42:45.957' AS DateTime), CAST(86299.95 AS Decimal(18, 2)), CAST(N'2023-05-25T16:42:45.957' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (51, N'09895772027506812457', CAST(148999.95 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T16:45:06.120' AS DateTime), CAST(142299.95 AS Decimal(18, 2)), CAST(N'2023-05-25T16:45:06.120' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (52, N'87520952440899390957', CAST(18000.00 AS Decimal(18, 2)), 6, CAST(N'2023-05-25T17:45:30.423' AS DateTime), CAST(12680.00 AS Decimal(18, 2)), CAST(N'2023-05-25T17:46:19.543' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (53, N'18963260005090891950', CAST(16000.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-25T17:55:37.960' AS DateTime), CAST(13120.00 AS Decimal(18, 2)), CAST(N'2023-05-25T18:07:44.273' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (54, N'10659596757691825494', CAST(8000.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-25T18:04:32.913' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T18:05:40.330' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [OrderNumber], [OrderCostWithoutDiscount], [OrderStatusID], [OrderDateCreate], [OrderCostWithDiscount], [OrderDateStatusChange]) VALUES (55, N'97694212397882722898', CAST(8000.00 AS Decimal(18, 2)), 1, CAST(N'2023-05-25T18:14:17.130' AS DateTime), CAST(6560.00 AS Decimal(18, 2)), CAST(N'2023-05-25T18:14:17.130' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (20, 2)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (21, 2)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (24, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (30, 11)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (37, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (40, 3)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (41, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (42, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (44, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (45, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (47, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (48, 1)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (50, 2)
INSERT [dbo].[OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) VALUES (55, 1)
GO
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (18, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (19, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (22, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (23, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (25, 4)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (26, 4)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (27, 4)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (28, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (29, 4)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (31, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (32, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (33, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (34, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (35, 2)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (36, 2)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (38, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (39, 10)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (43, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (46, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (49, 2)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (51, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (52, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (53, 1)
INSERT [dbo].[OrderInShop] ([OrderID], [OrderShopID]) VALUES (54, 1)
GO
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (18, 1, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (18, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (18, 25, 6)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (19, 1, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (19, 2, 6)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (19, 25, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (19, 26, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (20, 2, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (20, 25, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (21, 1, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (21, 25, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (22, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (23, 1, 4)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (23, 2, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (23, 25, 11)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (24, 1, 4)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (24, 2, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (24, 25, 11)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (25, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (25, 4, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (25, 6, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (26, 1, 3)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (26, 6, 3)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (27, 1, 6)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (27, 6, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (28, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (29, 1, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (30, 25, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (31, 1, 4)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (31, 12, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (32, 1, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (33, 2, 15)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (34, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (35, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (35, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (36, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (36, 25, 15)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (37, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (37, 25, 15)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (38, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (39, 6, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (40, 1, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (41, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (41, 2, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (42, 1, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (43, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (44, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (45, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (45, 2, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (46, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (47, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (48, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (49, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (49, 25, 3)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (50, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (50, 25, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (50, 26, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (51, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (51, 25, 5)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (51, 26, 8)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (52, 2, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (52, 3, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (53, 1, 2)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (54, 1, 1)
INSERT [dbo].[OrderProduct] ([OrderID], [ProductID], [ProductCount]) VALUES (55, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (1, N'Создан')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (2, N'Принят')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (3, N'В пути')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (4, N'Ожидает получателя')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (5, N'Получен')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (6, N'Отменён')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (7, N'Потерян')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (8, N'Ожидает поступления товаров')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (9, N'Собран')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (1, N'ООО "Лошадь-музыка"', NULL, NULL, NULL, N'vbkjzdfzbfgkj', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (2, N'ОАО "Музыкальный магазин"', 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080281028103012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A4242A96620003249ED400B58DACF8A749D08ECBCB8FDF11910C6373E3E9DBF1AE57C69E3958A3161A25D2B4AD9F3AE2339D83D14FAFB8AF3377791D9DD999D8E4B31C926B92AE2545DA27D065F91CAB4554AEECBB75FF00807A83FC54B10C7669B70CBD8B3A83FD693FE16AD9FF00D0327FFBF82BCBA8AE7FACD4EE7B5FD8782FE5FC59EAD1FC52D2CB012D8DDA0EE576B7F515BFA5F8BB44D59825BDEAACA7A4737C8C7E99EBF8578551551C54D6FA98D5C830B25EE5E2FEF3E91A2BC63C37E39D43447586E19AEECBA18DCFCC83FD93FD3A7D2BD734DD4ED356B24BBB2984913FA7553E847635D94AB46A6DB9F378ECB6B60DFBDAC7B96E8A28AD4F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCB3E21F89E79AF64D16D64296F1604E54F32375C7D07F3AF53AF9DAFA77BAD42E6E243979656763EE4E6B97153718A4BA9EF64186855AD2A9257E5FCD95E8A28AF38FB20A28A2800A295577305C819F53814B246F148D1C8A51D4E0AB0C11405FA0DAD3D135EBED02F05C59C9807FD644DF75C7A11FD6B328A69B4EE889D38D48B84D5D33DBFC3FE32D335E558D5FECF784730487927FD93FC5FCFDABA2AF9BD58AB0652430390476AF47F09FC41FB963ADC9ED1DD1FE4FF00E3F9FAD7751C4DF499F2B98646E9A7530FAAEDD7E5DCF49A29010C01041046411DE96BB0F9C0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AF9C1CE5D8FA9AFA389C027D2BE6FAE2C67D93EA386FFE5EFCBF50A28A2B84FA80A2BB0F10784FC8F0F69FADD8A131C96D135CC639DAC547CE3D89EBFE71C7D5CE0E2ECCC30F8885787341F97CC2BA3D323B7F12409A65C48906A51AEDB4B86E9281D237FE87F0F4AE729412AC0824107208ED4A2ECCAAB4F9E3A3B35B32C5FD85D69978F6B790B45327556FE63D47BD56AF4BF0F6A1A7F8DAC3FB275C8C3DFC2BFBA9C1C3BAFA83EA3B8EFD7D6B95F13784AF3C3B39620CD64C711CE07E8DE87F9D692A565CF1D51C9431CA553D8565CB35F73F3473D45145627A0763E15F1D5C68AA9657AAD71620E1483F3C43DBD47B57AB69FA85A6A966975653ACD0BF465EC7D08EC7DABE78AD4D0B5FBDD02F96E2D5C9427F79113F2C83D0FBFBD7551C438E92D8F0F31C9A188BD4A5A4BF067BED154B49D56DB59D362BEB56CC720E41EAA7B83EE2AED7A09A6AE8F8D9C650938C959A0A28A299214514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145003253885CFA29AF9C6BE8CB938B598FA237F2AF9CEB8719D0FA9E1BDAA7CBF50A28A2B88FA73DF3C3E89378534C49143235946ACA46411B00C579478C7C2EFE1ED437C20B584E4989BFBA7FBA7DFF98FC6BD5BC3073E16D2FF00EBD63FFD0455CD474FB6D56C65B3BB8C3C320C11DC7A11E8457A93A4AA41773E170B8F960F1527BC5B775F33E78A2B4F5FD167D075696CA6E40F9A3931C3A1E87FCF7ACCAF31A69D99F6F4E71A91538BBA64D69753595DC5756EE5268983230EC457B968FA8DA78A7C3CB349123A4ABE5CF09E42B771FD47E15E0F5D678075F1A3EB3F669DF6DA5DE11893C2BFF0B7F43F5F6ADF0F5396567B33CACE305EDE8FB487C51D50BE2DF055C6872BDD5A2B4DA7139DDD5A2F66F6F7AE4ABE90650CA55802A460823835E71E31F01C11DB4DA9E929E5F9637CB6CA3823B95F4F5C7E55A56C35BDE81C796E76A76A588DFA3FF3FF0033CDA8A28AE33E90EBBC03E203A46B02D277C5A5D90AD93C23FF000B7F43FF00D6AF63AF9BABDB7C13AEFF006E6828656CDD5BE229B3D4FA37E23F506BBB0B53EC33E5B3FC159AC4C3D1FE8FF4FB8E928A28AED3E6028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0082F4E2C2E0FA44DFC8D7CEB5F446A271A65D9F485FF00F4135F3BD70E33747D570DFC353E5FA8514515C47D31EF3E1539F0A697FF005EE9FCAB62B17C2273E12D33FEB80ADAAF661F0A3F36C57F1E7EAFF3396F1DE81FDB3A1B4D0A66EED7324781CB2FF12FE5CFD4578BD7D235E31E3AF0F1D17593710A62CEE8974C0E11BBAFF51EDF4AE4C553FB68FA1C831BBE1A6FCD7EABF5FBCE568A28AE13EA0F5AF00F8A86A76ABA5DE3FF00A640BFBB663FEB507F51FCB9F5AED8804104641EA2BE74B7B89AD2E23B8B791A39A360C8EBD4115EE3E17F1045E22D256E000B711FC93C7E8DEA3D8F51FF00D6AF470D5B9972BDCF8ECEB2EF612F6F4D7BAF7F27FE4CF27F17E88742D7E6851716D2FEF603DB69EDF81C8FCAB06BD9BC7FA2FF006AF87DA78933716799570392BFC43F2E7F0AF19AE4AF4F927E47BF9562FEB3874DFC4B47FD7985743E0DD77FB0B5E8E495B16B3FEEA6F400F46FC0FE99AE7A8ACE327177476D6A51AD4DD39ECCFA44104641C834571DF0F35E6D53466B29DF75C59E1413D5A3FE13F874FC057635EBC24A715247E7789A12C3D595296E828A28AA300A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2802A6AA71A3DF1F4B793FF004135F3CD7D07AC9C687A81F4B693FF004135F3E570E33747D5F0E7C153D50514515C47D29EEBE0E39F0869BFF5CBFA9ADCAC1F051CF83F4DFF00AE67FF004235BD5EC53F811F9BE2FF00DE2A7ABFCC2A86B3A4DBEB7A5CD63723E571F2B01CA37622AFD154D26ACCC6139424A517668F9EB54D36E748D466B2BA4DB2C6719ECC3B11EC6A9D7B178FFC3E9AAE8CD7D12FFA5D9A96047F127561FD47FF005EBC76BCAAD4FD9CAC7DFE5D8D58BA2A7D568FD42BA5F03EB2748F11C219B16F7444328EDCFDD3F81FD335CD500904107047422A232719268EAAF4635A9CA9CB667D20402304641EA2BC43C63A03683ADBA46A7EC93E6480F603BAFE1FCB15EC1A1DFF00F69E85657A4E5A5894B7FBDD0FEB9AC4F889642EBC2734BB417B675914F7C6769FD0FE95E8D7829D3B9F1995622785C5FB37B3767FD7A9E33451457987DC1D47C3FBF365E2DB74270972AD0B7E2323F502BDA6BE74B4B97B3BD82EA3FF00590C8B22FD41CD7D0F6F3A5CDB457111CC72A0753EA08C8AF43092F75C4F91E22A36AB0AABAAB7DDFF000E4945145759F3A14514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014560EADE30D1B46BBFB2DD5C319C7DE48D0B6CFAD6ADADFDA5F5BC5716D711C914A328C0FDEA9528B764CD6542AC20A728B49ECEC59A28A2A8C828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00CFD74E3C3DA99F4B497FF4035F3F57BFF884E3C35AA9FF00A7397FF4035E015C18CF891F5BC39FC29FAA0A28A2B8CFA33DC3C0E73E0DD3BFDC6FFD0DABA1AE73C0673E0BD3BE927FE8C6AE8EBD8A7F02F43F38C6FF00BCD4FF0013FCC28A28AB398475591191C02AC3041EE2BE7AD4EC9B4ED56EACDB3982564E7B80783F957D0D5E47F1334D16BAFC57AA30B771E4FF00BCB807F4DB5CB8B8DE2A5D8F7F87ABF2579527F697E2BFE05CE2A8A28AF38FB13D67E18EA3F68D0A7B163F35ACB903FD96E7F986AEBF50B44BFD3AE6CE4FBB3C4D19F6C8C57957C34BCF23C4CD6E4FCB730B281EE3E61FA035EBD5EA61E5CD4ECCF85CE29BA38D728F5B3FEBE67CE32C4F0CCF14830E8C5587A11D6995D4F8FF004BFECEF144D22AE22BB1E72FD4FDEFD727F1AE5ABCD9C7964D1F6987ACAB528D45D5057B17C3AD585FF8745A3B666B36F2CFAEC3CA9FE63F0AF1DAE9FC05AA369BE28B742D88AEBF70E3DCFDDFD71F9D6B427CB347166D86FAC616496EB55F2FF807B5514515EA1F0414514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451505EDC7D96C2E2E4FF00CB289A4FC86681A4DBB23C0F5A9BED1AEEA13649DF732303EDB8D520C55832920839041E9412598927249C935B3E15D2A1D6B5D8EC272C1258DFE653CA90A483F98AF19272959753F4994A3429734B68AFC8E9FC1DE3BB88EE21D375690CB0B9091DC31F9909E818F71EFDABD42BE6E3C1C57D03A15C35D681A74EE49792DA36627B9DA335DD85A8E49C59F2D9F60A9D1946AD356BEE68514515D67CF051451400514514005145140051451400514C9645861795BEEA2963F415E2971E38D7E6D44DDA5F3C43765615FB807A63BFE35955AD1A76B9E86072EAB8CE6E4695BB9EDD4554D2AF0EA1A4D9DEB26C69E1590A8EC48CD5BAD13BAB9C328B8C9C5F40A28A299214514500145145001451450065F894E3C2FAA9FF00A74947FE3A6BC0ABDEBC5271E15D53FEBD9FF95782D70633E247D770E7F067EBFA0514515C67D11ED9E01FF912B4FF00FB69FF00A31ABA5AE67E1F9CF82EC7D8C9FF00A1B574D5EC52F817A1F9CE3BFDEAA7F89FE614514559CA15C17C53881D1AC66C72970501FAA93FFB2D77B5C4FC51FF009166DFFEBF17FF00407ACABFF0D9E8654ED8CA7EA792514515E49FA01D078224F2FC65A6B7ABB2FE6A47F5AF71AF0CF058DDE30D347FD3427FF1D35EE75E8E13E07EA7C7F117FBC47FC3FAB391F887A42EA1E1D6BA51FBFB23E629F553C30FE47F0AF1CAFA2AF2D96F2C6E2D5FEECD1B467E8462BE7792368A568DC61909561E845638B8DA4A5DCEFE1EAEE546549FD97F98DA92099ADEE229D3EF46E1D7EA0E6A3A2B94FA06AEACCFA3A29566863950E55D4329F634FAC0F05DF7DBFC2761213978D3C96FF809C0FD00ADFAF622F9A299F9AD6A6E9549537D1B4145145519051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400564F89DCA785B5423FE7D641F9822B5AB23C50377857541FF004ECE7F4A99FC2CDB0DFC687AAFCCF05AEB3E1CAEEF17C27FBB1487F4C57275D87C3519F15E7D2DDCFF002AF2E8FF00111F7B98BB612A7A3391906D9181EC48AF76F093893C27A611DA051F971FD2BC475388C1AB5E42460C73BAFE4C457B07C3F9C4DE0EB45CE4C4CE87FEFA27F9115B61749B47979FAE6C2C26BBFE699D3D14515E81F201451450014514500145145001451450066788A7FB3F86F52973822DA4C7D4A903F5AF01AF64F88B7DF64F0A4908386B991621F4FBC7FF0041C7E35E4DA55A1BFD5ACED00CF9D3221FA13CD79F8A779A8A3EBF208FB3C34EA4BABFC91EF9A6C1F66D2ACE0C63CA8113F2502AD51457A09591F23293936D85145140828A28A0028A28A0028A28A00C8F150CF857541FF4ECE7F4AF05AF75F185C25B784B5277206E84C63DCB7CBFD6BC2ABCFC5FC48FAFE1D4FD84DF9FE8145145721F427B37C3A7DDE0FB71FDD9241FF8F67FAD7575C8FC3752BE12427A34CE47E83FA575D5EBD2FE1A3F3BCC3FDEEA7AB0A28A2B438C2B88F8A3FF0022D5B7FD7E2FFE80F5DBD711F147FE459B6FFAFC5FFD01EB2AFF00C3677E57FEF94FD4F25A28A2BC93F413A1F030DDE33D387FB4E7FF001C6AF70AF12F00FF00C8EBA7FF00DB4FFD16D5EDB5E8E13E07EA7C6F117FBCC7FC3FAB0AF0BF1959FD87C5BA8460615E4F357FE04377F326BDD2BCB3E295918F55B3BE03E59A23193EEA73FC987E54F151BC2FD88C82AF262B93F997FC1381A28A2BCD3ED4F4EF8597DBAD2FEC18F28E2651EC460FF21F9D7A1D789781751FECFF00165AE4E23B8CC0FF00F02E9FF8F015EDB5E9E1A57A76EC7C3E7943D9E2DCBA4B5FD028A28AE83C70A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACCF118CF867551FF4E72FFE806B4EB27C51208BC2DAA31EF6CEBF98C7F5A99FC2CDB0EAF5A2BCD7E67825765F0CFF00E46A7FFAF67FE6B5C6D761F0D3FE46B3FF005EEFFCC579747F888FBCCCBFDD2A7A333BC6B6BF64F17EA098E1DC4A3DF7004FEA4D75FF000AEF3759EA1624FDC916551FEF0C1FFD047E7597F146D847AEDADC01FEB6DF07EAAC7FA11507C3298C7E27923CFCB2DB3023E841FE95AC7DCAF63CFADFED194A9764BF03D7A8A28AF44F8D0A28A2800A28A2800A28A2800A28A2803CCBE2ADD1375A75A03C2A3CA47D4803FF00413589F0F6D7ED3E2FB76232B023CA7F2C0FD48A5F88973F68F17CE80E4411A463F2DDFCDAB63E155BEEBED46E71F72348C1FF007893FF00B2D79DF1E23E7F91F64BFD9F28F58FFE95FF000E7A7D14515E89F1A1451450014514500145145001451450079D7C52D4CAC567A5A1FBE7CF93E8385FD777E55E675D1F8EAF1AF3C5F7B93F2C2444A3D001CFEB9AE72BC9AD2E6A8D9FA0E594551C2423DD5FEFD428A2B5BC35A57F6CF882D2CC8CC6CFBA5FF70727FC3F1ACD26DD91D952A469C1CE5B2D4F60F08D8B69DE15D3EDDC61FCBF3187A1625B1FAE2B6E8E83028AF662AC923F36AB51D4A92A8F76EE1451453330AE2BE280CF862DCFA5DA9FFC71EBB5AE4BE23C265F08C8E3FE594C8E7F3DBFFB35655BF86CEECB5DB174FD51E37451457927E84747E033B7C6BA79F7907FE436AF6EAF05F0B5C7D9BC55A649DBED0A87FE0476FF005AF7AAF4308FDC68F8FE228BFAC465E5FAB0AE4BE22D88BBF0AC930197B591641F4FBA7F9E7F0AEB6A86B76A6F742BFB6032D25BBAA8F7DA71FAD74548F345A3C7C255F655E13ECD1F3ED14515E39FA40F86568278E643878D8329F70735F45C522CD0C72A7DD750C3E86BE71AF6FF00046A4BA97856D0EECC96EBE4483D0AF4FD315D98496AD1F39C4549BA70A8BA3B7DFF00F0C74545145779F241451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C9FC45BC16DE12962CE1AE6448C7E7B8FFE835D657947C4ED516E756B7D3E36CADAA6E7C7F7DBB7E000FCEB1AF2E5A6CF4B29A0EB62E0BA2D7EEFF8270B5D97C3352DE2A7207DDB6727F351FD6B8DAF42F8576CC6FB50BADA76A44B186C77273FFB2D705057A88FAECD64A383A8DF6FCC5F8AA7FD334C1FF4CDFF0098AC8F8739FF0084BE2FFAE4FF00CAB53E2A1FF898E9E3FE98B7F3ACEF86C33E2C1ED03FF4AD65FEF1F33828E993BFF0BFCD9EC5451457A07C705145140051451400514514005364912289A49182A202CC4F603AD3AB93F885AB7F677869EDD1B135E1F287FBBD58FE5C7E3533972C5C99B61A8BAF56349756792EA97A752D5AEEF5B3FBF959C03D813C0FCABD43E18D9983C3B35CB0E6E27247BAA803F9EEAF278A279E648A252D23B05551DC9E00AFA0748D3D74AD22D6C5307C98C2923B9EE7F139AE1C2C5CA6E4CFA9CFAAC6961A3423D7F25FD22ED14515E81F20145145001451450014514500145145007CFDAF4865F10EA521FE2BA90FFE3C6B3EA7BD97CFBEB8987492566FCCE6A0AF15BBB3F4DA71E5825D905775F0B620DAFDDC847296C40F6CB2FF008570B5DFFC2B52753D41FB08547E67FF00AD5AD0FE223873676C154F4FD4F52A28A2BD53E0028A28A002B0BC65179DE10D497D22DDF9107FA56ED64F89FF00E456D53FEBD64FFD04D4CFE166F8576AF07E6BF33C128A28AF18FD2496D6636F770CE3AC722BFE4735F4657CDD5F46DBB6EB689BD501FD2BBB06F73E5F8917F0DFAFE84945145769F2E78078834F6D2B5FBDB3230A92929FEE9E57F422B36BD13E29698127B3D4D07DF06193EA395FD33F9579DD791561C9368FD130188FAC61A153ADB5F5415DCFC32D50DB6B5369CEDFBBBA4CA8FF006D79FE59FC8570D5A3A05CB5A78874F9D4E365C267E84807F4CD14E5CB34CAC6D155B0F3A6FAAFC7A1F40514515EB9F9C85145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400535DD638DA4760A8A09627B014EAE1BE21F895F4DB51A55AE3CEBA8CF9ADFDC8CF1C7B9E6A273508F333A30B869E26AAA50EA70FE24F155F6BB7F2113BC766A4AC50A31036FA91DC9A7F85BC5579A26A51092E247B176026898E401FDE1E84573945795ED25CDCD7D4FBF783A3EC7D872FBBFD7E27D03AD6AB168DA3DC5FC982234CA2E7EF31E00FC4D781DCDC4B77732DC4EE5E5958BBB1EE4D686A7E24D5757B75B6BCBA2F6EAC19630A00040C0E833F9D5FF04688359F10C6255CDB5B7EF65CF438E83F13FA035B55A8EB4946279D81C2472DA13AB55DDFE9D8EDFC27E0CB25F0E2FF006AD9C734F7244A438E5063E519EA38393F5AEBACAC2D74DB65B6B38120841C85418E7D7DCD58A2BBE108C5591F2588C555AF2729BDDDEDD0F2FF008AA3FE261A71F589BF98ACFF008683FE2AB3ED6EFF00CC5697C561FE97A61FF624FE6B59DF0C87FC55327B5ABFF35AE297FBC1F4F49FFC23FC9FE6CF5FA28A2BD03E3C28A28A0028A28A0028A28A002BC73E22EA66FBC4CD6EAD98AD10463FDE3CB1FD40FC2BD89DD63467638551927D057CED7B72D7B7F7174F9DD348D21CFB9CD7262E568A8F73E8787A8A9569557F657E6757F0E348FB76BCD7B22E62B35DC3DDCF0BFD4FE02BD7EB94F879A78B2F0AC5291892E9DA56FA741FA0CFE35D5D6B87872D35E670E6F8875B172ED1D17CBFE08514515B1E60514514005145140051451400555D4A7FB2E9777719C7950BBE7E8A4D5AAC4F184DE47847537CE33094FF00BE885FEB532768B66B421CF5630EED1E134514578C7E9615E97F0A60221D4EE0F4668D07E1B89FE62BCD2BD83E1A5BF93E1532E399AE1DF3EC30BFD2BA30CAF50F1F3C9F2E0DAEED2FD7F43B1A28A2BD33E1C28A28A002B2BC4DFF0022BEA9FF005EB27FE826B56B2FC49CF86355FF00AF497FF413533F859B61FF008D1F55F99E054514578C7E9415F46DB8DB6D10F4403F4AF9CABE90518503D062BB707D4F98E24DA97CFF004168A28AEE3E58E33E26A6FF000B46DFDCBA43FF008EB0FEB5E435ECBF11937F84266FEE4B1B7EB8FEB5E355E6E2BF887DAE40EF84F9BFD029D1B98A549075560C3F0A6D15CC7B67D200E4023B8CD2D436B289ACE0947478D587E22A6AF6CFCC1AB3B05145140828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BC5FE21B3378CAE8374548C2FD3683FCC9AF68AF38F891E1DB89E68F58B488C8AA8239D50648C670DF4E707E82B9F1316E9E87B191D6853C5FBFD55BE679AD14515E61F7015E89F0A77FDAB53C7DCD91E7EB96C7F5AF3BAF67F01685268DA1992E50A5CDD3091D4F5551F741F7EA7F1AE8C345BA97EC78F9E568C308E2F795ADF7DCEAA8A28AF4CF873CCFE2B7FC7C697FEE49FCD6B3BE18FFC8D12FF00D7ABFF00E84B5BDF13749BCBCB7B2BCB685E54837AC81064AE71838F4E0D67FC33D22F62D52E3519A078ADC42625675C6E6241E3F2AE1945FD60FABA5561FD8ED5F5B35F3B9E9F45145771F281451450014514500145145006378AEF3EC3E15D467CE1BC928A7DDBE51FCEBC1C024E00C935EB5F13EF043E1F82D41F9AE27191EAAA093FA95AF39F0E59FDBFC49A7DB632AD3A961FEC8E4FE80D79F897CD51451F6191C551C1CAB4BAB6FE4BFA67B9E996A2C74BB4B403FD4C291FE400AB54515E8256D0F90949C9B93EA145145020A28A2800A28A2800A28A2800AE4BE234DE5784654CFF00AD9913F5DDFF00B2D75B5C17C539B6E9163067EFCE5FFEF9523FF66ACAB3B53677E590E7C6535E7F96A795D14515E49FA0857BB783EDFECBE11D323C6330893FEFA25BFAD7850049000C93C0AFA2ACE016B6505B8E9146A83F018AECC1AF79B3E7388E76A708776DFDDFF0E4D45145779F24145145001599E2338F0C6ABFF5E92FFE806B4EB23C54FB3C29AA1FFA7671F98C54CFE166D8757AD05E6BF33C168A28AF18FD2807515F48D7CDEA32E07A9AFA42BBB07F68F97E24FF00975F3FD028A28AED3E5CC0F1AC1F68F07EA480748C3FFDF2C1BFA5786D7D0DAA41F6AD22F6DF19F36074C7D548AF9E6B8318BDE4CFAEE1C9DE8CE1D9DFEF5FF0028A28AE33E88F79F0ACE6E3C2BA6484E48B755CFF00BA31FD2B62B96F87B7027F07DB267261778CFF00DF44FF002615D4D7B14DDE099F9C6321C988A91ECDFE614514559CC1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500529B46D32E15C4DA7DABEF1862615C9FC715CF4FF000DF409A42E8B7308273B63978FD41AEBA8A89538CB747452C5D7A5F04DAF99CFE95E0BD0F48996782D4C93AFDD9266DC47D074FD2BA0A28AA8C54559233AB5AA5597354936FCC28A28A666145145001451450014514500647883C4567E1CB359EE83BB48DB638D07CCC7BFE02BCFF56F899A85D031E9B02D9A7F7DB0EE7F4C0FD6B9FF00156B32EB7AF5C4EEC7C94631C2B9E1501FEBD7F1AC5AF3AAE224DB517A1F6980C9A853A719D68DE5F87DC6ABF89B5D91F7B6AF7C0FFB33B01F9038AD2D3BC7BAF5838DF75F6A8C7549C6ECFE3D7F5AE628AC1549A774CF52784A138F2CA0ADE874DE31F1347E249AC6486378D6284EF4639DAE4F383DC602F35A1F0CACBCFF0010CB7647CB6D09C1FF0069B81FA6EAE26BD5BE174702E8B79223833BCF89063EE803E5FE66B5A37A9553679F98A8E132F953A6B4DBEF6777451457A67C385145140051451400514514005145140057977C54B8DDA9E9F6D9FF00570B498FF78E3FF65AF51AF17F88573F68F185CA83910A2463FEF9C9FD49AE6C53B533DAC869F3632FD937FA7EA72D4514579A7DB1A1A0DB7DB3C41A7DBE321EE101FA6467F4AFA06BC67E1DDAFDA3C5D0BE32208DE53F96DFE6D5ECD5E86117B8D9F1FC4352F5E30ECBF30A28A2BACF9F0A28A2800AE6FC7B70B6FE0EBDC9C349B235F725867F406BA3242A96620003249ED5E35E38F13FF6EEA02DED9BFD06D98EC23FE5A3776FA7A7FF005EB1AF35183F33D3CA70B3AF898B5B45A6FF00AF3394A28A2BCA3EF49ECA3335FDBC43ABCAAA3F122BE8AAF0CF0658B5FF008B2C100CAC5279CDEC179FE600FC6BDCEBBF06BDD6CF92E23A89D5843B2FCFFE1828A28AEC3E702BE7CD66D3EC1ADDF5A8FBB14EEABF4CF1FA57D075E15E30C7FC25DA9E3A79DFD05726317BA99F45C3927EDA71F2FD7FE09874514579E7D71EA7F0AE5274ABF87F85670C3F15C7FECB5DF579E7C2A53F63D49BB19100FC8FF8D7A1D7AB87FE1A3E073749636A5BCBF241451456C79A1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500783788F40BAD07539629626FB3B3930CB8E1D7B73EBEA2B1EBDD7C59A17F6FE8525B478FB421124249C7CC3B7E20915E1D3432DBCEF0CD1B472C6C5591860823B57975E97B3969B1F799563FEB747DEF896FFE64745145607A82AAB3B05552CC4E0003249AF5BF873A25E697A6DD5C5E46F0B5D32EC89C60855CF2476CE7F4AE0FC19A53EABE26B550B98A06134A7B00A73FA9C0AF71AEDC2D3BBE767CD67F8D715F568F5D5FE8145145771F281451450014514500145145001451450015F3FEBF73F6CF10EA13E721EE1CAFD3271FA57BE4F2882DE599BA46858FE0335F39B31662C4E493926B8B18F448FA6E1C87BD527E8BF3128A28AE13EA8F47F8556999351BC23A04894FD724FF00215E955C87C36B6F23C2825C733CEEF9FA617FF65AEBEBD5A0AD4D1F019B54F698C9BECEDF7681451456C79C145159DAE6AF0E87A44F7D373B06117FBEC7A0A4DA4AECA84253928455DB395F88DE23FB1D90D22D9F13DC2E6620FDD8FD3F1FE5F5AF29AB17D7B3EA37D35E5CBEF9A66DCC7FCF6AAF5E555A8EA4AE7E8380C1C70945535BF5F50A28AEABC13E166D7AFF00ED3709FF0012F81BF799FF00968DFDD1FD7FFAF5118B93B237AF5E1429BA951E88EBBE1BE826CB4D7D5674C4D74311E7B47FFD73CFE02BB9A4550AA15400A060003814B5EB420A115147E7B8AC44B135A5565D428A28AB39C2BE7ED72E45E6BDA85C29CAC970ECBF4DC71FA57B86BD7DFD9DA05F5DE70D1C2C54FF00B44617F522BE7FAE2C64B647D470E52F8EAFA2FEBF00A28A2B84FA83D6BE184063F0E5C4C47FADB938FA0551FCF35DBD627842C4E9FE15D3E1618731F98DF563BBFAD6DD7AF495A091F9D63EA2A98AA935DD8514515A1C814514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001589ADF8574AD7FE7BB84ACE0604F11DAFF00E07F1ADBA294A2A4ACCD29D59D2973D376679E4BF0AADC87F2B54941C7CBBE2071F5E6A8C7F0AEF0CC04BA94022CF2CA84B63E9FFD7AF51A2B1786A7D8F4239D6352B73FE0BFC8CBD0B40B2F0FD97D9ECD4966E6495BEF39F7FF000AD4A28AD9249591E754A92A92739BBB614514532028A28A0028A28A0028A28A0028A28A00CDF10B98FC35AA383822D25C1FF809AF00AF79F15923C29AA11FF3EEC3F4AF06AE0C67C48FAEE1C5FB99BF3FD028A28AE33E88F78F09C02DBC27A620EF02BFFDF5F37F5AD9AA5A3A797A258463F86DA31F928ABB5ECC55A291F9A579735594BBB6145145519057947C4CD60DD6AB16991B662B51BA4C1EB21FF018FCCD7A36B9AAC7A2E8F717F260F96BF229FE263C01F9D7825C5C4B75732DC4EE5E5958BBB1EE4F5AE4C554B2E55D4FA2C8309CF51D796D1D17AFFC05F991514515E79F5C5DD274CB8D635286C6D973248D8271C28EE4FB0AF78D2F4DB7D234D82C6D9711C4B8CF763DC9F726B9CF87FA02E97A2ADECA9FE9778A1893D553F847E3D7FF00D55D7D7A586A5C91E67BB3E2739C7BC455F650F863F8B0A28A2BA4F1428A2B23C4BAEC5E1FD1E4BB701A53F243193F79CF4FC075349B495D974E9CAA4D420AED9C9FC4ED6952DA1D1E27CC8E44B363B28FBA0FD4F3F80AF31A9AEAE66BCBA92E6E24324D2B16763DCD435E4D5A9CF2E63F42C0E1161682A4BE7EA157748B06D4F58B4B2507F7D2AA9C7619E4FE59AA55DF7C30D28CDA9DC6A6EBF25BA79719FF006DBAFE43FF0042A29C79E690F1B88587C3CAA765F8F43D4800AA1540000C002968A2BD73F390A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28031FC57FF22A6A9FF5EEDFCABC1ABDD3C64FB3C21A91FF00A658FCC815E175E7E2FE247D7F0EAFDC4DF9FE8828A29554BBAA8EAC702B90FA13E88B01B74EB55F48907E82AC522A844551D00C0A5AF6D1F9849DDB6145145023CDBE2A5FB0FB069CAD8521A671EBD97FF66AF37AEC3E25316F16104F0B6E807EA7FAD71F5E55777A8CFBFCAA9A860E097557FBC2B6BC2DA2B6BBAF416A549814F9939F441D7F3E9F8D62D7A97C2CFB2FF66DF6CC7DAFCD1E66473B31F2FEBBA951829CD26566788961F0D29C77DBEFEA77C00550AA00006001DA968A2BD63F3E0A28A2800AF1BF885AC9D4BC42D6B1BE6DECF31800F05FF88FE7C7E15DDF8C3C5D0E836AD6D6EC1F51917E451FF2CC1FE26FE82BC61999D8B312CC4E4927249AE2C55556E447D3E43819297D666BD3FCC4A28A2B84FA92C58D8DC6A57D0D9DAA179A56DAA3FA9F6AF78D0B488743D1E0B18B9D832EFF00DF63D4D73FE01F0DC7A5E949A84F1FFA6DD2EEC91CA21E83F1EA7FFAD5D8D7A586A5C8B99EECF8BCEB30FAC54F630F863F8B0A28A2BA4F0C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028AF38F885E26D46C3528B4DB19DADD04424778CE1989278CF6031FAD687C3CF10DF6AF05DDADF48667B7DAC92B7DE20E783EBD3F5AC5568B9F21E8CB2CAB1C2FD69B56EDD6C76F451456C79C145145001451450014514500145145001451450014515CBF887C71A6E865A08CFDAEF071E5467843FED1EDF4EB532928ABB36A342A579F25357674E48552CC40006493DAB98D5BC7DA26985A3499AEE61FC107207D5BA7E59AF30D6BC55AB6BAC45D5C15833C4117CA83F0EFF008D62D71CF16F6823E930BC3D14B9B112F92FF33BABEF8A1A9CC48B2B4B7B65EC5F3237F41FA5614FE32F10DC365F559D7DA3C27F202B0A8AE69559CB767B54B2FC2D25EED35F9FE66C2F8AB5E56C8D5EEFF1909AD0B4F883E22B62375D4770A3F866887F3183FAD72F4525526B665CF07879AB4A0BEE47A5D8FC548CE16FF4D65F5781F3FF008E9C7F3AE96C3C6FE1FBFC2ADFAC2E7F867053F53C7EB5E1F456D1C5545BEA79D5B21C24FE1BC7D1FF0099F47A3A4881E365746E4329C834EAF9E6CB53BED39F7D95DCD01EFE5B900FD477AEAF4BF899AADA954BF8A2BC8FBB6363FE638FD2BA238B8BF8B43C8AFC3F5E1AD29297E0FF00CBF13D6E8AC5D0FC53A5EBEA16D66DB3E32D049C38FF001FC2B6ABA549495D1E254A53A52E4A8ACC28A28A66673BE3B38F05EA3F44FF00D18B5E215EDDE3C04F82F5103D233FF9116BC46BCEC5FC6BD0FB2E1DFF007697F8BF44156F4C4F3356B34FEF4E83FF001E1552B4342C1F10E9A0F4FB5C5FFA18AE78EE8F6AABB5393F267D03451457B27E661451450079B7C51D21B75AEAF18CAE3C897DBA953FCC7E55E6F5F42EABA6C3ABE9771613F09326DCE3953D8FE0706BC2F58D12FB43BD6B6BC88AF3F2381F2B8F506BCEC5536A5CCB667D96458D8D4A3EC24FDE8EDE9FF00CEAECFE19CB2278A1E352763DBB6F1F4208FF003EF5C7223C8EA91AB3BB1C0551924D7AE7807C2F368B6D25F5EAECBBB850A233D634EB83EE4E3F2151878B94D35D0EACE2BD3A7859465BCB44BFAEC767451457A87C185713E32F1BAE921F4FD3595EF88C3C9D443FE2DFCAA7F1B78B1744B436767203A84CBC639F297FBC7DFD3F3AF1E666762CCC5998E4927249AE4C457E5F763B9F4593E54AAFEFEB2F77A2EFFF0003F31D2CB24F33CB348D248E72CEC7249F734CA28AF3CFAE4ADA20ADDF09686DAEEBD0C0CA4DBC67CC9CF6DA3B7E3D2B334ED3AEB55BD8ED2CE2324CE7803A01EA7D057B6F867C3D078734C16E843CEE774D2E3EF37F80ED5D142939CAEF63C9CD7308E16938C5FBEF6F2F3364000000600E8052D1457A67C28514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451401E3FF12FFE46A5FF00AF64FE6D5A3F0A8FFA6EA4BEB1A1FD4D66FC4A607C578F4B7407F3357FE15E7FB5350F4F257FF42AF3E3FEF1F33EC6AAFF00847FFB757E68F52A28A2BD03E3828A28A0028A28A0028A28A0028A28A002A2B8B886D2DE4B8B895628631B9DD8E001521200249000E4935E3FE39F15FF006D5DFD8ACE43F6085BA8FF0096ADEBF41DBF3ACAAD554E373BB01819E32AF22D12DD96BC51F10A7BFDF69A497B7B53C34DD1E4FA7F747EBF4AE168A2BCC9CE537791F7586C2D2C3439292B0514515074051451400514514005145140051451400E8E478A4592376475395653820FD6BD33C25F103ED0F1E9FACBAAC87E58EE8F018FA37A1F7AF31A2B4A7525077472633054B170E5A8BD1F547D2345796F833C726D0C7A66AD2936FF007629D8F31FB37FB3EFDBE9D3D4410C010410790457A74EA46A2BA3E171982A984A9C93F93EE73FE39754F06EA25BBAA01F52EB5E1F5EB1F142ECC5A0DB5B038F3E7C9F70A0FF00522BC9EB8B14EF52C7D4E414DC709CCFAB7FE5FA0568E808CFE23D3154649BA8BFF42159D5D2780ED0DDF8BECF8CAC3BA56F6C0E3F522B082BC923D5C54D4284E4FA27F91EDB451457B07E6C14514500151CD04371198E789258CF55750C0FE06A4A281A6D6A8AB6DA65859BEFB5B1B6818F53144AA7F4156A91DD63467760AAA32598E0015C4EBDF11EC6C3741A628BC9C71E667F76BF8FF17E1F9D44A7182D4E8A387AF8A9DA09B7FD753B2B8B886D2069AE2548A25196776000FC6B83D7FE25410ABDBE8C9E749D3ED120C20FA0EA7F1E3EB5E7FAAEB7A8EB53F9B7F72F2E0FCA9D157E83A0ACFAE2A98A6F48E87D360F20A74ED2AEF99F6E9FF0492E2E26BAB89279E4692591B73BB1C926A3A28AE53E81249590569E87A0DEEBF7A2DACE3E07324ADF7631EA4FF4A4D0F44BBD7B514B4B55F792423E58D7D4D7B8691A45A689A74767689845FBCC7ABB7727DEB7A141D4777B1E4E699A47091E486B37F879B2BE81E1CB1F0F5A7956A9BA561FBD9987CCE7FA0F6AD7A28AF492515647C4D4A93AB2739BBB614514532028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F13F1F4DE6F8CAFBD10220FF00BE07F5CD741F0A63CCFAA4BFDD58D7F32DFE15CB78C4E7C5DA9FFD76FE82BAFF008507F75AA8F78BFF0067AF3A9EB5FEF3ECF1AB9729B2FE58FE87A3514515E89F18145145001451450014514500145154F54D4EDB48D3E5BDBB7DB1463A7763D80F7349B495D9518CA72518ABB6737F11B5496C3C3CB6F0B157BB93CB623FB8064FE7C0FC4D78F56CF887C497BE22BCF36E1B64284F950A9F9507F53EF58D5E5D7A9CF3BAD8FBDCAF08F0B875097C4F56145145627A214514500145145001451450014514500145145001451450015DA7843C73268E16C7512F2D8F4471CB43FE2BEDF97A5717455C27283BA30C4E1A9E229FB3A8AE8EFF00E275E4576FA4B412AC90B44F22329C839239FD2B80A7191DA3546725533B413C0CF5C5368A93E79731383C3AC3515493BDBFCC2BD13E155B0375A95D11CA22463F1249FF00D04579DD7AA7C2C8B6E8D7D363EFDC05CFD147F8D698657A88E3CEA7CB829F9DBF33BDA28A2BD43E1028A28A002B9FF1178BF4FF000F2F972133DD9195810F3F563D8555F19F8AD7C3F6620B621B50997E407911AFF78FF41FE15E3934D2DC4CF34D23492B9DCCEC7249AE5AF88E4F763B9EF657947D617B5ADA47A2EFFF0000D6D77C51A9EBF29FB54DB2007E5823E107D4773EE6B168A2B81C9C9DD9F5D4E942947920AC828A2ACD8E9F77A95CADBD95BC93CA7F85074FAFA0FAD24AE5CA4A2AF276456AD8D0BC37A87882E025AC456107124EE3089FE27D8576FA07C348A2DB3EB52095FA8B78CFCA3FDE6EFF0041FAD77D04115B4090C11245120C2A20C003D8575D2C2B7ACCF9EC767D4E17861F57DFA7FC128685A159E81A7ADADAAE49E6494FDE91BD4FF8569D145772492B23E52A54954939CDDDB0A28A29901451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451515D4862B49A41D523661F80A0695DD8F05F105D0BCF116A170A72AF70FB4FB6703F4AEF3E154256CF539F1F2BC91A0FC013FF00B35798D7B27C388043E118E40399A6773F9EDFFD96BCDC37BD56E7DA674D52C0FB35E4BEED7F43ADA28A2BD23E2828A28A0028A28A0028A28A002BC87E22EB8DA86B5FD9D13E6DACCE081FC52773F874FCEBD27C47AC2687A1DC5E9C79806D894FF139E9FE3F85782BBB492348EC59D892C4F524D71E2EA597223E9387F09CD378892D168BD7FAFCC6D14515C07D6051451400514514005145140051451400514514005145140051451400514514005145140057B47C3DB7F23C1F6CD8C199DE43FF007D63F9015E2F5EF7E1887C8F0BE971E31FE8C8C7EA467FAD75E117BED9E0710CED878C7BBFD0D6A28A2BD03E382A2B89E3B5B696E25388E242EE7D0019352D73DE389CC1E0DD4581C16554FF00BE9803FA135327CB16CD6853F6B5634FBB4BEF3C7357D4E6D6354B8BE9CFCF2B640CFDD1D80FA0AA54515E3B6DBBB3F498C5422A31D9053911A4754452CCC7015464935674CD3A6D5B5282C6DF1E6CCDB413D07727F01935ED5A0F8534DF0FC4A608849738C35C4832C7D71E83D856B4A8BA9E879F986674F06927AC9EC8E0F40F8717B7A567D558DA41D7CA1FEB1BFF0089FE7ED5E99A6E9563A45A8B7B1B74863EF81CB1F527A935728AF429D28D3D8F8FC66615F16FF78F4ECB60A28A2B538428A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B3B5EB85B5F0FEA13B1C04B77C7D769C7EB5A35C47C4CD4FECBA1C56087E7BB93E6FF0071704FEBB7F5A8A92E58367560A8BAD888535D5FFC39E4B5EE7E0B80DBF83F4D42304C65FF00EFA62DFD6BC574FB39351D42DECE11FBC9A4083DB27AD7D0904296D6F14110C47120451E800C0AE3C1C75723E8B88EAA50852F3BFE9FA92514515DE7C9851451400514514005145657893551A3681777A08F31536C5EEE781FAF3F8526D25765D3A72A93508EEF43CD7E21EBDFDA5ACFD8217CDB5992A71D1A4FE23F874FC0D71B4ACC598B312589C924F2692BC89C9CE4E4CFD1B0D42387A51A51E814514541B851451400514514005145140051451400514514005145140051451400514514005145140057D13631F93A7DB458C6C8957F202BE76AFA3D062351E80576E0F767CC7123D29AF5FD07514515DC7CB05729F114B0F084D81C1963DDF4CFFF00AABABAA5AB69B16AFA55C584C709326DC81F74F507F0201A8A91728B48E8C2558D2AF0A92D934CF9EE8AD0D5F46BDD12F5ADAF612841F95F1F2B8F507BD5054677088A5998E0003249AF21A69D99FA342719C54A2EE99D4FC3B8BCCF185BB63FD5C7237FE3A47F5AF67AE2BC01E179B47824BFBE429773AED58CF58D3AF3EE4E38F615DAD7A787838C353E1B39C442BE29B83BA4AC1451456E7941451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014561EBBE2CD2FC3F84BA919EE08C8822196C7A9EC07D6B9497E2B2E488B4724762F718FD36D652AD08BB367750CB7155E3CD4E1A7DDF99E8F457990F8AD3E79D263C7FD773FF00C4D5FB2F8A5632B85BCB09ADC1FE28DC4807E80D2588A6FA9ACB27C6C55F93F15FE677D5E41F12EE8CDE285873F2C102AE3DCE5BFA8FCABD56C351B4D52D56E6CAE12689BF894F4F623A83EC6BC6FC78DBFC69A87B18C7FE38B59E29FEEF43AF21A6D631F32B349FE691A9F0C6C16E35F9AF1C645AC5F2FB33703F4DD5EB55E79F0AA3C59EA52E3EF488BF903FE35E87578656A68E7CEEA39E364BB597E01451456E792145145001451450015E71F14F50216C74D53C1CCEE3F45FFD9ABD1EBC67E22CDE6F8BE64CE7CA8A34FA71BBFF0066AE7C4CAD4CF6323A4A78C4DF44DFE9FA9CA514515E61F701451450014514500145145001451450014514500145145001451450014514500145145001451450015F4469D71F6BD2ED2E7FE7AC2927E6A0D7CFD65673EA17B0DA5B2179A660AA3DFF00C2BE83B2B65B2B0B7B5539582258C1F65007F4AEDC1A7AB3E6388E51B538F5D7EE27A28A2BB8F960A28A280239EDE1B988C5710C72C67AA48A187E46A0B5D2B4EB27DF69616B03FF007A28554FE82ADD14ACB7294E4972A7A0514514C90A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACED77535D1B44BABF20318932AA7BB1E00FCC8AD1AE3BE25C853C2814747B8453F913FD2A2A4B960DA3A7074955C4429CB66D1E4B71713DEDD493CEED2CD2B6598F24935D35BFC3AF104F12C8D1410EE19DB24B823EB8CD64F85E259FC53A6238CAFDA1091EB839FE95EF75C3428AA89B91F539B665530728D3A296C7917FC2B1D7719F3AC7E9E637FF13589AC785B57D0D7CCBCB6FDC938F3633B973F5EDF8D7BC5473C115D5BC904F1AC9148BB5D1864115BCB0906B43CBA5C41888C93A8934783685AEDE681A82DD5AB654F12444FCB22FA1FF1ED4BE24D461D5B5FBABE80308E6DAC03751F28C8FC0D5FF17F85E4F0EEA198B73D8CC730B9FE1FF64FB8FD457375C52E68AE467D3D0542B358AA7BB56BFF009FA1EADF0B57FE24578DEB738FFC756BBBAE1FE170FF008A72E8FF00D3DB7FE8095DC57A543F868F8ACD7FDF2A7A8514515A9E7851451400514514005788F8F063C69A8FD633FF0090D6BDBABC53C7FF00F23A5F7D23FF00D16B5CB8BF817A9EF70F7FBD4BFC2FF347334514579C7D9051451400514514005145140051451400514514005145140051451400514514005145140051451401E9FF000B6D20363797861437025F2C484721700E057A15715F0C21D9E199A423992E988FA0551FE35DAD7AD415A9A3F3FCD65CD8CA9EA1451456A79E1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C6FC4C5DDE1553FDDB943FA30FEB5D95727F11973E1098FF0076543FAD675BF86CEDCB9DB174FD51E61E177D9E2AD2CFFD3CA0FCCE2BDEEBE7ED05B6F88B4C6F4BB88FFE3E2BE81AE7C1FC2CF5B88D7EF60FCBF50A28A2BB0F9C2AEA3A75B6AB632D9DDC6248641823B83D88F422BC275DD2CE8BADDD69E6412792C30F8C641008FC70457D015E61F11BC372477326BD148A629362CA87EF06C05047B600AE5C542F1E65D0F7B21C57B3ACE949E92DBD48FE196B66DEFE5D1E523CBB8CC917B381C8FC40FD2BD4EBC03C3F3B5B788B4D95491B6E63CFD37007F4AF7FA30B26E167D059FD08D3C429C7ED2FC50514515D4784145145001451450015E29E3FFF0091D2FBE91FFE8B5AF6BAF14F881FF23A5F7D23FF00D016B9717F02F53DEE1EFF007A97F85FE68E668A28AF38FB20A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A29C88D2310A32402DF801934DA0028A28A00F71F04DAFD97C21A7A91CBA190FBEE248FD08AE82AA6950FD9F47B283FE79DBA27E4A055BAF660AD148FCD7113F695A73EEDFE61451455188514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005717F13A474F0BC2AAC407BB45603B8DAC7F9815DA5713F14013E18B73E978A4FF00DF0F5956FE1B3BF2CFF7CA7EA79968BFF21ED3BFEBEA3FFD0857D075F3B58DC0B4D42DAE48C88A55908FA106BE885657457520AB0C823B8AC307B33D6E234F9E9BF5168A28AEC3E682B92F88E71E1197DE64FE75D6D723F120FF00C524DEF3A7F5ACEB7F0D9DB977FBDD3F54793E97FF00217B2FFAEE9FFA10AFA1ABE79D2FFE42F65FF5DD3FF4215F43573E0F667B1C47F1D3F47FA0514515D87CD05145140051451400578CFC458F678C2E1BFE7A471B7FE3B8FE95ECD5E5DF14EC8A6A5637C07CB2C46227DD4E7FF66FD2B9F14AF4CF67219A8E32CFAA6BF5FD0F3FA28A2BCC3EDC28A283D78A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0096198C49301D648F667D3907FA5454514C49582A6B480DD5EC16E3ACB22A0FC4E2A1AE8FC0B65F6DF175902329093337B6D1C7EB8A705CD248CB1153D9529547D1367B680000070052D1457B27E6A1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500158BE2BD25B5AF0EDCDA45FEB801245EECBCE3F1E47E35B54529252566694AA4A94D548EEB53E6F652AC55810C0E0823915EDBE08D5E2D57C376C8240D716C821954F518E01FC401CFD6B94F885E143148FAD58C64C6E73728A3EE9FEFF00D0F7FCEB8BD1F58BCD0EFD6F2CE4DAE38653F75C7A11E95E741BA152CCFB1C453866B8452A6ECD7E7D99F4151587E1CF1458F88ADB31308AE947EF2DD8FCC3DC7A8F7ADCAF4632525747C755A53A5370A8ACD05725F12149F08B9FEECC87F5AEB6B9CF1E45E77836FC0EAA11C7E0EBFD3351555E0CDF012E5C5537E6BF33C66C1B6EA56ADE9321FD457D135F382398E4571D54822BE8E5219430E846457360FA9EE7122D69BF5FD05A28A2BB4F980A28A2800A28A2800AC3F16E8BFDB9E1F9EDD173709FBD87FDE1DBF1191F8D6E514A5152566694AACA94D548EE8F9BD94AB156043038208E9495E8BE3FF08B24926B5A7C64AB7CD731A8E87FBE3DBD7F3AF3AAF26A41C25667E8584C5C315495487CFC9851451599D41451450014514500145145001451450014514500145145001452AB1460CA70C0E41F4A4249393D6800A28A2800AF4CF85BA6ED82F75375E5C88233EC396FFD97F2AF368A29279921894BC92305551D493C015EFDA1E98BA3E8B6B62B8CC483791DD8F2C7F3CD75616179F3763C2CFB12A9E1FD92DE5F923428A28AF44F8C0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28011943295600A918208E0D79778BFC04F6AD26A1A3C65EDFEF496EBC98FD4AFA8F6EDFCBD4A8ACEA538D456675E0F1B57093E7A7F35DCF9CEDEE26B4B849EDE568A68CE55D0E0835EABE10F1DA6AA56C753648AF4F09274597DBD9BF9FE9478B3C050EA61EF74B5486F3ABC5D125FF03FA1FD6BCA67826B59DE09E378A58CE191860835C3EFE1E5E47D5FFB2E6F47B497DEBFCD7F5B9F46D61F8C258A2F09EA5E6BAAEE84AAE4F527A0FCEBC54EABA8B2ED37F7457D0CCD8FE7559E4791B73BB31F5639AD258B4D59238E870F4A15233954D9DF6FF8236BE8DB75296D12B7DE0801FCABC67C1BE19B8D6B5586778996C217DD248470C473B47AE7BFA57B5556122D272661C435E139C2945EAAF7F9D828A28AEC3E7028A28A0028A28A0028A28A0042010410083D41AF0BF17E91FD8DE24BA81502C121F3610071B5BB0FA1C8FC2BDD6B9BF18F864788B4D061DAB7B065A263C6E1DD49F7FE7586229F3C74DD1EAE518D585AFEFBF765A3FD19E25454B736D3D9DC3DBDC44D14D19C3238C106A2AF30FBA4D357414514521851451400514514005145140051451400514514005145140051535A5A5C5F5CA5BDAC2F34CE70A88324D7A9F85FE1FC1A694BCD5425C5D8C158BAA467FF00663FA7F3AD69D29547A1C58CC7D1C246F37AF45D4A5E00F084903A6B3A8C655F19B68987233FC647F2FCFD2BD168A2BD3A74D423647C362F17531555D49FFC30514515672851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400566EA7A0695ACE0DFD9472B0180FCAB0FF00810C1AD2A29349AB32E1395397341D9F91CA8F877E1DDD9FB34A47A79CD572DBC19E1DB560D1E970B11FF3D0B49FFA1135BD454AA505D0DE58EC4C959D47F7B1A91A448A91A2A228C05518029D45156728514514005145140051451400514514005145140189E22F0BD8F88ADB6CEBE55C28FDDDC20F997D8FA8F6AF24D73C29AA680E5AE61DF6F9C2CF1F287EBE87EB5EED48CAAEA559432918208C822B0AB423535EA7A981CDAB613DDDE3DBFC8F9BE8AF61D6BE1DE95A88696C87D86E0F3FBB198C9F75EDF862BCDB5BF0CEA7A0498BC833113859A3E51BF1EDF438AE1A94270DCFABC266787C5691769767FD6A63D1451589E885145140051451400514514005145763E19F015E6B1B2EAFB75AD91E46461E41EC3B0F7357084A6ED130C4626961E1CF55D91C8C51493C8B1C51B49231C2AA0C93F85763A27C38D4AFCACBA837D8A03CED23321FC3B7E3F957A7699A2E9DA3C3E5D85AC7171CB01966FA93C9ABF5D90C225AC8F99C5710549FBB415BCDEFFE5F9999A3E81A7685079563005247CF2372EFF53FD3A569D14575A492B23E7E7525524E53776C28A28A64051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005473C115CC0F0CF1A49138C3238C823DC54945034DA77479C6BDF0CF7C8F71A2CAAA0F26DA53C0FF75BFA1FCEB81D4349BFD2A5F2AFAD2581BB6F5E0FD0F43F857D0B4C9228E64292A2BA1EAAC320D734F0B196AB43DCC2E7D5E92E5A8B997E3F79F38D15EF93F86743B8399349B3CFAAC414FE9555BC15E1C6EBA5C5F8330FEB583C24BB9E94788A87583FC0F0DA2BDB5BC05E1A6FF986E3E93483FF0066A8CFC3DF0DE7FE3CDC7FDB77FF001A5F549F745AE21C2FF2CBEE5FE678B55ED3747D4357984563692CC7382CA3E55FA9E82BD92DFC13E1DB660C9A646C47FCF5667FD18915BB1C71C31AC7122A228C0551803F0AB8E11FDA6615F88A16FDCC35F3FF0080719E19F87F6BA595BAD4B65D5D8E553198E33FD4FB9AED68A2BB2108C15A27CDE231357113E7AAEEC28A28AA300A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803FFFD9, NULL, NULL, N'jznvkmbnzdsv', N'https://OAO.MusicShop.ru')
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (3, N'ПАО "Гитарист"', NULL, NULL, NULL, N'kvbzdsnbv', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (4, N'ЗАО "Всадник-гитарист"', NULL, NULL, NULL, N'nmvzdsb  v', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (5, N'Холдинг "Павлин-гитара"', NULL, NULL, NULL, N'kbvmndsbvk', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (6, N'НАО "Пеликан-гитара"', NULL, NULL, NULL, N'момоим', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (7, N'ПАО "Страус-гитара"', NULL, NULL, NULL, N'bvkjdsbfkj', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (8, N'ПАО "Магнолия-гитара"', NULL, N'+7(900)013-00-00 доб 45', NULL, N'jbvkjzdsbk', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (9, N'ПАО "Гибискус-гитара"', NULL, N'+7(900)013-00-00 доб 01', NULL, N'djbvmdbsvkv', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (10, N'ПАО "Ипомея-гитара"', NULL, N'+7(900)013-00-00 доб 12', NULL, N'bvkbdsbv', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (11, N'НАО "Шиповник-гитара"', NULL, N'+7(900)013-00-00 доб 78', NULL, N'dsbkbkjdsbs', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (12, N'ООО "Тюльпан-гитара"', NULL, N'+7(900)013-00-00 доб 50', NULL, N'kbkdsbf', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (13, N'ООО "Ритм"', 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080281028103012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F52A28A2BF1C39828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0029ACCAAA59982A8EA49AC9D63C416FA4FEECA996E1864463B7D4D70DA8EAF79AA49BAE25F901F9635E157F0AF4F099655C47BCF489495CF453AAE9C0E0DFDAFFDFE5FF1A55D4F4F760A97D6CCC7A0132FF8D795D15E97F61C3F998F94F5E1C8C8E41A2BCAEDB51BDB3FF8F7B99631E81B8FCAB6EC7C65790B05BC459D3B951B5BFC2B8EB64B5A1AC1DC5CA7754567D86B363A9002DE705FFE79B70DF956857933A73A6F966ACC414514540828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A7600A28A29005145140051451400514514005145140051451400564EB7ADC3A4420604972E3E48FF00A9F6AABE22F100D323FB3DB106E9875EBE58F5FAD7072CD24F2B4933B48EDD598E49AF6B2FCB1D5B54A9F0FE65243AE6E25BBB879E67DF239CB135151457D3C528AB22C28A28A60145145002AB32306525587208EA2BA8D17C572C72AC1A8BEF88F0253F797EBEA2B96A2B9F1186A75E3CB342DCF5EE08C83907BD2D73BE11BF375A5B5BBB12F6C768CFF74F4FEA3F015D157C5E228BA351D37D080A28A2B11051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514C02B1755F1259E98E62E67B81D6343F77EA6B2FC41E276477B3B07C11F2C930EDECBFE35C79249C9E49AF730394F3AE7ADB762944EAE7F1BCA5716F6488DEB23EEFD062B1EE7C45AADCB65AEE4403A2C5F2FF2ACBA2BDAA781C3D3F862BF32AC5DFED8D4BFE7FEE7FEFEB51FDB1A97FCFF00DCFF00DFD6AA5456DEC297F2AFB82C6DDAF8AF54B6C06956751DA55CFEA39AEB348F105AEADFBB03CAB81D6363D7E87BD79C5391DA3757462AEA72083820D71E272CA35A3EEAB3F21347AED15CDF87BC482FCADA5E10B723EE3F4127FF005EBA4AF95C461EA509F24D121451456020A28A2800A28A2800ACED63548F49B169DB0643F2C687F89BFC2B4090A0924003B9AF37F116A5FDA5AA3B236608FE48FD3DCFE3FE15E865D84FAC55D765B8D2B99B34D25C4CF34CE5E473B998F7A8E8A2BEC5249591A0514514C028A28A0028A28A0028A28A00E83C1D71E56B4623D268CAE3DC73FD0D77F5E57A5CFF0066D56D66CE02CAB9FA679FD2BD52BE5F3AA7CB594FBA22414514578A4851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E6271851451400514514005145140056078AB537B0D384309DB2DC12B9EE17BD6FD79DF8AAFBED7AD3A29CA403CB1F5EFF00AF1F857A395D0F6D5D5F65A8D189451457D89A0514514005145140051451400E4768DD5D09565390457A5E89A90D4F4E498E3CD5F9641EFEB5E655D2F836E8C5A935B9276CA878F71CFF00207F3AF3734C3AAB41CBAC75264775451457C79014514500145148480327802981CE78C2FF00ECFA725AA36249DBE6C7F7475FD71FAD7095A1ADEA0752D5659C1FDD8F923FF747F9CFE359F5F6997E1FD85049EFBB345A0514515DA30A28A2800A28A2800A28A2800A28A2800AF57B1B91796105C2FF00CB440C7D8F715E515DA783350F32DE5B073F345F3C7FEE93C8FCFF009D78F9CD073A2A6BEC9323ABA28A2BE5480A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A28022B89D6DAD659DFEEC485CE3D866BC99DD9DD9D8E598E49F7AF40F16DC9834368D7ACCEA9D7B753FCBF5AF3EAFA7C9295A94AA772E21451457B65051451400514514005145140055FD1A716DAB5B4A4E1438C9F6EF5429412AC08EA2A671528B8BEA23D7A8ACFD1AF05F6950CD9CB05DADF515A15F07569BA73707BA330A28A2B300AABA810BA65D1620010B727E956AB93F186ACAB08D3616CBBE1A523B0EC2BAB074655AB46311A38CA28A2BEE0D028A28A0028A28A0028A28A0028A28A0028A28A002B6BC2B2B45E20800242C8195BDFE527F98158B5A1A1BECD72C8FFD3551F9F15862A3CD466BC9899E9F451457C29985145148028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A00E2FC6F719B8B5B61FC285CFE2703F91AE52B5BC4B3F9FAFDC9CE550841F80E7F5CD64D7DBE029FB3C3C23E468828A28AEB1851451400514514005145140051451401D1785B59FB15D7D9276FDC4A7827F85ABBDFA57905743A5F8B2EACD161B95FB444A300E70E3F1EF5E266596CAB4BDAD2DFA92D1DF515CAFFC26F6DFF3E72FFDF42B2756F155C6A1018218FECF137DFC364B0F4CD7974B2AC44E5692B21599A7AEF8A8465ED74E6CB7479C76FF0077FC6B8E666762CC4927924F7A4A2BE9B0D85A7878F2C11495828A28AE918514514005145140051451400514514005145140055AD31FCBD56CDFFBB3A1FF00C78555A7C2DB268DBFBAC0D4545783407AE514515F02F7320A28A2900514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451400514556D42636DA75D4C3EF471330FAE2AE11E692480F2FBB97CFBC9E6FF009E92337E66A1A28AFBD8AE58A48D028A28AA18514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145149EC07AFD14C85B7C31BFF7941A7D7C04B46CC828A28A900A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28ACBD7F56FEC6D37ED0AAAD2338440DD33C9FE95AD1A33AD515386EC695CD4A0918C9ACDD1B588758B3F353E59170244FEE9FF0A8FC49726D7C3D79229C314D831FED1C7F5AD9612A2C42C3CD5A57B05B5B1A514B1CF18922916443D190E45495C9F806679B45B92DD16E9947FDF2B59FA66AD3BFC429ED99CE1E5962653FDD50C47FE822BB65953F6B5A9C65FC357F52ADB9DE514515E39014514500145145001451450014514500145145547E24074D451457E98761CCD14515F989C61451450014514500158BE2A9C45E1F997386919517F3CFF206B6AB95F1BCDB6CED20C70F233E7FDD18FF00D9ABB3010E7C4C5798D6E715451457DB1A0514514005145140051451400514514005145140051451400514E44790E11198FA019A592292220491BA13D997140ECED71945145020A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A293D80F59B4FF8F383FEB9AFF2A9AAAE9ADBF4AB363FC5021FFC7455AAF82A8AD368C828A28ACC028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B0FC59A3CDADE86F6F6CC05C46E25881380C467E5FC4135B75CB6BFAFB4723D95A3636FCB2483AE7D057A196D3AD3C44654775A9D981C1D5C555E4A7FF000C73FE05BB7B2BCBD6BFDF6C888232B22904BE7D3DB07F3ADEF146A367A9E81716969700DC36D64CA90090C0D72CCE4F524FE3499AFADAD82855C4AC549BE656F4D0FAC870DD0DE726D9D0F86B55B4D174186D270ED7196790C6063713F5F4C0FC2A3379A2A7885B5C8ED27376576E0B8099C63763D71C560EEA5CD2780A4E73A9ADE5BEA744787F06B74DFCCEEADBC51613C81240F093DDB915B4195941520A9E4115E53BB9EB5BFE1DD70D9CDF65B86FF4773C31FE03FE15E463B258C60E743A743CDCC787A3083A986E9D0EE68A28AF9B3E4428A28A401451450014514500145145547E24074D451457E98761CCD14515F989C6145145001451450015C1F8CAE3CDD5A3801E218C647B9E7F962BBCAF30D767FB46B978F9CFEF4A8FF80F1FD2BD8C969F35772EC8A8EE67D14515F5458514514005145140055EBDD22EEC2DE29A740124E983D0FA1AAD6D1896EA18CE70CEAA7F3AECFC569BB4618CFCB2AE07E06B96B5670A908AEA7452A2A74E527D0E1E8A3A515D47385145140055FD2F4D7D42E3072B0AFDF6FE83DEA8AAB3B2A28CB31C002BB4B2B75B2B34817A8E58FAB77A0ECC1E1FDACEF2D913C10C36917976F188D7DBBFD69B384950A4A8AEA7B30CD56BED56CB4E5537772916EE80F24FE02A1B4D5EC35107EC9731C8C3F87A1FC8F35B4612B5EDA1EBB74D7B9F818BA9E9DF646F322C9858F43D54FA567575970AB2C6C8E32AC304572F3446199E33FC2715138DB53C7C5D154E578ECC8E8A28A839028A28A0028A28A0028A28A0028A28A0028A28A0028A28A181EA7A4FFC81AC7FEBDE3FFD0455CAA1A21DDA1D91FF00A62A3F4ABF5F075D35565EACCC28A28ACACC4145145166014514516601451451660145145166014514516601451451660145145166014500162028249EC282082410723B1A7CB2B5EC01451452B303335DD40E9FA6B3A1C4B27C89EDEF5E7ACD939EB5BBE2BBB69B53F2037C90AE31EE793FE7DAB85D7F5078156DE262ACE37311E95F6D9360F928AEF2D4FB9CBA30CBB01EDE6B57AFF923689A8DA68D7EF4883EAC2B833331EAC4D33CCF7AF7D60FCCC1F123E94FF13BA6BEB45FBD7317FDF62961BDB6B87D914C8EC3B035C1EFF7A74570F04C92A36194E45378456DC88711D4E74A50563D00D19A6EECA823BD15C07D7AD55CF43F0DEA3F6FD3155CE6683E46F71D8FF9F4AD9AF3FF0008DEFD9F59F218FC93A95FF810E47F9F7AF40ED5F159AE1D50C434B67A9F9BE7385587C5C94767AA0A28A2BCC3C90A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A28011982A9663800649AF2496432CCF21EACC58D7A56BD39B7D0AF1C75F2F6FFDF5F2FF005AF32AFA4C8E9DA329FC8B88514515EF1414514500145145005AD386ED52D07ACC9FFA10AEAFC61AACDA3E9115D40A8D2F9EAAA5C640E09FE9FAD72BA5FF00C85ACFFEBBA7F315BFE3EB69EF346B5B7B789E595EED42A20C93F23D70D6829E2A9C59EAE5ED28B6CC8D7444FA82DCC2311DCC493A8C63EF0ACCAE86FB41D5278AC047672129671237206182F22AA8F0B6B47FE5C5BFEFB5FF001AF42961EAA825CAFEE3CAC456A2AACAD25F7991456CFF00C229ADFF00CF91FF00BFA9FE34F1E11D68FF00CBA81F5917FC6B4FABD5FE57F718FD6297F32FBCA9A2C3E6DF8723E5886EFC7B7F9F6AD7D5F554D2B4D92E5B0587CA8A7F898F4A4B4D32E3490F1DCA8595F0701B3C76FEB5C978AE4B8D5359B6D2ECE379A55E1634192CCDCFF2C7EB57468B954E568F6E8D48D2C2F3AEA72D7D7B35EDCBCF3B9791CE49350C17735A4E934323248872AC2BD32CBE155B5959FDB7C47AAAC1185CBC71E1421E3AB9FCBA7E35627D2BE17448B035E45B9BE51225CBB1C9EE48E063DF8F5AF6952D2C78D2C646F7577E857D1B584D634C49B8132FCB2A83D1BD7F1A83534F99651DFE5349A30D0FC37E394B6B5BC8EFB49BEB72C8490FE5B0CE01C75FBBE9FC5ED5D75D5C78767B8818C5184DC7CC0508006D3CFE78FCEB86AE116BEF2474D4C73A94EDC8DE9BD8E0A8AF40DBE12F5B5FC8D1B7C25EB6BF91AC7EA5FDF5F79E67D77FB8FEE3CFEA9DFDFAD9A0E3748DD16BD2DBFE111552C7ECC4019E14D72D178AFC21A1A2DD5B69AD7DA84C3CC72C38849E4202DFDDE071E95A53C0A52BCA49AF235A78973DA2CE11F55BF2DC161EC12BB5BDF0C5DD97C3987C44F792FDB24D921876AEDF2DCE17DF3CA9FE95337C67B907E4D1A1C7BCC7FC2BB8F1378AA4D07C236BAD476C92BCE63FDD331006E5CF5AEDF6148D7DA55FE4FC4F0D4BED524655412B331C0023EFF956AEB3A5F89742BB8EDAF2090C9246245F29778C1F703AD75DA57C5BBCD4B5AB1B16D2A045B9B88E12C24625433019FD6BA2F883E33BAF08B69EB696D0CE6E44858CA4FCBB76E318FF0078D1EC6976FC05CF5BF97F13CAB4EB5D7F50D46D6D160B98C4F2AC7E635B9DAB938DC78E82B67C5BE1AD6BC3DA9C56D66F73A8C52441FCD8ED8F072410719F4FD6B63C3DF14B57D67C4561A7496564915C4CA8E555F217BE3E6AD7F883E3BD4BC29ACDB59D84169224B6E25633A3139DCC3B30F4A3D8D2EDF807356FE55F79E6420F121FF987DFFF00E02B7F857609E0ED45FC02758F32EFFB5776E1685147CBBF6E318CE71CD671F8C7E213FF002E7A67FDFA93FF008BAF419FC4B7C9F0BBFE122D908BE302C980A7664B85E99CF43EB4FD8D2EDF807356FE54795A689E2F73F2E9D73F8AA8AE9341F056B777A76A52EA51CB05C2478B54DC9F33E09FE7B6B9F7F8A5E2671C4F027FBB1FFF005EBD27E1F6BD7FADF83F51BFD426F32E229A44460B8DA046AC3F52697B1A3D857AFD91C4C5A2FC478A358E28AED11780A2E63007FE3D5D3784BC39E25BB92F0F892FB50B4454020D970A4B31CE4F19E981F9D79D1F889E2BFF00A0C49FF7ED3FF89AF49F851AFEABAF0D58EAB74F7221F27CBDCA06DCEFCF41EC2B3784C337F02FB87FBEF239E6D0BE240919566B82A0901BED4BCFBF5ADBF0EF85BC55733CDFDBDABDE5A4213F77E4CE1896F7AE3755F1478C0EB57D15B5EDEF94B7322A044E8031C0E95DEFC2DBDD72F63D55F5C92EA4DAD1087ED03A7DEDD8FD28FA9E1BF917DC4DEAF7460B7863E226F60BA96541E0FDABAD6C69DE10F13BE8D78FA86BD7516A433F668E39B74678E371F73C7B571DAAC9E3F7D5EF8DB7F6E791F6893CB11F99B76EE38C63B62BD0FC0BFDB6DE0CBD4D67ED8350F365119B9DDE66DD8BB719E7AE68FA9E1BFE7DAFB90B9A7FCC8E58785BE221FF0098A01FF6F47FC2B46DFC1BE307D366927F123C77A1BF7512B16461EEDDBF2ED5C5ADBFC45931F36BA3FDE79057A6E856DAD0F865756B7AD71FDACF05C0432B1F33710DB79EBE94FEA586FF009F6BEE173CBAC91CF2F83FC787AF88235FFB6EFF00FC4D5893C15E330B1F95E295662BF3876750A7DBAE7F4AE517C21E3D9FACD743FDFBA615E95F10F49D575DD16DADB467D9325C077225F2FE5DAC3AFD48A3EA587FF9F6BEE42551FF003A39CFF8433C73FF00432C5FF7F64FFE26B46EBC19AFFF00675B7D97C51722F07FAFF35CF967FDDC73F9D715FF000AFF00C727FE5E0FFE06FF00F5EBD1FC65A1EA1ABF852D34DD327D97113C7BDB7EDCAAA91D7EB8A7F52C3FFCFB5F7213A9FDF5F719361E0DF122DF426FFC5323DB06CC890B30661E809A9B50F076B2D7D235978B2E60B627291CB9765FC722B33C1DE04D6744F13DAEA37F78B2430EFCA6F2D9CA32FAFBD5CF1A7802EFC51E20FED087514823F2963D8C85BA679EB47D4B0FFF003ED7DC4FB65FCFF81734EF086A8826FB6F89EEAE772E23F2894D87D7EF1CD52FF84375F1D7C6B27FDF07FF008AAD2F01783E6F071BFF003AF12E45D08F1B50AEDDBBBDFF00DAAE4E7F839712DCC920D6620AEE580F20F193F5A3EA387FF9F6BEE0F6CBFE7E7E0751A5F84AFD6E1FED9E29BABB4D9C244C5083EBF78D526F0DDD46CCB2F8EE552A704165047FE3D57BC0DE096F07DDDD5C3DF2DC99E309811EDC60E7D6B0EFFE1225FEA9777ADAB327DA267976887EEEE6271D7DE9FD4687FCFB5F70BDAC7F9FF037F42D30DA6A89247E2D3A9481580B67915B3C75C039A6EB7A6A4DAA4924FE2F6D3642066D965550BC75C13557C2FF000E21F0CEBB06A89A8C93BC4ACBE5988283B948F5F7A7F8A3E1D5BF89F5C9353975196067454F2D630C06063D69FD52972F2F22B0FDBC6D6E7FC0B10F86D5F479265F155F48A32DF6C49C6C551D7DBB1A9341D2F4F98DC91E23BBD50228C8175B447D79F94FB7E95774DF0CC3A6F8326F0E0B879229629633315C11BF3DBF1ACBD27C216BE0FD1F5892D6E6495E7B6249718DA555B1FCEB9F1382A6A93E4A51B9A509C675631E77AF91574BD174A9EC52FB54BB26498960AF2F3B73819EE4F1D6BCA7C72B6D6FE2ABE86CDF75BA6CD8739FE053FCF35EABE19F0D4775145A85F1DC84E6284F4603B9FF000AF31F89E90278C2E27B4FF51222A92061432A85207E42AA8414609D923DDC75573AF2A54EA4A6A3BFF2AF2391DF46FF007A7DAE9F7B7B8305BBB29FE33C0FCEB417C31A8B7530AFD5CFF85692AB05BB32A581C4D557841B5E865EFA7441A599235196760A07D6B5D7C29747EFDCC23E9935A1A7F8712CEE92E269FCD2872AA17033EB594B1104B467750C971729AE68D91BDC0181D3B504F14DCD359B8AF33767DEFC287DB5C9B6BD86719CC6EAFF0091AF5ECF19F5AF1776E6BD734991A6D1AC5D8E59A0424FA9DA2BE7F8829AE584FE47C6712C13709FA9768A28AF973E4C28A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A00C1F174A23D05D7FE7AC8A9FF00B37F4AF3EAEDFC6D2634EB68FF00BD2EEFC94FF8D7115F5B93C6D86BF76CB8EC1451457AA505145140051451401734AE757B3FFAEC9FCEBA9F16EAB36896763A84088F243763E571C1063707F435CBE91CEB167FF5D97F9D745E36D3EE754D32CECAD137CD2DD80A09C7F0393FA0AE395FEBB4EC7A7825074A4AA6DD7D096EFC6777025B14B68499ADE398E73C1619C75AA87C77A876B6B5FC437F8D5997C1B7B72B681E7863115B4713752772AE0F6A962F01C4BCCD7EC7D963C7F5AF7A9AC7496A7CED77818D47CB6B143FE13AD4BFE7DED3FEF96FFE2A987C71AA1FF9676C3E887FC6B713C23A2DBFCD34B237FD749401521B1F0ADB0C95B53FF032FF00D4D6DECF15F6A76F99CFED30D7B285FE41A15F5B6AB04875211FDA26C63230303A63D2B95D33571A6FDB1F41B06D4F5ABE9A4F9C0E2DE20E55371F7DB9C71D467B574963A8E9112DD412C68226959E23B3E5DBDBE95CC5CFC50B5D26CEDECF44D30F96883699D76AB7A9183EB9E6B6C3DAD793D7B9DF5F9D7B918BB69A3DB632EEFC03E36D7A7371A9BC7E667A4D701B1F40B902A41F073552C33A95A2AF7CAB66B1AFBE28F8A2E246315E476D1B7448E1438FC5813505A6B9E39D6086B4BCD4A752DB731F099F43DABA3DC336B1096E92356E7E1EEB3E19961D5B7DBDD436B20964443860AA72783ED9AEFAFC6857D6CEF132A370BF2FCA6B91B7D0BC71358CC356D61ADAD1E260F1C92090818231C703F0356ED748BFBAD2ADEF151764912B8CB738C5455BAD231BDCAA16A97752AD9AEDD4EA7FE11DF0D5AF1712C67FEBADCEDFE4451BBC2367FF003E8DF9C9FE359307822E6682394DDC4A5D436304E334FF00F840EE7FE7F63FFBE0D72FEF57C3491C4FD95ED2AACB37BE25F0ADA880B5BC663132FCC906DDBEFD053A4B1F87FAD8123369FBA46000F3BCA627F307BD715E3BD024D0F4CB7792E124F365DA0018E80D72367E1DD6B538F7D969B732A76609807E84F5ADE8CA7F6E3A9D30A14F939A1369773D987823C083ADB5B1FADEBFFF00175BDABE97A35FE930D96A91C6D65195F2D5E5280103039041E95E207E1978B4FF00CC353FF0223FFE2ABD27C6DE1DD535DF0B5A58D9C48D711CA8CC19C28C0520F3F8D745DFF291CB1FF9FC5BB2F0F781ED750B696D20B5174B2AB4244EEC7783C63E6F5AD2F1327866592DCF8896D99943187CDCF4E33D3F0AF2FD03E1AF88EC75FD3EF2E22B758A0B8495F130270AC0D74FE3FF00066AFE27BCB292C5AD82C31B2B79B215E491ED46BFCA16A7D6A9AFA3FF00C208356B74D2A3B1FB7E4B45E5A36EC8073827D81AB3E25BCF0747A846BE21FB19BAF2814F3E22CDB327DBD775715E12F86FAE687E27B3D46EA5B330C3BF708E46279465FEEFBD68F8DFC05AAF89F5C8AF2DA7B64892DD62C48C7390CC7D3FDAA3DEFE50B505FF002F1FDE5B1A9FC314E5574DFC2DDBFF0089AEA66D4744B6F0AADD3B44346F294A80A76EC2463E5FA915E589F0735327E7D46DD47B2935DF5DF849EF3C1117878DEF965618E3694479FBB8ED9F6A7EFF00625BC3F5A8CA4BE38F0243F7258C638F96DDBFC2BA1D23C47A46A7A4DC5FE9D266D2066573E595C1550C78FA115E783E0B2E39D7CFFE027FF675D77873C1EBE1FF000EDE69435033ADC3BB197CADBB77205E9B8FA51FBCEC4FFB2FF3B21FF85A5E12FF009FA97FF01DBFC2B6F40F15693E2359DB4C959C40543EE8CAF5CE3AFD0D79F8F83B623EFEBEFF00842A3FF66AEAFC21E10B4F0B4776B6F7EF73F682A589006DDB9F4FAD3FDE760FF65FE6652BAF8ADA0DB5C4B0EC99DA366538423907E95B9E17F1758F8A61B892D11E31032AB07EF9FF00F5571F3FC2AD0A7B99667D6AE0348E5880D1F527E95D2F84FC2FA7F866DEE62B2BD92E16670CE5D978C0F6A5FBC0FF0065F339F9FE3269F0CF24634BB86DAC573E6015D5F853C57078AF4C96F62B77B711CC6228EC09E154E7FF001EFD2B8F6F875E105919A5D58124E70D70A3FAD757E17D2B44D16C66B6D26E639A2693CC7226DF86C01EBED45A7DC7CD85FE56720FF1A2DF9D9A4CA3FDE90575DA778B86A1E09B8F102DB6C68E295C444F1F267FC2B9FF00F8453E1BA31124F62581E73A911FFB3D7476965E1CB5F0CCB696AF6FFD9051C395B82CBB4E777CD9FAF7A2D3EE0A587FE4679F3FC67D473F269B6A3FDEDDFF00C5576FE3CF16DD78574CB6B9B382195A59BCB22607006D27B11E9587F61F8656FC86B33FF6F0CDFF00B3574BE25BEF0E43690FF6F79061327EEC4885BE6C7B7B5169771F3D1E94D9E707E336B7FF003E1A7FFDF2FF00FC55779E3FF155E786B45B5BBB148CCB2DC08DBCC1918DAC7FA56447E25F86E1D5121B22CC7007D818F3FF007CD743E22D77C39A6DB43FDB62178A473E5AC96FE6FCC075C60FAD2B3FE61F347FE7D338BF067C43D6B5CF1659D85E343F679049BC2A63384623F5147C43F1BEBBA2789DACF4DBB1041E4236DF2D5B939E7E606BA1D13C57E0CBDD5A1B6D2A1812EDB76C64B2D9D01279DBE99A935FF1AF86349D4CDB6A5034972115B22DC3F1DB9345BFBC529AE948CDF861E2AD5BC4126A8355BBFB408445E5FEED576E7767EE81E82B89D5BE21F8AADB57BEB68F55658E2B891147931F003103F86BD47C37E30D0F5D6B94D2E1963F24297DD104CE738E87D8D655EFC50F0CD95F5CDACD6B766586568DC881482CA707F8A95BFBC3F68FFE7C95FE17789758D766D53FB52EDEE16258FCBCA2AED27767A01E82B92D77C4DE308FC45A9DBDA5E5FF00911DDCA912C69C050E40EDE95E93E1AF1A693E237BA16104D17901779911573BB763A1FF0066B0352F8B1A6E9FA95D59FF0065CB23DBCCD116DC06E2AD827A5165FCC1CF3E948CDF016A9E2DBBF15DBAEA926A4F6451CBF9C8C133B4E3B53FC7571E334F155C0D1C6AFF0062D89B3ECD1B94CED19E83D6B63C37F1321F106B4BA7C7A5980323379865CF4F6DB507893E299F0FEB9369ABA48B8F2C29F33ED1B739507A6D3EB45A3FCC3BD6FF009F6BF035340935E93E1B5E0BC17835630DC797E72B097760ECC679F4C5739E17FF0084920D17C40FADA5F22B4082337208CE4B6719FA8AEA348F1A1D57C273EB5F611134492B087CDDD9D80F7C0AC2D3BC73378BF43D6A2934F5B61042AC0AC85B39CFB7B572E3153745F349AD8EBC0BADF5987EED6EBB1663D5A7B1F0BFDA65908B99D7ECF6A01FBB1AF0587F9F4AE3678A1B88FCB9A34913AE1C645696AB712DCDBD94C10ADAA44B0C67FDA50377EB5945EBCEA926DA5D8FD0F2DA14E109CDA579BD7CBCBFAEA480AA28550028E001DA8DD516EA6EEACAC7AEA492B226DD46EA87751BA8B0739297A633530B530B534889CC1DABD5BC2D2F9DE1AB17F442BF9123FA5791BBD7ACF84576F85AC07AA31FCD8D78BC4097D5A3EA7CA710B4E947D4DBA28A2BE3CF910A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A280390F1C9E2C07FD74FF00D96B8FAEB3C70F99ACA3EEAAEDF9E3FC2B93AFB2CAD5B0B12D6C1451457A05051451400514514017B4719D66CFFEBAAFF3AED758B3D52EE3B56D2258E2BA82E049BE4FBA176B29EDFED5719A20CEB5683FE9A0AEBFC42FADAE9F19D0439BA3300DB429F936B7F7B8EB8AE58FFBFD3BFE07751BFD5A76697AEDF32D4BA66BB70B187D6162C46A1FCB8872D8F98E78EF4DFF0084654AEEBDD5AFA503AE65DAB59F369FE29BCF27FD2CC3FB94DF9976FCFB46EFBBEF9A8C782AF6E1B75E6A4377A852FF00CC8AFA55792D29B7EACF9AA89464F9AA457A22F1B2F0A589DD23DB3B8EBBA6321FCB3487C4DE1EB1FF008F58413FF4C60DBFCF14C8FC11A746B99EEE6623D0AA8FEB4FFECCF0A5A712BC0587FCF498E7F2CD57EF92D146267FBA7BB948A569AED885BB7961626795A44CA02403DAB9CD17E23691068B0E9DA9D8487C989622022BAC9B700120FD2BA1BAB6D1DECA792DCC63EF188AB7D702BCFF0046F87DA86B91B5D89A282DCC8554BE72C0120F6F6A745CD3B68CF52AC684E1CF2BAF5FD0EC07C53F0E5932ADBD84DB7D6289571FCAA8DFFC638C922C34D6E3BCE7AFE46AD43F09346870F77A95C3AE0E7255055993C21F0FA08158CD6E841DDE61BC2491E841623F4AEBF7CF3FFD953D13679B6B7E38D735D8CC37170B1DB9EB142BB41FA9EBFF00EAAEDB4AD76FA3D06CA24946C5B755195CF18A2F7C2BE05BAB56FB05F471483700E975BB27DC13FCBD6ACF8685843E0282695A333CB0BA8CF241C902B1AB19EEA563D0A156838D953BEAB4B1B567A46BF358DBCB06B016378D591589F9463A74A90E8BE28038D5E33FF036FF00E26B988FC41AADB22C50DEC8B1A0DAA300E07E5530F15EB40FFC7E93F58D7FC2BCFF00AC505A3E6FBCE6A987AFCEEDCBF71A37DA6CB6AF0DFF008A2E925B2B525D3736E1BFB71DEB16FBE2F25B3F95A5E98AD129C0695F6E47FBA3A552F136B375AB6991C5A94C5AD229D249446A012B9C1FD09A8D7C0FA16AC826D37537556F9B0087C0FA75AECC3CD4A3FBBFC770F650493AFF0086C579FE2FF881E526282CA34ECA5198FE7BABB0F1778B752D37C2F6F7D68F1A4D23C609DB9E0A926B973F0C6C54FCFAC4807FD7203FAD749ABE8761A96890D85D5EBC70C650890328CE063BD747BE5296116CBF0391D0FE21788AFBC41636F35E0314B3AABA85ED9E6B5FE2178B75AD2F52B48AC2FE4811A12CC100E4EEA4D37C1DE1BB1D42DEE61D5A692789C32299E3C13F4DB5A3E20D1FC3BA95DC536A97BE54889B5479CAB919F714AD3EE3F69865B47F039BF06F8CFC41A878A2D6DAF3549A58183EE42060E1091DAA4F1DF8B75CB1F1235BD9EA9710422243B636C0CD6DE8DA6F846C7528E4D3EE6192EC6ED83ED019BA1CF1F4A9B584F06C97CD26ABF63FB56D00F9929071DB8CD1CB2EE1EDA8F4A7F81E6A7C65E246FF0098E5FF00E13B0AF42D7F5BD4A1F86D657315FDCA5CBC5016992560E49504FCC39AAE67F8750FF0589C7FB2CD5B97DA9F86E0D1216BC4B73A7154112B405D718F97E5C7A51CAFB8FDB43A527F71E49FF094F884FF00CC7754FF00C0B93FF8AAF47F0DEA57EFF0E6F679EF2E659CC73B2C924ACCDC29C609FA556FF849FC0901CC365031FF00A67658FE6A2BA0B4F11E9A7416BFB5B7916D511D846B185385CE703F0A397CC3DB3E94CF176D435493EFDDDE367D64635E8FF0BE5B9165A8997CD3991305F3E86AC9F8A161B7F77A6EA44F6CC4B8FF00D0AB5B43F168D6E19A44B39A111B05C48304D1CABB87B7A9FF003ECF1E9F4AD4E5BA94A69F78D976E442C7BFD2BD23E195A5E5969B7CB716B3425A6520488573F2FBD447E206B4EE443E1FDC33C665C56F687AFEABA8C32BDEE9AB6855804024DDB851CB10788ABFCABEF3CA97C1FE219D9B6697375EE557F99AF43F879A0EB1A2437EBA85A9844AC86306456CE3767A13ED503788FC744FC9A0DA28FF0069F3FF00B3D6BE85AAF88EE567FED8B3B5B7C6DF2BCACF3D739F98FB53E5890F115BFBA70137C3AF12CF7533AD94688CECCBBA74E99F635DEE95E1CD46DBC032E8D2F94B752452A7DFCA82D9C723EB5972CBE3B9E46D93E9F0AE78FBDD3F5AD9806BDFD80F0CD7D0FF0069323012AFDD0DCED3D3E9DA8E55D85F58ABFCD13865F855AF16F9AE2C40F6918FFECB5DDF8C3C293F89AD6D618EEE387C990B92CB9ED8AE77FB2BC74FF7FC496E3FDDCFFF00115B7E20B2D63528614D3B576B265625D95986E1F851CB1EC275EAFF003AFB8C3B3F84CF05CC33C9ACA1F2DD58AADBF5C1CE33BABA7F14F8461F12ADA2CD7C605B72C784CEEDDB7DFDAB9DB4F0DF8922BB8659FC57712223AB3C7BDF0C01E47DEABFE23D02EF5D7B7316AAF6C9106DC067E6CE3DFDA9F2AEC4FB69BDEA7E058D03E1FE97A1EA90DFC77D34B3461B682540E548FEB5635DF05681ACEA46FAFEE6E1252814859954607D56B0B44F050D2B568AFE4D4A49DE30C307BE411FD6AC6B1E09D375BD49AF6E6E6E959955711B281C7D54D16F225D47FF003F5FDC6FF873C3BA0E82F7074DB8791A50BE66E9C374CE3A7D6B32F3C2FE069AFAE66BB9E0FB4492B3CA1AFB69DC4E4F1BB8E69BA178574CF0F4B349693DD399942B79AEA7A7D14553BAF04787EE6F66BA9E49CC9348D23832A8192727B53B7913CFFF004F19D17872C7C2FA61B91A23C6C5B6F9BB662FEBB7F99AC9BBD47E1DC17D70D76966D706563297B567F9B3F37F09EF56345D1748D144DF6007F7B8DE4BEEE99C7F3AAB2F877C2924B24B35A5BB48CC59D8CCDC92727F8A8D7B215E2F79499A5A1EB7E0BBABF29A2C164B74B196262B1F2CEDE33F36D1EA2ABEB3E30F0869FAA4D0DFD9C72DE26DDEDF63563F7411F311E98A6E9565E1CB0BA76D3618639B66D628EC4EDC8F53F4A8350BFF000AC37D23DF7D9FED3C6F2C8C4F4E3F4A2EFC83961D1499BBA778A747B9D025D42D2DD92CE357664112A9F9473F2D65D9F8C749D7F4AD5E2D36D2487CBB66DC5A355CE55B1D3E9535A6B1A2FF00653CF6AF17D854316210E303EF718A8B4CD7741D485C45A7342C028126C8B6F073EC3DEB1C43FDDBF79237C34631AD197249D8C6F0F5F5ADC5BC9A3DFE3CA98EE89CFF000B7F4AC3F12DB4FE1F93CB7C36FF00F55263861EB5ADA5DE68A2D121BE8504F1920B15EBCD617C41D5A1BEBCB34B793CC8E288FCDEE4FF00F58572C29C6505CCF53EAABE371143133F631718CB7BED7EEBD4C34D7665E24457F71C1A90EBFE907FE3FF00FD6AC02DCD377D57B0A6FA111CDB1915653378EBCFDA15FC4D496DAD196E16391000C7008F5AE777D2893041A1D0A76D8A866D8A534DCAE76A5E9ACD5116A633D70247D83A9A03BD7B5787E210F8774E4E47FA3A139F5233FD6BC4A247B8B88E18C6E79182A8F526BDF234114491A8C2AA80057CEF114ED0843D59F2B9ED4BF2C47D14515F267CE0514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451401C2F8D49FED784678FB38FF00D09AB9AAE8BC66D9D6A31FDD8147FE3CD5CED7DB65FF00EED0F4345B0514515D830A28A2800A28A2803474119D72D7FDFF00E86BB0D7B57D4346D3D25D3AD05D4F24A13CBD8CDC618E70BCF6AE47C3DFF21DB5FF0078FF00E826BD09E5BB8612F6968B73216036B4BB00EBCE706B9E9293CC29D9DBFA67573463839B924D5F66EC604FAA78A2731FD9ACDE2DD146CD887A315048F9BDC9AAED63E2FBA3FBC9A58C1FEECCA9FF00A09AEA249758603C9B5B34CA8CF993B1C1C72385F5AAEC9E237E0CDA747EEAAE4FEB5F4AE85FE29499F36EBA527CB18AFC4E70F83356B96DD7177113FEDBB31FE55623F01123F7B7E01FF663CFF5AD63A6F8824FBDAD2463D120151B787F557FBFE22B8FA2C78FFD9AA561A1FC8DFCC3EB13FE74BE460CBE1AB98F5092DA170D14781E6BF19E01E9F8D7332DAF8D648A4B2D3A62B670DC491A88E4446E1DB9C9C1C75FF0AEE44171A7EA0DA7BDFB3868BCEF3987CC4E76E39FA572B751EB167AD6A56FA56A8BE6E566486750432B0E581F5DD9F6AD29538C76563D19E22A4E115269D92B68734DF0E7C493CCAD2244779F9DCCA0EDFAFF00F5AAF5BFC28BF663F6AD4A08973C18D0BFF5145CEBDE3F807926DCEE4C9F363815B3F88F97F4AA2F178EB5B61F68B89634FEF975887FE3BCD6F68F633E6ACF79452352EFC19E1ED0ACE47D42FCCD3AA1651909BB8FEEE49AD4F0B69F612785EDDAE66DB204E9BC0C0233FD6B93BFD32CBC3D69235E5D7DBB559D0A460F44C8C679FE66BB336DA74FA1C31DBB059ADA055240C13B57B8FC2A2693E8BD0D294A4A37E67AF546BE8BE1DD2AE749B7BEBC9983480E43481578623FA55F363E12B4E4BDAB11EB397FD335C1411CD32AAC68EE71D1466AFC5A06AD37DCB09FFE04BB7F9D79CAB2BDA14D333AD45B9B72A8D2B9D26A37BE149F4CBAB344854CD1345BE3B5F9972319071DABC46C742BED42F65B7870A626DAEC4F02BD5E1F076AF2FDE8E38BFEBA3FF8669D73E0CD474A864BDB6D97121E658A20771C0EA3D7E95D34255A72F7E1644C2A52A316A12BB7DCE3E3F085EB44A26D76E5580C6D19207FE3D5B575A3FDAF424D324BC930AAAA65C7276FE3482EAE1D11C496F1EE5059257C329F422A432BBDB30FB5C0B27F795B20575E8473D5EE64D9782ED2CEF21B91752BBC4EAE32B8E47E35A5AAF87AC358BA49EEFCD2C89B0056C71927FAD565FB42CC8EFADC05036593E5E47A75A4BF2F34CAD0EBF15AA85C14050E4FAF268BC4AE6A8FED13E9FE18D2B4CBD4BBB6497CD4CE373E47231535EE81A5DFDE35D5CC2CF23000E4FA567DA0D9748F2788D2E00CFEEF31F3C557D46D2CEE6EE4924D7C459FF9661D38E28BA0F7DEF23593C35A227FCB846DFEF0CD684D6D6335A25BCD6D13C11E36A32F031C0AE25B47D11BFD66BAEDF4715A7A87F61DE58C305C6A388D486528FC9C0C7F5A2E8391BFB4FEE358DAE836FF00F2E96898FF006055D4BDB282C7721892D941E9F740EF5C41D33C28393A84C7FEDA1FF0ABCB7BE1D8B4B3A7FDA64683057BE704E7AE28E60F649EED9BEBE27D163E16FAD97E8D56AD35DB3BC0E6D6E1250870C50D709E4F8397AACEDF8BD6BE8D71E1F8239869EAE8320BEEDDCFA75A5ED3CC3D843B32F3F8F34A4FE391BFDD0BFE35774FF14DAEA36B2DC40B2848890DB80F4CFAD719E6F83D7A58CE7FEFBFFE2AB5B4BBFD0E3B39C59DB491C40FCE8DFC5C7D68F69E657B087F2B276F893A701F2C1767EA8BFF00C555FD1BC5F16B267F2A191045B7EFE39CE7FC2B941AAF8587FCC1653FF6CD7FF8AABBA66BFA0C3248B6D62F6BB977316500363F1A5ED3CCAF614FF9192DCFC49782E24892C376C72B932E338FC2B560F16CB3F875F54FB3056546611EFF0042475C572EDE20D137161A00662739216B513C43629A0B4C9A6A08C7CBF66E31F7B1E9F8D1ED3CC7EC21FC9F8945FE255F37DCB48D7FE079FE95B3E27F15DF69315B9B609990B03B867A62B9F3E29D3C7DDF0F5B8FC17FF89AD1D5BC516F098447630DCEE1BBE6C1DBFA52E75DCA5463FF003ECA361E3CD6AEB52B681DE1D924AAAD88FB13CD6878ABC57A9E9D770436922A868F7371EF546D3C5FBEEE28CE996F1233805876AB3ABF8B64B4BA1141690CC3602589E879E28E75DCAF66BFE7DA2BF877C4DACDF6B51477171234443165C1C74A4F116ADE211ADCD1D94D78B0A85DA220D8FBA29FA678B6EAEB508E196D618E36CE481CF4A8F55F16EA16DA8CB0DB47018D7182C993D051CCBB8F91F4822EF85AF7C40F7F37F68B5F18BCAF94CCAD8DD91EB593AD45E219B57BA30C57CF0973B0846C63DAACE99E34BA37446A21161DA70638CE43553B8F19EB0F33987CB48CB7C80C792051CD1EE3519FF2A37BC1F0EA56B6F75F6C8A646765DBE60C13C5729278775C96677FB0CDF3313C903FAD6EE93E2F9BECD7075290191798C04C6EE3A703FCE6B18F8B35FF00F9FBFF00C829FE14B9A1DC6955EC8DAF08691A9E9DAA4D35D5B3C48D0950491D772FF8555D67C33AB5FEB575711C4BB247CA92DDAA5D03C45A9DCDEC8B7B73BD04790362AF391E82B2EFBC47AC1BEB8F26F2458BCC6D8001C2E78ED4734076ADE4761A6691796DE14974D73189A48E451C9C65B38EDEF51785740BDD0DEE9AE2481BCE0A17CB627A67D40F5AC7B6F13C83C3B2ACB7521BFC32AE473C9E0E7DBFA53BC31ACDF4B25CFDB2EA49000BB779E9D6B0C4FB29526A5AA2E9AC429269A3A183458AE6EAE65B99B6247272A38E0F239AE67C62966668DB4F03CB89763E3904FAE7F2A86D6FE7BC6BA134AECE242464FF000F6FCBFAD39C060558641EA0D62A71869147D152C354C543DA54A97BADBA267285E8DE6B7BFB36D739D87F3A069F683FE58FEA6B6F6F13956535BBA30779A7C4AF2CAB1AF5638ADC1656A3FE58AD4B1C3144731C6AA7D454BAEADA1A4329A9CCB99AB168C94C67CF7A8C9A4EB5CA91EFB9E874DE07B1FB778A6D89194833337E1D3FF1EC57B25717F0EB48FB269526A122E25BA384CF641FE273F90AECEBE1B3BC42AD89696D1D0F90CCEB7B5AEEDD34168A28AF1CF3828A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A00E07C6431ADAFF00D715FE66B9EAE93C6A0FF6BC27B7D9C7FE84D5CDD7DB65EEF8687A1A2D828A28AEC185145140051451401A7E1EFF0090F5AFD5BFF4135D278BB5BBED0B468EE2C245491E75424A86E36B1EFF004AE73C39FF0021FB5FF817FE826B47E237FC8BB07FD7D2FF00E82F5C4E728E3A0E2EC7AB82A50A949C66AEAE453F8AF595316DBA03743139FDD2F564527B7A9AACDE28D65BADF3FE0AA3FA566DC7FCB0FF00AF787FF45AD455E92C4566B593FBCF22AE1E8AA924A2B7EC68B6BFAB3F5D42E07D1C8A8CEAFA99EBA8DD9FFB6CDFE354A8A5ED66FA93ECA0BA12C97534843CB348EE3F8998935CFF00891EE616B7D4ADA6749A2F90BA9E403FE4FE75B4FF0070D549912E6DDE094651C60D7561E6D599E9D28C674396C6341F10B59862D92791337F7D9307F4E2ABDE78F35CBB5DA934702E083E520C9FC4E7F4AC6BFB096CAE1A371C7F09F51555227760AAA493D00AF4D4DB5B9C1F57A69FC26A68F1C9A86B292CCED2107CC766392715D8C92B03F29233C71597A4D8FF00675A1DF8F3A4E5BDBDAAF47F3CCA3DEB8EA4EF2B9E8D382853D4F46B3F1858D86976D6B1DBCCEF144A84E02A92073DEA197C7B39FF0053631AFF00BEE5BFC2B90A2B99E3AB6C9D8F11E0E936DB47453F8D35697FD5B450FF00B899FE79ACE9F5ED56E0FCF7F38F647DA3F4ACEA2B19622ACB793348D0A71DA285726462EE4B31EA5B934DDABE83F2A5A2B2E67DCD44DABFDD146D5FEE8FCA968A2EC04DABFDD146D5FEE8FCA968A2EC04DABFDD1F951B57FBA3F2A5A28BB189B57FBA3F2A36AFF747E54B451760767E10B1B3B8D22579AD609584EC32F18638DAB5D0FF006569C3A585AFFDF95FF0AC6F057FC81A6FFAF86FFD056BA4AF8DC7D6A8B1124A4F7336CA7FD95A77FD03ED7FEFCAFF00852FF65E9C3A585AF3FF004C57FC2ADD15C9EDEAFF00330BB29FF6569DFF0040FB5FFBF2BFE147F6569DFF0040FB5FFBF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF7E57FC28FECAD3BFE7C2D7FEFCAFF00855CA28F6F57F9985D94FF00B2B4EFFA07DAFF00DF95FF000A3FB2B4EFFA07DAFF00DF95FF000AB9451EDEAFF330BB29FF006569DFF40FB5FF00BF2BFE147F6569DFF3E16BFF007E57FC2AE5147B7ABFCCC2ECA7FD95A70FF970B5FF00BF2BFE147F6569DFF40FB5FF00BF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF007E57FC28FECAD3BFE81F6BFF007E57FC2AE5147B7ABFCCC2ECA7FD95A77FD03ED7FEFCAFF851FD95A77FD03ED7FEFCAFF855CA28F6F57F9985D953FB2F4E1FF2E16BFF007E57FC293FB2B4EFF9F0B5FF00BF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF007E57FC297FB2F4E1FF002E16BFF7E57FC2ADD147B7ABFCCC2ECC8D4FC3D617FA6DC5B25ADBC523A7C9224614AB76E40AF18BDB49ACAEA4B79D0A4B1B6D6535EFD5C978DB40B5BED3E4D44B7957102F2C07DF1E87FC6BDBC9B32953A9ECAA3BA97E67AB96E3BD84B927B33C8CD255F1A55E491B4B15BC92440E37A21233E94C3A5DE2C7E63DB4AA83F88A902BEBF9A37E5B9F47EDE9B574CA7456B5A787355BE884B6D652CB19380EA38FCE8BDF0F5FE9823FB6C3E4F999D9B8F5C75E9F5A4AAC1CF91357EDD4878AA4B792FBCC9ADCF0C787E5D7B544870CB6E9F34D20ECBE9F535B9A4FC3BBABC8A2B8BAB98E186450E02F2C54F35E8DA6E9969A4DA2DAD9C4238D7A9EEC7D49AF1731CE6952838517797E479D8CCCE118F2D2776588A28E08638624091C6A155474007415251457C5B6DBBB3E6DB6DDD8514514841451450014514500145145547E24074D451457E98761CCD14515F989C6145145001451450071FE384FF8F1902FF7D49FFBE71FD6B90AEFFC61019742DE3FE58CAAE7FF0041FF00D9AB80AFAFCA27CD864BB1A4760A28A2BD3185145140051451401ABE1BFF0090FDB7FC0BFF00416AD8F1C59CFA96990595AA6F9CCDE684DC0655460F5FF785657860675D88FA2B1FD2B47C64712D9FFBADFD2BCEA97FAE46DD11E9E1AA7B2A0E7E673B78116E9A389F7C7105895FFBC1405CFE95051457A09591E6CA5CD27261451453101191549FE5622AED56B94FE31F8D6F4656763AB0B52CF95952648E74D92A2BAF6C8A862B5B6B76DD0C2AADEBDEA634C26BAD37B1DAD2DC52D9AB364B9767F4AA80166C0AD5863F2A20BDFBD655A4946C61889DA36EE3E8A28AE23CF0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803BBF057FC81A6FF00AF86FF00D056BA4AE6FC15FF002069BFEBE1BFF415AE92BE2B30FF00799FA99BDC28A28AE210514514005145140051451400514514005145140051451400514514005145140051451400550D6AC9F51D1AEED2360249632109E9BBA8FD6AFD15A53A92A73538EEB519CEF8334ABDD2343686FD552E2599A428AC0ED18000C8E3F873F8D5AF1469F71AA787EE6DAD4037070D18638DC410715B145744B1B56588FAC3DEF71F33BDCC6F0BE9D71A5F87ADAD6EB02E06E670A73B49627154FC5DE1BB8F10C7662DAE2385E1760DBC1C156C67A771815D2D14471B563887894FDEBBFC42EEF72386248208E18C6123508BF40315251457236E4EEC90A28A290051451400514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451401475883ED3A3DE45B771313103DC723F515E5D5EBC402307A1AF26B984DBDD4D09EB1BB27E4715F4791D4F7650F995122A28A2BDF2C28A28A0028A28A00D0D12E92CF57B79A462B1E4AB1F623156FC4F7D1DDEA2890C8AF1C498CAF4C9EBFD2B128AC9D18BA8AA75355564A9BA7D028A28AD4C828A28A0029080460F4A5A284DA609B4CA535B30394195A8042EC7014D6A515BAAED2D51D2B1324B52BDBDB795F3372DFCAAC51456529393BB309CDC9DD8514515248514514005145140051451400514514005145140051451401DDF82BFE40D37FD7C37FE82B5D25627852DFECFA0C4C461A66690FF21FA015B75F118E9296226D77336145145720828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A003BD79BF89ADBECFAF5C606164C483F1EBFAE6BD22B8EF1BDA9DD6B7601C106263FAAFFECD5EAE4F5393116EE5477391A28A2BEB4B0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AB5A6DA9BDD4ADEDF04879006C0FE1EFFA54CE4A31727D00F4CD3E2FB3E9D6B0F748954FE55668A2BE0A72E69393320A28A2A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A000F4ACBF10DB0BAD06E94E3289E6293DB6F3FCB23F1AD4A6BA2C91B230CAB02A47B56B467ECEA29AE83479151525C42D6D732C0FF7A37287F0351D7DE45DD268B0A28A298C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BB4F06E9A2381F50917E693E48B3D97B9FCFF0095725676CF7B790DB270D2385CFA7BD7AA410A5B5BC70463091A8551EC2BC5CE713C94D528EEFF002264C928A28AF972028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A00F3EF16DA7D9F5A6940F96740E3EBD0FF2FD6B06BB8F1A5A9974F82E5413E4BE1B1D8377FCC0FCEB87AFB3CB6AFB4C345F6D0D16C145145778C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00D9F0AA86F10DBE47DD0C7FF001D35E8D5E79E125CEBF11FEEA31FD2BD0EBE573A7FED0BD0890514515E392145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145547E24074D451457E98761CCD14515F989C614514500145145001451450057BDB55BDB19AD9F18950AE48CE0F63F81AF2A7468DD91D4AB29C107B1AF5DAF3DF15D87D93576954623B81BC7FBDFC5FE3F8D7BB9257B4DD27D752A261514515F4A585145140051451400514514005145749E1DF0E1BD22EEF108B61F710F1E67FF5AB1AF88850839CD88E6E8AF555D36C1142AD95B803FE990A5FECFB2FF9F3B7FF00BF4B5E47F6E43F945CC794D15EAADA6D83A956B2B720FF00D325AE67C43E1BB7B7B26BBB08D90C673220248DBEA2B6A19BD2AB3506AD70E6390A28A2BD72828A28A0028A28A0028A28A0028A28A0028A28A0028A28A00E8FC16B9D6A43FDD818FF00E3CB5DE5719E0AB597CFB8BC2B88B679609EE720FF004AECEBE4736929625DBA19CB70A28A2BCB1051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400562F89EC05EE8D2381FBC83F78A7D875FD3F956D521008C1E735AD0AAE954535D06790D15AFE21D20E977E7CB07ECD2FCD19F4F55FC2B22BEE68D58D5829C76658514515A0C28A28A0028A28A00D1D0ACBFB435AB7848CC6A7CC93FDD5FF001381F8D7A6E3030060572BE09B1D9673DFB8F9A76D887FD95EBFF8F67F2AEAEBE4F37AFED2BF22DA3A7CC890514515E492148402082320F506968A6079E7897471A65E092107ECD372BFECB775AC3AF53D4F4F8B53B17B594E3772AD8FBADD8D797CB13C133C320C3A31561E8457D6E578BF6F4B965F122D319451457A8505145140051451400514514005145140054F696935F5CA5BC0859D8FE5EE69904325CCC90C285E473B540EE6BD2346D1E1D22D762E1A76FF005927A9F41ED5C18FC6C70D0EF27B09BB172CED63B2B38ADA2FB91AEDFAFBD4F4515F1D29393E666614514548051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514014F53B08F52B092DA4E370CA363EEB7635E6777693D8DCBDBDC214917B7AFB8AF58ACED5B48B7D5ADBCB946D917FD5C8072A7FC2BD5CBB307877C92F85FE052763CC68ADFB9F086A704264430CD8FE18D8EEFD40AC49609A06DB345246DE8EA457D3D2C452ABF04AE55C8E8A28AD861525BDBCB77731DB423324AC157FC7F0EB51D76BE11D18C11FF694EB879171083D97FBDF8FF2FAD72E33131C3D2737BF4F513763A3B4B58ECECE1B68862389028A9E8A2BE2652729733330A28A2A4028A28A002B82F18588B6D516E50612E1727FDE1C1FE9FAD77B599AF69DFDA7A549128CCABF3C7FEF0EDF8F4AEFCBB11EC2BA93D9E8C68F33A29482AC55810C3820D257D9EE6814514500145145001451450014515D4F877C3667297B7C9FB9FBD1C47F8FDCFB7F3AC31189861E1CF316C5FF000A68BF66845FCEBFBE907EEC1FE15F5FA9AE9E8A2BE2F1388957A8E722370A28A2B0105145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514005145140054734315C44D14D1AC88DD558645494552935AA6073773E0CB195CB4134B0E7F87EF28FEBFAD674DE08B81FEA6F237FF007D0AFF008D76B457753CCF130FB43BB38FD37C1CF15DAC9A84913C4A72238C93B8FBE474AEC3DA8EF456188C554C43BD460DDC28A28AE610514514005145140051451401CAF8A34012A49A85AAE255199507F10FEF0F7FF3F5E2ABD7AB8ED7BC2CCA5EEF4E4CA9E5E00391EEBFE15F4395E6292F6355FA32D3392A295D1918ABA9561D41183495F429A6AE8A0A28A2800A2B46C342D43524DF04388FA798E768FF00EBD765A4786ED74E45925559EE7AEF61C2FF00BA3FAD7062731A3416F77D84DD8C7F0F7865A475BCBF8F118E6385BF8BDDBDBDABB4A28AF96C562A7889F34C86EE145145728828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00A77FA5DA6A5185BA84311F75870C3F1AC73E0AD3C9389EE40F4DCBFE15D2515D34B175A92B424D21DCE6BFE10AB0FF009F8B9FCD7FC2AD5A78574CB470E6379D874F34E47E5D2B6E8AA963B112567261710000000600EC2968A2B944145145200A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0FFD9, N'+7(900)605-00-00 доб. 01', N'Office@Rythm.ru', N'bkhdsbfjbds', N'https://Shops.Rythm.ru')
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (14, N'ОАО "Лошадь-ритм"', NULL, NULL, NULL, N'bvdjvbdsjhsf', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (15, N'ООО "Ритм-маркет"', NULL, N'+7(900)645-00-00 ', NULL, N'bsdbjhfb', N'https://Shps.OOO.Rythm-market.ru')
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (16, N'ООО "Орёл-музыка"', NULL, NULL, NULL, N'jbvjhdbsf', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (17, N'ООО "Цветы-музыка"', NULL, N'+7(900)050-00-00', N'Main@FlowersMusic.ru', N'dsbsfkjbdskb', N'https://Shops.FlowersMusic.ru')
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (18, N'ООО "Музыка звёздного неба"', NULL, NULL, N'Main@StarrySkyMusic.ru', N'vbkjdsbvkbds', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (19, N'ООО "Дуб-музыка"', NULL, NULL, NULL, N'огаороам', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (20, N'ООО "Лилейник-музыка"', NULL, NULL, NULL, N'bdvkbdbssvk', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (21, N'ООО "Юкка-музыка"', NULL, NULL, NULL, N'khhvbsdk', N'https://Ukka-Music.ru/')
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip], [OrganizationTelephone], [OrganizationEmail], [OrgamizationAddress], [OrganizationSite]) VALUES (27, N'ОАО "Нотный стан"', NULL, N'fafererte', N'fsgddrt', N'ыпрофыпоф', N'http://Shops.NoteStan.ru/web/shops/music')
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[Pounkt] ON 

INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (1, N'млврлорл', 13, N'Ритм', N'10:00-20:00', 1, N'+7(900)605-00-00 доб. 07', N'a1@Rythm.ru', N'a1')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (2, N'плдклдукпдк', 13, N'Ритм', N'7:30-22:00', 1, N'+7(900)605-00-00 доб. 08', N'a2@Rythm.ru', N'a2')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (3, N'олпоклоп', 13, N'Ритм', N'9:00-21:30', 2, N'+7(900)605-00-00 доб. 09', N'a3@Rythm.ru', N'a3')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (4, N'hsughskgh', 1, N'Лошадь', N'7:00-23:00', 3, N'+7(900)602-00-00 доб. 01', N'abc@HorsMusic.ru', NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (5, N'плоылоп', 1, N'Лошадь-экспресс', N'7:00-23:00', 1, N'+7(900)602-00-00 доб. 02', NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (6, N'мрамыломло', 5, N'Гитарные струны', N'10:00-23:00', 3, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (7, N'ашгрму', 14, N'Музыка всадника', N'8:30-22:30', 2, NULL, NULL, N'/123')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (8, N'ыпышпекпо', 14, N'Лошадь-ритм', N'8:30-22:30', 4, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (9, N'аплорплокел', 13, N'Лошадь-ритм', N'8:30-22:30', 4, N'+7(900)605-00-00 доб. 06', N'a4@Rythm.ru', N'a4')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (10, N'влрлвли', 13, N'Москва-ритм', N'8:30-21:30', 2, N'+7(900)605-00-00 доб. 02', N'a8@Rythm.ru', N'a8')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (11, N'варподаы', 13, N'Новгород-Ритм', N'10:00-18:00', 6, N'+7(900)605-00-00 доб. 03', N'a5@Rythm.ru', N'a5')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (12, N'влрлвли', 13, N'Новгород-ритм', N'9:00-21:00', 6, N'+7(900)605-00-00 доб. 04', N'a6@Rythm.ru', N'a6')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (13, N'аплорплокел', 13, N'Новгород2-ритм', N'10:00-22:00', 7, N'+7(900)605-00-00 доб. 05', N'a7@Rythm.ru', N'a7')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (14, N'авоитолвачт', 21, N'Юкка-музыка', N'7:00-21:00', 5, NULL, NULL, N'/VyborgShop1')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (15, N'gjdgohr', 15, N'Ритм-маркет', N'7:00-21:00', 1, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (16, N'zsdgzdgr', 15, N'Ритм-маркет', N'7:00-21:00', 2, NULL, NULL, N'/123')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (17, N'выпявапва', 15, N'Ритм-маркет-экспресс', N'7:00-21:00', 3, NULL, NULL, N'/Express/1')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (18, N'иетрщео', 15, N'Ритм-маркет', N'7:00-21:00', 4, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (19, N'орвкелдордлео', 15, N'Ритм-маркет', N'7:00-21:00', 5, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (20, N'щротовещрощ', 15, N'Ритм-маркет', N'7:00-21:00', 6, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (21, N'арлоуырплор', 15, N'Ритм-маркет', N'7:00-21:00', 7, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (22, N'риоатотвр', 15, N'Ритм-маркет', N'7:00-21:00', 3, N'+7(900)609-00-00', N'a@RythmMarket.ru', N'/3/1')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (23, N'huidfhigh', 13, N'Ритм-Тверь', N'8:00-20:00', 8, N'+7(900)605-00-00 доб. 10', N'a10@Rythm.ru', N'a10')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (24, N'djgog', 1, N'Лошидь-тверь', N'8:00-22:00', 8, NULL, NULL, NULL)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (25, N'рвяшггршаар', 13, N'Ритм-Петербург', N'8:00-23:00', 9, N'+7(900)605-00-00 доб. 11', N'a11@Rythm.ru', N'a11')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (26, N'khvkjdhkhgh', 13, N'dhgkjd', N'7:00-23:00', 9, N'+7(900)605-00-00 доб. 12', N'a12@Rythm.ru', N'a12')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (27, N'hbghdbsrg', 13, N'Ритм-экспресс', N'7:00-23:00', 9, N'+7(900)605-00-00 доб. 13', N'a13@Rythm.ru', N'a13')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (28, N'hbghdbsrg', 13, N'Ритм', N'7:00-23:00', 9, N'+7(900)605-00-00 доб. 15', N'a15@Rythm.ru', N'a15')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (29, N'щпоппаар', 13, N'Ритм', N'7:00-23:00', 9, N'+7(900)605-00-00 доб. 14', N'a14@Rythm.ru', N'a14')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (30, N'hvdsfhvihsf', 13, N'Торжокский ритм', N'8:00-16:00', 15, N'+7(900)605-00-00 доб. 16', N'a16@Rythm.ru', N'a16')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (32, N'мфсымвымваы', 27, N'Торжковский нотный стан', N'8:00-16:00', 14, N'fafaf', N'fadfafer', N'fasfafassf')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (34, N'сфвыпрфвп', 2, N'Торжковский музыкальный магазин', N'8:00-17:00', 14, N'ысгпыфвсп', N'bcihads@bvhkdfv', N'new/shop')
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID], [PounktTelephone], [PounktEmail], [SitePath]) VALUES (35, N'dsgagerg', 2, N'Музыкальный магазин во Мшинской', N'Пн: Выходной; Вт-Чт: 9:00-17:00; Пт: 8:00-18:00; Сб-Вс: 8:00-20:00', 18, N'+7(123)124-00-00', N'1234@123.ru', N'dfghdf')
SET IDENTITY_INSERT [dbo].[Pounkt] OFF
GO
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (1, N'Ритм-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (2, N'Ритм-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (3, N'Лошадь-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (11, N'Новгород-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (13, N'Новгород2-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (14, N'Юкка-экспресс')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (15, N'Ритм-доставка')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (16, N'Ритм-экспресс-доставка')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (17, N'Ритм-экспресс')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (23, N'Ритм-тверь-заказы')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (24, N'Лошадь-Тверь-заказы')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (25, N'Ритм-Петербург')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (27, N'Ритм-экспресс')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (28, N'Ритм')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (29, N'Ритм-экспресс')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (30, N'Пункт выдачи торжокского ритма')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (32, N'Пункт выдачи нотного стана в торжке')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (34, N'Экспресс музыкального магазина в Торжке')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (35, N'Доставка во Мшинской')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (1, N'1234      ', N'Гитара 123', CAST(8000.00 AS Decimal(18, 2)), 18, 2, 5, N'Гитара аккустическая, 6 металлических струн', 2, NULL, NULL, N'6;20;Метал;EADGBE;Нет')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (2, N'abcd      ', N'Гитара аккустическая 123', CAST(5000.00 AS Decimal(18, 2)), 50, 2, 27, N'Гитара аккустическая со встроенным звукоснимателем, 6 струн', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (3, N'ab12      ', N'Гитара аккустическая 123', CAST(4000.00 AS Decimal(18, 2)), 4, 3, 27, N'Гитара аккустическая с местом под звукосниматель, 6 струн', 3, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (4, N'12345678  ', N'Гитара классическая 123', CAST(6000.00 AS Decimal(18, 2)), 10, 2, 28, N'Гитара классическая, 7 струн', 3, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (6, N'abcdefg   ', N'Гитара классическая abc', CAST(4800.00 AS Decimal(18, 2)), 20, 3, 28, N'Гитара классическая, 6 струн', 4, NULL, NULL, N'6;20;Нейлон;EADGBE;Нет')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (7, N'a1b2c3d4e5', N'Укулеле 123', CAST(3200.00 AS Decimal(18, 2)), 32, 4, 6, N'Укулеле со звукоснимателем, 4 нейлоновых струны', 5, NULL, NULL, N'4;20;Нейлон;GCEA;Звукосниматель;Тенор')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (8, N'vkdfdsfvk ', N'Укулеле 123', CAST(3500.00 AS Decimal(18, 2)), 2, 2, 6, N'Укулеле, 4 нейлоновых струны', 5, NULL, NULL, N'4;20;Нейлон;GCEA;Нет;Сопрано')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (9, N'gcjhgjhfg ', N'Укулеле abc', CAST(4230.45 AS Decimal(18, 2)), 0, 3, 6, N'Укулеле, 4 нейлоновых струны', 1, NULL, NULL, N'4;12;Нейлон;GCEA;Звукосниматель;Баритон')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (10, N'jkdskhgk  ', N'Укулеле abc', CAST(9800.00 AS Decimal(18, 2)), 1, 1, 6, N'Укулеле, 4 нейлоновых струны', 1, NULL, NULL, N'4;12;Нейлон;GCEA;Звукосниматель;Бас')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (11, N'dfkgbdfk  ', N'Электрогитара', CAST(9800.00 AS Decimal(18, 2)), 1, 1, 7, N'Электрогитара, 6 струн, 4 ручки регулировки звука, звукосниматель встроенный', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (12, N'vkjdskvds ', N'Бас-гитара', CAST(9500.00 AS Decimal(18, 2)), 2, 1, 8, N'Бас-гитара, 5 струны, 4 ручки регулировки звука, звукосниматель встроенный', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (13, N'врмловрм  ', N'Укулеле-концерт', CAST(9000.00 AS Decimal(18, 2)), 0, 2, 6, NULL, 3, NULL, NULL, N'4;20;Нейлон;GCEA;Место под звукосниматель;Концерт')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (16, N'вамрывлр  ', N'Укулеле-концерт', CAST(8500.00 AS Decimal(18, 2)), 20, 2, 6, N'Укулеле конецетная, 4 металлические струны, Наличие встроенного звукоснимателя', 1, NULL, NULL, N'4;25;Нейлон;GCEA;Звукосниматель;Концерт')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (20, N'вааапу1   ', N'Кападастр гитарный', CAST(141.00 AS Decimal(18, 2)), 24, 2, 36, N'Кападастр гитарный универсальный', 4, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (21, N'dfsbsdfbs ', N'Кападастр для укулеле', CAST(75.00 AS Decimal(18, 2)), 3, 4, 36, N'Кападастр укулельный универсальный', 4, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (22, N'vsdbsbgs  ', N'Кападастр для гитары и концертной укулеле', CAST(501.78 AS Decimal(18, 2)), 9, 1, 36, N'Кападастр раздвижной, подстраиваемый под гитару и под укулеле.
Идеально подходит как для аккустической гитары, так и для классической гитары, и даже для электрогитары и бас-гитары.
Также, подходит для укулеле любого типа.
Подходит, как для металлических, так и для нейлоновых струн.', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (23, N'dfndfn    ', N'Кападастр бас-гитарный', CAST(650.00 AS Decimal(18, 2)), 17, 2, 36, N'Кападастр для бас-гитары. Может быть подстроен под электрогитару. Подходит под струны, как маленькой, так и большой толщины.
Не рекомендуется под нейлоновые струны. Рекомендуется только под металлические струны.', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (24, N'dsbsbsgb  ', N'Фортепиано', CAST(9970.98 AS Decimal(18, 2)), 21, 1, 3, N'Фортепиано стандартное.
Пидаль сустейна в наличии', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (25, N'kcbbdfvbd ', N'Пионино', CAST(9999.99 AS Decimal(18, 2)), 12, 3, 25, N'Пионино домашнее. Стандартного размера.
Красного цвета. 
Съёмная педаль сустейна. 
Встроенный съёмный звукосниматель.', 3, 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080281054603012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A8E79E1B58249EE258E18635DCF248C15547A9278028024A2BC93C43FB41F85F4A9DA0D32DEE756914E0C91E238BF066E4FE0B8F7AC3B5FDA5ECDE602F3C313C51679686F048DF9145FE7401EEF45731E13F1FF873C690B368F7C1A741992D651B254FF80F71EE323DEBA7A0028A28A0028A28A002B8EF1B7C4CF0F78163D97F334F7ECBBA3B2B7C1908EC4F651EE7F006AD7C40F16C7E0AF075E6AE543CE008ADA33D1E56FBBF80E49F606BE30BFBFBBD57509EFEFAE1EE2EA772F2CAE72589A00F62D43F692D7A4989D3B44D3608B3C0B82F2B63EAA57F955ED13F693B913AA6BDA142D113F34962E5597FE02E4E7FEFA15E0D45007DD1E1CF13E8FE2CD2D750D1AF12E61E8E070D1B7F7597A835AF5F13F80FC677BE07F1341A9DBB3B5B1212EEDC1E268FB8FA8EA0F63F8D7D08BFB417821BA9D497EB6C3FA35007AA515E5DFF000BFF00C0FF00F3D750FF00C05FFEBD4D6FF1E3C073C811EFEEA007F8A4B57C7FE3A0D007A5D159BA3788747F10DB7DA348D4AD6F631D4C32062BF51D47E35A5400514514005145140051451400514514005145140051451400515E71A97C71F04E97A8DC58C975752C96F218DDA1B72CBB81C1C1E33CF7AA47F682F040E9FDA47E96C3FF008AA00F54A2BCA7FE1A13C15FDCD53FF0197FF8AAC8F12FED11A3268B2AF872DAEA5D49FE58DAEA20B1C7FED1E4E48EC2803D8751D5B4ED1EDFED1A9DFDAD9C3FDFB8956307F126B92B9F8C7E00B497CB93C470B37AC504B20FCD548AF92357D6B53D7AFDEFB55BD9AF2E5FAC92B671EC3B01EC38AA1401F70E85E36F0CF895B668FAD5A5D4B8CF941F6C98FF0071B0DFA56F57C051C8F0CAB2C4EC92210CACA70548EE0D7BB7C3DF8F62C34F7B0F1835CDCB443F71791A07761FDD719193E8DDFBFA900FA1E8AF2E8BE3FF0081A4902B4D7F1027EF3DA9C0FC8935DC685E2DD03C4D1799A36AD6B79C64A23E1D7EA870C3F11401B3451450014515E2DF1D7E235C6856D1F867479DA2BEBA8F7DD4C870D144780A0F666C1FA0FAD0074FE2DF8CBE14F0A5C4966679351BE4E1A0B301821F4672768FA0C91E95C37FC34C43E763FE11493CACFDEFB78DDF9797FD6BE7BA2803EBEF08FC64F0A78B2E23B359E4D3EFDF8582F005DE7D1581DA7E9C13E95E835F0057D31F02BE22DC6BF692786F579CCB7F691EFB699CFCD2C4300A93DD9723EA0FB13401ECF4514500145155AEF50B2B05DD79796F6EBEB34AA83F53401668AC17F1C784A36DAFE28D154FA1D4221FFB3503C6FE136FBBE28D14FD3508BFF8AA00DEA2B0FF00E134F0A9E9E26D1BFF0003E2FF00E2A9E3C5FE193D3C45A49FA5EC7FFC55006CD15CFDC78EBC2568B99FC4DA42FB7DB6327F207359727C5AF01C470DE25B43FEEABB7F25A00ED2B13C53E2CD1FC1DA436A5AC5CF951676C68A373CADFDD55EE7F41DF1583FF0B8BC01FF00431C3FF7E65FFE26BE67F891E349FC6FE2EB9BF2EDF61898C56511CE16207838EC5BA9FAE3B0A00EDBC41FB44788AF6774D0ED2DB4DB607E56917CE94FB927E51F4C7E26B0ED7E3AF8FADE60F2EA905D283FEAE6B48C29FF00BE154FEB5E6F45007D45E02F8EBA5F892E62D375C8134CD4242163903660958F6C9E50FA0391EFDABD76BE00AFA0BC03F1E74CD3BC336BA6F89C5F3DEDB7EED6E628C389231F74B1DD9DC3A1E3B03D49A00F7DA2BCFECFE35F802EF03FB73C863FC335B4ABFAEDC7EB5D15878DBC2DAA102CBC43A64CC7A22DD26EFF00BE49CD006F51480865041041190477A5A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028AF2DF1A7C72F0FF00862E24B1D3E36D5EFE3255C42E1628D8762FCE4FB007EA2BCDA5FDA43C5266CC5A4E8E9167EEBA4ACDF9EF1FCA803E9BA2BC43C2FF00B45E9D7B711DB788F4D6B0DC71F6AB7632463FDE5FBC07D3757B4DA5DDBDFDA4577693C73DBCCA1E396360CAE0F4208EB401351451400514514005145140051451400514578BFC46F8EB068377368FE1A8A2BCBE88EC9AEE4E6289BBAA81F7987AF41EF401ED1457C59A87C4DF1B6A5334B3789B528C939C5B4C6051F826055ED13E3078DF449D5C6B52DEC40FCD0DF7EF95BF13F30FC08A00FB168AF3FF0087DF16347F1C5AB4526DD3F5485774B6D2C830C3BB231EA3DBA8FD6BA8BDF15F8774D42F7BAEE9B001FF003D2E901FCB39A00D8A2BCD753F8EDE05D3D9962BEB9BE65EA2D6DD88FCDB683F81AE62EFF695D2518FD8FC3D7B32F6334E91FF0020D401EE3457CFEDFB4CFF0077C25F9EA3FF00DAAA093F697BA23F75E17857FDEBD2DFFB20A00FA1E8AF99AEBF690F12C808B5D274A873DDC48E47FE3C2B1DFE38FC43BD908B6BC8633FDD82C91B1FF7D03401F58D15F28A7C56F8ADD45CDD38FF00B05C7FD23A90FC5EF8A29F79A41F5D3547FECB401F55515F283FC65F8963ADD15FFB87A7FF001355DBE37FC4388FEF3538C7B359443FF65A00FADE8AF94ADFF680F1C424798FA7CFED25B63FF4122B6AD3F693D7531F6CD0B4E9BD7C9778FF00996A00FA4E8AF09B5FDA5AC5B1F6CF0D5C45EBE4DD2C9FCD56B66DBF68BF084B813596AF01EF985187E8F9FD2803D768AF37B7F8EBE019B1BF549E0FFAE96921FF00D041ABDA67C61F02EA924891EBB15B946DA3ED48D0861EA0B0C63F5A00EEA8ACFB0D7747D531FD9FAAD8DDE7A7D9EE124FE46B42800A28A827BCB5B6FF008F8B9862FF00AE8E17F9D004F4566BF887458C65F58D3D7FDEB941FD6A9CBE36F09C1FEB7C4FA321F437F167FF0042A00DEAF95FE34FC46B8F126BD3E83A7CECBA358C9B1821E2E2553CB1F550781F4CF718F68F157C55F0BE9DE1AD4A6D3B5FB0B9D416DDFECD1C33072D21185E9EF835F209258924924F249A004A28A2802CE9FA85DE95A8417F617125BDD40E1E3963382A6BEB1F067C5BF0FEB5E11B6BFD6B56B0D3F505CC5730CD32A12E31965527254E41FCC76AF916BAAF00F81EEBC7DAECDA5DADE436AD15B9B86795491B432AE001DF2C2803E96BEF8D3E02B1C83AE09DC7F0DBC123E7F1DB8FD6B9ABEFDA3BC330E459697AA5CB0EEEA91A9FC7713FA56769FF00B3558210753F11DCCDEAB6D6EB1FEAC5BF9574D69F00FC0B6D8F36DAF6EF1FF3DAE9867FEF8DB401E7FA9FED27ABCBB8697A0D95B0EC6E65698FE9B6B9C3F14FE27F89A531E9B7176DCE3CAD36C8123F10A5BF5AFA1F4EF867E0AD2995AD7C3761B97A34D1F9C47E2F9AEA228A382358E28D638D4615517007E1401F16F8C2DFC6D0A5A4DE2F6D536DC9736EB7F33364AE376149F971B8761D6B95AF7EFDA64FCFE185F41747FF00455780D001451450015F437C36F845E12F14FC3FD2F59D46DEE8DDDC093CC29705412B23A74FA28AF9E6BEBEF82273F08B441E8671FF0091E4A00A1FF0A07C0DFF003C2FFF00F028FF008554BDFD9DFC1F711116D73A9DAC9FC2CB32B8FC432F3F98AF5BA2803E55F137C27F17FC3CB8FEDAD0EEE6BBB680EEFB5596E49A21FED2039C7A9048F5C576BF0EFE3D4578F1697E3068E0988DB1EA206D473FF4D00E14FF00B438F503AD7BAD78B7C4EF8236FAC2CDACF85A14B7D4B9796CC61639FD4AF656FD0FB75201ED08EB222BA306461956539047AD2D7CA5E01F8ADADFC3FBEFEC5D6A1B8B8D2E2731C96B28C4B6A73CECCFFE8278F4C57D39A1EBBA6F893498753D26E92E6D651C3AF507BA91D411E86803468A28A0028A28A0028A28A0028A28A0028A28A00F39D4BE07F82754D46E2FA4B4BA8A5B890C8EB0DC155DC4E4E076E7B5513FB3EF820F41A90FA5C8FF00E26BD528A00F283FB3EF82114B33EA6140C926E471FF008ED7CBFA81B56D46E4D8ABA59995BC857396099F9727D718AFB77C6170D69E09D7AE50E1E2D3AE1D4FA111B115F0D500145145001477E99A29402CC15412C4E001DE803E98B3F80DE0CD6B42B3BFB59F54B63776F1CE8567560372861C15E7AD721AC7ECEFE22D3AE3CFD0356B6BC55394DE4C128FA751F8E457D05E1CB17D2FC2FA469F28C496B650C0DF5540A7F9569D007CB9FF000AF7E33E3C9F3B54F2C71FF2195DBF9799FD2ABDDDA7C5EF87883519AE3545B54E5DC5C0BA840FF6972C00F7207D6BEABA0804608C83401E0BA07ED236DF6454F1168D3FDA1460CB6054ABFBED7231F99AF19F1B788478ABC67AA6B4824115CCD98965C0658C00AA0E0900ED03A1AFAB757F84FE08D6E769EEB40812663967B6668727D484201FCABE48F13D95BE99E2DD66C2D54ADB5ADF4F0C4A4E48459180193D78028032A8A28A002B73C1DE2497C23E2BB0D72288CDF65725A20FB7CC520AB2E7071904F6AC3AD9F08D9DBEA3E33D0AC6F2312DB5CEA16F0CD19246E469141191CF43401ED4DFB4CC58F97C28E4FBDF81FF00B4EB99D67F680F176ACDF67D22DADB4D0FC2F949E74A7DB2DC7E4B5ED91FC21F014472BE1BB73FEF49237F36AE8B4AF0DE87A12E34AD22CAC8E305A081518FD48193F8D007CB9FD99F177C4C3CC913C49346FD04B23C287E818814FB6F819E3FBF7DF716105BB31C97B9BB424FD769635F5A51401F32C1FB37F89D9419F56D2633E88D237FEC82A56FD9B7C418F975BD309F7120FE95F4AD1401F137867C137DE29F16CDE1DB2BAB68EE63F33F7931608761C1E809FD2BD057F66EF12FF16B1A48FA190FFEC954BE0D3E7E364A7FBC2EBFA9AFA96803E74B4FD9AB5176FF004CF11DAC4BFF004C6D9A43FA95ADA8FF0066AD242625F10DEB37AAC08A3F2C9AF71A2803E7CF117ECF9A6E8FE1CD5354835DBB91ECAD25B858DE15C39442D8C83DF15E075F796B165FDA5A25FD87FCFCDB490FFDF4A47F5AF83994AB15604303820F6A004A28A2800AECBE1A782ED7C77E249F48B9BF92C8ADA34F1C8881B2C19460838ECC4FE15C6D769F09B57FEC6F89FA1CECDB639A7FB33E7A11202833F8B03F850077D7FF00B356AB1E7FB3FC43673FA0B881A2FF00D04B5727A9FC0EF1DE9C0B269B15EA0EAD6B70ADFA3618FE55F5CD1401F11097C61E0A9C2EFD6746707852648437E1C035D768DF1F3C6BA66D4BB96D3538C718B9870D8FF7936FEB9AFAB258A39A368E58D648D86195C641FA8AE5355F85FE09D64B1BAF0ED92BB757B7530367D728467F1A00F3CD23F692D2E5DABAC685776C7A17B591651F5C36D23F5AEFF45F8ABE0AD78AA5AEBD6F14CDC79575985B3E9F3E013F426B8DD57F673F0D5D066D3752D42C5CF40E56641F8100FF00E3D5C06B5FB3CF8AEC033E997165AA463A2ABF9521FC1BE5FF00C7A803EA2565750CA432919041E08A47748A3692475444059998E0003A926BE348352F1F7C36BA58FCCD53491BB88A652617FA2B651BEA2A6F18FC57F12F8D74FB7B0BE962B7B58D7F7B15A828B3B7F79F939FA74EF8F400FA075BF8E1E08D1A76856FE6D424538616316F5FFBE890A7F026A969FF00B40F826F6611CC752B104E37DCDB82A3FEF86635F29D1401F7A699AAD86B36297BA65E41776AFF0076585C32FD38EFED56EBE24F0678DB57F046B297DA6CCC62247DA2D598F973AFA11EBE87A8FD2BECAD075BB3F11E8567ABD83EFB6BA8C3A67A8EC54FB82083EE2803468A28A0028A28A0028AE4BC79F10B49F00E98B717D99EEE6C8B7B38D807931D4E7F854773FCEBE6FF00107C69F1A6BB3B98B523A65B93F2C36236607BBFDE27F1FC05007D7B457C4F6BF117C696730962F146ACCC0E712DD3CABF93122BD6BC05FB403CD75169DE2F48D44842AEA30AED0A7FE9A2F4C7BAE31E9DE803DFA8A44759115D1832B0C8607208A5A0028A28A0028A28A0028A28A0028A28A0028AF3EF1C7C5FF0EF82A56B325B50D517EF5A5BB0FDDFFBEDD17E9C9F6AF28BAFDA47C48F31369A36931459E1661248DF9865FE5401F4C515E09E1EFDA422927487C45A37931B1C1B8B272C17EA8DCE3E8DF857B7693ABE9FAEE9B16A1A5DDC5756928CA4B19C83EDEC7D8F22802ED1451400514514005145701F11BE2A699E02856D847F6DD5E55DD1DAAB6020ECCE7B0F6EA7F5A00EFE8AF8E75BF8BFE37D6E7676D6E6B28C9F962B13E4AAFE23E63F8935474FF899E36D36612C1E26D49C839DB7139994FE0F91401F6A515E2DF0E7E3AC3AF5DC3A3F89628AD2FA53B21BB8F88A56ECAC0FDD63EBD0FB57B4D00145145001451450014514500145145001451450014567EB7ADE9DE1DD266D4F55BA4B6B484659DBBFA003A927B015E01E27FDA2F53B8B8921F0D58436B6C0E16E2E977CAC3D76E76AFD0EEA00FA3E8AF9162F8E5F10239B7B6B114AB9FF0056F670EDFD141FD6BD2BC15FB425A6A1711D8F8A6D63B191C855BD833E567FDA5392A3DF247D2803DC28A44759115D183230CAB29C823D452D001451450015E41F1DFC7B3F877468741D36668AFF005142D2CA870D1403838F42C7233E81BDABD6A7B882D63325C4D1C318EAD23051F99AF917E356AB16ADF1435192DEE62B8B68638628A489C3A91E5AB1C11C7DE66A00F3FA28A2800AF63F80FE3C9F49F1027862F6666D3B50622DC31E219BB63D9BA63D707D6BC72A5B6B89AD2EA1B9B791A39E171246EBD5581C823E86803EFAAA17DADE93A667FB4354B2B4C75FB45C247FCCD7C55A878C7C4BAAE7EDFAFEA570A7F81EE5F6FF00DF39C554B1D1357D59BFE25FA5DF5E127FE5DEDDE4CFE40D007D797BF167C09604897C4968F8FF009E01A6FF00D001AC1BAF8FFE06B7CF9535FDCE3FE795A919FF00BE88AF08B0F841E3CD43063F0EDC44A7BDC3A458FC1883FA574B65FB3B78BEE306E6EF4BB55EE1A6676FC9571FAD0077B37ED21E1953FB8D23567FF7D635FE4E6AA37ED2BA48FB9E1EBD3F59D07F4ACBB6FD9A2E180377E28893D445645BF52E3F9569C5FB3569607EF7C4578E7FD8B755FEA680187F696B0FE1F0D5C9FADD28FF00D96ABC9FB4CC63FD578518FF00BD7F8FFDA75AB1FECDDE1C1FEB759D55BFDDF2D7FF0065357E0FD9DFC1917DFB8D5E6FF7EE107FE8282803CFB5FF00DA1F59D574ABAB1B0D260D3DA78CC7E789DA47407825781838EFDABC6ABD13E31786F41F09789ED747D0AD9E3096A259DE4959CB3331C0E4F18001E3FBD5E774005145140057AA7873E03F887C43A5D9EA8BA9E970D95DC4B2A36F777DA467EEEDC67DB35E575F627C1AF33FE152E83E6E777972E33E9E6BE3F4C500725A3FECE3E1FB6556D5B55BEBE90755882C287F0F98FEB5D5DB7C18F005B2803C3E921EED2DC4AC4FE6D8AEF68A00E28FC24F019FF996ED7F067FFE2A84F849E0346C8F0DDAE7DDDCFF0036AED68A00C0B2F0378534F20DAF86F4A8D874716885BF32335B91C51C2812245441D154600A7D14005145140052101810C0107A834B4500665DF87343D401179A369D720F5F3AD51FF98AE76FBE11F80F50CF9BE1CB68C9EF6ECF0E3FEF820576B4500792DEFECF1E0DB9C9B79F54B43D8473AB2FFE3CA4FEB5CFDDFECD16ED9365E27953D166B40FFA861FCABDEA8A00F9A2EFF66EF11267EC9ACE9737A79BE6464FE4AD5E61A3785758F106B72E8DA55A8B8BE883931798A990A707058815F7357CBBF079B3F1C2E48FE2FB5FF33401C75E7C32F1BE9D969BC33A89DBCE608BCDC7FDF19A821F12F8D3C34C225D575AB0C71E5492C88BFF007CB71FA57DB548CAAEA5594107A822803E2E6F14F8F7C52FF664D535BD409E0C36CD2107FE029D7F2ABD69F07FC7FA97EF46813A6EE4B5CCD1C67F10CC0FE95F6122246BB5155547651814EA00F93A3F807E3A71F35AD927FBD74BFD335623FD9EBC6AE7E67D2E3FF7AE5BFA29AFAA68A00F907C63F08B5BF03F87C6AFAADFE9D246D32C2B1DB3BB316209FE2503A29AF3EAFA6BF69063FF00083E98B9E0EA4A7FF21C9FE35F32D001451450015EEFFB35E945B51D735838C47125AAFBEE3B8FFE80BF9D78457D31FB37228F066AAE07CEDA8104FB08D31FCCD007B3D145140051451401F3D7ED307FD2FC36BE91DC1FD63AF05AF76FDA5CFF00C4CFC3CBE90CC7FF001E4AF09A0028A28A002BEBAF81A73F097491E8F38FFC8AF5F22D7D6DF024E7E1469E3D269C7FE446A00F49A28A2800A28A280380F88DF0AF4BF1DDB1B952B67ACC6B88AED5787C74590771EFD47E95F3A69FAA78B7E1178AE484ABDB4E87F7D6D2E4C3729D8FA30F461C8FCC57D955E55FB40DB5BC9F0DCDC49044D3C575188E465059324E707A8CD006DF813E2A683E3885218E4165AAEDF9ECA66E49EFB0FF0018FA73EA2BBAAF8822F096BE3C330F8A6D2D64934E591834F01CB40C87AB01CA8E873D3DEBD4FE1CFC78B8B36874AF17C8D3DB93B5351C6648FF00EBA01F787B8E7D73401F46515059DEDAEA36715E595C45716D2AEE8E589832B0F50454F40051451400514514005145140051451401CFF8F3FE49E7897FEC1575FF00A29ABE20AFB73C7E76FC3AF129FF00A865C0FF00C86D5F11D001451450015E8BF04FC3769E24F8890ADE1CC3A7C26FBCBC6448C8CA141F6CB03EF8C579D57AEFECE871F116F07AE9920FFC8915007D4545145001451450015F0E78CCEEF1CF881BD752B93FF915ABEE3AF863C587778CB5C6F5D4273FF911A8031E8A28A002B7BC1076F8FBC38DE9AA5B1FFC8AB5835B5E0F3B7C6DA0B7A6A36E7FF222D007DCB451450014514500145145007CA5F05DF3F19E33FDE173FF00A0B1AFAB6BE4BF828F9F8C7627FBC2E3FF0045B9AFAD2800A28A2800AF893E20E97FD8DF1075EB10BB512F24741E88C77AFE8C2BEDBAF97BF687D14D8F8E6DB54503CBD46D464FFB71FCA7FF001DD9401E43451450014F86592DE78E689CA491B07461D410720D328A00FBA7C2FACAF887C2DA5EAEB8CDDDB24AC076623E61F81C8FC2B5ABCE7E064ED37C27D315893E5493A0CFFD7463FD6BD1A800A28A2800A28A28038CF8B1A8AE99F0BF5D9D9518B402150CA0F2EC13383DC6ECFE15F19D7D4FFB435CB41F0DA28C1E27D4228CFD02BB7FECB5F2C5001451450015EBDF0A3E2FD9F827489B46D5ED2EA7B569CCB14B06D631E40046D2471919EBDCD790D7B17C22F85DA378EBC31AA5E6AA6E63923B910412DBC9B4A61433704107EF2F6A00F6CD1FE2A78275B55FB37882D2290FFCB3BA6F2181F4F9F00FE19AEB20B882EA212DBCD1CD19E8F1B0607F115F3CEAFF00B366A11966D1B5FB69C7511DDC4D191EDB97767F215C85C7C25F88DE1F98CD69A75C123A4DA7DCA927F00437E9401F5D53259638219269582471A96663D001C935F20B5C7C5AB2FDDBC9E318C0E006FB4E3F0AA57B7BF1264B39DAFAE3C566D446C66F39EE3CB098E77678C63AE68033BC6BE28B9F1878AEF758B863B6572B021FF96710FB8BF975F724F7AE7E8A2800A28A2803E9EFD9FBC5B2EB3E17B8D0EEE42F3E945442C7A985B3B47FC04823E85457B0D7C35E1AF166B7E10BE92F343BD36B3CA9E5C87CB470CB907043023A8AEEECFF00683F1B5B63CE1A6DD7AF9D6C467FEF865A00FAAA8AF9CED7F695D4D00FB5F872D253DFCAB868FF00986AD14FDA62023E7F0AC8A7FD9BF07FF698A00F7BA2BC1FFE1A5ECFFE8589FF00F0307FF1149FF0D316BDBC2D37FE068FFE22803DE68AF071FB4BDA77F0BCE3E9783FF88A78FDA5B4FEFE1ABA1F4BA5FF00E26803DD6BCFBE2FF8E24F0578409B27DBAA5FB182D5BBC7C7CD27E0318F7615C78FDA574AFE2F0EDE8FA4EA7FA57977C53F88517C41D5EC6E6DAD26B5B7B5B73188E5604EF2C493C7B6DFCA8038492479A5796576791D8B33B1C9627A927B9A6D1450015E87F08BC793F83BC550DBCF337F645FC8B15CC64FCA84F0B20F423BFA8CFB579E51401F7FD15E0967FB46D859E8B6503E8779737915BA24CED32A2B38501883C9C139ED5CEEB5FB44F89AFB31E916167A6A9E8C419E41F89C2FFE3B401F4ED15F238BDF8BDE251E7452789A58DF9DD089218CFF00DF3B5694FC39F8ABAA8D93D8EA92AB75FB4DF281FF008F3D007D27E25F1CF87BC2F61733DF6A9662E228D992D44CBE6C8C070A1473C9E338EF5F196B3ABDE6BDACDDEABA84BE65D5D486491BB64F61E800C003D05767AE7C1CF13F86FC2B79AFEACD650416BB3742B31791B73AA0C606DEADEB5E7D4005145140057B8F87BF6899F4BF0FD9D86A5A23DFDDDBC7E5B5C8BA09E601D091B0F38C64E793CF7AF0EAF62F813E0CF0F78B86BE35DD356F3ECBF67F27323A6DDDE66EFBA475DA3F2A00DF3FB4CAFF000F8489FAEA38FF00DA54CFF86996EDE121FF00831FFED55E867E0AFC3D6EBE1E5FC2EE71FF00B3D30FC11F87BFF40023FEDF67FF00E2E803CF8FED33276F09A7FE0C3FFB5D03F69993BF84D0FD3503FF00C6EBBF3F03FE1E9FF981B8FF00B7C9FF00F8BA07C0FF0087C3FE606E7EB793FF00F17401C17FC34D1EFE11FF00CA97FF006AA3FE1A68FF00D0A3FF00952FFED55AFF00117E11F83747F006AFA9695A535ADEDAC4248E51732BE30C3230CC472323A572FF00047C07E17F18681A9CDAEE962EAE2DEE82A49F68963C29507185603A83DB3CD00690FDA6877F0891F4D47FFB553C7ED330F7F0A3FF00E078FF00E375DE8F829F0F07FCCBC3F1BC9FFF008BA78F831F0F87FCCBA9FF0081337FF17401C0FF00C34C5BF7F0B4BFF81C3FF88A0FED316FDBC2D29FADF0FF00E22BD03FE14DFC3FFF00A1722FFC0897FF008BA46F839F0FF6927C3B171E97130FFD9E803E74F891F12AF7E215F5B335B1B2B0B65FDDDA89778DE7AB938193D871C0FA9AE1A958E58900004F41DA92800A28A2803D4BC17F1C358F08F8763D19EC22D462858F9124D2B2B469FDCEF903B7A74F4AD89BF692F1030FDC689A621FFA68647FE445707F0C742D3FC4DF10B4CD1F5589A5B3B912EF5572A7E589D8723DD457D169F02FC0087E6D2667F66BC97FA30A00F17BCF8FFE39BA07C99AC2CF3DE0B5071FF7D96AE6350F897E35D4F22E7C4BA8807AAC32F920FE09815F4FDB7C22F015A1063F0DDB363FE7AC9249FF00A131ADEB2F09F8734EC7D8B41D32DC8EF15A229FCC0CD007C5096DAC6B736F486FAFE53FC4A8F2B7F5A8F51D2352D1E68E1D4F4FBAB29644F3112E6168D99724640600E320FE55F79001400A0003A015F3E7ED2BA630BAD075551F2B2496CE7D082197F9B7E5401E094514500145145007D7DF0BB47F0DDEF80343D52D744D392E64B65596616C9BDA44F91C96C6796526BD00000000600E805790FECEDAA7DAFC0977A7B365ECAF5B03D11C061FF8F6FAF5FA0028A28A0028A28A0028A28A00F907E374AD27C5CD6831C84102AFB0F250FF00326BCFABBCF8CE73F16F5E3FEDC43FF20A57074005145140057DD5E19D24683E17D2F490413696B1C2C47F1305193F89C9AF856BEFC84EE8236F5507F4A007D145140051451400514514005145140051451400514514005145140057CB1F06DBFE2F6B9FEF7DABFAD7D4F5F297C197CFC6984FF7BED3FF00A0B1A00FAB68A28A0028A28A0028A28A00F17FDA44FF00C51DA4AFAEA19FFC86D5F3457D27FB499FF8A5B461EB7AC7FF001C35F365001451450015F4BFECDC7FE28FD597D2FF003FF90D6BE68AFA4FF66C6FF8A5F5A5F4BD53FF008E0A00F6CA28A2800A28A2803E72FDA54FFC4EF415F4B694FF00E3C2BC36BDBFF6943FF151E88BE968E7FF001FAF10A0028A28A002BEB3F80A73F0B2D07A5CCC3FF1EAF932BEAFF80273F0BE11E97730FD45007A8514514005145140057967ED0271F0C587ADEC23FF0042AF53AF28FDA14E3E1AA0F5BF887FE3AF40127C00C3FC2F552011F6C98107F0ACFF001FFC08D3B5D79752F0D345A75FB12CF6EC3104A7DB1F70FD38F61D6AEFECF673F0D187A5FCA3F44AF56A00F8FD7C37F13FC0F3BA5959EB968B93B9AC4BC9137B9D995FCEADA789BE304FF2C727891CFA259BE7F45AFAD68A00F94925F8D53F2078A467FBC9227F302A7487E37F63E22FF8149FE26BEA6A2803E5F11FC7303AEBBFF7D2D2EDF8E7FF0051CFCD6BE9FA2803E6155F8E99E3FB6FF129457D3D450014514500737F1054B7C39F1201FF0040CB83F9464D7C495F796B365FDA7A1EA161C7FA55B490F3FED291FD6BE0E6528C55810C0E083DA80128A28A002BD47E00DEC76BF13E289C806EAD258533DCF0FF00C90D797569F8775897C3FE23D3B578725ECEE125DA3F8803CAFE2323F1A00FBB28A86D2EA1BEB382EEDDC3C13C6B2C6E3A32B0C83F91A9A800A28A2800AF853C4A7778AB576F5BD98FFE3E6BEEBAF8435E3BBC45A9B7ADDCA7FF001F34019F451450015ADE163B7C5DA2B7A5FC07FF00222D64D697874EDF13694DE97909FF00C7C5007DDB45145001451450014514C94ED85DBD149A00F91BE08BFF00C5DED1CFF785C7FE8992BEBCAF8FBE0A1DBF177423EF38FF00C81257D834005145140057CEDFB4B3E755F0F47FDD8266FCD97FC2BE89AF9C3F6943FF00150E863D2D1CFF00E3F401E1F4514500145145007D67F0187FC5ABB3F7B89BFF004335E995E65F011B3F0B2D47A5CCC3FF001EAF4DA0028A28A0028A28A00F1CFDA3CFFC507A68F5D4D0FF00E4292BE63AFA67F6913FF145E94BEBA883FF0090DEBE66A0028A28A002BE9EFD9C0FFC5BFD457D35473FF90A2AF986BE9AFD9BDBFE288D517D35263FF90E3A00F65A28A2800AE6BE211DBF0E3C487FEA1B38FF00C70D74B5CB7C483B7E1AF88CFF00D43E51FF008E9A00F8A68A28A0028A28A00F4CF81DA1695E21F1BDDD8EB1630DE5B7F67C8E239464060F1E08F43827F3AF6ABEF813E03BC24C7A75C5A13DEDEE9FF931615E45FB3C1C7C48987AE9D28FFC7D2BEA6A00F1BB8FD9C3C2EF936FAAEAF17B3BC6E3FF004015424FD9AB4D3FEAFC4776BFEF5BA9FEA2BDCE8A00F07FF8668B4FFA1A26FF00C021FF00C5D56D43F671B5B2D36EAEC7896673042F26DFB1819DA09C7DFF006AFA06B3F5EFF917753FFAF497FF00403401F267C2FF0087B07C42D4AFED67D424B216B0AC819220FBB2718E48AF501FB35699DFC47767E96EBFE3587FB35FFC8C1AE7FD7AC7FF00A1D7D1F401E1E3F66BD1FF008BC417C7E90A0AF39F8AFF000D2D3E1EFF0064B59DF5C5DC77BE68633281B4A6CC631EBBBF4AFADABC67F68FD3CCFE0DD32FD5726DAF7637B2BA1E7F355FCE803E66A28A2800A28A2803E86F843F0E3C17E28F03DAEABA8E966EAFD659229CB5C4817706C8F95580FBA56BD8349F0978774220E97A2585A38E92470287FF00BEB19FD6BC33F66FD7CC3AB6ABE1F91FE4B8885D420F6753B580FA823FEF9AFA32800A28A2803CFBE371C7C22D6C7A9807FE478EBE41AFAEBE391C7C25D587AC900FFC8A95F22D001451450015EFDFB329F9BC50BEA2D4FF00E8EAF01AF7BFD99CFF00A578957D52D8FEB25007D0945145001451450071BF15CE3E16F883FEBDBFF6615C17ECD7FF0022EEB9FF005F69FF00A05777F16CE3E15F883FEBDC7FE86B5C0FECD47FE245AF0FFA798FFF00413401EE54514500151CE76DBCADE884FE952557BE3B74FB96F4898FE86803E08A28A2800A28A2803BDF82C76FC5CD08FF00B530FF00C83257D855F1CFC1C3B7E2CE827FE9A483FF00213D7D8D4005145140057957ED05A77DB3E1A9B90BCD95E452E7D01CA7F3715EAB5CAFC4AD3FFB53E1B7882D82EE6FB1BCAA3D4A7CE3F55A00F8AA8A28A0028A28A00F6DFD9B753F27C4BAC6965B02E6D56603D4C6D8FE521FCABE92AF8E3E106ACBA3FC50D16591F6C53C86D9F3DFCC52ABFF008F15AFB1E800A28A2800A28A2800A28A2803E38F8C2777C58D7CFF00D3541FF90D2B87AED3E2D9DDF153C407FE9E00FF00C716B8BA0028A28A002BEF8B23BAC2D9BD6253FA0AF81EBEF4D28EED22C9BD6043FF008E8A00B7451450014514500145145001451450014514500145145001451450015F257C167CFC64D3CFF7BED3FF00A29CD7D6B5F217C137CFC5FD18FF007BED1FFA224A00FAF68A28A0028A28A0028A28A00F12FDA4FF00E458D17FEBF5BFF4035F36D7D27FB4983FF08B68C7B0BD23FF001C35F365001451450015F467ECD4F9D175F4F4B888FE6ADFE15F39D7D05FB33CA0C5E2587B86B671F8F983FA5007BED145140051451401F35FED247FE2ABD1D7D2C49FFC7CD78A57B3FED227FE2B3D297D34F07FF223D78C5001451450015F55FECFA73F0CB1E97D28FD16BE54AFA9FF0067939F86D28F4D4251FF008EA5007AC514514005145140057927ED1271F0E2DC7AEA510FFC724AF5BAF21FDA34E3E1DD88F5D5231FF90A5A0093F67739F86F38F4D4651FF8E475EB55E45FB399CFC3BBD1E9AA483FF21C55EBB400514514005145140051451400514514005145140057C5BF13B443E1FF0088DAD5905DB135C19E2F4D927CE00FA6EC7E15F6957807ED1FE1A6234CF13429C01F63B92074EAC87FF4319FA5007CFF004514500145145007D63F01F5F3AC7C3986D257DD3E992B5B1CF529F790FD30DB7FE035E9D5F327ECEBAEFD8BC617BA348D88F51B7DC833D648F247FE3A5FF2AFA6E800A28A2800AF833573BB5ABE6F5B890FFE3C6BEF3AF822FCEED4AE9BD6673FA9A00AF4514500157B453B75ED39BD2EA33FF8F0AA356B4C3B756B36F49D0FFE3C2803EF5A28A2800A28A2800A82F0EDB1B86F4898FE953D57BE1BB4FB95F58987E86803E43F83476FC5AD04FF00B728FF00C84F5F6257C75F07067E2CE823FE9A487FF213D7D8B4005145140057CD9FB499FF008AA3455F4B263FF8F9AFA4EBE68FDA44FF00C561A4AFA5867FF22350078BD145140051451401F577C0039F86118F4BC987F2AF51AF2AFD9F0E7E1991E97D28FD16BD56800A28A2800A28A2803C57F6923FF14968EBEB7C4FFE436AF9AABE91FDA4CFFC535A22FADE39FF00C72BE6EA0028A28A002BE96FD9B4FF00C521ABAFA5FE7FF21AD7CD35F497ECD87FE298D697D2F14FFE382803DB68A28A002B93F89C76FC32F111FF00A72715D6571BF15DF67C2DF101F5B6C7E6C05007C654514500145145007AAFECF871F1308F5B1947EAB5F5557CA7FB3F7FC94E5FFAF29BFF0065AFAB2800A28A2800ACEF101C786B543E9672FF00E806B46B2BC4C76F853586F4B198FF00E386803C13F66B3FF1516B83FE9D13FF0043AFA42BE6CFD9B0FF00C553ACAFAD929FFC7C57D27400572BF127413E24F87BACE9C8BBA63019611DCBA7CEA07D4AE3F1AEAA8A00F8028AD9F16E96345F186B1A685DA96D792C683FD90C76FE98AC6A0028A28A00EB7E186AFF00D89F12B42BB2DB51AE440E7B6D932873F4DD9FC2BED2AF80E291E195258D8AC88C19587623A1AFB8BC25AFC5E28F0A69BAD458C5D4019C0FE171C3AFE0C08FC28036A8A28A00F36F8EC71F0A7501EB3403FF00220AF926BEB2F8F471F0B2EC7ADCC23FF1EAF936800A28A2800AF77FD9A0FF00C4CBC44BEB0C07F57AF08AF73FD9A8FF00C4EB5F5F5B788FFE3CD401F465145140051451401C47C5F38F853AFF00FD714FFD18B5C17ECD27FE24FE201FF4F117FE82D5DDFC6338F84DAF1FFA6718FF00C8A95C0FECD07FE259E221E93407F47A00F77A28A2800AA7AB1DBA3DF37A5BC87FF1D3572A86BA76F87F526F4B594FFE386803E0FA28A2800A28A2803B6F84476FC55F0F9FFA6EC3FF001C6AFB26BE32F85076FC52F0F1FF00A79C7FE3A6BECDA0028A28A002A2B9812EAD66B790663950A30F62306A5A2803E07BDB492C2FEE2CE61896DE5689C7BA920FF2A82BBBF8C9A645A57C53D66384612775B9C63F8A450CDFF8F135C2500145145003E29648268E689CA491B06461D411C835F74F87754FEDBF0D697AAE003796B14E40EC594123F026BE13AFB33E134FF68F859E1F7CE716DB3FEF9665FE9401D9D14514005145140051451401F187C553BBE28F884FFD3D11FA0AE3EBACF89E777C4EF111FF00A7D715C9D001451450015F7868677681A6B7ADAC47FF001D15F07D7DD9E1C3BBC31A4B7AD9427FF1C1401A745145001451450014514500145145001451450014514500145145003253B6176F4526BE40F82C76FC5CD08FFB530FFC81257D797876D95C1F48D8FE95F207C1C38F8B3A09FF00A6920FFC84F401F62D14514005145140051451401E3BFB47C79F01E9B27F775341F9C527F857CC55F54FED090997E1A2B819F2AFE273EDC3AFF5AF95A800A28A2800AF70FD9AE7DBE21D72DF3F7ED51F1FEEBE3FF66AF0FAF58FD9E6F3ECDF1224809E2EAC258C0F70CADFC94D007D4F4514500145145007CC7FB481FF008AEF4D5F4D314FFE4592BC72BD7FF68E39F885603D34A8FF00F46CB5E414005145140057D47FB3A9CFC39BA1E9A9CA3FF21C75F2E57D41FB389CFC3DBF1E9AAC9FFA2A2A00F5FA28A2800A28A2800AF1DFDA3CFF00C505A6AFAEA887FF00214B5EC55E33FB489FF8A2B4B5F5D441FF00C86F4012FECE07FE280D457D35473FF90A2AF61AF1AFD9BCFF00C511AA2FA6A4C7FF0021A57B2D00145145001451450014514500145145001451450015CDF8FB421E24F026B1A66CDD2496CCD08C7FCB45F993FF001E02BA4A2803E00A2BA3F1F68C3C3FE3DD6F4C45DB1C574CD10F446F9D07FDF2C2B9CA0028A28A00D8F0AEB2FE1EF15E97ABA923ECB72923E3BA67E61F8AE47E35F730218020820F208AF806BEE0F03DF9D53C09A0DEB1CBCB630973FED0501BF5068037E8A28A002BE05B83BAEA56F5727F5AFBEABE0163B989F539A004A28A2800A9ECCEDBEB76F4954FEB5053E23B6646F4606803EFCA28A2800A28A2800A8E71BADE45F5423F4A92908C823D6803E3FF0082C377C5CD087FB531FF00C81257D835F217C115FF008BBDA2FF00B22E3FF44495F5ED001451450015F32FED207FE2B8D2D7D34D53FF009124AFA6ABE61FDA3CFF00C5C0D3D7D34B8CFF00E4596803C7A8A28A0028A28A00FA9BF67839F86F30F4D4651FF8E257ACD7917ECE873F0EAF07A6A720FF00C87157AED001451450014514500786FED2ADFF00123D057D6E643FF8E8FF001AF9CABE80FDA62E46DF0DDA8EB9B891BFF2181FD6BE7FA0028A28A002BE8EFD9ACFFC4835D1E97519FF00C74D7CE35F487ECD68478735B7C706ED003F44FF00EBD007B7D14514005709F1965117C26D798F74897F39507F5AEEEBCD3E3CCFE57C2BBD4CFF00AEB8853FF1F0DFFB2D007C974514500145145007A9FECFC09F89ABED652FFECB5F5657CB7FB3AC7BFE23DCB7F734D95BFF001F8C7F5AFA92800A28A2800AC8F159C783B5C3FF0050F9FF00F45B56BD63F8B7FE44CD77FEC1F71FFA2DA803C07F66D3FF00157EAE3FE9C3FF006A2D7D2D5F347ECDDFF238EADFF60FFF00DA8B5F4BD00145145007C9DF1E7466D33E25DC5D84C45A8C11DC291D3206C6FC72B9FC6BCC6BE9FF00DA1BC3C351F05DB6B31A666D3271BC81FF002CA4C29FFC7B67EB5F305001451450015F467ECE1E21F3F48D53C3D2BE5EDA4175003FDC6E180F60C01FF81D7CE75E83F05756FEC9F8A3A5866C47781ED5FDF72FCBFF008F05A00FAFA8A28A00F2EF8FC71F0BE61EB7708FD4D7CA35F55FED0471F0CF1EB7D10FD1ABE54A0028A28A002BDBFF0066B3FF001516B8BEB6887FF1FAF10AF6CFD9B0FF00C555ACAFAD903FF8F8A00FA4E8A28A0028A28A00E0FE339C7C24D7BFDD87FF004725705FB339FF0042F120FF00A696FF00CA4AEFBE328CFC25D787FB111FFC8C95C17ECD03FD03C467D65807E8F401EF145145001599E243B7C2FABB7A594C7FF1C35A7591E2B3B7C1FADB7A584E7FF21B5007C2F45145001451450075DF0B8EDF89FE1D3FF4F8A3F9D7DA35F157C343B7E25F870FFD3FC63F5AFB56800A28A2800A28A2803E4EF8F98FF85A5718EF6B0E7FEF9AF31AF52F8FF1B47F13E463D24B38587EA3FA5796D001451450015F5F7C117DDF08F451FDD338FF00C8F257C835F587C02BAFB47C2E822FF9F6BB9A2FCC87FF00D9E803D3E8A28A0028A28A0028A28A00F8A7E249DDF12BC467FE9FE51FF8F572D5D2FC433BBE23F890FF00D44A71FF008F9AE6A800A28A2800AFBA3C2A777843446F5B080FFE435AF85EBEE5F071DDE08D01BD74DB73FF0090D68036A8A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0086EC66CA71EB1B7F2AF903E0D8CFC59D07FEBA49FF00A29EBEC0B9FF008F49BFDC6FE55F207C19FF0092B5A0FF00BF2FFE897A00FB128A28A0028A28A0028A28A00E03E355AFDABE136B58196884528FC254CFE99AF8FEBEDCF1FD9FDBFE1EF886D80CB369F3328F56542C3F502BE23A0028A28A002BB6F8457DF60F8A9A0CA4E03CED09F7DE8C83F5615C4D5FD0EF8E97AFE9BA803836B7514F9FF75837F4A00FBC28A3A8C8A2800A28A2803E5CFDA28E7E235A8F4D3221FF009124AF23AF58FDA18E7E24C63D34F887FE3CF5E4F4005145140057D39FB379FF008A13525F4D4D8FFE428EBE63AFA63F66E3FF001466ACBE9A813FF90D2803D9E8A28A0028A28A002BC57F6923FF0014968EBEB7C4FF00E436AF6AAF11FDA4CFFC535A22FADE31FF00C728025FD9B4FF00C521ABAFA5FE7FF21AD7B4D7897ECD87FE298D697D2F14FF00E382BDB6800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803E4EF8F70AC5F14AE9C0C196DA176F73B76FF415E635E9FF001F5F77C51B81FDDB5847E99FEB5E614005145140057D91F0818B7C29D00B1C9F25C7E5230AF8DEBECAF84800F855E1FC7FCF03FF00A1B50076B45145003263B6191BD149AF80EBEF8BE709A7DCB9380B13127F035F03D0014514500145145007DFCA77283EA334B515B1DD6B09F5407F4A96800A28A2800A28A2803E47F8263FE2F0699EC2E3FF00453D7D715F237C123FF17834BF7171FF00A29EBEB9A0028A28A002BE5DFDA2CE7E22D98F4D2E31FF009125AFA8ABE59FDA1CE7E24403D34E887FE3F25007935145140051451401F4F7ECE07FE2DFEA0BE9AA487FF21455EC35E35FB379FF008A1F535F4D498FFE438EBD96800A28A2800A28A2803E62FDA36FBCFF001CD859A9CADB58293ECCCEC4FE816BC76BD0FE37DC19FE2D6AEA4E56258235FF00BF484FEA4D79E5001451450015F517ECE96FE57C3CBB988E66D4A420FB048C7F306BE5DAFAF3E085A8B6F84FA4B7F14CD348DFF7F580FD00A00F43A28A2800AF19FDA3EF3CAF05E99660E0CF7E1CFB8446FEAC2BD9ABE6EFDA4B5659FC43A3692AD9FB2DB3CEE0763230033F847FAD00788D145140051451401ED3FB36DB96F186AF73DA3B0F2FFEFA914FFECB5F4B57817ECD168445E23BD2386682253F4DE4FF0035AF7DA0028A28A002B17C5E71E09D78FA69D71FFA2DAB6AB0FC6871E04F109F4D32E7FF00453500781FECDC7FE2B4D547FD43CFFE8C4AFA62BE64FD9BCFFC573A98FF00A86B7FE8D8EBE9BA0028A28A00CAF136949AE785F54D2DD430BAB59221ECC54E0FE0706BE15AFBFEBE11D7EC5B4BF11EA960C306DAEE5848FF0075C8FE94019D451450015A5E1DBE1A6789B4AD419B6ADADE43313E815C1FE959B45007DFC08650CA41046411DE96B80F837E253E24F87562657DD7561FE87364F27601B4FE2A579F5CD77F401E4FFB431C7C36887AEA110FFC75EBE58AFA8FF68A38F8736A3D753887FE4392BE5CA0028A28A002BDA3F66E3FF1596ACBEBA7E7FF00222578BD7B27ECDE7FE2BAD4D7D74D63FF009163A00FA6E8A28A0028A28A00E0BE34C9E5FC24D74FAAC2BF9CC82B87FD9A548D27C40FD8CF081F82B7F8D747F1FEF05AFC30921CE3ED5790C5F5C65FFF0064AA1FB395A18BC077F72460CFA8301EEAA883F993401EC345145001589E323B7C0FE206F4D36E0FFE436ADBAC0F1C9DBF0FFC487D34BBA3FF00909A803E1FA28A2800A28A2803A6F87476FC48F0D9FF00A88C23FF001F15F6CD7C45E006DBF117C347FEA296C3FF00222D7DBB4005145140051451401F30FED1C8A3C7DA7B8FBCDA6267F0964AF1EAF5EFDA31F77C44B25FEEE9718FFC8929AF21A0028A28A002BE9EFD9C5C9F87FA829FE1D51F1FF7EA2AF986BE9DFD9C3FE442D4BFEC26FF00FA2A2A00F62A28A2800A28A2800A28A2803E21F1E9DDF113C4A7FEA29723FF0022B573D5BBE363BBC7BE226F5D52E4FF00E456AC2A0028A28A002BEE1F039DDE00F0DB7AE976C7FF00212D7C3D5F6EF804EEF875E1A3FF0050BB61FF0090D6803A2A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28023B8FF008F697FDC3FCABE40F831FF00256F41FF007E5FFD12F5F5F5C9C5ACC7D11BF957C81F064E3E2D683FEFCBFF00A25E803EC4A28A2800A28A2800A28A28022BA816EAD26B77FB92C6C8DF42315F03C88D148D1B8C3292A47B8AFBF6BE10D79045E22D4E31D16EE551F839A00CFA28A2800A28A2803EEBF0D5D9BFF0B691784E4DC5943293EBB901FEB5A95CB7C3693CDF86BE1C62738B0897F25C7F4AEA6800A28A2803E54FDA08E7E2691E96510FD5ABCAEBD43E3F1CFC50987A5A423F435E5F4005145140057D29FB369FF8A53585F4BE07FF001C15F35D7D21FB359FF8A735C5F4BB43FF008E5007B7D14514005145140057877ED2A7FE245A0AFADCC87FF1D15EE35E1BFB4A8FF8916827FE9E64FF00D045002FECD67FE241AEAFA5D467FF001D35EE35E1DFB350FF00890EBA7FE9EA3FFD04D7B8D001451450014514500145145001451450014514500145145007C93F1D9B3F15B501FDD8601FF90C579B57A2FC736CFC59D547F763807FE424AF3AA0028A28A002BECAF84473F0ABC3E7FE9830FF00C7DABE35AFB1BE0E927E13E839FF009E727FE8D7A00EE68A28A00E4FE26EAA745F86BAF5E038736AD0A1F469088C1FC0B66BE2CAFAB7F680B8F23E18BC79C79F790C7F5EADFF00B2D7CA54005145140054D6B6EF77770DB443324D22C6A3DC9C0A86BAFF0085BA51D63E266836D80552E85C367A623CC9FF00B2E3F1A00FB3D54222A8E806052D1450014514500145145007C8BF04BFE4AFE93F4B8FFD12F5F5D57C89F044E7E2F6907D45C7FE897AFAEE800A28A2800AF957F68339F89807A58C43F56AFAAABE52F8FE73F13E41E96708FE7401E5B4514500145145007D2FFB371FF8A3F565F4BFCFFE435AF68AF13FD9B0FF00C52FACAFA5EA9FFC7057B650014514500145145007C73F18CE7E2CEBC7FE9A463FF212570D5D0F8EEFCEA7E3ED7EEF3957BF9821FF0064310BFA015CF5001451450015F627C196DDF093413FEC4A3FF233D7C775F64FC22B6369F0A7C3F1B75681A4FF00BEDD9BFF0066A00EDA8A28A002BE30F8A9AA36ADF1375E9D9B72C7746DD7D008FE4E3FEF9AFB3EBE09D46E5AF753BBBB63969E67909F52CC4FF5A00AD4514500145145007D51FB3DE9A6CFE1C3DDB2F37D7B24AA7D55404FE6AD5EAF5CEF80B4E5D2BC01A059AAEDD9631330FF006D94337FE3C4D74540051451400560F8DFFE441F11FF00D82EE7FF0045356F56178DBFE442F117FD832E7FF4535007807ECE1FF23E6A5FF60C7FFD1B1D7D395F31FECDFF00F23DEA5FF60C6FFD1B1D7D394005145140057C9DF1DBC3EDA37C469EF11316FA9C6B728474DFF75C7D7233FF0002AFAC6BC9BF682D05753F00A6A88B99B4B9D5F3DFCB721187E650FE1401F2CD145140051451401ED1FB396B6D6BE2BD474677FDCDEDB79AABFF004D233DBFE02CDF90AFA5EBE2EF85DA89D2FE26F87EE036D0F76B031F693F767FF42AFB46803C7FF68E38F87B603D7558FF00F454B5F3057D39FB481FF8A174C5F5D4D4FF00E4292BE63A0028A28A002BD83F67138F885A80F5D2A4FF00D1B1578FD7AE7ECE871F11AEC7AE9928FF00C891D007D474514500145145007827ED2BA962D740D2D5BEFBCB70E3D3002AFF00E84D5DFF00C1BD34E99F0AF46561879D1EE1BDF7B92BFF008EEDAF1DFDA3A666F1FE9F113F2A698840F732499FE42BE89F0CC0B6DE14D1E041858AC61451EC100A00D5A28A2800AE7BC7A71F0EFC4BFF0060BB9FFD14D5D0D739E3FCFF00C2BAF12E3FE81971FF00A2DA803E23A28A2800A28A280377C12DB3C7BE1D6FEEEA76C7FF0022AD7DC55F0BF855C45E2FD1243D12FE06FCA45AFBA2800A28A2800A28A2803E58FDA18E7E24C43D34F887FE3CF5E4F5EADFB4267FE165AFFD7845FCDABCA6800A28A2800AFA6FF66F6FF8A1B535F4D498FF00E428EBE64AFA5FF66E27FE10FD5876FED0FF00DA6B401ED1451450014514500145145007C33E2F3BBC6BAF37AEA3707FF22356356B78A0EEF16EB2DEB7D39FFC88D5934005145140057DB3F0ECEEF86FE1B3FF0050E807FE382BE26AFB57E1A9DDF0D3C387FE9C221FA500755451450014514500145145001451450014514500145145001451450056D40EDD36E9BD2173FA1AF907E0F9DBF15F403FF4D5C7FE437AFAF354FF009045EFFD707FFD04D7C81F08FF00E4AAF87FFEBBB7FE80D401F6551451400514514005145140057C21AFB6FF0011EA8DFDEBB94FFE3E6BEEFAF8335624EB37C4F537127FE8468029D145140051451401F687C2D39F85FE1EFF00AF45FE66BAFAE37E13B07F85BE1F23FE7DB1F93115D9500145145007C99F1E8E7E29DD8F4B7847FE3B5E675E91F1D8E7E2BEA23D21807FE435AF37A0028A28A002BE8CFD9A8FFC4935E5F4B988FF00E3A6BE73AFA23F6683FF0012CF112FA4D01FD1E803DDE8A28A0028A28A002BC3FF00694FF917B433FF004F4FFF00A057B857887ED29FF22EE87FF5F6FF00FA05001FB35FFC8BBAE1FF00A7B4FF00D02BDBEBC43F66BFF91735BFFAFB4FFD02BDBE800A28A2800A28A2800A28A2800A28A2800A28A2800A28A4660AA598E140C93E9401F15FC4BD4BFB5BE24F882EF395FB63C4A7D563FDD83F928AE56A7BCB83757D7172739965690E7DCE6A0A0028A28A002BED3F863666C7E19787A1604136692E0FFB7F3FFECD5F1A58DA3DFEA16D6517125C4AB12FD58803F9D7DE3696D1D959416908C45046B1A0F40A303F95004D4514500786FED29A808F42D0F4DCFCD35CBDC11FEE2EDFFDA95F3957AE7ED117ED73F106DAD377EEED2C5005F46666627F2DBF95791D001451450015EABFB3E5B79FF12CCB8CFD9EC6593E992ABFFB3579557BA7ECD5A7EFD5F5ED448FF55045003FEFB163FF00A00A00FA2E8A28A0028A28A002AB6A1702D34CBAB92702185E427E809AB35C8FC50D50691F0CF5FB9DDB59AD5A05F5CC988C63FEFAA00F9DBE054265F8AFA6B81C4514EE7FEFDB2FF5AFADEBE6CFD9BB4A33F89F57D54AE52D6D16007FDA91B3FCA33F9D7D274005145140057C9DF1ECE7E295C8F4B6847FE3B5F58D7C95F1DCE7E2ADF8F48201FF008E0A00F35A28A2800A28A2803E8FFD9ACFFC53FAE2FA5D467FF1CAF70AF0BFD9A4FF00C49F5F5F4B888FFE3AD5EE9400514514005477132DBDB4B337DD8D0B9FA019A92A86B793A0EA2075FB2CB8FF00BE4D007C2534AF3CF24D21CBC8C598FA92734CA28A0028A28A002BEE7F095AFD87C1BA1DA631E4D84119FA88D457C315F7D5BA08ED6245FBAA800FCA8025A28A28039EF1CEBBFF0008D782357D58102482DD8459FF009E8DF2A7FE3C457C435F4FFED17A81B6F01D9592B106EEF9770F5555627F5DB5F3050014514500140049000C93D00A2BA3F00E8CDAFF008F345D34296496E91A4007FCB35F99FF00F1D53401F6A585BFD934DB5B6FF9E30A47F9002AC514500145145001585E37E3C03E233FF50BB9FF00D14D5BB583E38FF927FE24FF00B05DD7FE8A6A00F01FD9C3FE47CD487FD431FF00F46C75F4E57CC5FB387FC8FDA97FD82DFF00F46C55F4ED001451450015CEF8F6C86A3F0FFC416BB7717B098A8FF68212BFA815D1532689278648645DD1C8A5581EE0F06803E03A2AEEAFA74BA46B57DA6CC0F9B6970F0367D5588FE954A800A28A28026B4BA92CAF60BB84E258245910FA15391FCABEF0D3EF63D474DB5BE87FD55CC29327D18023F9D7C135F5DFC14F10A6BBF0DAC622D9B8D3B36728CF40BF73F0D857F23401CE7ED227FE28DD257D750CFF00E437AF99EBE95FDA4B3FF08968FE9F6E3FFA2DABE6AA0028A28A002BD63F67838F89328F5D3E51FF008F25793D7AB7ECF79FF8596DFF005E12E7F35A00FAA68A28A0028A28A00F967F6889D25F8910229C9874E891BD8EF91BF930AFA6F4B85ADF49B385C61A381108F70A057CA77DBBE237C7868D32D05CEA2231FF005C22E09FFBE109FC6BEB7A0028A28A002B03C70BBFE1FF008917D74BB91FF909AB7EB2FC4B6E6EFC2BABDB0EB3594D18FC508A00F8528A28A0028A28A00B5A64BE46AD673671E5CE8DF93035F7AD7C015F786877A352D034DBE0DB85CDAC5367D77283FD6802FD145140051451401F2A7ED0473F1371E96310FD5ABCAEBD43E3F1CFC50987A5A423F435E5F4005145140057D2BFB369FF008A4B585F4BE07FF21AD7CD55F48FECD87FE29AD697D2F14FFE39401EDD451450014514500145145007C25E213BBC4BAAB7ADE4C7FF001F359B57B5A3BB5DD41BD6E643FF008F1AA34005145140057DA5F0BCEEF863E1D3FF004E6A3F9D7C5B5F677C293BBE16F878FF00D3AE3FF1E3401D8D14514005145140051451400514514005145140051451400514514014F56FF903DF7FD7BC9FFA09AF903E127FC954F0FF00FD7C1FFD01ABEC0D57FE40F7DFF5EF27FE826BE40F849FF2557C3FFF005DCFFE80D401F6551451400514514005145140057C23AFC2D6FE23D5206FBD1DDCA87EA1C8AFBBABE2BF8996074EF899E228186375EBCC07B49F38FD1A80394A28A2800A28A2803EB9F8197EB7BF0AB4D8F765ED649A07F63BCB0FD1857A357867ECD57C5F44D7AC0B710DCC5301FEFA907FF458AF73A0028A28A00F917E391CFC5AD587A2403FF20A579D57A0FC6E39F8BBADFB0807FE408EBCFA800A28A2800AFA17F6673FE89E245F47B73FA495F3D57D03FB331F93C50BE86D4FFE8DA00F7EA28A2800A28A2800AF11FDA507FC537A237A5E38FF00C72BDBABC57F6921FF00149E8EDE97C47FE38D400CFD9B07FC533AD1F5BC51FF008E0AF6DAF15FD9B47FC523ABB7ADF81FF90D6BDAA800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD7A430F87753957AA5A4AC3F0435A1599E22E7C31AB7FD79CDFFA01A00F84E8A28A0028A28A00EABE1AD98BFF00895E1D818640BE8E423D761DFF00FB2D7DAB5F1A7C24609F157C3E4FFCFC11F9A30AFB2E800A28A2803E4AF8EE0FFC2D6BFCF7820C7FDFB15E6B5EA9FB414423F89BBFFE7AD8C4FF00AB0FE95E574005145140057D35FB37C312F81F539C0FDEBEA4C8C7D9638C8FFD08D7CCB5F4CFECDCC7FE109D517B0D449FFC869401ECD45145001451450015E2BFB47EB06DBC2DA5E908D86BDB932B81DD231D3F3753F857B557CC5FB46DF99FC7361640E56DAC1588F46676CFE816803D1FF67ED20587C39FB732E24D42EA4973FECAFC807E6AC7F1AF56AE77C05A78D2FE1FE81678C3258C45C7FB4CA19BF526BA2A0028A28A002BE46F8E873F16754F68E0FF00D14B5F5CD7C8DF1D063E2C6A9EF1C1FF00A296803CE68A28A0028A28A00FA23F6683FF0012EF110F4960FE4F5EEF5E11FB340FF8977888FACB07F27AF77A0028A28A002AA6A98FEC9BDCF4F21FFF0041356EB03C6F766C7C07E20B953878F4E9CA9FF6B61C7EB401F0FD14514005145140057DF164C5EC6DDCF568949FCABE0EB1B57BEBFB6B38FF00D64F2AC4BF56200FE75F7B22844545FBAA302801D45145007857ED2CD8D2BC3E9EB3CC7F255FF1AF9D6BE90FDA522CF873449BFBB76EBF9A67FA57CDF4005145140057AAFECF688FF12CB328252C656527B1CA8FE44D79557A9FECFC71F13547AD94C3FF0041A00FAB28A28A0028A28A002B07C71FF2207893FEC1773FFA29AB7AB03C7271F0FBC487FEA1575FFA29A803C07F670FF91F752FFB05BFFE8D8ABE9DAF98BF6703FF0015FEA23FEA16FF00FA362AFA76800A28A2800A28A2803E46F8E1A41D2BE28DFC8176C57D1C7751FBE576B7FE3CAD5E735F4B7ED13E19FB7786ACFC450AFEF74E93CA9CFAC4E4007F07C7FDF46BE69A0028A28A002BD9FF00672D65AD7C5BA8E90CC7CABDB5F35467F8E33C7FE3ACDF9578C5779F062E1ADFE2CE8641E1DA58C8F506271401EB9FB488FF008A334A6F4D400FFC86F5F33D7D53FB4258B5D7C3559D5722D2FA2958FA02193F9B8AF95A800A28A2800AF56FD9EDD13E25B2BB00CF612AA03FC4728703F004FE15E535D47C38D48E93F11FC3F7618A8FB6C71311FDD73B1BF463401F6BD145140054572CC96933A7DE54623EB8A969180652A7A1183401F29FC00547F89F1B38CB2D9CC509F5E07F226BEADAF92BE0731B7F8B9A7C59FBD1CF19FC2363FD2BEB5A0028A28A00291943A3230CAB0C114B45007C0F7B6AF637F736920C4904AD137D54907F95415D67C4DB78ADBE26788A384610DEBBE3DDBE63FA935C9D001451450015F607C16D4DB53F857A4976CC96DBED9BE8AE76FF00E3BB6BE3FAFA9BF67724FC379F27A6A32E3FEF88E803D668A28A0028A28A00F933E3D1CFC53BB1E96F08FF00C76BCCEBD37E3D8C7C53BA3EB6D09FFC76BCCA800A28A2800AFA3BF66A3FF122D797D2E633FF008E9AF9C6BE8EFD9AC7FC4835D6F5BA8C7FE3A6803DC68A28A0028A28A0028A28A00F82B533BB55BC6F59DCFF00E3C6AAD4D78775ECEDEB231FD6A1A0028A28A002BECAF846777C2AF0F9FF00A60C3FF1F6AF8D6BEC6F83A777C27D04FF00D33907FE457A00EE68A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00ABA9F3A55E0FFA60FF00FA09AF903E117FC956D03FEBBB7FE8B6AFAFF53FF9055E7FD707FF00D04D7C81F087FE4AB681FF005DDBFF0045B5007D934514500145145001451450015F26FC7B8043F14EE9C0FF005D6D0B9FFBE76FFECB5F5957CC5FB475AF97E3BD3EE40F966D39413EA5647CFE8450078ED145140051451401EE3FB354FB75FD76DF3F7ED637C7FBAC47FECD5F4757C8FF00037583A57C4FB1889C457F1C96AFF88DCBFF008F2AFE75F5C500145145007C7BF1A0EEF8B9AF1FF6A11FF9063AE0ABB9F8C4777C58D78FFD348C7FE424AE1A800A28A2800AF7DFD998FEF7C4EBEAB6A7FF0046D78157BCFECCE7FD37C48BEB1DB9FD64A00FA1A8A28A0028A28A002BC63F6911FF00145E94DE9A881FF90DEBD9EBC73F68F1FF00141E9ADE9A9A0FFC85250033F66E1FF144EA8DEBA891FF0090D2BD9ABC77F6701FF140EA2DEBAA38FF00C85157B15001451450014514500145145001451450014514500159DE201BBC37AA0F5B3947FE386B46B3F5ECFF00C23DA9E3AFD925FF00D00D007C21451450014514500761F0AF3FF0B43C3D8FF9FB1FC8D7D9F5F18FC2A04FC51F0F63FE7E87F235F67500145148CC154B31C00324D007CABFB415DC173F133CB8640ED6D63145281FC2F966C7E4CBF9D795D69F88B567D7BC49A96AD2139BBB992600F6058903F0181F85665001451450015F4DFECDE98F02EA6FEBA930FCA28FFC6BE64AFAC7E0269ED65F0BEDE66047DB6EA5B819F4C84FFD92803D3A8A28A0028A28A002BE43F8B93B6B9F18752B784EE2268AD231EE1554FF00E3D9AFAEC90AA589C00324D7C81E0289BC5DF1AAC6E6505BCFD464BF933FEC96979FC401401F5EC312410C70C63091A8551E807029F4514005145140057C95F1DC63E2ADF9F58203FF008E0AFAD6BE4EF8F831F14AE4FADB427FF1DA00F31A28A2800A28A2803E8BFD9A47FC49B5F6F5B8887FE3AD5EE95E1FFB358FF8A7B5C6F5BA41FF008E57B85001451450015CA7C4CFF9267E22FF00AF193F957575CAFC4BFF009269E23FFAF093F95007C554514500145145006FF81881F103C365802A354B6C83FF005D56BEE0AF85FC28FE5F8C3447FEEDFC07F2916BEE8A0028A28A00F15FDA48FF00C525A3AF737E4FFE436AF9AABE90FDA51BFE29CD0D7D6EDCFF00E395F37D001451450015EA7FB3F7FC94E5FF00AF29BFF65AF2CAF51F80071F13E31EB6730FE5401F575145140051451400573DE3D38F877E253FF50BB91FF909ABA1AE6FE20FFC939F127FD832E3FF0045B500781FECE271F10EFC7AE9527FE8D8ABEA0AF977F674FF00928B79FF0060C93FF46455F515001451450014514500705F1A081F08F5E27FBB08FF00C8D1D7C7B5F607C6BE7E116BBF483FF47C75F1FD001451450015DCFC1C8CC9F1674151DA491BF289CFF4AE1ABD13E072EEF8B7A41FEEA4E7FF0020B8FEB401F4EF8DACADB50F036BB6D76330B58CA58F71852C08F70403F857C3D5F70F8DC91E01F1191D46977247FDFA6AF87A800A28A2800AD4F0DAB378A7485419637B0803DF78ACBAE97E1EC2B3FC46F0E46C323FB460623E8E0FF4A00FB6A8A28A0028A2918ED527D066803E47F82E777C65D298773727FF0020C95F5CD7C87F041BFE2EEE8F9EEB3FFE897AFAF2800A28A2800A28A2803E2AF896FBFE26788CFA5F483F238AE56BA4F880C5BE2378909FFA09DC0FFC88D5CDD001451450015F537ECEFF00F24DE7FF00B08CBFFA0475F2CD7D4BFB3B907E1BDC0F4D4A51FF008E47401EB54514500145145007CA3F1FC63E284BEF690FF235E5D5E9FF001F4E7E28DC7B5AC3FCABCC2800A28A2800AFA4BF66C1FF0014CEB47FE9F17FF4015F36D7D21FB359FF008A735B1FF4F69FFA05007B7D1451400514514005145231DA8CDE833401F01C8774AEDEAC4D368A2800A28A2800AFB0BE0B9DDF08F413FECCC3FF0023495F1ED7D7DF044E7E11689EC671FF0091E4A00F41A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28029EAE71A2DF1F4B793FF4135F207C2538F8A9E1FF00FAF83FFA0357D79AE1C787F523E96B29FF00C70D7C81F0A4E3E28F878FFD3D01FF008E9A00FB3A8A28A0028A28A0028A28A002BC37F692D20CDA268BAC22FF00C7B4EF6F211E8E011F9143F9D7B95795FED059FF00856471FF003FD167F26A00F9528A28A0028A28A00DCF064ED6BE39D02753829A8DB9FC3CC5CD7DC75F0C78506EF18E860F7D4201FF009116BEE7A0028A28A00F8D7E2E1DDF157C407FE9BA8FFC716B8AAEBFE29BF99F143C42DE97657F2007F4AE42800A28A2800AF75FD9A4FF00C4D7C42BEB0427FF001E6AF0AAF74FD9A7FE433AFF00FD7BC5FF00A135007D1745145001451450015E3DFB47FF00C881A77FD8513FF454B5EC35E39FB479FF008A0F4D1EBA9A1FFC8525003BF670FF00927DA87FD8564FFD15157B0D78EFECE07FE281D487A6A8E7FF0021455EC540051451400514514005145140051451400514514005676BC76F877533E96929FF00C70D68D50D706EF0FEA43D6D651FF8E1A00F83E8A28A0028A28A00EC7E149C7C52F0F1FF00A7AC7FE3A6BECEAF8CBE138CFC52F0F8FF00A79CFF00E3A6BECDA002A8EB45D742D40A1C38B690AFD769ABD5CFF8E755FEC5F026B9A8038786CE4F2CFF00B646D5FF00C788A00F8828A28A0028A28A0096DA1373770C0182995D5371E832719AFBAF45D26DF42D12C74AB41882D215853D4E06327DCF5FC6BE1FD06D9EF3C45A65AC43324D77146A3D497007F3AFBBE800A28A2800A28A280333C49762C3C2FAB5E31C082CA6909FF7509AF9B3F678B4F3FE23CD311C5BE9F23E7D09645FFD98D7B17C6ED58E95F0BB51556DB25EBC76AA7FDE396FFC755AB89FD9AF482B69AEEB2CBC3C91DAC67FDD1B9FFF00424A00F7AA28A2800A28A2800AF943E3F63FE1684DFF005E90E7F235F57D7CA1F1F863E284C7D6D213FA1A00F2FA28A2800A28A2803E92FD9B31FF0008CEB5EBF6C5FF00D0057B6D788FECD83FE29AD68FADE28FFC72BDBA800A28A2800AE53E261C7C33F1167FE7C64FE55D5D721F148EDF85FE213FF4E8C3F51401F17D145140051451401ABE18C7FC259A367A7DBA0CFF00DFC5AFBAABE13F0E1DBE27D25BD2F613FF008F8AFBB2800A28A2803C33F6953FF124D047ADCCA7FF001D15F39D7D1BFB4A8FF891E827D2E641FF008E8AF9CA800A28A2800AF4DF80871F14AD47ADB4C3FF001DAF32AF4EF80833F14ADBDADA6FFD06803EB1A28A2800A28A2800AE7BC78377C3CF128FFA85DCFF00E8A6AE86B0BC6E33E01F118F5D2EE7FF004535007CFBFB388CFC42BF3E9A549FFA362AFA7EBE63FD9C07FC579A91FF00A863FF00E8D8EBE9CA0028A28A0028A28A00E13E328DDF0975E1FEC447FF0022A57C775F6BFC46D2E4D67E1D6BD630A9695ED19D1475664F9C0FC4AE2BE28A0028A28A002BD1FE05FF00C958D33FEB94FF00FA29ABCE2BD67F67BD2E4BCF88725F053E558DA3B3376DCF8403F1058FE1401F4678C13CCF04EBC9FDED3AE07FE436AF86ABEF6D46D05FE997766C70B710BC44FF00BC08FEB5F05CB1BC32BC522957462ACA7B11D4500368A28A002BA9F86CEA9F12BC3859828FB7C4324F72D815CB54D69732D95E4177036D960916443E8CA723F51401F7CD150DA5C2DE594172830B346B201EC466A6A002A3B838B694FA213FA549515D0CDA4C3D636FE5401F227C146DBF177423EA671FF9024AFB02BE3DF82E33F16F41FF007A6FFD13257D854005145140051451401F10F8F0E7E21F894FFD456E7FF46B573D5BBE3639F1EF88C9EFAA5CFF00E8D6AC2A0028A28A002BEA0FD9C8E7E1E5F0F4D564FF00D15157CBF5F4EFECE07FE282D487FD451FFF004545401EC54514500145145007CA3F1FC63E27CA7D6D213FA1AF2EAF55FDA0C63E2667D6C623FAB57955001451450015F497ECD83FE298D69BD6F147FE382BE6DAFA5BF66D1FF1486AEDEB7F8FFC86B401ED345145001451450014D906E8D97D4114EA2803E00A29CE36BB2FA1C536800A28A2800AFAFBE080C7C22D14FA99CFFE4792BE41AFB07E0A8DBF08F421ED31FF00C8F250077D4514500145145001451450014514500145145001451450014514500677880E3C37AA1F4B397FF4035F207C2D38F8A1E1EFFAFB5FE46BEBDF119C7863563E96537FE806BE40F85E71F13BC3BFF5F8B401F69514514005145140051451400579BFC75B6371F0A751900FF5134327FE440BFF00B357A4579CFC73BDFB27C29D4907DEB9921847FDFC0C7F453401F2351451400514514017B469CDB6B9A7CE3AC5731BFE4C0D7DE35F06E8D6E6F35CD3ED5412D35CC71803DD80AFBCA800A28AADA95E0D3F4BBBBD6195B785E523D9549FE9401F13F8DEEC5FF8F35FBA539593509CA9FF006779C7E98AC1A73BB4B2348EC59D896627B934DA0028A28A002BDE3F668889D43C4737658A053F8973FD2BC1EBE8DFD9AACCA685AF5EE389AE638B3FEE293FFB3D007B95145140051451400578CFED227FE28AD287AEA23FF45BD7B3578D7ED203FE288D2DBD35103FF21BD001FB379FF8A23541E9A89FFD1695ECB5E35FB378FF008A1F536F5D4987FE438EBD96800A28A2800A28A2800A28A2800A28A2800A28A2800AA5AC8DDA1EA03D6DA41FF8E9ABB5435B6DBA0EA2DE96B29FFC74D007C1F451450014514500769F09467E2A787C7FD3C13FF8E357D975F19FC263B7E29F87CFFD3C91FF008EB57D994005797FC7EBD6B5F85F342091F6BBB8613EF825FF00F64AF50AF22FDA314B7C3AB323F87548C9FF00BF728A00F9768A28A0028A28A00F43F825A3FF006BFC50D399973158ABDDBFFC04617FF1F65AFAF2BE71FD9A910EBDAEC854798B6B1A83E80B1CFF00215F4750014514500145145007887ED297257C39A1DAE7FD65DBC98FF7531FFB3D6FFC028045F0BE07031E75DCCE7DF90BFF00B2D705FB4ADF8935BD074E07982DA49C8FF7D828FF00D166BD4BE0DDA1B2F851A1A30C3491C929FF008148CC3F422803BBA28A2800A28A2800AF943E3F488FF142654605A3B4855C7A1C13FC88AFABEBE27F88DA9FF6C7C45D7EF436F46BC78D181EAA87629FC945007314514500145145007D2DFB36A11E10D5DF1C1BFC67E91AFF008D7B4D7977C00D3DACBE18C73B023EDB772CE33E8311FF00ED3AF51A0028A28A002B8CF8B076FC2CF101FF00A76C7FE3CB5D9D713F178EDF853AF9FF00A62A3FF222D007C6D4514500145145005FD10EDD7F4E6F4BA88FFE3C2BEF0AF82F4B3B757B26F49D0FFE3C2BEF4A0028A28A00F11FDA4D33E1AD11FD2F1C7E69FF00D6AF9BABEA0FDA2ED0CDE00B3B851FEA35142DF428E3F9E2BE5FA0028A28A002BD43E017FC95083FEBD26FE42BCBEBD03E0A5D1B5F8B1A373F2CBE6C4DF8C4D8FD71401F5FD145140051451400560F8E0EDF00788CFA697727FF0021356F573BE3E3B7E1DF894FFD42EE47FE426A00F04FD9C0FF00C57BA90F5D31CFFE458EBE9DAF97FF0067238F8877C3D74A93FF0046C55F50500145145001451450015F287C60F86973E13D6A6D5F4F80B6877726E52838B673D51BD067A1FC3A8E7EAFA8E6822B981E09E24962914ABC722865607B107A8A00F8128AFA2BE2AFC22F0B697E15D4FC47A5C53D8DC5B2AB88227CC2C4BAA9F9482475EC40F6AE13E12FC32D3BE2026A336A17F756F1D93C6BB2DC2E5F7063D4838FBBE9401E73A7E9F77AADFC363616F25C5D4EDB238A35CB31AFAFFE1778113C09E1616B3147D4AE984B7922F4DDD907B28FD493DEB4FC2BE03F0EF83612BA369E91CAC3125C4877CAFF00563DBD8607B574940057C57F12ED12CBE25788608E311AFDB5DC28E8377CDFD6BED4AF9A7F685F094D65E2387C4D0444DA5F22C53B01C24CA3033F55031FEE9A00F16A28A2800A28AEB3E1C784E6F18F8D2C74F588B5A2389AEDF1C2C4A7273F5FBA3DCD007D89A22345A0E9D1B8C325AC4A47A10A2AFD1450014C98660907AA9FE54FA47FB8DF4A00F903E0A0CFC5DD0BEB3FFE8892BEC0AF907E08FF00C95DD13E971FFA224AFAFA800A28A2800A28A2803E25F88507D9BE2378923FFA88CEE3E8CE5BFAD7355E95F1D7473A5FC4EBB9C29115FC31DCA7A671B1BF5427F1AF35A0028A28A002BE8DFD9AF5247D0F5BD2BA490DCA5C0F70EBB7F4F2FF005AF9CABD7BF675BD307C40BBB52DF25CD838C7AB2B211FA6EA00FA868A28A0028A28A00F963F68718F89309F5D3E23FF008F3D793D7AE7ED1631F11AD0FAE9919FFC8925791D001451450015F4D7ECDE3FE288D51BD75123FF0021A57CCB5F4F7ECE03FE280D45BD75471FF90A2A00F61A28A2800A28A2800A28A2803E06BA1B6EE65F49187EB50D59D446DD4EED7D2671FF008F1AAD4005145140057D8BF06C6DF84DA08FFA6721FF00C8AF5F1D57D93F0846DF853A00FF00A60C7FF22350076D4514500145145001451450014514500145145001451450014514500667893FE456D5FF00EBCA6FFD00D7C81F0C3FE4A77877FEBF52BEC0F110CF867561EB6737FE806BE40F85C33F13FC3BFF005F8BFD6803ED1A28A2800A28A2800A28A2800AF26FDA2091F0DE003A1D46207FEF892BD66BCB3F6818F7FC3166FF009E77B0B7FE843FAD007CA745145001451450075FF0B6D52EFE27F87A2906556ED64FC50161FAA8AFB42BE34F84A76FC54F0F9FFA7823FF001C6AFB2E800AC3F1A3F97E04F10C9FDDD32E5BF289AB72B03C72BBFE1F78917D74BB9FFD14D401F0FD14514005145140057D4DFB3C22AFC36988182DA8CA4FB9DA83FA57CB35F527ECECFBFE1C5C2FF7352957FF001C8CFF005A00F5BA28A2800A28A2800AF1BFDA40FF00C50BA60FFA89AFFE8A92BD92BC63F6913FF146694BEBA803FF0090DE8024FD9C0FFC507A90FF00A89BFF00E8A8EBD8EBC67F66E3FF001456AABE9A893FF90D2BD9A800A28A2800A28A2800A28A2800A28A2800A28A2800AC1F1BDDFD87C07AFDC8FBD1E9F395FAEC38FD715BD5C7FC54257E17F8848FF9F423F51401F185145140051451401DC7C1FB77B9F8ADA0A20CED99E43F458D98FF002AFB1EBE55FD9F2DD66F899E630C982C65917D8E557F931AFAAA800AF23FDA26E628BE1E5B40FCC936A11841E985724FF4FC6BD72BC5BF691B5924F0869374A098E1BED8F8EDB90E0FFE3BFAD007CD34514500145145007B8FECD40FF6FEBA71F28B58F27FE046BE8EAF10FD9B74A30787B59D59971F6AB948109F48D4938FC64FD2BDBE800A28A2800A28A2803E46F8E37E6FBE2AEA51E72B6B1C502FFDF018FEAC6BEA6F0E69DFD91E19D2B4DC60DA5A4509FAAA007F957C9FE254FED8F8E57B6E7E6F3B5C16F8F5FDE84FE95F61D0014514500145145006478A7526D1BC25AC6A487125AD94B2A1FF00682123F5C57C3049624924927249EF5F687C52566F861E220B9CFD8D8F1E9C66BE2EA0028A28A0028A2B77C15656DA978E343B1BC04DBCF7D0C7228FE205C71F8F4A00FB1FC1FA5AE8BE0CD1B4E0BB4DBD9C4AE3FDADA0B1FCF35B7451400514514005713F1746EF853E201FF4C14FFE3EB5DB571BF15C67E16F8807FD3B67FF001E1401F195145140051451401734A1BB58B15F5B88C7FE3C2BEF3AF83F431BBC41A68F5BA887FE3E2BEF0A0028A28A00F3CF8E11ABFC24D6198728D032FD7CE41FC89AF90EBEBCF8E07FE2D1EB1EED07FE8E4AF90E800A28A2800AECFE13027E29F87F1FF3F07FF416AE32BBBF8331F99F16B4153D9E56FCA173FD2803EC4A28A2800A28A2800AE73E200CFC39F127FD832E3FF45B57475CFF008EC6EF87BE251FF50ABAFF00D14D401F3EFECE633F116F3DB4B93FF46455F5157CC3FB380FF8B81A837A69720FFC8B157D3D400514514005145140051451401C27C663B7E12EBC7FD8887FE464AF3FFD99CFFA278957D1EDCFE92577FF0019C67E126BDFEE43FF00A392B80FD99C7FA37894FABDB7F292803DEE8A28A002A86B3A3D86BFA4DC697A9DBACF6970BB6446FD083D883C83DAAFD1401F2D78CFE03F88344B9927D011B56D389CAAA604F18F42BFC5F55EBE82BCDE7F0F6B76AEC971A3EA10B28CB092D9D48C7AE457DDB595E27FF914F59FFAF19FFF0045B5007C79E07F02EABE3CD59EC74D686358543CF34CD858D49C741C93EC3F4AFAC3C0DE04D2BC07A39B2D3C19269486B8BA907CF330FE40761DBEB935E2DFB36363C4BADA7AD9A9FC9FFF00AF5F48D0014514500141E9452119047AD007C87F043FE4AE68BF49FF00F44495F5ED7C85F0407FC5DDD1BD84FF00FA224AFAF6800A28A2800A28A2803E7FFDA5ED173E1CBD03E63E7C4C7DBE423FF66AF00AFA5BF691B567F08E917607CB15F18CFB6E463FFB257CD34005145140057A47C0A90A7C57D3541FF5914EA7FEFDB1FE95E6F5D7FC2CD43FB33E27F87EE09C06BA1013FF005D018FFF0066A00FB428A28A0028A28A00F983F68E18F883A79F5D2A3FFD1B2D78FD7B27ED203FE2BAD30FAE9AA3FF0022C95E374005145140057D43FB398C7C3BBD3EBAA487FF0021455F2F57D4BFB3B8C7C37B83EBA94A7FF1C8E803D6A8A28A0028A28A0028A28A00F837581B75BBF5F4B9907FE3C6A9568EBE36F88F545F4BB947FE3E6B3A800A28A2800AFB37E138DBF0B3C3E3FE9DB3FF008F1AF8CABED1F85A36FC30F0E8FF00A7353FA9A00EBA8A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00CED7FFE45CD53FEBD25FF00D00D7C83F0B3FE4A8787BFEBEC7F235F5FEBDFF22EEA7FF5E92FFE806BE40F857FF2543C3DFF005F63F91A00FB3E8A28A0028A28A0028A28A002BCB3F6819D62F862C8DD66BD8517EBF337F2535EA75E2FFB48CA4783B498B3F2B6A1B8FE11B0FEB401F345145140051451401DC7C1F88CBF15F405033895DBF28DCFF4AFB1EBE52FD9FEC85D7C4E498FFCBA59CD30FC709FFB3D7D5B40056278C867C0DE201EBA6DC7FE8B6ADBAC6F170DDE0BD747AE9D703FF21B5007C3345145001451450015F527ECECB8F871727FBDA94A7FF1C8EBE5BAFAA7F67B5C7C3463EB7F29FD16803D5A8A28A0028A28A002BC53F6923FF14A68E3D6F89FFC71ABDAEBC4FF006933FF0014B68C3FE9F5BFF403400EFD9B4FFC525AC0F4BE1FFA2D6BDAABC53F66D3FF0014A6B03FE9F87FE802BDAE800A28A2800A28A2800A28A2800A28A2800A28A2800AF2AFDA0755974FF86FF66898A9BFBC8E07C7F700673FAA0FCEBD56BCABF681D2A5D43E1BFDA6252C6C2F239DF03F808643FAB8FCA803E55A28A2800A28A2803D93F670B5793C71A95D63F770E9CC84FBB4898FD14D7D375E37FB3B7879F4FF0008DEEB334655F529C2C791D628F201FC58BFE42BD92800AC1F19F8660F17F84EFF004499821B88FF0075211FEAE4072ADF81033ED9ADEA2803E0DD5F49BDD0B56B9D335181A0BBB77292237AFA8F507A83DC552AFB43C6FF000E341F1DDB28D422686F63188AF20C09147A1ECCBEC7F0C57CA779E0FBA8FC7F3F84ACA74B9B95BB36B14AE3CB0E41E09EB8FD68039BABDA3E8F7DAFEAF6DA5E9B034F7770E12341FCC9EC07527B0AF55D2BF673F135CCCBFDA7A8E9F65067E631B34AFF0080C01FAD7B7F823E1D683E04B565D3A2696F24189AF27C191FD87F757D87E39A00D1F07F86E0F0978534FD12021BECD1FEF2403FD6487966FC493F862B728A2800A28A2800A64B2A430BCB23058D14B331EC07534FAE73E205DB58FC3CF10DC21C32E9F3053E84A100FEB401F32FC388A4F147C6AB1BC2A7F797D25FC99FE1C6E93F9E07E35F5ED7CD7FB36D8A4BE29D62FD865ADECD625F6DEE0FFEC95F4A500145145001451450066F8834DFED8F0DEA9A6719BBB496019F564207F3AF85248DE195E2914A488C55948E411D457DFB5F357C6FF86773A6EA971E2BD2603269D72DE65E4718E6090F57C7F758F39EC49F51401E2B451450015DA7C26D2E4D5BE27E85146A4AC1702E5CFF007563F9F3F9803F1AE3638DE591638D19DDC8555519249E800AFAA3E0B7C379BC1FA5CBAB6AD104D5EF902F967ADBC5D769FF00689C13F403B1A00F55A28A2800A28A2800AE5BE24DAC979F0DBC430C4097FB0C8E00EFB46EFE95D4D3648D2689E2914323A956523820F51401F01515D5FC43F065CF823C5973A73A31B37264B3988E1E2278E7D4743EE3DC572940051451401B1E13B592FBC63A2DAC409796FA151F8B8AFB9EBE6AFD9FFC1135FEB87C5779115B3B2DC96BB87FAD948C123D42827F123D0D7D2B40051451401C27C64B592F3E13EBB1C632C91C72FE092A31FD01AF8EEBEF8BDB48350B1B8B2B940F6F7113452A1FE2561823F235F14F8D7C237DE0BF12DCE93788C5158B5BCC4713444FCAC3FAFA10450073B451450015E8DF032D64B8F8B1A5C88095B78E795FD8794CBFCD8579CD7D37F00FC0D3E85A3CFE22D46168AEF514096F1B0C3241D727D371C1FA28F5A00F64A28A2800A28A2800AC3F1A0DDE04F108F5D32E47FE426ADCAC3F1A7FC889E21FFB065CFF00E8A6A00F00FD9BC7FC573A99F4D3587FE448EBE9BAF993F66FFF0091E753FF00B06B7FE8C8EBE9BA0028A28A0028A28A0028A28A00E1BE310CFC27D787FD338CFF00E454AE03F6681FE81E233EB2C03F47AEFBE321C7C26D78FF00D33887FE454AE03F6673FE85E241E925B9FD24A00F79A28A2800A28A2800AC7F169DBE0CD71BD34FB83FF90DAB62B0FC6876F813C42DE9A65C9FFC84D401E0BFB369FF008ABF575F5B0CFF00E445AFA5ABE65FD9BCFF00C56FAA2FAE9C4FFE444AFA6A800A28A2800A28A2803E48F82498F8C1A68FEEADC7FE8A715F5BD7C91F049BFE2F069A7FBCB71FFA29EBEB7A0028A28A0028A28A00E03E34E98353F859AB60664B5D9729EDB5867FF1D2D5F1FD7DBDE3CB67BCF87FE218235DCEFA74FB47A9084815F10D0014514500157B449DADB5ED3A753868AEA2707DC3035468A00FBFE8AE13E0FF008925F137C39B09EE5CBDD5A13673393CB14C6D27DF695CFBD77740051451401F36FED276B22789B45BC20F972D9B44A7DD1C93FF00A18AF12AFB07E2E7829FC69E0D922B44DDA95937DA2D477738F993FE043F502BE4092378A468E446491095656182A475047AD00368A28A002BEAEF8036925BFC308A57042DCDDCD2A7B8C84FE686BE67F0DF87AFFC53AF5AE91A6C45E79DB05B1C46BDDDBD001CD7DB3A168F6DE1FD0AC748B41FB8B48562527AB60724FB9393F8D0068514514005145140051451401F0AF8986DF15EB0BE97D38FFC7CD655749F106C9F4FF889E22B775DB8D426751FECB3165FD08AE6E800A28A2800AFB33E145E5B5EFC30D05ADA5590456C21931FC2EBC303EF9AF8CEBDEBF66CD664179AD686CC4C4D1ADE46BFDD208463F8E53F2A00FA168A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00CFD7BFE45DD4FFEBD25FF00D00D7C81F0AFFE4A8F87BFEBEC7F235F5D78A2410F84B5994F44B19D8FE11B57C95F092332FC55F0FA8ED3B37E48C7FA5007D954514500145145001451450015E2FF00B48A67C1DA4C9FDDD436FE71B7F857B4578FFED1CB9F87B60DDC6AB1FF00E8A96803E60A28A2800A28A2803D83F6713FF170B501EBA549FF00A362AFA7EBE5FF00D9C467E215F9F4D2A4FF00D1B157D414005657899777853585F5B1987FE386B56B3B5F1BBC39AA2FADA4A3FF001C3401F08D14514005145140057D5BFB3F8C7C3143EB7931FE55F2957D63F00C63E16DB9F5BA98FF00E3D401E9D45145001451450015E23FB4A1FF008A6F441EB78E7FF1CAF6EAF10FDA53FE45DD0CFF00D3DBFF00E81400EFD9B0FF00C533AD0F4BC53FF8E0AF6DAF11FD9AFF00E45BD6CFFD3DA7FE815EDD4005145140051451400514514005145140051451400557BFB1B6D4F4FB8B0BC8965B6B88DA2951BA3291822AC51401F197C42F87BA9780B596866579B4D958FD92F00E1C7F75BD1C771F88E2B8DAFBDEFAC2D353B392CEFEDA1B9B69461E299032B0F706BE40F03F8474FF00177C469341BA967B7B5633956B72032EDC9039078E280387AECBE1EFC3DD4BC79ACAC30ABC3A6C4C3ED77847083FBABEAE7B0FC4F15EF3A57ECFFE0BD3E6596E7EDFA81073B2E27013F240A7F5AF4CB1B0B4D32CE3B3B0B686DADA21848A140AAA3D80A004B0B1B6D334FB7B0B38962B6B78D628917A2A81802ACD145001451450015F29F879BFB4BF692322F21B5AB975FF00754B91FA0AFA9EE674B5B59AE24FB912176FA01935F2C7C0C85F55F8B697D20CBC304F74C7DD86CFFDA9401F565145140051451400514514005717F169FCBF857E206F5B70BF9BA8FEB5DA570DF18BFE493EBF8FF9E51FFE8D4A00F37FD99A23BBC4D2E38C5B28FF00C8A7FC2BE81AF0AFD9A540D27C40FDCCF08FC95BFC6BDD6800A28A2800A28A2800A46557464750CAC30548C822968A00F9FF00E377C38F0D687E1D6F10E95666CAEDAE92378A16C42C1B393B3F84F1DB03DAB9CF86FF00066DBC71E1C5D6AE75A96D53CF788C11DB827E5C73B8B7BFA57A77ED07FF0024CC7FD7F45FC9A97F67DFF92643FEBFA5FE4B401D07847E16785BC1B22DC58D9B5C5F018FB5DD90F20FF778017F000D76945140051451400514514005145140185E2BF08E8FE32D21B4DD62DFCC8F3BA3910E2489BFBCA7B1FD0F7AF9E7C47FB3EF8A34D9DDF45920D5AD739501C45281EE18E3F23CFA57D4745007C51A97C39F17E91A7DC5FEA1A15CDBDADBAEE96572BB54671EBCF27B5753F07FE19D8F8EE7BBBDD52EA45B2B17456B68B8698904F2DD871DB93EA2BDDFE2FF00FC929D7FFEB8A7FE8C5AE07F669FF904F883FEBBC3FF00A0B5007B759595AE9B650D959411C16D0A048E28D70AA07602A7A28A0028A28A002B9FF17783746F1AE9274FD5E02DB72619E3E2485BD54FF43C1EE2BA0A2803E3CF895F0D27F8797569BB5286F2DAF4BF91852B200B8CEE5E9FC43907F0151F873E1278C3C51A75BEA361A7C4B6170098EE26B8450402413B725BA83DABB1FDA4AE8BF8BF48B4CFCB15879A07BB48C3FF006415EE3F0F2D96D7E1CF8722518CE9D0391EEC818FEA680380F037C03D3B42BA8B51F115C47A9DDC67725BA2FEE10FA9CF2FF8803D8D7B251450014514500145145001587E33E3C0BE213FF50CB9FF00D14D5B9589E3319F02F8807AE9B73FFA29A803C03F66FF00F91E3541FF0050D6FF00D191D7D355F32FECDE3FE2B7D50FFD435BFF0046475F4D50014514500145145001451450070BF19067E136BC3FE99C67FF0022A5701FB338FF0042F121F592DC7E9257A07C6338F84DAF7FD738FF00F46A579FFECD07FD07C463D25B7FE525007BCD145140051451400560F8E3FE49FF00893FEC1775FF00A29AB7AB0BC6BCF80FC443FEA1973FFA29A803C03F66FF00F91EF52FFB0637FE8D8EBE9CAF997F66FF00F91E3543FF0050D6FF00D191D7D354005145140051451401F247C125FF008BC1A68FEEADC7FE8A7AFADEBE4EF82E027C66B543C1FF004903FEF86AFAC6800A28A2800A28A28011955D191D432B0C10470457C2FE28D20683E2AD57490494B4BA922427BA863B4FE58AFBA6BE60FDA07C272E97E2D4F10C319FB1EA6A03B01C2CCA3047E2A01F7F9BD2803C7E8A28A0028A2A6B5B59EF6EE1B5B589E6B899C471C68325989C002803E96FD9C22917C0DA948C088DF516DBEF88D327FCFA57B1D735E01F0C0F07F82F4ED1CE0CF1A6FB861DE56396FC01381EC0574B40051451400579B78FBE0DE89E349A4D42DDCE9BAB37DE9E34DC929FF6D78C9F7183EB9AF49A2803E18D13C33A9F88F5FF00EC5D2A249EF4EFDAA5C2021739E4F1DABD2745FD9DBC4F793A9D5AF2CB4EB7CFCDB5CCD27E0071FF008F5667C156CFC64B53FDE5B9FF00D01ABEB1A00E5FC17E02D0FC0D60D06950169E403CFBA979925C7A9EC3D8715D45145001593E27D6D7C37E18D4759680CE2CE0697CA071BC8E833DB9EF5AD515CDADBDEDAC96D750473DBCAA5648A540CAE0F5041E08A00E2BE17FC416F883A2DDDD4D62B69716B3796E88FB958119046791DC63DABBAAE77C3DE0BD27C297F7D3E8909B582F4A34B6CA731AB2E79507A673C8E9C0C62BA2A0028A28A00F977F688D3A0B4F1FDB5DC43125E5923CBEECACC80FFDF2147E15E455EEDFB4AD848BAAE83A8ED26292092027D0AB06FF00D9BF4AF09A0028A28A002BD27E0C78AF45F07789EF351D6AE5E18E6B5FB347B232FCB3AB1271D86DFD6BCDAAC49018EC6DE56520CACF8CF751819FCF23F0A00FBD6391258D648D832380CAC0E4107A1A7552D1D4A689A7A1EAB6D18FFC7455DA0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00E5BE255D7D8FE1A788A5CE33612C7FF7D8D9FF00B357CE1F02ED7ED1F15F4D931916F14D29FF00BF6CBFFB357B9FC72B936FF09F545070667863FF00C8AA7FA57937ECE56E24F1EDFCE471169CE07D4C91FF00406803E9EA28A2800A28A2800A28A2800AF21FDA307FC5BBB2F6D523FF00D152D7AF5709F1874097C43F0D75286DD0BDC5AEDBB8D40C93B39603DF696A00F8EE8A28A0028A28A00F62FD9C07FC57BA91F4D2DC7FE458ABE9DAF05FD9BB40962B6D5FC412A15498ADA4048FBC07CCE7E99DA3F035EF5400552D606ED12FD7D6DA41FF008E9ABB557521BB4BBB1EB0B8FF00C74D007C1545145001451450015F5AFC0718F855627D6798FF00E3E6BE4AAFAE3E058C7C27D30FACB39FFC8AD401E8F45145001451450015E25FB498FF008A63453E978C3FF1C35EDB5E29FB49FF00C8ABA37FD7E9FF00D00D0027ECD83FE297D64FADEA8FFC7057B6578A7ECDBFF22A6B1FF5FC3FF405AF6BA0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BE52F830D9F8D109FEF7DA7FF416AFAB6BE4DF82C4FF00C2E5B3F7FB4E7FEFDBD007D654514500145145001451450073DE3CBC1A7FC3FF00105C9382BA7CC14FFB45085FD48AF12FD9AEC99F5FD72FF6FCB0DAA43BBDDDB38FFC72BD4FE32B94F84BAF15EBE5C43F3950570FFB356DFEC5D7F03E6FB4459FA6D38FEB401EE74514500145145001451450015C3FC61FF924FAFF00FD724FFD1895DC5711F17FFE4946BFFF005C53FF00462D00703FB349FF0089578847A4F09FFC75ABDD6BC27F669FF905F884FF00D3687FF416AF76A0028A28A0028A28A0028A28A00F27FDA18E3E1B443D750887FE3AF4BFB3D1CFC3571E97F28FFC752A2FDA28E3E1CDA8F5D4E21FF90E4A5FD9D8E7E1C5C8F4D4A51FF8E47401EB7451450014514500145145001451450014514500711F17FF00E4946BFF00F5C53FF462D703FB34FF00C82BC41FF5DE1FFD05ABBCF8C671F09B5E3FF4CE31FF009152B81FD9A0FF00C4BBC443D2580FE8F401EEF451450014514500145145007CC1FB477FC943B0FF00B0547FFA365AFA0FC19FF222F87F1FF40DB6FF00D14B5F3E7ED1DFF250B4FF00FB0547FF00A365AFA07C1073E01F0E1F5D2EDBFF00452D006F51451400514514005145140056378B867C17AF0F5D3AE3FF0045B56CD6378BBFE44AD7BFEC1D71FF00A2DA803C03F66E1FF1596AC7FEA1FF00FB512BE98AF99FF66EFF0091CB56FF00B07FFED44AFA62800A28A2800A28A2800A28A280382F8D071F08F5EFF761FF00D1D1D701FB331FF47F130FF6ADBF94B5DFFC69FF009247AEFF00BB0FFE8E8EB80FD99BFD4789BFDEB6FE52D007BE5145140051451400561F8D3FE444F10FFD832E7FF45356E561F8CFFE445F107FD836E7FF00453500780FECDFFF0023BEA9FF0060E3FF00A312BE9AAF99BF66EFF91DB54FFB071FFD1895F4CD0014514500145145007C9AE1FE1E7C7F0CFC4316A5B81FFA6137F82487F115F5957CAFFB426D5F89885386FB044588F5DCFF00D315F534649890B7DE2A09A0075145140051451400566EBDA0E9DE25D1AE34AD52DC4D6B3AE18742A7B329EC47635A545007C9DE33F823E25F0DDC493699049ABE9B92564B75CCA83D190739F75C8FA74AF369ADE7B694C53C324520E0A48A548FC0D7DF54607A5007C0D3DA5CDB2C6D716F2C4B20CC66442A1C7A8CF5AFA97E15FC26D37C2D6B6BAEDE3ADEEAF3421D1F6FC96E1867083D7071B8FE18E73C0FED27FF00233E8BFF005E4DFF00A19AFA03C3CC1FC33A530E8D6709FF00C705006951451400514514005145231DA8CDE833401F247C127CFC5FD30FF796E3FF004539AFAE2BE41F82271F17744F7138FF00C81257D7D40051451400514514005145140051451401C8FC48F06A78E3C1F71A62ED5BC8CF9D68EDD04A01C027D08241FAE7B57C6D7D6375A65F4D657B03C17503949629061948ED5F7BD7CF3FB4B59DB4579E1DBC8E08D6E675B8496555019C2F95B413DF1B9B1F5A00F06A2BA3F06782F53F1D6AF3699A54B6D1CF15B9B86372ECAA5432AE0100F3971FAD7A6E91FB36EAF24CA759D6ECA0873CADA2B4AC7DB2C140FD680389F877F0C354F1FDCC92C720B3D2E060B35DBAE727AED41FC4D8FC07E59F7CB8F81DE10BCB1B0B5B85BD3F62B616D1BA4DB491B99CB10060B167635DA7873C3D61E16D02D746D35196DADD700B9059C9E4B311D493CD6AD003511638D51461540007B0A75145001451450014514500145145001451450014514500145145007967ED02C57E1930FEF5EC23FF00423FD2B81FD9AD7FE2A3D6DBB8B441FF008FFF00F5ABBEFDA0467E18B1F4BD84FF00E855C1FECD7FF2306B9FF5EB1FFE87401F47D1451400514514005145140051451401F33FC56F83779A4DF4FAE786AD5EE74C949926B58972F6C7A9C0EE9F4E9F4E6BC62BEFFAF11FDA1F44D26DBC256BAAC1A75AC5A84BA8A46F731C415DD4C7212091D7903AD007CDD5DBF803E196B5E39BE8DA3864B5D2437EFAF9D7E5C0EA13FBCDF4E077AF4FF809E10F0EEB3E11B9D5353D1ED6F2F62D41E2492E137E1447190369E3AB1ED5EEE889146B1C68A88A30AAA3000F4028029E8DA459681A35AE95A745E55A5AC6238D73938EE49EE49C927D4D5EA28A00290804104641EA0D2D1401F0C78AB4397C37E2AD4F47994836B70C8B9FE24EAA7F1520FE358F5F52FC65F85D278BAD975BD1914EB16B1ED78781F698C72067FBC39C7A8E3D2BE5E9E09ADA7782E2278A68DB6BC72295653E841E868023A28A2800009380324D7DB3F0F34293C37E00D1B4B99764F15B86954F557725D87E0588FC2BC47E0D7C27BAD4351B6F136BD6CD0E9F03092D6DE55C35C38E8C41FE01D7DF8EDD7E94A0028A28A0028A28A002BC4BF6933FF14C68A3FE9F5BFF004035EDB5E23FB4A7FC8B7A27FD7DBFFE81400EFD9B0FFC52DAC8FF00A7D5FF00D0057B657897ECD9FF0022CEB5FF005F8BFF00A00AF6DA0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BE4CF82DFF2596CBFEDE7FF0045BD7D675F26FC161FF1796CFDBED3FF00A2DE803EB2A28A2800A28A2800A28A280384F8CDFF0024975EFF00722FFD1C95C0FECCED9B2F1227A496E7F3127F85779F1A4E3E11EBA7FD9847FE478EB80FD99BFD4789BFDEB6FE52D007BE514514005145140051451400570FF180E3E146BE7FE9920FFC8895DC5709F198E3E12EBC7FD8887FE464A00E13F6693FF12BF108F49A1FFD05ABDDABC1BF6673FE85E241E925B9FD24AF79A0028A28A0028A28A0028A28A00F20FDA38E3E1ED80F5D563FFD152D2FECE473F0EEF87A6A920FFC851545FB481FF8A134D5F5D4D4FF00E429297F6703FF001416A4BE9AA39FFC8515007B15145140051451400514514005145140051451401C2FC64FF924DAF7FD738BFF0046A5703FB347FC78788FFEBAC1FC9EBBDF8CA71F0975EFF722FF00D1C95C0FECCE7FD0BC483D24B7FE525007BCD14514005145140051451401F2FF00ED1DFF00250EC3FEC151FF00E8D96BE82F03FF00C93FF0DFFD82ED7FF452D7CF5FB454AB27C46B550798F4D895BEBE6487FA8AFA23C1B198BC0DE1F8D860A69B6CA7F08968036E8A28A0028A28A0028A28A002B27C50864F08EB518EAD6138FCE36AD6A86EE0175653DB9E92C6C87F118A00F9B7F66E61FF00099EACBDCE9E48FF00BF895F4C57CABF002E4D9FC50FB3B70D716734247B82AFFF00B257D55400514514005145140051451401C17C69FF009247AF7FBB0FFE8E8EB80FD99BFD4789BFDEB6FE52D77DF1ABFE4916BBF483FF0047C75C07ECCDFEAFC4FF005B5FFDAB401EFB4514500145145001585E3638F017888FA69973FF00A29AB76B03C7271F0FBC487D34ABAFFD14D401E07FB379FF008AE7531EBA6B7FE8C8EBE9BAF98BF6703FF15EEA43D74C7FFD1B1D7D3B4005145140051451401F297C6D3F6AF8C52C079012DE3FCD41FF00D9ABEADAF93FE30363E375D1F47B5FFD1695F58500145145001451450014514500145145007CF3FB4B5A32DF787AF31F2BC53444FA1050FF00ECC6BD7FE1D5FAEA5F0E7C3D72A73FE83146C7FDA41B1BF5535C87ED03A3FF00687C3AFB722E64D3AE5252475D8DF211F9B29FC2A8FECE9ADFDB7C1D7DA43B664D3EE7720F48E4191FF8F2BFE7401EC94514500145145001515D1DB69337A231FD2A5AADA89DBA65DB7A42E7F43401F237C163B7E2E6827FDA987FE4192BEC2AF8E7E0E1DBF167413FF4D241FF00909EBEC6A0028A28A0028A28A0028A28A0028A28A002BE4CF8E1E2D9BC45E3CB8D39268DF4FD1DDADE00B195224C2F9C589E49DEBB7D30831D493F4FF897529B46F0AEAFAA5BAC6D3D9594D711AC80952C885803820E323D457C29401EC1FB38FF00C943D43FEC1527FE8D8ABE9FAF983F671FF9287A87FD82A4FF00D1B157D3F4005145140051451400514514005145140051451400514514005145140051451401E5DF1FFF00E4984BFF005F90FF00335C17ECD43FE27DAEB7A5AC63FF001E35DCFED08FB7E1A01FDEBE887E8C7FA571DFB33C44DEF8926FEEC76EBF9990FF00ECB401F4351451400514514005145140051451400578EFED1E7FE282D357D75443FF0090A5AF62AF19FDA44FFC515A58F5D441FF00C86F4012FECE07FE280D457D35473FF90A2AF61AF1AFD9BCFF00C511AA0F4D498FFE438EBD96800A28A2800A28A2800AE67C4FF0FF00C31E2FF9F58D2E296E3181731931CA3D3E65E48F63915D351401E1BE22F801E18D3743D4F53B6D475506D6D659D237923232A8580FB99C715C6FECFBA4E9DAAF8D2F8EA16505D1B7B3F3611320608FBD46E00F19E7AD7D0FE363B7C05E226F4D32E4FF00E426AF01FD9BCFFC573A9AFAE9AC7FF22C7401F4DD145140051451400514514005788FED29FF0022DE89FF005F6FFF00A057B75788FED29FF22DE89FF5F8FF00FA05001FB367FC8B5AD7FD7E2FFE815EDD5E25FB367FC8B3AD7FD7E2FF00E802BDB6800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AF943E0C2E3E33DB8FEEFDA7FF406AFABEBE54F8383CBF8DA88DC366E971EFB5A803EABA28A2800A28A2800A28A2803CFFE36FF00C921D73FEDDFFF0047C75C0FECCDF73C4FF5B5FF00DAB5E81F1A86EF845AE8F680FF00E478EB81FD9987EE3C4CDEAD6C3F496803DF28A28A0028A28A0028A28A002B84F8CC33F0975EFF00722FFD1C95DDD70FF1846EF84FAF8FFA6487FF0022250079EFECCE3FD0FC487FE9A5BFF292BDEABC27F6681FF12CF10B7ACD00FD1EBDDA800A28A2800A28A2800A28A2803C6FF6901FF142E98DE9A928FF00C85252FECE03FE283D49BD75371FF90A3A77ED1FFF0022069DFF006144FF00D152D2FECE3FF24FB50FFB0AC9FF00A2A2A00F60A28A2800A28A2800A28A2800A28A2800A28A280381F8D471F08F5DFA43FF00A3E3AE07F6663FE8FE261FED5B7F296BBEF8D7FF00248B5DFA41FF00A3E3AE03F666FF0053E26FF7ADBFF6AD007BED14514005145140051451401F1EFC58BB7D77E2E6AD1C5C917096718F42A1508FFBEB35F5EDADBA5A59C36D1FDC86358D7E806057C6F68DF6EF8D3034BCF9FE2152DEFBAE39FE75F66D00145145001451450014514500145145007C93E052743F8FB6D0BFCBE56A7716A41FF6B7C7FD6BEB6AF92FE26AFF00C233F1C6E2FE1F9425DC17CB8F5C2B1FFC78357D69400514514005145140051451401C07C6C38F843AEFFDB0FF00D1F1D79FFECCA7E5F140F7B5FF00DAD5DEFC6F38F847AD7B983FF47C75C07ECCC7E7F138F516BFFB56803E81A28A2800A28A2800AE7BC79FF24F3C4BFF0060ABAFFD14D5D0D6078E867E1F78947AE9575FFA29A803C03F670FF9281A8FFD82DFFF0046C55F4F57CC5FB380FF008AF7523E9A5BFF00E8D8ABE9DA0028A28A0028A28A00F937E3371F1A2ECFFD7B1FFC8695F5957C9DF19FFE4B3DDFFDBB7FE8095F58D0014514500145145001451450014514500739E3EB317FF0F7C436C464B69F3328FF006950B0FD40AF07FD9C6FCC3E35D4AC8B616E2C0B81EAC8EB8FD19ABE95BBB75BBB29ED9FEE4D1B46DF42315F247C20B97D17E2F6970CFF00296965B4947B956503FEFAC5007D7B451450014514500154F56E346BE3FF004EF27FE826AE552D64E343D40FA5B49FFA09A00F90FE10FF00C956D03FEBB37FE8B6AFB26BE35F84871F157C3FFF005DCFFE80D5F655001451450014514500145145001451450073FE3BFF009279E26FFB055D7FE8A6AF882BEDFF001DFF00C93CF137FD82AEBFF45357C41401EC9FB37C13378EB53B858A43047A6323C814ED5669632A09E8090AD81DF69F4AFA6EBC03F665FF0099A7FEDD3FF6B57BFD00145145001451450014514500145145001451450014514500145145001451450078FF00ED1D2EDF87F6118EAFA9A7E42393FF00AD597FB34DBEDD1FC41738FF005971147FF7CAB1FF00D9AAE7ED227FE28ED247FD443FF69B549FB37A63C0BA9C9DDB5365FCA28FFC6803D928A28A0028A28A0028A28A0028A28A002BC67F691FF912B4AFFB088FFD16F5ECD5E35FB480FF008A1F4B3E9A92FF00E8B92800FD9BFF00E448D53FEC227FF45A57B2D78DFECDE3FE285D4CFAEA4DFF00A2A3AF64A0028A28A0028A28A0028A28A00E7BC7A76FC3CF129FFA85DC8FFC84D5E03FB389FF008B83A80F5D2A4FFD1B157BDFC41FF9273E24FF00B06DC7FE8B35E03FB39FFC945BCFFB05C9FF00A322A00FA8A8A28A0028A28A0028A28A002BC4FF006931FF0014B68CDE97AC3FF1C35ED95E2FFB488FF8A3B496F4D431FF0090DA8019FB368FF8A57596F5BE03FF001C15ED75E31FB370FF008A37566F5D431FF90D2BD9E800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AF92EFE46F879F1F64BA946C820D48CD9FFA6137271F44723EA2BEB4AF9CFF00692D1845ACE8DAD227FC7C42F6D230F543B973EE439FFBE6803E8B0410083907A114B5C9FC32D64EBDF0E343BD77DD28B710C84F52F192849F73B73F8D7594005145140051451401C27C66FF009249AF7FB917FE8E4AE03F667FF8F3F127FD74B7FE52577FF19467E12EBDFF005CE2FF00D1A95C0FECD03FD07C467FE9ADBFF27A00F79A28A2800A28A2800A28A2800AE27E2F7FC929D7FF00EB8AFF00E8C5AEDAB87F8C071F0A35F3FF004C907FE444A00E0FF669FF00903F883FEBE21FFD05ABDD2BC27F6693FF0012BF108F49A13FF8EBD7BB50014514500145145001451450078EFED1E7FE281D387FD4513FF454B4BFB381FF008B7DA80FFA8AC9FF00A2A2A67ED21FF222E99FF6135FFD15252FECE1FF002216A5FF006137FF00D151D007B1D145140051451400514514005145140051451401C0FC6A38F847AEE7D21FFD1F1D703FB331FF0047F130FF006ADBF94B5DE7C6DCFF00C2A1D73FEDDFFF0047C75C0FECCD9D9E28F4CDAFFED5A00F7EA28A2800A28A2800A28A2803E32B25F23E345BA7FCF3F10A8FCAE057D9B5F1C32FFC5F62A3FE866C7FE4CD7D8F40051451400514514005145140051451401F277C773E7FC57B9897EF08204FC4AE7FAD7D60060003B57C9FF183E6F8DF78A7A7996A3FF21C75F58D0014514500145145001451450079D7C723FF00169756F7783FF46A5701FB339FF4AF128FF62DBF9C95E83F1C067E126B07D1A03FF9192B80FD9987EFBC4CDE8B6A3FF46D007D054514500145145001587E331BBC0BE215F5D32E47FE426ADCAC7F160DDE0DD717D74FB81FF90DA803E7EFD9BC7FC56DAA37A69C47FE444AFA66BE6AFD9B47FC55DABB7A5863FF00222D7D2B4005145140051451401F297C6503FE1754DEFF0065CFFDF2B5F56D7CA5F1B7FD1FE30CB33F0BE5DBC99F60A07F4AFAB6800A28A2800A28A2800A28A2800A28A2800AF8FF00C68BFF000897C6FBDB88FE516DAA477AB8EC18ACBF97CD5F6057C8FF001D540F8B1A911DE2809FFBF6B401F5C75A2A1B4CFD8E0C9C9F2D727F0A9A800A28A2800AA1AEFF00C8BFA97FD7ACBFFA01ABF59DAF9C786F543E9692FF00E806803E44F84FFF00254FC3FF00F5F3FF00B2B57D995F18FC2938F8A5E1EFFAFAFF00D94D7D9D40051451400514514005145140051451401CFF008EFF00E49E789BFEC1575FFA29ABE20AFB7FC77FF24F3C4DFF0060ABAFFD14D5F105007D01FB32FF00CCD3FF006E9FFB5ABDFEBC03F665FF0099A7FEDD3FF6B57BFD001451450014514500145145001451450014514500145145001451450014514500787FED2972ABE1FD0ED49F9A4BA92403D95307FF004315B5FB3DDAB5BFC346948C0B9BF9651EE0054FFD92BCFBF691BF32F8BF49B0CE56DEC7CDC7A177607F4415ED1F0B34F1A6FC30F0F400637DA2CE7FEDA1327FECD401D7D1451400514514005145140051451400578EFED1E3FE282D34FF00D44D3FF454B5EC55E3FF00B477FC93ED3FFEC2B1FF00E8A968013F6701FF001406A27FEA28FF00FA2A2AF61AF20FD9C7FE49E5FF00FD8564FF00D15157AFD00145145001451450014514500739F1039F875E25FF00B065C7FE8B6AF01FD9CBFE4A25F7FD82E4FF00D1B157BE7C433B7E1C7890FF00D43671FF008E1AF02FD9D0E3E22DD8F5D3241FF9122A00FA8A8A28A0028A28A0028A28A002BC6FF6901FF143698DE9A928FF00C87257B2578F7ED1E3FE2DFE9E7D3558C7FE4296801BFB378FF8A17536F5D4D87FE428EBD8EBC7FF0067118F87B7E7D75593FF0045455EC14005145140051451400514514005145140051451400514514005793FED0B6A93FC378E661F3DBDF44EA7EA194FF3FD2BD62BCBBE3F827E184A474177093F99A00A5FB3A5CBCDF0FAF21739106A2EA9EC0A467F9935EBD5E2DFB36C80F847578B3F32DFEE3F8C6BFE15ED34005145140051451401C3FC6019F851AFFF00D724FF00D1895C0FECD3FF0020BF109FFA6D0FFE82F5DF7C6004FC28D7C0FF009E487FF2225701FB341FF89778887A4B01FD1E803DDE8A28A0028A28A0028A28A002B86F8C5FF249F5EFFAE71FFE8D4AEE6B88F8BE377C28D7C7FD3143FF009116803CFF00F668FF00907788BFEBB41FC9EBDDEBC2BF6691FF00129F1037ACF08FFC75ABDD6800A28A2800A28A2800A28A2803C77F68FF00F91074DFFB0A27FE8A969FFB3926DF8797CC7F8B54908FFBF51553FDA4A70BE14D1EDFBC97C5FF00EF9423FF0066ADBF8056DE47C2F824C7FAFBB9A4FC885FFD96803D428A28A0028A28A0028A28A0028A28A0028A28A00E07E348DDF08F5D1ED09FFC8F1D703FB330FF0047F1337ABDB0FD25AF41F8CC71F0935EFF00722FFD1C95C07ECCE7FD0FC483FE9A5BFF00292803DEA8A28A0028A28A0028A28A00F8E873F1E80F5F13FF00EDD57D8B5F1F20FF008C8155FF00A9A71FF9355F60D00145145001451450014514500145145007CA1F1886DF8DB727D5AD4FFE3895F57D7CABF18933F1B987F78DAFFE82B5F55500145145001451450014514500701F1B06EF845AEFB7907FF23C75C07ECCC3E5F1437A9B51FF00A36BBDF8DD2AC5F0935907AC86055FAF9C87F9035C5FECD3015D27C41718F9649E1407FDD563FF00B35007BAD145140051451400565F8946EF0AEB0BEB6330FF00C70D6A5677883FE45BD53FEBCE5FFD00D007CFDFB360FF008A9B5A6F4B351FF8F8AFA4ABE70FD9AFFE460D73FEBD63FF00D0EBE8FA0028A28A0028A28A00F9AFF690D25A0F14695AB05FDDDD5A1809C7F1C6C4FF00271F957B9780F5B1E22F0268DA9EE05E5B65594FFD345F95FF00F1E535C4FED09611DCFC394BA23F79697B1BAB7B302A47EA3F2A4FD9E2EDEE3E1C4D0B1245B6A1246BEC0AA37F363401EB3451450014514500145145001451450015F2B7ED0760F6BF1216E48F92EECE3914FBAE508FFC747E75F54D78A7ED1DA22DCF8634CD6917F7967726173FEC483FA328FCE803D53C2BA9C7ACF84F49D463395B8B48E43EC4A8C8FC0E47E15AF5E53FB3EEAAD7FF000E0D9BB65AC2EE485413FC0D871FAB37E55EAD40051451400565F894E3C2BAB9F4B29BFF004035A9597E25E7C2BAC0FF00A729BFF403401F217C2E38F89FE1DFFAFC5FEB5F68D7C5DF0BBFE4A7F877FEBF17FAD7DA340051451400514514005145140051451401CFF8EFFE49E789BFEC1575FF00A29ABE20AFB7FC77FF0024F3C4DFF60ABAFF00D14D5F105007D01FB32FFCCD3FF6E9FF00B5ABDFEBC03F665FF99A7FEDD3FF006B57BFD0014514500145145001451450014514500145145001451450014514500145145007CB1FB43A91F126127F8B4F888FFBE9EBE8DF07E3FE108D036FDDFECEB7C7FDFB5AF9EBF68E503E21581F5D2A3FFD1B2D7BF780D8B7C3CF0D13D7FB2EDBFF00452D00743451450014514500145145001451450015E3BFB479FF008A074E1EBAA21FFC852D7B1578D7ED207FE288D2D7D75107FF0021BD0049FB381FF8B7FA80F4D5643FF90A2AF61AF1AFD9BCFF00C50FA9AFA6A4C7FF0021C75ECB400514514005145140051451401CB7C493B7E1AF88CFFD384A3FF1D35E05FB3C1C7C49987AE9D28FFC7D2BDF7E248DDF0D7C463FE9C253FF008ED780FECF033F12663E9A7CA7FF001E4A00FA9E8A28A0028A28A0028A28A002BC83F68EFF00927961FF006158FF00F454B5EBF5E45FB460CFC3AB33E9AA467FF21CB400DFD9CBFE49E5F7FD8564FF00D15157AFD791FECE831F0E6ECFAEA729FF00C871D7AE50014514500145145001451450014514500145145001451450015C67C57D1DF5BF865ADDAC4A5A58E11708075CC6C1CE3EA148FC6BB3A46557464750CAC304119045007CE7FB36EB2B06B5ACE8CED83730A5C460FAA12180F721C7FDF35F46D7C8FE1A56F03FC79B7B304A4506A8D67CF78A425013FF0001606BEB8A0028A28A0028A28A00E7FC73A63EB1E04D72C2305A49ACA51181DDC292A3F302BC43F66CD563835ED6B4A76C3DD5BC73460F7F2C9047D7127E95F47D7C95784FC2FF008E6D28568ECEDEF7CC0077B6947207AE1588FAAD007D6B45351D248D648D8323005594E4107B8A7500145145001451450015C67C5A19F857E20FFAF71FFA1AD7675E2DFB435E788AD342B25B197CBD0E72D15E84C659CE0A86EF8C03D3B8E7B50056FD9A87FC48B5E3EB731FFE826BDCABC47F66C89C786B5B948F91AF1541F521327F98AF6EA0028A28A0028A28A0028A28A00F03FDA65C883C329D8B5C93F808BFC6BD0BE0E4221F84DA0A8EF1C8FF009CAE7FAD79BFED332A993C3308FBCA2E5CFD0F9407F235EA7F0B2230FC2FF0F2918CDA2B7E649FEB401D7D145140051451400514514005145140051451401C17C68FF9247AF63FBB0FFE8E8EB81FD99FFE3DBC4BFEFDB7F292BD03E328CFC25D787FB111FF00C8A95C0FECD03FD07C467D65B71FA49401EF3451450014514500145145007C7CA7FE32041FFA9A7FF6EABEC1AF90553FE321B6FF00D4D39FFC9AAFAFA800A28A2800A28A2800A28A2800A28A2803E5DF8BA99F8E96E3FBCD69FD2BEA2AF977E2E93FF0BD2DCFA35A63F4AFA8A800A28A2800A28A2800A28A2803CABF68398C7F0CC203C4B7D121FC98FF004A8FF678B610FC389A5C7CD3EA12393F4545FE94EFDA19377C358CFF00735088FF00E3AE3FAD58F805FF0024BA0FFAFA9BF9D007A7D1451400514514005676BFFF0022E6A9FF005E92FF00E806B46B33C4876F85B573E96531FF00C70D00781FECD7FF0021FD77FEBD63FF00D08D7D1F5F377ECD67FE2A5D6C7AD9A1FF00C7EBE91A0028A28A0028A28A00F32F8F59FF008559778FF9F9873FF7D5647ECDE47FC20BA98CF23536FF00D151D765F15F4A3AC7C30D7ADD465E3B7FB42E3AFEEC893F9291F8D798FECD5A99FF0089FE94C78FDD5CA0FCD5BFF65A00FA028A28A0028A28A0028A28A0028A28A002B8CF8B1A67F6AFC2FD7A00B968EDFED0BEDE590E7F4535D9D66788D55FC31AB230CAB594C0FD361A00F0FF00D9A750C5C78834E63F79619D07A60B2B7F35AFA0EBE62FD9C19878F7525FE13A5B93F512C5FE26BE9DA0028A28A002B3BC4037786B555F5B3947FE386B46A8EB237685A82FADB483FF001D3401F1FF00C2A1BBE28F8787FD3D03FA1AFB3ABE34F848377C55F0F8FF00A7827FF1C6AFB2E800A28A2800A28A2800A28A2800A28A28039FF1DFFC93CF137FD82AEBFF0045357C415F73F8B2C6E353F06EB961671F997575A7CF0C29B80DCED1B05193C0C923AD7C31401F407ECCBFF334FF00DBA7FED6AF7FAF00FD997FE669FF00B74FFDAD5EFF004005145140051451400514514005145140051451400514514005145140051451401F307ED1DFF250B4FF00FB0547FF00A365AF7FF022EDF87BE1A1E9A55AFF00E8A5AF02FDA3C7FC57FA71F5D2D07FE4596BE81F058C7813C3C3D34CB6FF00D14B401B9451450014514500145145001451450015E2FF00B48E7FE10DD24F6FED0FFDA6F5ED15E35FB480FF008A1F4C6F4D4947FE4392801BFB3767FE10BD54F6FED03FFA2D2BD9EBC6FF0066F1FF00142EA6DEBA9B0FFC851D7B2500145145001451450014514500735F10C6EF871E241FF50D9CFF00E386BC07F67419F88D767D34C94FFE448EBE82F1E8DDF0EFC4A3FEA17727FF002135780FECE233F107503E9A549FFA362A00FA7E8A28A0028A28A0028A28A002BC93F68919F8716FEDA945FF00A0495EB75E4FFB437FC9368BDB508BFF00417A006FECEE31F0DE7F7D465FFD023AF5AAF28FD9E47FC5B593DF5097FF00414AF57A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F94BE3645FD93F1864BE8C6D6912DEE863D5405CFF00E395F5602194303904641AF9A3F691B5D9E32D2AEC0FF5B61E5FD4AC8C7FF66AFA1FC3F73F6CF0DE97740E7CEB38A4CFAE501FEB401A345145001451450078DFED11AAEA1A77867498ECAF27B659EE9BCDF25CA1701720123B64F4AE03E26583EA3F0C7C13E2AB991A5BF92016771339CB4A3059093DC8DADCF7CD767FB4A7FC8BDA1FFD7DBFFE815C778D35DD22E7E05F85F44875081F54B69219A5B656CBA2149064FF00DF4BC75E6803DABE10EA52EA9F0B3439E762D247134049F48DD917FF001D515DBD79B7C08903FC29D3D47FCB39A753FF007F09FEB5E93400514514005145140057897ED25A9343E1AD1B4C0702E6EDE63EE235C7FED4FD2BDB6BC57F690D2E4B8F0B695A920052CEE9A37E7902451CFE683F3A00D6FD9F6248FE190655C3497B2B39F53851FC80AF54AF2EF801FF0024C22F7BC9BF98AF51A0028A28A0028A28A0028A28A00F96BF684D4CDEFC448AC54E56C6CE38C8FF00698973FA32FE55F4A681A7FF006478734CD3718FB25A4507FDF2807F4AF95FE28E5FE38EA224E41BBB7073E9E5C7FD2BEB9A0028A28A0028A28A0028A28A0028A28A0028A28A00E23E2F8DDF0A35F1FF004C50FF00E445AE07F6691FF129F1037ACF08FF00C75ABD03E2E7FC92AF107FD705FF00D0D6B81FD9A7FE40DAFF00FD7C45FF00A0B5007B9D14514005145140051451401F2428FF008C8CC7FD4CA4FF00E47AFADEBE4753FF0019199FFA9988FF00C98AFAE2800A28A2800A28A2800A28A2800A28A2803E5FF8BA3FE2FADA7BB5A7F315F5057CC1F173FE4BB59FFBD69FCC57D3F400514514005145140051451401E5BFB407FC93093FEBF21FEB47ECFE73F0C507A5E4C3F952FC7FFF00926127FD7E43FD693F67F18F8629EF7937F4A00F52A28A2800A28A2800ACCF127FC8AFABE7FE7CA6FF00D00D69D66F8846EF0CEAA3D6CE61FF008E1A00F00FD9AFFE464D6FFEBCD3FF0043AFA46BE70FD9AC7FC545AE1F4B441FF8FD7D1F40051451400514514015B51B617BA65DDA10089E178F07FDA523FAD7CD3FB39CDE57C41BE81B23CCD35C63DC4919FE59AFA7EBE5EF83E059FC72BAB61F2806EE203E84F1FA5007D434514500145145001451450014514500158FE2C90C5E0DD7241D534FB86FCA36AD8ACFD7ACDB51F0EEA764832F71692C2BF56423FAD007CEDFB3781FF09B6A87B8D388FF00C8895F4CD7CADFB3E5F2D9FC4B6B690E0DE594B0A83DD8157FE486BEA9A0028A28A002AAEA43769578BEB038FF00C74D5AA86EC6EB29D7D6361FA5007C7DF0786EF8B1A00FFA6B21FF00C84F5F63D7C79F0606EF8B7A08FF006A63FF00905EBEC3A0028A28A0028A28A0028A28A0028A28A002BE14F12E9B0E8DE2AD5F4BB7691A0B2BD9ADE369082C551CA827000CE07A0AFBAEBE40F8DBFF00257B5DFF00B77FFD111D007A07ECCBFF00334FFDBA7FED6AF7FAF08FD9A2C6E23D3BC457ED1E2D669608637DC3E6740E5863AF0244FCFD8D7BBD0014514500145145001451450014514500145145001451450014514500145145007CC9FB487FC8F3A61FFA86AFFE8D92BE81F077FC891A07FD836DFF00F45AD7CFFF00B487FC8EFA5FFD8357FF0046495F407843FE449D07FEC1D6FF00FA2D68036A8A28A0028A28A0028A28A0028A28A002BC7BF68F1FF16FF4F6F4D5231FF90A5AF61AF1FF00DA38FF00C5BED3C7AEAB1FFE8A96800FD9C463E1EEA07D75593FF45455EC15E3FF00B389CFC3DBF1E9AAC9FF00A2A2AF60A0028A28A0028A28A0028A28A00C2F1B0DDE01F11AFAE97723FF002135780FECDE3FE2BAD4DBD34D61FF009163AFA07C5E3778275E5F5D3AE07FE436AF02FD9B87FC565AB37A69F8FF00C889401F4BD145140051451400514514005794FED09FF24D17FEBFE2FE4D5EAD5E57FB410CFC33CFA5F447F46A004FD9F3FE4999FF00AFE97F92D7AAD795FECFA31F0C81F5BD94FF00E835EA940051451400514514005145140051451400514514005145140051451401E1FF00B48E8ED3E83A3EB08A4FD9677824C7A480104FE298FC6BB4F839AD2EB5F0C3496DD996CD0D9C83D0C7C2FF00E39B4FE3567E2CDA4179F0B75F49C0DA96FE6A9C746560CBFA8AF3FF00D9AA695B44D7A03FEA52E6275FF799483FA2AD007B9D145140051451401E21FB4A29FF008473436C702EDC1FFBE2B9FD07E05DAF8BBC21A56B96BAE49673DD5B29789EDC489B87CA7077023A7BD773FB41D87DAFE1BADC08CB35A5EC726E03EE82194E7DBE61FA5687C0D96693E14698B32B011C932C658755F318F1EA3248FC28037FC03E0F8FC0FE1587464BB6BA757696494AED059BAE07381D3BD74F451400514514005145140057967ED0271F0C9BDEF62FFD9ABD4EBCB7F68019F862E7D2F213FCE800FD9FCE7E18A7B5E4DFD2BD4ABCBBE000C7C308CFADE4C7F957A8D001451450014514500145145007C95F190083E34DFCA48505AD9C93D062241FD2BEAFB4BBB7BFB386EED268E7B79903C72C6D95753D0835F38FC61F02F8975CF8A7E6E9BA4DCDC417D1C2B14F1A131A90A14EF61C2E31DFB57BFF008674387C35E1AD3F4681CBA5A4223DEDD58F527F1249A00D5A28A2800A28A2800A28A2800A28A2800A28A28038CF8B233F0B3C41FF005EE3FF00425AE07F66A1FF00121D78FADCC63FF1D35ECDAA69969ACE9773A6DFC226B4B98CC72C6491953EE391F5ACCF0A783B46F05E9D258E8D6ED1C72C9E648D2397676C63927D076A00DEA28A2800A28A2800A28A2803E4B54FF8C8FC7FD4C64FFE46CD7D695F29281FF0D2B8FF00A8F93FF8FD7D5B40051451400514514005145140051451401CCEAFF0FF00C37AEF896CFC41A85879BA85AEDD8FBC856DA72BB9470D83FF00D7C8AE9A8A2800A28A2800A28A2800A28A2802A6A5A658EB1A7CB61A95AC5756928C3C52AEE53DC7EB469BA658E8FA7C561A6DAC56B6910C24512ED51DCFEB56E8A0028A28A0028A28A002AA6A96CF7BA4DEDAC64092681E352DD325481FCEADD1401E27F02FC0BE21F0AEA7AD5D6B7606CD248D218C33A92E4124918278E9CFBD7B6514500145145001451450015E0FA67C3BF12695FB403EB76F658D21AEE6BA375BC6CD922B6E5C6739CB118C7BF4E6BDE28A0028A28A0028A28A0028A28A0028A28A0028A28A00F923C5F6B3FC34F8CE6FA08C8823BB5BFB751C0789CE4A8F6FBE9F857D61657906A3616F7B6B2092DEE23596271D1958641FC8D78E7ED1DA3433F85B4DD64281716B75E416EE6375271F8151F99AE97E076A32DFFC2CD396524B5AC92DB863DD43123F20C07E1401E8B451450014D906E89D7D548A751401F207C1219F8BBA1FB79E7FF20495F5FD7C85F043FE4AE68DFEECFF00FA21EBEBDA0028A28A0028A28A0028A28A0028A4041CE0F43834B40057C69F16755B1D6BE27EB57FA6DCC77568EF1A24D19CAB148911B07B8DCA791C1EA322BECBAF802803E9FF00D9C7FE49E6A1FF0061593FF45455EC15E77F053C353786FE1CDA99EE2399F5371A88080E2359234DAB93D4ED504F03924738C9F44A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F997F690FF0091DF4BFF00B070FF00D18F5F40F843FE44AD07FEC1D6FF00FA2D6BC03F6911FF001596927D74FF00FDA8F5F40F85063C1DA20F4D3E0FFD16B401AF451450014514500145145001451450015E37FB481FF8A174C1FF005135FF00D15257B2578DFED21FF223699FF6125FFD1725002FECE07FE283D487FD44DFFF0045475EC75E39FB37FF00C889A9FF00D84DBFF45475EC740051451400514514005145140193E281BBC23AD2FAD84E3FF21B57817ECD83FE2AAD65BD2C80FF00C7C57D13A95A1D434ABCB20FB3ED103C5BB19C6E5233FAD7967C1CF867AD781B52D56F35892D7F7F1AC312C0E5F7007258F0303A63BFD2803D768A28A0028A28A0028A28A002BCB3F681FF009264DFF5FB17FECD5EA75E5DFB400CFC3090FA5E427F9D0027ECFF00FF0024C53FEBF26FE95EA55E5DF00063E17C47D6EE63FA8AF51A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00E3BE2B7FC92DF10FFD7AFF00ECC2BCFF00F66AFF009016BDFF005F31FF00E8268A2803DC68A28A0028A28A00CED7FF00E45FD43FEBDDFF00952E85FF00200D3FFEBDD3F90A28A00D0A28A2800A28A2800A28A2800AF2EF8FFF00F24C24FF00AFC87FAD145002FC01FF00925F0FFD7DCDFCC57A8514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145007CA6BFF00272DFF0071E3FF00A1D7D59451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451401E55FB41FF00C9331FF5FD17F26A77ECFDFF0024C57FEBF66FFD968A2803D4E8A28A0028A28A00F90BE087FC95CD1BFDD9FF00F44BD7D7B4514005145140051451400514514014B49FF9072FFD7493FF00436ABB45140057C01451401F6FF813FE49E7867FEC156BFF00A296BA0A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F9A3F691FF91C749FFB07FF00ED46AFA03C2BFF0022868BFF005E107FE8B5A28A00D7A28A2800A28A2800A28A2800A28A2800AF1BFDA43FE446D33FEC24BFFA2E4A28A005FD9BFF00E444D4FF00EC26DFFA2A3AF63A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCC3E3EFFC92EB8FFAFA87F9D145002FC03FF925B6DFF5F537FE855E9D45140051451400514514005145140051451401FFD9, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (26, N'илоачло   ', N'Пионино 2', CAST(8500.00 AS Decimal(18, 2)), 19, 3, 25, N'Пионино новое', 4, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (35, N'12345     ', N'Медиатор тонкий', CAST(40.00 AS Decimal(18, 2)), 0, 3, 45, N'Медиатор толщиной 1 мм', 4, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (43, N'sgdfgdgsrg', N'Медиатор толстый', CAST(45.00 AS Decimal(18, 2)), 6, 3, 45, N'Медиатор для бас-гитары', 4, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (44, N'чсмлоявами', N'Медиатор для электрогитары', CAST(36.00 AS Decimal(18, 2)), 3, 2, 45, N'Медиатор для гитары и электрогитары', 3, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (45, N'мявапвапва', N'Медиатор совместимый', CAST(78.00 AS Decimal(18, 2)), 42, 1, 45, N'Медиатор для всех струнных инятрументов', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (48, N'fsdafadggd', N'Набор медиаторов 10 шт.', CAST(120.00 AS Decimal(18, 2)), 12, 1, 45, N'Упаковка медиаторов. 10 медиаторов, 4 из которых толщиной 0,5 мм, 3 толщиной 1 мм, 2 толщиной 1,5 мм, и 1 толщиной 2 мм. Подходят для любого струнного инструмента. упругие. Не цепляют струны. Сделаны из экологичного материала.', 1, 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080281028103012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A42C14A82402C703DFBD002D1451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400572DE29D70697AEF86EDBFE7BDE12FCF41B4C7CFB664CFF00C06BA9AF10F89DA8B5C78CDA38DB1F638923054FF17DF27EBF363F0AC6BCF92173D5C9B08B1589E47B59FE56FD4F6FA2AAE9978BA8E95697AA302E214971E9B8038AB55B277D4F2E51716E2F74145145020A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28011982A96620281924F6AF9A757BD3A96B17B7C7FE5BCCF201E809C81F957BD78CAFF00FB37C23A95C6EC3184C69EBB9FE518FCF3F857CF15C38C96AA27D870BD1B46A567E4BF57FA1EE7F0C6FF00ED9E0D862272D6B2BC2727B6770FD1B1F857635E4BF082FF0066A1A8E9EC7FD6C4B32FFC04E0FF00E843F2AF5AAE8A12E6A68F0B39A3EC71B517777FBF50A28A2B63CC0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803CEBE2E6A1E568D6560AF869E632301DD5477FC587E55E415DBFC53BFF00B578B7ECC1895B485508EC18FCC4FE457F2AE22BCAC44B9AA33F47C968FB2C0C177D7EFF00F80745E05BFF00ECEF19E9B21276492790C077DE368FD483F857D055F2EC7234522C884ABA10CA47622BE99D3EED750D36D6F50616E225940F40C01FEB5D183968E2785C5146D529D65D55BEEFF872CD14515DA7CA851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514562F8B6FFF00B33C27A9DD02C1840510AF50CDF2A9FCD8526ECAE694A9BA95234E3BB76FBCF04D6EFF00FB535CBEBEC92B3CEEEB9EA173F28FC060550A28AF15BBBB9FAAC20A11515B20AF75F8697FF6DF065BC64E5ED64781BF3DC3F4603F0AF0AAF4DF841A86DBBD474E627E7459D07618386FFD097F2AE8C2CAD53D4F1F8828FB4C1397F2B4FF004FD4F57A28A2BD33F3E0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AF3DF8B97FE4E856762A486B99CB9C742A8391F9B29FC2BD0ABC53E2ADFF00DA7C56B6A09DB6902A919FE26F989FC8AFE55862656A6CF6321A3ED71D1ED1BBFEBE76386A28A2BCA3F440AE93C077FF00D9FE33D3DCB1092BF90DEFBC607EA47E55CDD3E295E09A39A36DB246C194FA11C8AA8CB964998D7A4AB529537D535F79F50D15058DD477D616F7711CC73C4B22FD08CD4F5ED1F9534E2ECC28A28A0414514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015F366BD7FFDA9AFDFDF0FBB34ECCBCE7E5CF1FA62BDEFC557FF00D99E15D4AEC1C32C0CAA7D19BE55FD48AF9CEB87192DA27D7F0BD1D2A567E4BF57FA0514515C27D6851451401EEFF0DF50FB7F82ED54B167B6668189F6391FF8EB2D75B5E55F08350C4FA969ACC7E6559D07A60ED6FE6BF957AAD7AF425CD4D33F35CDE8FB1C6D48F777FBF50A28A2B53CD0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803CFFE2D5FF91E1FB5B252035CCFB88F554193FA95AF1BAEF3E2BDFF00DA7C4F15A2B02B6B000C3D19BE63FA6DAE0EBCAC44B9AA33F45C8E8FB2C0C3BBD7EFFF008160A28A2B03D70A28A2803A7F87FA87F67F8D2C096C24EC606F7DC303FF001EDB5EFB5F2FDBCF25ADCC5710B6D92270E8DE841C8AFA6AD2E63BCB382EA2398E68D644CFA1191FCEBD0C1CB4713E3389E8DAAC2AAEAADF77FC393514515D87CB05145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514565789750FECBF0D6A37BBF6347036C6FF006C8C2FFE3C4526ECAE5D383A93508EEDD8F03F11DFFF006A788F50BD0C19259D8A11DD01C2FE80566514578ADDDDCFD5A9C1538284765A05145148B0A28A2800AF7AF8757FF6FF0005D98662D25B9681B3DB69E07FDF256BC16BD47E105FF3A969CCDFDD9D17FF001D63FF00A0D74E1656A96EE785C4347DA609CBF95A7FA7EA7A9D14515E99F00145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C17C58D43ECDE1A82C95F0F7738DCBEA8A327FF001ED95DED78CFC58D43ED1E24B7B256252D60195F476393FA05AC3112E5A6CF5F23A1ED71D0ECB5FBBFE0D8E068A28AF28FD1428A28A0028A28A002BA9F879A87F67F8D2CB2DB63B8CC0DEFB8703FEFA0B5CB54B6B70F69770DCC47124322C8A7DC1C8AA84B9649986268AAD46549F54D1F4FD1515B5C25DDAC37311CC7322C8A7D4119152D7B47E56D34ECC28A28A041451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450035DD238DA4919551412CCC70001DCD7CDDAFEA6DACEBD7BA81CE2794940DD42F451F800057B3FC46D57FB33C1F708AD896EC8B75FA1FBDFF8E823F1AF07AE0C64F5513ECB8670D684F10FAE8BF5FEBC828A28AE23EA828A28A0028A28A0028A28A00F7CF87BA80D43C1763960D25B830381DB69E07FDF3B6BA8AF28F845AA15B9BFD29DCED751711A9E808F95BF120AFE55EAF5EBD0973534CFCD737A1EC31938F46EFF007EA1451456A79A14514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500790FC5DD43CDD5EC74F5276C10995BD32E71FC97F5AF39AE8FC7777F6CF1AEA6E0F0920880F4D8029FD41AE72BC8AD2E6A8D9FA6E5947D8E0E9C3CAFF7EA14514564778514514005145140051451401BBE0DD43FB33C5FA6DC13F299844FE9B5FE527F0CE7F0AFA1EBE5C562AC19490C0E411DABE9BB0BA5BED3AD6ED7EECF124A3E8C01FEB5DF83968E27C771451B4E9D55D6EBEEFF0087658A28A2BB4F940A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28ACBF11DF1D37C37A95DA394922B7728C3B3630BFA9149BB2B974E0E73505BBD0F9EF56B917BACDF5D29C89EE24901C75CB13FD6A9D14578ADDDDCFD5E31518A8AE814514522828A28A0028A28A0028A28A002BDFBE1FDF9BFF0005E9ECCDB9E153037B6D3803FEF9DB5E035EBBF082590E91A8C45D0C693AB2A83F30257927D8E063E86BAB08ED52DDCF0388E929E0F9BF95AFF2FD4F47A28A2BD23E0828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B8CF8A375F67F05C917FCFC4F1C5F91DFFF00B2D7675E71F17E7DBA469D6F9FBF3B3E33FDD5C7FECD595776A6CF4729873E3A9AF3BFDDA9E45451457907E961451450014514500145145001451450015E91F082EB6EABA95A7FCF48165FFBE5B1FF00B3D79BD769F0BA7F2BC671A7FCF68244FE4DFF00B2D6D41DAA23CDCDE1CF81A8BCAFF76A7B8514515EB1F9A851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514521200C93803A9A0086EAEA3B487CC9338CE001D4D4CACAE8AEA72AC320FAD72FA95E9BCB9CA9FDDA7083FAD5DD12FB07ECB21E0F3193FCA83B278471A5CDD4DCA28A2838C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCBBE319E3451FF5DFFF0069D7A8D7987C624262D1DF1C069867EBB3FC2B0C4FF099EB645FF230A7F3FC99E55451457947E8C1451450014514500145145001451450015D57C3838F1E69BEFE6FFE8A7AE56BACF86C85BC756040FB8B293FF7ED87F5AD297C6BD4E3CC3FDD2AFF0085FE47BC514515EC1F97851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400563EB57DB13ECB19F9987CE7D07A5685EDD2D9DB34ADC9E8A3D4D72723B49233B9CB31C9341DB83A3CD2E77B21B4A09560CA4820E411DA928A47AA757A7DE0BCB60C71E62F0E3DFD6ADD7256376D6772B20C953C38F515D62B2BA2BA9CAB0C83EB4CF1B1347D9CB4D98B45145073051451400514514005145140051451400514514005145140051451400579F7C5C8777872CE6C731DD85CFA02ADFE02BD06B97F887666F3C137E1572D16D947FC05867F4CD67595E9B477E5753D9E329C9F75F8E8781D14515E39FA68514514005145140051451400514514005777F09E0F33C5934847115A3B038EE5947F535C257A9FC1FB4E354BD61FF003CE243F996FF00D96B6C3ABD447979CD4E4C0D47E56FBDD8F51A28A2BD63F370A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A42401927007534B58FAD5F6C4FB2C67E661F39F41E941A52A6EA494519DA95E9BCB9CA9FDDA7083FAD52A28A47B908A8454505145141415B5A25F60FD9643C1E6327F9562D282558329208390476A0CEAD35523CACED68AA9A7DE0BCB60C71E62F0E3DFD6ADD33C3945C5F2B0A28A282428A28A0028A28A0028A28A0028A28A0028A28A0028A28A002A0BDB58EFEC2E2CE5FF00573C6D1B7D08C1A9E8A069B8BBA3E5FB8824B5B996DE65DB244E51C7A10706A3AEC3E2569274DF16CD3A2621BD513AE071BBA37E3919FF0081571F5E34E3CB2713F53C2D755E8C6AAEA828A28A83A028A28A0028A28A0028A28A002BDE3E1CE9ADA6F836D8B8224BA6372C0FA3602FFE3A14FE35E25A669F2EABAA5B58418F32E24118247033DCFB0EBF857D296F025ADAC56F102238902283E8060576E0E3AB91F2DC4F88E5A50A0BABBBF97F5F812D14515DE7C605145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514521200C93803A9A0082F6E96CED9A56E4F451EA6B9391DA4919DCE598E49AB7A95E9BCB9CA9FDDA7083FAD52A47B185A3ECE377BB0A28A283A828A28A0028A28A00B36376D6772B20C953C38F515D62B2BA2BA9CAB0C83EB5C556D6897D83F6590F0798C9FE541C38CA3CCB9D6E8DCA28A299E5851451400514514005145140051451400514514005145140051451401C77C48D04EB1E1A6B88973736399900EE9FC63F219FF0080D78657D49D460D782F8F3C32FE1FD75DE28C0B0BA6324057A2FAA7B609E3DB1EF5C38BA7F6D1F5FC378E567859BF35FAAFD7EF395A28A2B84FAD0A28A2800A28A2800A28ABBA4E9773AD6A90585A2EE9666C67B28EEC7D80E69A4DBB226728C22E527648EF7E13E83E6DDCDAE4CBF24398A0CF7723E63F8038FF00811F4AF5AAA7A569B068FA55B69F6C311408141EE4F727DC9C9FC6AE57AF4A9F242C7E6798E31E2F112ABD365E9FD6A145145687085145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400563EB57DB13ECB19F9987CE7D07A5685E5D2DA5B34ADC9E8A3D4D727248D2C8CEE72CC724D076E0E8F34B9DEC86D145148F5428A28A0028A28A0028A28A0029412AC1949041C823B5251401D5E9F782F2D831C798BC38F7F5AB75C958DDB59DC89064A1E1C7A8AEB1595D0329CAB0C823BD33C6C4D1F673D3662D145141CC145145001451450014514500145145001451450014514500159BAEE8B6BE20D265D3EED7E57E51C0E6361D187BFFF005C77AD2A29349AB32A13953929C1D9A3E6CD7344BDF0FEA7258DEC7B5D79471F7645ECCA7D2B3ABE90D7BC3FA7F88AC0DADF459C64C722F0F19F507FA7435E2DE24F036ADE1D7790C6D75623917312F007FB43F87F97BD79B5B0EE0EEB63EFB2CCEA962A2A151F2CFF0007E9FE473145145731EE0514569E8DE1FD4F5FB95874FB5790670D291844FAB741FCE9A4DBB22275214E2E537648CF86196E6748208DA496460A88832589E800AF74F03783D3C356067B90ADA94EBFBD6073E5AF5D80FF0033DCFD053FC25E07B1F0CC6B3BE2E75161F34E47099EA10761EFD4FE95D557A3430FC9EF4B73E2739CEBEB3FB9A1F0757DFF00E00514515D47CE05145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400504803278028AC7D6AFB627D9633F330F9FD87A50694A9BA92514676A57A6F2E7E53FBA4E107F5AA545148F7211508A8A0A28A282828A28A0028A28A0028A28A0028A28A002B6B44BEC1FB248783CC67F98AC5A504AB06524107208ED419D5A6AA47959DAD15534FBC1796C18E3CC5E1C7BD5BA678728B8BE561451450485145140051451400514514005145140051451400514514005145140181A9F82FC3DAB36FB9D3625909C9921CC6C7EBB719FC73584DF09BC3E5F22E35151FDD12A63FF0040AEF28ACDD283D5A3B696638BA4B96151A5EA72B61F0EBC3362558D89B9914E435C485BF35E14FE55D3C30C56F0AC30449144830A88A15547B014FA2AA308C764615B135AB3BD5937EAC28A28AA310A28A2800A28A2800A28AC3D535164BD8D213C42727DCFA7E5FCE834A54A5525CA8DCA29914AB34292A1CAB0C8A7D066D59D985145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051450480327802802BDE5D2DA5B34ADC9E8A3D4D727248D2C8CEE72CC724D5BD4AF4DE5CFCA7F749C20FEB54A91EC6168FB38DDEEC28A28A0EA0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2802CD8DDB59DC89064A1E1C7A8AEB1595D0329CAB0C823BD7155B5A25F60FD9243C1E633FCC5338719479973ADD1B945145079614514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450056BEB916968F2FF17451EA6B9324B3124E493926B4358BBFB45D796A7F77171F53DEB3A91EC61297242EF766D6877782D6AE7AFCC99FD47F9F7ADCAE2E3768A45910E194E41AEBEDA75B9B74997A30E9E8699C98DA5CB2E75D4968A28A0E20A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AC7D6AFB627D9633F330F9FD87A5685E5D2DA5B34ADC9E8A3D4D727248D2C8CEE72CC724D076E0E8F34B9DEC86D145148F5428A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0029412AC1949041C823B5251401D5E9F782F2D831C798BC38F7AB75C958DDB59DC89064A1E1C7A8AEB1595D0329CAB0C823BD33C6C4D1F672D3662D145141CC14514500145145001451450014514500145145001451450014514500145145001451450014514500154F52BBFB25A3303FBC6F953EBEB572B96D4EEFED576C54E634F957FC683A30D4BDA4F5D914A8A28A47B415ADA25DF9731B763F2C872BEC7FFAF5934AAC558329C30390476A0CEAD35520E2CED68AAF63722EED125FE2E8C3D0D58A678528B8BB30A28A281051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400504803278028AC9D6EECC712DBA1F9A4196F503FFAF41A52A6EA4945199A95E9BCB9CA9FDD27083FAD52A28A47B908A84545051451414145145001451450014514500145145001451450014514500145145001451450015B5A25F60FD9243C1E633FCC562D282558329208390476A0CEAD35523CACED68A82CE6371691CA482CC39C7AD4F4CF09A69D985145140828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A290900124E00EA4D0050D5EEFECF6BB14FEF24E07B0EF5CCD59BFBA37776D27F08E107B556A47B587A5ECE167B85145141D01451450068E8F77F67BAF2D8E23978FA1ED5D2D7135D569B77F6BB40C4FEF17E57FAFAD33CDC6D2D7DA22E5145141E7851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400D92458A3691CE15464D721713B5CDC3CAFD58F4F4F6ADAD76E0A429029FBE72DF41FE7F4AC0A47A982A568F3BEA145145077051451400514514005145140051451400514514005145140051451400514514005145140051451401AFA1DDEC95AD98FCAFCAFB1FF3FCAB7EB8A4768DD5D4E194E41AEC6DE613DBC728E8EB9FA533CBC6D2E5973AEA4945145070851451400514514005145140051451400514514005145140051451400514514005656B777E5402053F3C9D7D96B4DDD638D9DCE154649AE46EAE1AEAE5E66FE23C0F41DA83AF094B9E7CCF64434514523D70A28A2800A28A2800ABBA5DDFD96EC6E3FBB7F95BDBDEA95141338A9C5C59DB5159FA45DFDA6D3631CC91F073DC7635A14CF0A7070938B0A28A282028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A29B2388E3673D1412680398D526F3B5090F643B07E1FF00D7CD52A524B31627249C934948FA0847962A2BA0514514141451450014514500145145001451450014514500145145001451450014514500145145001451450015D0683317B69223FF002CDB23E87FC9AE7EB4F439365F14CF0E8463DC73FE341CF8A8F35267474514533C50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A8E7996081E57FBAA3340D26DD9195AE5DED45B543CB7CCFF004EC2B0AA49A569E6795CFCCC726A3A47B9469AA70510A28A28350A28A2800A28A2800A28A2802CD85D7D92ED643F74F0DF4AEB010C010720F208AE2ABA2D16EFCDB73031F9E31C7BAFFF005A99C18DA575ED11A945145079814514500145145001451450014514500145145001451450014514500145145001451450014514500145145001557517D9A74E7FD8C7E7C55AAA5AB7FC82E6FC3F98A0D292BD48AF3472D4514523DE0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AB7A6B6CD4603FED63F3E2AA54F65FF001FD6FF00F5D17F9D04545783475F4514533C00A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AC2D72EF73ADAA1E17E67FAF615AF7570B6B6CF337F08E07A9ED5C8BBB48ECEE72CC724D07760A9734B9DF41B4514523D40A28A2800A28A2800A28A2800A28A2800A9AD6E1AD6E5255EC791EA3B8A868A04D26ACCED11D644575395619069D58DA1DDEE46B673CAF299F4EE2B6699E155A6E9CDC5851451419851451400514514005145140051451400514514005145140051451400514514005145140051451400554D4D7769B38FF00673F91AB751CE9E6DBC91FF794AFE6282A0ED24CE368A28A47D005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400559D3D776A100FF006C1AAD5A3A2A6FD455BFB8A5BFA7F5A0CEABB536FC8E968A28A6782145145001451450014514500145145001451450014514500145155AFEE85A5A349FC47841EF40E317276463EB577E6DC0814FC91F5F76FF00EB565529249249249EA4D2523DDA7054E2A2828A28A0D028A28A0028A28A0028A28A0028A28A0028A28A0092195A099254FBCA735D74332CF0A4A87E561915C6D6CE87778736AE783F327D7B8A0E2C652E68F32DD1BB4514533CA0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A280391BE8BC9BE9931801891F43C8AAF5B5AF41868EE00E0FC8DFD3FAD62D23DCA13E7A6985145141B05145140051451400514514005145140051451400514514005145140051451400514514005145140056EE8116126988EA428FC3AFF004AC2AEBAC60FB3D945191C85CB7D4F26838F1B3E5A7CBDCB14514533C90A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800AE6757BBFB45D9453FBB8FE51EE7B9AD9D52EFECB68769C48FF002AFB7BD72D41E860A97FCBC614514523D20A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A723B4722BA1C329C834DA2803B0B59D6E6D9265FE21C8F43DEA6AE7B44BBF2AE0C0E7E593A7B37FF005EBA1A67875E97B39B5D028A28A0C428A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0086EA05B9B6785BF88707D0F6AE41D1A3764618653822BB5AC3D6ECC86FB520E0F0F8FD0D07760AAF2CB91F53168A28A47A814514500145145001451450014514500145145001451450014514500145145001451450014514AAACEC15412C4E001DE802FE916BF68BC0EC3F7717CC7EBD87F9F4AE9AAB585A8B3B558F8DE7973EA6ACD33C4C4D5F693BAD828A28A0C028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00E5F559DE7BD3B95951784046323D7F1AA35A9AF7FC7F27FD721FCCD65D23DCA0D3A6AC14514506C1451450014514500145145001451450014514500145145001451450028241041C11C822BADB2B83736892B295623904639AE46BAFB3FF008F1B7FFAE4BFCA83831F6E544F4514533CC0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A6BA2C88C8E32AC30453A8A00E52FEC9ECA7DA798DB946F5AA95D8DC5BC775098A41953F983EB5CB5DDA4967318DC707EEB762291EBE1B10AA2E596E57A28A283AC28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B7747D3CA62EA61F311F229EDEF50E95A679A45C4EBFBBEAAA7F8BDFE95BF4CF3B1788FF009771F985145141E7051451400514514005145140051451400514514005145140051451401CEEBDFF001FC9FF005C87F335975A9AF7FC7F27FD721FCCD65D23DBC3FF000A214514506E1451450014514500145145001451450014514500145145001451450015D7D9FF00C78DBFFD725FE55C8575F67FF1E36FFF005C97F9507063FE144F4514533CC0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A8AE2DE2B988C72AE54F4F51F4A968A069B4EE8E5AFB4D96CDB77DF889E1C76FAD52AED4804104020F041AC7BCD10312F6A769FEE1E9F81A0F4A86313D2A7DE61514F9629217D9221461D88A6523B93BEA828A28A0614514500145145001451450014514500145156AD74FB8BB3F22E13FBEDC0A09949455E4560092000493D00ADBD3F47C625BA1CF511FF8FF00855EB2D361B31B87CF27773FD3D2AE533CDAF8C72F761B05145141C2145145001451450014514500145145001451450014514500145145001451450073BAF7FC7F27FD721FCCD65D6C6BD0BF9F1CD8F90AEDCFA1C9FF001AC7A47B78669D2414514506E1451450014514500145145001451450014514500145145001451450015D7D9FFC78DBFF00D725FE55C8AAB3B05504B1380077AEC6DD0C56D146DD51029FC05079F8F6B95224A28A299E6851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400C9618E74D92A2BAFA1159371A0A3736F26DFF65F91F9D6CD141A53AD3A7F0B3929B4FBA809DF0B103F89464556AEDAA296D609BFD6428C7D4AF3F9D076431EFED238EA2BA69345B37E8AC9FEEB7F8D40DA0427EE4CE3EA01A46EB1B49EE60515B7FF0008F8ED73FF0090FF00FAF4A3C3EBDEE4FF00DF1FFD7A0AFADD1EFF00998745742BA0DB0FBD24ADF881FD2ACC7A55947C88431F5624D043C6D35B6A72EA8CEDB514B1F403357ADF47BA9B05D444BEADD7F2AE912348D76A22AAFA28C53A99CF3C749FC2AC67DB68F6D072E3CD6F56E9F95687418145141C939CA6EF2770A28A282028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A006C91A4B1B23A86561820D62DD684725AD9F23FB8FF00E35B94506B4EB4E9BF759C7CD6B3DB9FDEC4CBEF8E3F3A86BB6AAF2D85ACDF7E04C9EE060FE6283B218FFE6472345746FA1DA37DD3227D0E7F9D576F0FFF0072E7F029FF00D7A46EB1949F5B189456A9D06E73F2CB11FA923FA530E89783A7967E8D41A2C4527F68CDA2AF1D1EF87FCB107FE063FC693FB22FBFE787FE3EBFE340FDB53FE65F794A8ABDFD917DFF003C3FF1F5FF001A70D1AF4F5451F561407B6A7FCC8CFA2B4C685767AB443EAC7FC2A54D0253F7E741F404D04BC4D25F68C7A2B7D340847FAC99DBFDD007F8D598F48B28F1FBADC4776626833963692DB53980A58E14124F602AF5BE9177360B2794BEAFD7F2AE9238A3886238D507FB2314FA673CF1D27F0AB14ACF4C82CFE619793FBEDDBE9E95768A2838A5394DDE4C28A28A090A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803FFFD9, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (1, N'Музыкальные инструменты', 0, 0, N'Цвет', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (2, N'Струнные', 1, 1, N'Количество струн; Количество ладов; Струнный материал; Строй; Наличие встроенного звукоснимателя или места под него', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (3, N'Клавишные', 1, 1, N'Количество клавиш; Количество встроенных звуков музыкальных инструментов', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (4, N'Духовые', 1, 1, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (5, N'Гитары', 1, 2, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (6, N'Укулеле', 1, 2, N'Вид', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (7, N'Электрогитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (8, N'Бас-гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (9, N'Блок-флейты', 1, 4, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (10, N'Музыкальные пособия', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (11, N'Сборники песен', 1, 10, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (12, N'Музыкальные гаммы', 1, 10, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (13, N'Музыкальная аппаратура', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (14, N'Звуковые карты', 1, 13, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (15, N'Усилители', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (16, N'Звукосниматели', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (17, N'Микрофоны', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (18, N'Наушники', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (19, N'Колонки', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (20, N'Аксессуары', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (21, N'Ремни для гитары', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (22, N'Ремни для укулеле', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (23, N'Пидали сустейна для синтезатора', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (24, N'Синтезаторы', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (25, N'Пионино', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (26, N'Рояль', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (27, N'Аккустические гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (28, N'Классические гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (29, N'Запчасти от инструментов', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (30, N'Струны для струнных инструментов', 1, 37, N'Количество струн в упаковке; Размер струн; Количество струн на инструменте; строй', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (31, N'Струны для гитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (32, N'Струны для укулеле', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (33, N'Струны для электрогитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (34, N'Струны для бас-гитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (35, N'Тюнеры', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (36, N'Кападастры', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (37, N'Запчасти для струнных инструментов', 1, 29, N'', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (38, N'Ладовые порожки', 1, 37, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (39, N'Ладовые порожки для гитары', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (40, N'Ладлвые порожки для укулеле', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (41, N'Ладовые порожки для электрогитары', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (42, N'Ладовые порожки для бас-гитары', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (45, N'Медиаторы', 1, 20, N'', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (47, N'Комбики', 1, 15, N'', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (52, N'Аксессуар', 1, 20, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (60, N'Звукосниматели для укулеле', 1, 16, N'', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (62, N'Гитарные звукосниматели', 1, 16, N'', 2)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 1, 19, CAST(N'2023-05-25T18:04:32.990' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 2, 210, CAST(N'2023-05-27T23:30:12.497' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 3, 12, CAST(N'2023-05-25T17:45:30.550' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 8, 80, CAST(N'2023-05-25T16:45:06.200' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 9, 90, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 12, 20, CAST(N'2023-05-22T20:27:59.807' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 25, 64, CAST(N'2023-05-25T16:45:06.207' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 26, 102, CAST(N'2023-05-25T16:45:06.210' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (1, 48, 70, CAST(N'2023-05-27T23:54:35.043' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (2, 2, 70, CAST(N'2023-05-27T23:52:53.223' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (2, 7, 150, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (2, 8, 60, CAST(N'2023-05-25T16:40:51.320' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (2, 25, 102, CAST(N'2023-05-25T16:40:51.313' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (4, 1, 33, CAST(N'2023-05-22T20:11:58.383' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (4, 2, 70, CAST(N'2023-05-27T23:52:19.930' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (4, 4, 12, CAST(N'2023-05-19T15:16:40.640' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (4, 48, 99, CAST(N'2023-05-27T23:53:47.380' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 1, 8, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 2, 9, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 3, 10, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 4, 15, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 8, 100, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 9, 80, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (9, 25, 24, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 6, 49, CAST(N'2023-05-25T13:05:07.060' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 7, 45, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 8, 85, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 9, 80, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 10, 10, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 11, 10, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 12, 20, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 25, 33, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (10, 48, 80, CAST(N'2023-05-27T23:55:28.060' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (12, 25, 36, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (13, 25, 24, CAST(N'2023-05-13T09:25:24.693' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (16, 2, 10, CAST(N'2023-05-13T09:36:44.497' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (16, 25, 10, CAST(N'2023-05-13T09:37:07.880' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (18, 1, 38, CAST(N'2023-05-13T09:34:24.223' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (18, 2, 15, CAST(N'2023-05-13T09:34:41.623' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (18, 3, 24, CAST(N'2023-05-13T09:34:49.530' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (18, 4, 59, CAST(N'2023-05-13T09:34:56.843' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (18, 6, 20, CAST(N'2023-05-13T09:35:52.207' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (19, 25, 45, CAST(N'2023-05-13T09:34:02.053' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (20, 2, 40, CAST(N'2023-05-13T09:32:10.960' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (20, 4, 20, CAST(N'2023-05-13T09:33:52.950' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (20, 25, 50, CAST(N'2023-05-13T09:31:42.510' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (21, 1, 10, CAST(N'2023-05-13T09:31:20.340' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (21, 4, 150, CAST(N'2023-05-13T09:33:39.670' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (21, 25, 10, CAST(N'2023-05-13T09:31:30.997' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (25, 2, 10, CAST(N'2023-05-27T23:30:31.603' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (26, 2, 35, CAST(N'2023-05-27T23:31:01.747' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 3, 59, CAST(N'2023-05-28T21:32:18.517' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 7, 9, CAST(N'2023-05-28T21:32:31.813' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 20, 200, CAST(N'2023-05-28T21:34:46.080' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 21, 50, CAST(N'2023-05-28T21:35:21.403' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 22, 34, CAST(N'2023-05-28T21:35:56.900' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 23, 234, CAST(N'2023-05-28T21:36:20.010' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 35, 100, CAST(N'2023-05-28T21:36:39.743' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 43, 100, CAST(N'2023-05-28T21:36:52.113' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 44, 23, CAST(N'2023-05-28T21:37:06.467' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 45, 50, CAST(N'2023-05-28T21:37:34.193' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (30, 48, 20, CAST(N'2023-05-28T21:37:55.737' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (32, 4, 80, CAST(N'2023-05-29T00:30:29.183' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (32, 12, 80, CAST(N'2023-05-29T00:31:49.160' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (32, 25, 50, CAST(N'2023-05-29T00:32:54.520' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (32, 48, 40, CAST(N'2023-05-29T00:32:10.340' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (34, 2, 80, CAST(N'2023-05-29T00:28:49.263' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (34, 9, 50, CAST(N'2023-05-29T00:29:12.740' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (34, 25, 30, CAST(N'2023-05-29T00:29:33.710' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (34, 26, 100, CAST(N'2023-05-29T00:36:35.530' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 1, 80, CAST(N'2023-05-29T12:48:28.047' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 2, 50, CAST(N'2023-05-29T12:48:46.890' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 3, 177, CAST(N'2023-05-29T12:56:02.560' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 4, 12, CAST(N'2023-05-29T12:49:08.153' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 6, 27, CAST(N'2023-05-29T12:49:30.090' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 7, 199, CAST(N'2023-05-29T12:56:25.463' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 8, 80, CAST(N'2023-05-29T12:49:59.143' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 9, 55, CAST(N'2023-05-29T12:50:20.170' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 10, 98, CAST(N'2023-05-29T12:56:54.787' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 11, 77, CAST(N'2023-05-29T12:50:55.380' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 12, 88, CAST(N'2023-05-29T12:51:16.170' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 13, 80, CAST(N'2023-05-29T12:57:18.057' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 16, 55, CAST(N'2023-05-29T12:51:36.353' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 20, 56, CAST(N'2023-05-29T12:51:58.687' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 21, 45, CAST(N'2023-05-29T12:57:43.197' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 22, 56, CAST(N'2023-05-29T12:52:22.473' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 23, 69, CAST(N'2023-05-29T12:52:49.327' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 24, 192, CAST(N'2023-05-29T12:58:13.117' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 25, 90, CAST(N'2023-05-29T12:53:11.760' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 26, 77, CAST(N'2023-05-29T12:53:33.863' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 35, 87, CAST(N'2023-05-29T12:54:01.163' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 43, 87, CAST(N'2023-05-29T12:54:27.010' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 44, 67, CAST(N'2023-05-29T12:54:53.070' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 45, 89, CAST(N'2023-05-29T12:58:39.997' AS DateTime))
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop], [DateUpdate]) VALUES (35, 48, 111, CAST(N'2023-05-29T12:55:19.663' AS DateTime))
GO
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 1, 33, CAST(N'2023-05-25T18:14:17.167' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 2, 260, CAST(N'2023-05-27T23:51:54.643' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 3, 15, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 4, 5, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 6, 23, CAST(N'2023-05-13T09:43:26.503' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 7, 20, CAST(N'2023-05-13T09:42:28.000' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 9, 15, CAST(N'2023-05-13T09:43:08.527' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 25, 69, CAST(N'2023-05-25T16:42:46.033' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 26, 99, CAST(N'2023-05-25T16:42:46.037' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (1, 48, 425, CAST(N'2023-05-27T23:54:17.083' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 1, 3, CAST(N'2023-05-25T13:06:44.693' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 2, 11, CAST(N'2023-05-27T23:05:29.767' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 4, 12, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 6, 5, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 7, 14, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 8, 15, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 25, 63, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (2, 48, 100, CAST(N'2023-05-27T23:55:35.133' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 2, 29, CAST(N'2023-05-27T23:43:33.487' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 3, 45, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 4, 34, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 6, 50, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 8, 150, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 9, 50, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 25, 42, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (3, 48, 373, CAST(N'2023-05-27T23:53:47.380' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 1, 40, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 2, 59, CAST(N'2023-05-27T23:06:11.463' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 10, 30, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 11, 50, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 12, 40, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (4, 25, 42, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 1, 30, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 2, 14, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 3, 15, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 4, 25, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 6, 20, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 7, 30, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 8, 40, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 9, 35, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 10, 10, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 11, 13, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (5, 12, 45, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (6, 25, 20, CAST(N'2023-05-22T20:25:23.470' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (7, 25, 33, CAST(N'2023-05-13T09:38:12.407' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (8, 1, 40, CAST(N'2023-05-13T09:55:35.987' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (8, 10, 50, CAST(N'2023-05-13T09:55:47.860' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (9, 2, 5, CAST(N'2023-05-27T23:05:46.010' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 2, 120, CAST(N'2023-05-29T00:35:32.610' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 3, 258, CAST(N'2023-05-28T21:17:44.653' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 4, 370, CAST(N'2023-05-29T00:30:29.173' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 6, 34, CAST(N'2023-05-28T21:18:43.650' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 9, 50, CAST(N'2023-05-29T00:29:09.583' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 12, 370, CAST(N'2023-05-29T00:31:49.150' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 20, 3400, CAST(N'2023-05-28T21:21:56.753' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 21, 900, CAST(N'2023-05-28T21:22:27.520' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 22, 123, CAST(N'2023-05-28T21:23:33.657' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 23, 340, CAST(N'2023-05-28T21:22:57.760' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 25, 150, CAST(N'2023-05-29T00:32:54.513' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 26, 150, CAST(N'2023-05-29T00:36:35.517' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 35, 450, CAST(N'2023-05-28T21:19:31.687' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 43, 380, CAST(N'2023-05-28T21:19:56.827' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 44, 123, CAST(N'2023-05-28T21:21:25.260' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 45, 499, CAST(N'2023-05-28T21:20:26.277' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (14, 48, 370, CAST(N'2023-05-29T00:32:10.307' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 3, 400, CAST(N'2023-05-28T21:32:18.510' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 7, 80, CAST(N'2023-05-28T21:32:46.223' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 20, 1000, CAST(N'2023-05-28T21:34:46.077' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 21, 800, CAST(N'2023-05-28T21:35:21.390' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 22, 200, CAST(N'2023-05-28T21:35:56.877' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 23, 1000, CAST(N'2023-05-28T21:36:20.017' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 35, 400, CAST(N'2023-05-28T21:36:39.737' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 43, 200, CAST(N'2023-05-28T21:36:52.093' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 44, 100, CAST(N'2023-05-28T21:37:06.470' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 45, 350, CAST(N'2023-05-28T21:37:34.173' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (15, 48, 200, CAST(N'2023-05-28T21:37:55.743' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 1, 370, CAST(N'2023-05-29T12:48:28.037' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 2, 180, CAST(N'2023-05-29T12:48:46.877' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 3, 277, CAST(N'2023-05-29T12:56:02.550' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 4, 222, CAST(N'2023-05-29T12:49:08.147' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 6, 195, CAST(N'2023-05-29T12:49:30.070' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 7, 346, CAST(N'2023-05-29T12:56:25.447' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 8, 264, CAST(N'2023-05-29T12:49:59.133' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 9, 500, CAST(N'2023-05-29T12:50:20.177' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 10, 430, CAST(N'2023-05-29T12:56:54.790' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 11, 367, CAST(N'2023-05-29T12:50:55.363' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 12, 368, CAST(N'2023-05-29T12:51:16.160' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 13, 283, CAST(N'2023-05-29T12:57:18.047' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 16, 389, CAST(N'2023-05-29T12:51:36.220' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 20, 399, CAST(N'2023-05-29T12:51:58.657' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 21, 242, CAST(N'2023-05-29T12:57:43.200' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 22, 289, CAST(N'2023-05-29T12:52:22.453' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 23, 176, CAST(N'2023-05-29T12:52:49.290' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 24, 570, CAST(N'2023-05-29T12:58:13.093' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 25, 584, CAST(N'2023-05-29T12:53:11.753' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 26, 467, CAST(N'2023-05-29T12:53:33.857' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 35, 346, CAST(N'2023-05-29T12:54:01.157' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 43, 369, CAST(N'2023-05-29T12:54:27.020' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 44, 476, CAST(N'2023-05-29T12:54:53.060' AS DateTime))
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 45, 423, CAST(N'2023-05-29T12:58:40.000' AS DateTime))
GO
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock], [DateUpdate]) VALUES (18, 48, 444, CAST(N'2023-05-29T12:55:19.653' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProductManufacture] ON 

INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (1, N'abc')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (2, N'bcd')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (3, N'cde')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (4, N'abcdef')
SET IDENTITY_INSERT [dbo].[ProductManufacture] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSupplier] ON 

INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (1, N'abcd')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (2, N'bcde')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (3, N'cdef')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (4, N'defg')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (5, N'abcdefg')
SET IDENTITY_INSERT [dbo].[ProductSupplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (1, N'Клиент', N'Client')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (2, N'Директор', N'Director')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (3, N'Администратор', N'Admin')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (4, N'Менеджер по складу', N'StockManager')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (5, N'Менеджер по заказам', N'OrdersManager')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (6, N'Оператор', N'Operator')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleNameEng]) VALUES (7, N'Продавец', N'SalesMan')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (1, N'Магазин-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (2, N'ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (4, N'Лошадь-музыка')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (9, N'Лошадь-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (10, N'Москва-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (12, N'Новгород-магазин')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (13, N'Новгород2-магазин')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (14, N'Юкка')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (15, N'Ритм-маркет')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (16, N'Ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (18, N'Ритм-супермаркет')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (19, N'Ритм-маркет')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (20, N'Ритм-гипермаркет')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (21, N'Ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (22, N'Ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (23, N'Ритм-Тверь')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (24, N'Лошадь-тверь')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (25, N'Ритм-Петербург')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (26, N'dhgkjd')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (28, N'Ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (29, N'Ритм-магазин')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (30, N'Магазин торжокского ритма')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (32, N'Магазин нотного стана в Торжке')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (34, N'Музыкальный магазин в Торжке')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (35, N'Магазин во Мшинской')
GO
SET IDENTITY_INSERT [dbo].[Sity] ON 

INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (1, N'Санкт-Петербург')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (2, N'Москва')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (3, N'Сочи')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (4, N'Великий Новгород')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (5, N'Тверь')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (6, N'Псков')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (7, N'Торжок')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (8, N'Порхов')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (9, N'Кашин')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (10, N'Углич')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (11, N'Луга')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (12, N'Гатчина')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (13, N'Петергоф')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (14, N'Кронштадт')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (15, N'Выборг')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (16, N'Мшинская')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (17, N'Ростов')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (18, N'Ярославль')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (19, N'Калязин')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (22, N'Владимир')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (23, N'Суздаль')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (24, N'Киров')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (25, N'Казань')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (27, N'Кострома')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (28, N'Плёс')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (29, N'Сергеев-посад')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (30, N'Переславль залесский')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (31, N'Мышкин')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (32, N'Старая Ладога')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (33, N'Пушкин')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (34, N'Павловск')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (35, N'Ломаносов')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (36, N'Туапсе')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (37, N'Шепси')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (38, N'Лоо')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (39, N'Зеленогорск')
SET IDENTITY_INSERT [dbo].[Sity] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (1, N'Питер-Склад', N'иьмивылаам', 1, NULL, N'MainOffice@PiterStock.ru')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (2, N'Москва-склад', N'фвыаорукора', 2, N'+7(400)800-70-00', N'MainOffice@MoscowStock.ru')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (3, N'Петербург-склад', N'аыыимрвыам', 1, N'+7(400)800-09-00', NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (4, N'Сочи-склад', N'пшрпа', 3, NULL, NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (5, N'Выборг-склад', N'рмшнмк', 15, NULL, NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (6, N'Новгород-склад', N'ошдркыд', 4, NULL, NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (7, N'Новгород2-склад', N'млоыотмловиаы', 4, NULL, NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (8, N'Тверь-склад', N'олврплорлоп', 5, N'+7(400)400-58-00', N'Office@TverStock.ru')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (9, N'Склад-Петербург', N'мловялшряша', 1, NULL, NULL)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (14, N'Торжок-склад', N'kjjhlflhj', 7, N'xgbfxbfxb', N'vzdvdfsfvv')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (15, N'Склад торжковских музыкальных инструментов', N'ысыфвмфывмв', 7, N'', N'')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (16, N'Псков-склад', N'dfbdsfdfsh', 6, N'', N'')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (17, N'Порхов-склад', N'апкыепкыеп', 8, N'сивыавыа', N'иыикыиркер')
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID], [StockTelephone], [StockEmail]) VALUES (18, N'Склад на Мшинской', N'афыпкуфкп', 16, N'+7(123)000-12-00', N'123@123.ru')
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (2, N'sidorov', N'password', 0, N'0.0', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (4, N'anton1', N'123', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (5, N'sidorov1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (6, N'AntonSidorov', N'password ', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (7, N'AntonSidorov1', N'', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (8, N'a', N'passwords', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (9, N'as', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (11, N'sajkjvadfs1', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (12, N'hsdhsghsh', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (18, N'Директор', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (19, N'SysAdmin', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (20, N'Cunsumer1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (21, N'Cunsumer2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (22, N'Cunsumer3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (23, N'ManagerOrder1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (24, N'ManagerOrder2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (25, N'ManagerGoods1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (26, N'ManagerGoods2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (27, N'Operator1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (28, N'Operator2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (29, N'Operator3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (30, N'Client1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (31, N'Client2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (32, N'Client3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (33, N'Client4', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (34, N'client5', N'1234', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (35, N'CSCASDC', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (41, N'Anton Sidorov 123', N'123', 0, N'0.0', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (45, N'A 123', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (46, N'a 1234', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (47, N'anton123', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (48, N'Anton1234', N'1234', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (49, N'sidorov12', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1048, N'anton.dsid', N'string', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1049, N'an', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1050, N'an123', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1052, N'123', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1056, N'anton', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1057, N'Anton Sidorov sss', N'', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1059, N'ClientDirect', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1060, N'order stock', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1061, N'log', N'pas', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1062, N'anton sidorov 1234 ', N'', 0, N'0.0', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserEmail] ON 

INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (1, 6, N'ab@cd.ef')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (3, 7, N'A@MusicGamms.d')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (4, 8, N'ab@cd.ef')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (6, 6, N'abcd@efgh')
SET IDENTITY_INSERT [dbo].[UserEmail] OFF
GO
INSERT [dbo].[UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) VALUES (6, N'Сидоров', N'Антон', N'Дмитриевич')
INSERT [dbo].[UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) VALUES (7, N'Сидоров', N'Антон', N'')
INSERT [dbo].[UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) VALUES (1061, N'Матысик', N'Ирина', N'')
GO
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (2, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (2, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (7, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (8, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (9, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (12, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (18, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (19, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (20, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (21, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (22, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (23, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (24, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (25, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (26, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (27, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (28, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (29, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (30, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (31, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (32, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (33, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (34, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (35, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (35, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (35, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (35, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (41, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (41, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (45, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (46, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (47, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (48, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (49, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1048, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1049, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1050, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1052, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1056, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1057, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1059, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1059, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1060, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1060, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1060, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1061, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1062, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1062, 6)
GO
INSERT [dbo].[UserSignIn] ([LoginToken], [UserID]) VALUES (N'PSFXK23H8VLD3BOY4AP0', NULL)
INSERT [dbo].[UserSignIn] ([LoginToken], [UserID]) VALUES (N'XMA2JNCNWTR36Q4LM42J', 19)
GO
SET IDENTITY_INSERT [dbo].[UserTelefon] ON 

INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (1, 6, N'+7(123)456-78-90')
INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (3, 7, N'+7(123)456-78-90')
INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (6, 6, N'+7(123)456-78-95')
SET IDENTITY_INSERT [dbo].[UserTelefon] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Order]    Script Date: 29.05.2023 13:01:56 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [IX_Order] UNIQUE NONCLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product]    Script Date: 29.05.2023 13:01:56 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [IX_Product] UNIQUE NONCLUSTERED 
(
	[ProductArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 29.05.2023 13:01:56 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[UserLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserNikName]    Script Date: 29.05.2023 13:01:56 ******/
ALTER TABLE [dbo].[UserNikName] ADD  CONSTRAINT [IX_UserNikName] UNIQUE NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserPsevdonim]    Script Date: 29.05.2023 13:01:56 ******/
ALTER TABLE [dbo].[UserPsevdonim] ADD  CONSTRAINT [IX_UserPsevdonim] UNIQUE NONCLUSTERED 
(
	[PsevdonimName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CopyMessage] ADD  CONSTRAINT [DF_CopyMessage_CloseCopy]  DEFAULT ((0)) FOR [CloseCopy]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_DateOpen]  DEFAULT (getdate()) FOR [DateOpen]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_DaysOpen]  DEFAULT ((0)) FOR [DaysOpen]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_HoursOpen]  DEFAULT ((1)) FOR [HoursOpen]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_MinutsOpen]  DEFAULT ((0)) FOR [MinutsOpen]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_SecondsOpen]  DEFAULT ((0)) FOR [SecondsOpen]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_DateLastActive]  DEFAULT (getdate()) FOR [DateLastActive]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_DaysNoActive]  DEFAULT ((0)) FOR [DaysNoActive]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_HoursNoActive]  DEFAULT ((0)) FOR [HoursNoActive]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_MinutesNoActive]  DEFAULT ((30)) FOR [MinutesNoActive]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_SecondsNoActive]  DEFAULT ((0)) FOR [SecondsNoActive]
GO
ALTER TABLE [dbo].[Environtment] ADD  CONSTRAINT [DF_Environtment_BrowserUse]  DEFAULT ((0)) FOR [BrowserUse]
GO
ALTER TABLE [dbo].[LoginHistory] ADD  CONSTRAINT [DF_LoginHistory_LoginSuccessfully]  DEFAULT ((0)) FOR [LoginSuccessfully]
GO
ALTER TABLE [dbo].[LoginHistory] ADD  CONSTRAINT [DF_LoginHistory_LoginActive]  DEFAULT ((0)) FOR [LoginActive]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDateSent]  DEFAULT (getdate()) FOR [MessageDateTimeSent]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDelayedSend]  DEFAULT ((0)) FOR [MessageDelayedSend]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDelayedTime]  DEFAULT (getdate()) FOR [MessageDelayedTime]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageStatusID]  DEFAULT ((2)) FOR [MessageStatusID]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderStatusID]  DEFAULT ((1)) FOR [OrderStatusID]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDate]  DEFAULT (getdate()) FOR [OrderDateCreate]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDateStatusChange]  DEFAULT (getdate()) FOR [OrderDateStatusChange]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductDiscount]  DEFAULT ((0)) FOR [ProductDiscount]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_Subcategorie]  DEFAULT ((0)) FOR [Subcategorie]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_RootCategoryID]  DEFAULT ((0)) FOR [RootCategoryID]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_CategoryFilterID]  DEFAULT ((1)) FOR [CategoryFilterID]
GO
ALTER TABLE [dbo].[ProductInShop] ADD  CONSTRAINT [DF_ProductInShop_DateUpdate]  DEFAULT (getdate()) FOR [DateUpdate]
GO
ALTER TABLE [dbo].[ProductInStock] ADD  CONSTRAINT [DF_ProductInStock_DateUpdate]  DEFAULT (getdate()) FOR [DateUpdate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_ChatUser]  DEFAULT ((0)) FOR [ChatUser]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Encription_Algorithm]  DEFAULT ((0.0)) FOR [Encription_Algorithm]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserBlocked]  DEFAULT ((0)) FOR [UserBlocked]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_RoleID]  DEFAULT ((1)) FOR [RoleID]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD  CONSTRAINT [FK_ClientOrder_OrderInPounktOfIssue] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientOrder] CHECK CONSTRAINT [FK_ClientOrder_OrderInPounktOfIssue]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD  CONSTRAINT [FK_ClientOrder_User] FOREIGN KEY([ClientID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientOrder] CHECK CONSTRAINT [FK_ClientOrder_User]
GO
ALTER TABLE [dbo].[CopyMessage]  WITH CHECK ADD  CONSTRAINT [FK_CopyMessage_Message] FOREIGN KEY([IDMesaage])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CopyMessage] CHECK CONSTRAINT [FK_CopyMessage_Message]
GO
ALTER TABLE [dbo].[CopyMessage]  WITH CHECK ADD  CONSTRAINT [FK_CopyMessage_User] FOREIGN KEY([IDRecipient])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CopyMessage] CHECK CONSTRAINT [FK_CopyMessage_User]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_Environtment] FOREIGN KEY([EnvirontmentToken])
REFERENCES [dbo].[Environtment] ([EnvirontmentToken])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_Environtment]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_MessageStatus] FOREIGN KEY([MessageStatusID])
REFERENCES [dbo].[MessageStatus] ([StatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_MessageStatus]
GO
ALTER TABLE [dbo].[MessageRecipient]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipient] CHECK CONSTRAINT [FK_MessageRecipient_Message]
GO
ALTER TABLE [dbo].[MessageRecipient]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipient_User] FOREIGN KEY([RecipientID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipient] CHECK CONSTRAINT [FK_MessageRecipient_User]
GO
ALTER TABLE [dbo].[MessageRecipientsList]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipientsList_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipientsList] CHECK CONSTRAINT [FK_MessageRecipientsList_Message]
GO
ALTER TABLE [dbo].[MessageSender]  WITH CHECK ADD  CONSTRAINT [FK_MessageSender_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageSender] CHECK CONSTRAINT [FK_MessageSender_Message]
GO
ALTER TABLE [dbo].[MessageSender]  WITH CHECK ADD  CONSTRAINT [FK_MessageSender_User] FOREIGN KEY([SenderID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageSender] CHECK CONSTRAINT [FK_MessageSender_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([StatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
ALTER TABLE [dbo].[OrderAttachment]  WITH CHECK ADD  CONSTRAINT [FK_OrderAttachment_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderAttachment] CHECK CONSTRAINT [FK_OrderAttachment_Message]
GO
ALTER TABLE [dbo].[OrderAttachment]  WITH CHECK ADD  CONSTRAINT [FK_OrderAttachment_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderAttachment] CHECK CONSTRAINT [FK_OrderAttachment_Order]
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_OrderInPounktOfIssue_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue] CHECK CONSTRAINT [FK_OrderInPounktOfIssue_Order]
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_OrderInPounktOfIssue_PounktOfIssue] FOREIGN KEY([PounktOfIssoeID])
REFERENCES [dbo].[PounktOfIssue] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue] CHECK CONSTRAINT [FK_OrderInPounktOfIssue_PounktOfIssue]
GO
ALTER TABLE [dbo].[OrderInShop]  WITH CHECK ADD  CONSTRAINT [FK_OrderInShop_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInShop] CHECK CONSTRAINT [FK_OrderInShop_Order]
GO
ALTER TABLE [dbo].[OrderInShop]  WITH CHECK ADD  CONSTRAINT [FK_OrderInShop_Shop] FOREIGN KEY([OrderShopID])
REFERENCES [dbo].[Shop] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInShop] CHECK CONSTRAINT [FK_OrderInShop_Shop]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[OrderSaleMan]  WITH CHECK ADD  CONSTRAINT [FK_OrderSaleMan_OrderInShop] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderInShop] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSaleMan] CHECK CONSTRAINT [FK_OrderSaleMan_OrderInShop]
GO
ALTER TABLE [dbo].[OrderSaleMan]  WITH CHECK ADD  CONSTRAINT [FK_OrderSaleMan_User] FOREIGN KEY([OrderSaleManID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSaleMan] CHECK CONSTRAINT [FK_OrderSaleMan_User]
GO
ALTER TABLE [dbo].[Pounkt]  WITH CHECK ADD  CONSTRAINT [FK_Pounkt_Organization] FOREIGN KEY([PounktOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pounkt] CHECK CONSTRAINT [FK_Pounkt_Organization]
GO
ALTER TABLE [dbo].[Pounkt]  WITH CHECK ADD  CONSTRAINT [FK_Pounkt_Stock] FOREIGN KEY([PounktStockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pounkt] CHECK CONSTRAINT [FK_Pounkt_Stock]
GO
ALTER TABLE [dbo].[PounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_PounktOfIssue_Pounkt] FOREIGN KEY([PounktID])
REFERENCES [dbo].[Pounkt] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PounktOfIssue] CHECK CONSTRAINT [FK_PounktOfIssue_Pounkt]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategory] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductManufacture] FOREIGN KEY([ProductManufactureID])
REFERENCES [dbo].[ProductManufacture] ([ManufactureID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductManufacture]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductSupplier] FOREIGN KEY([ProductSupplierID])
REFERENCES [dbo].[ProductSupplier] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductSupplier]
GO
ALTER TABLE [dbo].[ProductAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttachment_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttachment] CHECK CONSTRAINT [FK_ProductAttachment_Message]
GO
ALTER TABLE [dbo].[ProductAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttachment_Product] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttachment] CHECK CONSTRAINT [FK_ProductAttachment_Product]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_CategoryFilter] FOREIGN KEY([CategoryFilterID])
REFERENCES [dbo].[CategoryFilter] ([CategoryFilterID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_CategoryFilter]
GO
ALTER TABLE [dbo].[ProductInShop]  WITH CHECK ADD  CONSTRAINT [FK_ProductInShop_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInShop] CHECK CONSTRAINT [FK_ProductInShop_Product]
GO
ALTER TABLE [dbo].[ProductInShop]  WITH CHECK ADD  CONSTRAINT [FK_ProductInShop_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInShop] CHECK CONSTRAINT [FK_ProductInShop_Shop]
GO
ALTER TABLE [dbo].[ProductInStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductInStock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInStock] CHECK CONSTRAINT [FK_ProductInStock_Product]
GO
ALTER TABLE [dbo].[ProductInStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductInStock_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInStock] CHECK CONSTRAINT [FK_ProductInStock_Stock]
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_Pounkt] FOREIGN KEY([PounktID])
REFERENCES [dbo].[Pounkt] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shop] CHECK CONSTRAINT [FK_Shop_Pounkt]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Sity] FOREIGN KEY([StockSityID])
REFERENCES [dbo].[Sity] ([SityID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Sity]
GO
ALTER TABLE [dbo].[UserEmail]  WITH CHECK ADD  CONSTRAINT [FK_UserEmail_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserEmail] CHECK CONSTRAINT [FK_UserEmail_User]
GO
ALTER TABLE [dbo].[UserInitials]  WITH CHECK ADD  CONSTRAINT [FK_UserInitials_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInitials] CHECK CONSTRAINT [FK_UserInitials_User]
GO
ALTER TABLE [dbo].[UserNikName]  WITH CHECK ADD  CONSTRAINT [FK_UserNikName_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNikName] CHECK CONSTRAINT [FK_UserNikName_User]
GO
ALTER TABLE [dbo].[UserPsevdonim]  WITH CHECK ADD  CONSTRAINT [FK_UserPsevdonim_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPsevdonim] CHECK CONSTRAINT [FK_UserPsevdonim_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[UserSignIn]  WITH CHECK ADD  CONSTRAINT [FK_UserSignIn_LoginHistory] FOREIGN KEY([LoginToken])
REFERENCES [dbo].[LoginHistory] ([LoginToken])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSignIn] CHECK CONSTRAINT [FK_UserSignIn_LoginHistory]
GO
ALTER TABLE [dbo].[UserSignIn]  WITH CHECK ADD  CONSTRAINT [FK_UserSignIn_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSignIn] CHECK CONSTRAINT [FK_UserSignIn_User]
GO
ALTER TABLE [dbo].[UserTelefon]  WITH CHECK ADD  CONSTRAINT [FK_UserTelefon_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTelefon] CHECK CONSTRAINT [FK_UserTelefon_User]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [DaysNoActiveCheck] CHECK  (([DaysNoActive]<(2) AND [DaysNoActive]>=(0)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [DaysNoActiveCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [DaysOpenCheck] CHECK  (([DaysOpen]<=(2) AND [DaysOpen]>=(0)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [DaysOpenCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [HoursNoActiveCheck] CHECK  (([HoursNoActive]>=(0) AND [HoursNoActive]<(24)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [HoursNoActiveCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [HoursOpenCheck] CHECK  (([HoursOpen]<(24) AND [HoursOpen]>=(0)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [HoursOpenCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [MinutesNoActiveCheck] CHECK  (([MinutesNoActive]>=(0) AND [MinutesNoActive]<(60)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [MinutesNoActiveCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [MinutsOpenCheck] CHECK  (([MinutsOpen]>=(0) AND [MinutsOpen]<(60)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [MinutsOpenCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [SecondsNoActiveCheck] CHECK  (([SecondsNoActive]>=(0) AND [SecondsNoActive]<(60)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [SecondsNoActiveCheck]
GO
ALTER TABLE [dbo].[Environtment]  WITH CHECK ADD  CONSTRAINT [SecondsOpenCheck] CHECK  (([SecondsOpen]>=(0) AND [SecondsOpen]<(60)))
GO
ALTER TABLE [dbo].[Environtment] CHECK CONSTRAINT [SecondsOpenCheck]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [CheckActive] CHECK  (([LoginActive]<=[LoginSuccessfully]))
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [CheckActive]
GO
/****** Object:  Trigger [dbo].[DeleteOldTokens]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DeleteOldTokens] 
   ON  [dbo].[Environtment] 
   After INSERT,UPDATE
AS 
BEGIN
	Delete From Environtment Where DateClose < GETDATE()
	Delete From Environtment Where DateNoActiveClose < GETDATE()
END
GO
ALTER TABLE [dbo].[Environtment] ENABLE TRIGGER [DeleteOldTokens]
GO
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE TRIGGER [dbo].[SubCategorieUpdate]
ON [dbo].[ProductCategory]
AFTER INSERT, Update
AS 
BEGIN
	Declare @count int
	Select @count = Count(*) From ProductCategory where Subcategorie = 0 and RootCategoryID <> 0
	 if (@count > 0)
	 Update ProductCategory set RootCategoryID = 0 where Subcategorie = 0
	 Select @count = Count(*) From ProductCategory where RootCategoryID is null
	 if (@count > 0)
	 Update ProductCategory set RootCategoryID = 0 where RootCategoryID is null
	 Select @count = Count(*) From ProductCategory where RootCategoryID < 1 and Subcategorie = 1 
	 if (@count > 0)
	 Update ProductCategory set Subcategorie = 0 where RootCategoryID = 0
	 Select @count = Count(*) From ProductCategory where CategoryParametersName is null
	 if (@count > 0)
	 Update ProductCategory set CategoryParametersName = '' where CategoryParametersName is null


END
GO
ALTER TABLE [dbo].[ProductCategory] ENABLE TRIGGER [SubCategorieUpdate]
GO
/****** Object:  Trigger [dbo].[DeleteOldPozition]    Script Date: 29.05.2023 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[DeleteOldPozition] 
   ON  [dbo].[ProductInShop] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	Delete From ProductInShop Where ABS(DATEDIFF(MINUTE, DateUpdate, GETDATE()))>0 and QuantityInShop <1
	Delete From ProductInStock Where ABS(DATEDIFF(MINUTE, DateUpdate, GETDATE()))>0 and QuantityInStock <1
END
GO
ALTER TABLE [dbo].[ProductInShop] ENABLE TRIGGER [DeleteOldPozition]
GO
/****** Object:  Trigger [dbo].[DeleteOldPozitionInStock]    Script Date: 29.05.2023 13:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create TRIGGER [dbo].[DeleteOldPozitionInStock] 
   ON  [dbo].[ProductInStock] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	Delete From ProductInStock Where ABS(DATEDIFF(MINUTE, DateUpdate, GETDATE()))>0 and QuantityInStock <1
	Delete From ProductInShop Where ABS(DATEDIFF(MINUTE, DateUpdate, GETDATE()))>0 and QuantityInShop <1
END

GO
ALTER TABLE [dbo].[ProductInStock] ENABLE TRIGGER [DeleteOldPozitionInStock]
GO
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 29.05.2023 13:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 

CREATE TRIGGER [dbo].[UserUpdate]
   ON [dbo].[User]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	Declare @count1 int
	Declare @count2 int
	Declare @count3 int
	Declare @count int
	Select @count1 = Count(*) from [User] where UserPassword is null and Encription_Algorithm <> '0.0'
	Select @count2 = Count(*) from [User] where UserPassword = '' and Encription_Algorithm <> '0.0'
	Select @count3 = Count(*) from [User] where Encription_Algorithm is null	
	set @count = @count1 + @count2 + @count3
	if(@count > 0)
	Update [User] set Encription_Algorithm = '0.0' where Encription_Algorithm is null or UserPassword is null and UserPassword = ''
	Select @count = Count(*) from [User] where UserPassword is null
	if(@count > 0)
	Update [User] set UserPassword = '' where UserPassword is null
END
GO
ALTER TABLE [dbo].[User] ENABLE TRIGGER [UserUpdate]
GO
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 29.05.2023 13:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE TRIGGER [dbo].[UserInitialsUpdate] 
   ON  [dbo].[UserInitials]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	Declare @count int
	Select @count = Count(*) from UserInitials where UserSurName is null
	if(@count > 0)
	Update UserInitials set UserSurName = '' where UserSurName is null
END
GO
ALTER TABLE [dbo].[UserInitials] ENABLE TRIGGER [UserInitialsUpdate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CategoryFilter"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 322
               Bottom = 170
               Right = 591
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AssortimentsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AssortimentsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 317
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CategoriesView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CategoriesView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CategoryFilter"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 155
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 322
               Bottom = 249
               Right = 591
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CategoriesWithFilter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CategoriesWithFilter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CategoryFilter"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 322
               Bottom = 238
               Right = 808
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FiltersOfCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FiltersOfCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CategoryFilter"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 322
               Bottom = 170
               Right = 591
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GoodsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GoodsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CategoryFilter"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 7
               Left = 322
               Bottom = 170
               Right = 591
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'KitsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'KitsCategories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Environtment"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 244
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LoginHistory"
            Begin Extent = 
               Top = 7
               Left = 320
               Bottom = 254
               Right = 543
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LoginHistoryView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LoginHistoryView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OrderInfo"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ClientOrder"
            Begin Extent = 
               Top = 37
               Left = 455
               Bottom = 156
               Right = 656
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderProduct"
            Begin Extent = 
               Top = 86
               Left = 747
               Bottom = 277
               Right = 948
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 1368
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderClient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderClient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Order"
            Begin Extent = 
               Top = 7
               Left = 589
               Bottom = 250
               Right = 862
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderStatus"
            Begin Extent = 
               Top = 7
               Left = 910
               Bottom = 126
               Right = 1111
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Order"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 249
               Right = 321
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderStatus"
            Begin Extent = 
               Top = 7
               Left = 369
               Bottom = 221
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderProduct"
            Begin Extent = 
               Top = 7
               Left = 618
               Bottom = 148
               Right = 819
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderPositionsQuantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrderPositionsQuantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Organization"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Pounkt"
            Begin Extent = 
               Top = 7
               Left = 329
               Bottom = 170
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sity"
            Begin Extent = 
               Top = 7
               Left = 618
               Bottom = 126
               Right = 819
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stock"
            Begin Extent = 
               Top = 7
               Left = 867
               Bottom = 170
               Right = 1068
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrganizationStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'OrganizationStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -240
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Product"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 281
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 76
               Left = 520
               Bottom = 239
               Right = 789
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductManufacture"
            Begin Extent = 
               Top = 294
               Left = 662
               Bottom = 413
               Right = 880
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductSupplier"
            Begin Extent = 
               Top = 358
               Left = 272
               Bottom = 477
               Right = 473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductInShop"
            Begin Extent = 
               Top = 7
               Left = 340
               Bottom = 148
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RythmShop"
            Begin Extent = 
               Top = 7
               Left = 589
               Bottom = 273
               Right = 790
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInRythm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInRythm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductData"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductInShop"
            Begin Extent = 
               Top = 7
               Left = 309
               Bottom = 148
               Right = 510
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInShopsInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInShopsInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductInStock"
            Begin Extent = 
               Top = 7
               Left = 340
               Bottom = 148
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductData"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInStocksInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductsInStocksInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OrganizationStock"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 232
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RitmStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RitmStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RitmStock"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 297
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PounktOfIssue"
            Begin Extent = 
               Top = 7
               Left = 297
               Bottom = 126
               Right = 534
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmPounktOfIssue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmPounktOfIssue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SityPounkts"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmPounkts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmPounkts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RythmPounkts"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 249
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Shop"
            Begin Extent = 
               Top = 7
               Left = 297
               Bottom = 126
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmShop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RythmShop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Organization"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Pounkt"
            Begin Extent = 
               Top = 7
               Left = 329
               Bottom = 170
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 7
               Left = 618
               Bottom = 229
               Right = 862
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "ProductInShop"
            Begin Extent = 
               Top = 7
               Left = 910
               Bottom = 148
               Right = 1111
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Shop"
            Begin Extent = 
               Top = 154
               Left = 48
               Bottom = 273
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sity"
            Begin Extent = 
               Top = 154
               Left = 910
               Bottom = 273
               Right = 1111
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stock"
            Begin Extent = 
               Top = 175
               Left = 297
               Bottom = 338
               Right = 498
            End
            DisplayFlags = 280' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ShopProducts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ShopProducts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ShopProducts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Organization"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Pounkt"
            Begin Extent = 
               Top = 7
               Left = 329
               Bottom = 170
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stock"
            Begin Extent = 
               Top = 7
               Left = 867
               Bottom = 170
               Right = 1068
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sity"
            Begin Extent = 
               Top = 189
               Left = 626
               Bottom = 308
               Right = 827
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SityPounkts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SityPounkts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Product"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 265
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ProductInStock"
            Begin Extent = 
               Top = 7
               Left = 340
               Bottom = 148
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sity"
            Begin Extent = 
               Top = 26
               Left = 1033
               Bottom = 145
               Right = 1234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stock"
            Begin Extent = 
               Top = 26
               Left = 695
               Bottom = 189
               Right = 896
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StockProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StockProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Environtment"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LoginHistory"
            Begin Extent = 
               Top = 7
               Left = 320
               Bottom = 221
               Right = 543
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "UserSignIn"
            Begin Extent = 
               Top = 7
               Left = 591
               Bottom = 126
               Right = 792
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserSignInView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserSignInView'
GO
USE [master]
GO
ALTER DATABASE [MusicShop] SET  READ_WRITE 
GO
