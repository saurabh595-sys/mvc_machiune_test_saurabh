USE [master]
GO
/****** Object:  Database [test_db]    Script Date: 12-04-2022 12.00.21 AM ******/
CREATE DATABASE [test_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\test_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\test_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [test_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [test_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [test_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [test_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [test_db] SET  MULTI_USER 
GO
ALTER DATABASE [test_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [test_db] SET QUERY_STORE = OFF
GO
USE [test_db]
GO
/****** Object:  Table [dbo].[Category_master]    Script Date: 12-04-2022 12.00.21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_master](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_master]    Script Date: 12-04-2022 12.00.22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_master](
	[productId] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category_master] ([CategoryId], [CategoryName]) VALUES (1, N'car')
INSERT [dbo].[Category_master] ([CategoryId], [CategoryName]) VALUES (2, N'bike')
GO
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (1, N'bmw', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (2, N'dukati', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (3, N'honda', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (4, N'mustang', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (5, N'ford', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (6, N'Lamborghini ', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (7, N'Ford Raptor.', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (8, N'Ferrari Testarossa', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (9, N'Porsche 911 Carrera', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (10, N'Jensen Interceptor', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (11, N'Lamborghini Huracán', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (12, N'Ferrari 812 Superfast', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (13, N'Jeep Gladiator', 1)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (14, N'Yamaha MT-15', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (15, N'TVS Apache RTR 160', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (16, N'Yamaha YZF R15 V3', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (17, N'TVS Jupiter', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (18, N'TVS NTORQ 125', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (19, N'Hero Splendor Plus', 2)
INSERT [dbo].[Product_master] ([productId], [ProductName], [CategoryId]) VALUES (20, N'TVS Sport', 2)
GO
ALTER TABLE [dbo].[Product_master]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category_master] ([CategoryId])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[Category_master_curd]    Script Date: 12-04-2022 12.00.22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Category_master_curd]
      @Action varchar(10)
      ,@CategoryId INT =null
      ,@CategoryName varchar(50)=null
AS
BEGIN
      SET NOCOUNT ON;
 
      --SELECT
      IF @Action = 'SELECT'
      BEGIN
            SELECT *
            FROM Category_master
      END
	  --SELECT WHERE
     IF @Action = 'SELECT2'
      BEGIN
            SELECT *
            FROM Category_master where CategoryId = @CategoryId
      END
 
      --INSERT
      IF @Action = 'INSERT'
      BEGIN
            INSERT INTO Category_master(CategoryId,CategoryName)
            VALUES ( @CategoryId,@CategoryName)
      END
 
      --UPDATE
      IF @Action = 'UPDATE'
      BEGIN
            UPDATE Category_master
            SET  CategoryName = @CategoryName
            WHERE CategoryId = CategoryId
      END
 
      --DELETE
      IF @Action = 'DELETE'
      BEGIN
            DELETE FROM Category_master
            WHERE CategoryId = @CategoryId
      END
END
GO
/****** Object:  StoredProcedure [dbo].[Product_master_curd]    Script Date: 12-04-2022 12.00.22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_master_curd]
      @Action VARCHAR(10),
      @productId INT =null,
      @ProductName varchar(50)=null,
	  @CategoryId INT =null
AS
BEGIN
      SET NOCOUNT ON;
 
      --SELECT
      IF @Action = 'SELECT'
      BEGIN
            SELECT *
            FROM Product_master
      END
 
      --INSERT
      IF @Action = 'INSERT'
      BEGIN
            INSERT INTO Product_master(productId,ProductName,CategoryId)
            VALUES ( @productId,@ProductName,@CategoryId)
      END
 
      --UPDATE
      IF @Action = 'UPDATE'
      BEGIN
            UPDATE Product_master
            SET productId = @productId, ProductName = @ProductName,CategoryId=@CategoryId
            WHERE productId = @productId
      END
 
      --DELETE
      IF @Action = 'DELETE'
      BEGIN
            DELETE FROM Product_master
            WHERE productId = @productId
      END
END
GO
USE [master]
GO
ALTER DATABASE [test_db] SET  READ_WRITE 
GO
