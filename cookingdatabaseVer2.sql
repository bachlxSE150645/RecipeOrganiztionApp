USE [master]
GO
/****** Object:  Database [CookingTeamDB]    Script Date: 6/2/2023 11:46:45 PM ******/
CREATE DATABASE [CookingTeamDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CookingTeamDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.CHIENDB\MSSQL\DATA\CookingTeamDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CookingTeamDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.CHIENDB\MSSQL\DATA\CookingTeamDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CookingTeamDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CookingTeamDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CookingTeamDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CookingTeamDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CookingTeamDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CookingTeamDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CookingTeamDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CookingTeamDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CookingTeamDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CookingTeamDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CookingTeamDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CookingTeamDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CookingTeamDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CookingTeamDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CookingTeamDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CookingTeamDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CookingTeamDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CookingTeamDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CookingTeamDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CookingTeamDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CookingTeamDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CookingTeamDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CookingTeamDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CookingTeamDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CookingTeamDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CookingTeamDB] SET  MULTI_USER 
GO
ALTER DATABASE [CookingTeamDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CookingTeamDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CookingTeamDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CookingTeamDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CookingTeamDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CookingTeamDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CookingTeamDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [CookingTeamDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CookingTeamDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[accountID] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[roleID] [uniqueidentifier] NOT NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nchar](15) NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[ingredientID] [uniqueidentifier] NOT NULL,
	[ingredientName] [nvarchar](max) NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[ingredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meal]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meal](
	[mealID] [uniqueidentifier] NOT NULL,
	[accountID] [uniqueidentifier] NOT NULL,
	[recipeID] [uniqueidentifier] NOT NULL,
	[price] [decimal](18, 3) NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED 
(
	[mealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderID] [uniqueidentifier] NOT NULL,
	[mealID] [uniqueidentifier] NOT NULL,
	[accountID] [uniqueidentifier] NOT NULL,
	[createDate] [datetime] NULL,
	[quantity] [int] NULL,
	[totalPrice] [decimal](18, 3) NULL,
	[status] [nchar](10) NULL,
	[detail] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[recipeID] [uniqueidentifier] NOT NULL,
	[recipeName] [nvarchar](50) NULL,
	[recipeImage] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[accountID] [uniqueidentifier] NOT NULL,
	[status] [nvarchar](10) NOT NULL,
	[createDate] [datetime] NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[recipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeDetail]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeDetail](
	[recipeID] [uniqueidentifier] NOT NULL,
	[ingredientID] [uniqueidentifier] NOT NULL,
	[quantity] [int] NOT NULL,
	[unit] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[reviewID] [uniqueidentifier] NOT NULL,
	[accountID] [uniqueidentifier] NOT NULL,
	[recipeID] [uniqueidentifier] NOT NULL,
	[reviewContent] [nvarchar](max) NULL,
	[rating] [float] NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[reviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleID] [uniqueidentifier] NOT NULL,
	[roleName] [nchar](10) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[wishListID] [uniqueidentifier] NOT NULL,
	[accountID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[wishListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishListItem]    Script Date: 6/2/2023 11:46:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishListItem](
	[wishListID] [uniqueidentifier] NOT NULL,
	[recipeID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([roleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_Account] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account] ([accountID])
GO
ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_Account]
GO
ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_Recipe] FOREIGN KEY([recipeID])
REFERENCES [dbo].[Recipe] ([recipeID])
GO
ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_Recipe]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account] ([accountID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Meal] FOREIGN KEY([mealID])
REFERENCES [dbo].[Meal] ([mealID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Meal]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Account] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account] ([accountID])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_Account]
GO
ALTER TABLE [dbo].[RecipeDetail]  WITH CHECK ADD  CONSTRAINT [FK_RecipeDetail_Ingredient] FOREIGN KEY([ingredientID])
REFERENCES [dbo].[Ingredient] ([ingredientID])
GO
ALTER TABLE [dbo].[RecipeDetail] CHECK CONSTRAINT [FK_RecipeDetail_Ingredient]
GO
ALTER TABLE [dbo].[RecipeDetail]  WITH CHECK ADD  CONSTRAINT [FK_RecipeDetail_Recipe] FOREIGN KEY([recipeID])
REFERENCES [dbo].[Recipe] ([recipeID])
GO
ALTER TABLE [dbo].[RecipeDetail] CHECK CONSTRAINT [FK_RecipeDetail_Recipe]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Account] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account] ([accountID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Account]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Recipe] FOREIGN KEY([recipeID])
REFERENCES [dbo].[Recipe] ([recipeID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Recipe]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Account] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account] ([accountID])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Account]
GO
ALTER TABLE [dbo].[WishListItem]  WITH CHECK ADD  CONSTRAINT [FK_WishListItem_Recipe] FOREIGN KEY([recipeID])
REFERENCES [dbo].[Recipe] ([recipeID])
GO
ALTER TABLE [dbo].[WishListItem] CHECK CONSTRAINT [FK_WishListItem_Recipe]
GO
ALTER TABLE [dbo].[WishListItem]  WITH CHECK ADD  CONSTRAINT [FK_WishListItem_WishList] FOREIGN KEY([wishListID])
REFERENCES [dbo].[WishList] ([wishListID])
GO
ALTER TABLE [dbo].[WishListItem] CHECK CONSTRAINT [FK_WishListItem_WishList]
GO
USE [master]
GO
ALTER DATABASE [CookingTeamDB] SET  READ_WRITE 
GO
