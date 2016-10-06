IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'JokePoint')
	DROP DATABASE [JokePoint]
GO

CREATE DATABASE [JokePoint]  ON (NAME = N'JokePoint', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL$NETSDK\Data\JokePoint.mdf' , SIZE = 1, FILEGROWTH = 10%) LOG ON (NAME = N'JokePoint_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL$NETSDK\Data\JokePoint_log.LDF' , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'JokePoint', N'autoclose', N'true'
GO

exec sp_dboption N'JokePoint', N'bulkcopy', N'false'
GO

exec sp_dboption N'JokePoint', N'trunc. log', N'true'
GO

exec sp_dboption N'JokePoint', N'torn page detection', N'true'
GO

exec sp_dboption N'JokePoint', N'read only', N'false'
GO

exec sp_dboption N'JokePoint', N'dbo use', N'false'
GO

exec sp_dboption N'JokePoint', N'single', N'false'
GO

exec sp_dboption N'JokePoint', N'autoshrink', N'true'
GO

exec sp_dboption N'JokePoint', N'ANSI null default', N'false'
GO

exec sp_dboption N'JokePoint', N'recursive triggers', N'false'
GO

exec sp_dboption N'JokePoint', N'ANSI nulls', N'false'
GO

exec sp_dboption N'JokePoint', N'concat null yields null', N'false'
GO

exec sp_dboption N'JokePoint', N'cursor close on commit', N'false'
GO

exec sp_dboption N'JokePoint', N'default to local cursor', N'false'
GO

exec sp_dboption N'JokePoint', N'quoted identifier', N'false'
GO

exec sp_dboption N'JokePoint', N'ANSI warnings', N'false'
GO

exec sp_dboption N'JokePoint', N'auto create statistics', N'true'
GO

exec sp_dboption N'JokePoint', N'auto update statistics', N'true'
GO

if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
	exec sp_dboption N'JokePoint', N'db chaining', N'false'
GO

use [JokePoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WordCount]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[WordCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddDepartment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddDepartment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddProductToCart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddProductToCart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssignProductToCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssignProductToCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CleanShoppingCart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CleanShoppingCart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountOldShoppingCartElements]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountOldShoppingCartElements]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateOrder]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateOrder]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateProductToCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateProductToCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteDepartment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteDepartment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmptyShoppingCart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmptyShoppingCart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoriesForNotProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoriesForNotProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoriesForProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoriesForProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoriesInDepartment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoriesInDepartment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoriesWithDescriptions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoriesWithDescriptions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoryDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoryDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartments]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentsWithDescriptions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentsWithDescriptions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetMostRecentOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetMostRecentOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOrderDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOrderInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrdersBetweenDates]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOrdersBetweenDates]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductsInCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductsInCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductsOnCatalogPromotion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductsOnCatalogPromotion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductsOnDepartmentPromotion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductsOnDepartmentPromotion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetShoppingCartProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetShoppingCartProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSimilarProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSimilarProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTotalAmount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTotalAmount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetUnverifiedUncanceledOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetUnverifiedUncanceledOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetVerifiedUncompletedOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVerifiedUncompletedOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MarkOrderAsCanceled]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MarkOrderAsCanceled]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MarkOrderAsCompleted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MarkOrderAsCompleted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MarkOrderAsVerified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MarkOrderAsVerified]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MoveProductToCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MoveProductToCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFromCategoryOrDeleteProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RemoveFromCategoryOrDeleteProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveProductFromCart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RemoveProductFromCart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SearchCatalog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SearchCatalog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCartItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCartItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDepartment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateDepartment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOrder]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOrder]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateProductPicture]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateProductPicture]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Department]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Department]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OrderDetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OrderDetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Orders]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Orders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Product]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ShoppingCart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ShoppingCart]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/* You may need to use your user name instead of dbo, 
   in which case you'll also need to update the SearchCatalog stored procedure */

CREATE FUNCTION dbo.WordCount
(@Word VARCHAR(20), 
@Phrase VARCHAR(1000))
RETURNS SMALLINT
AS
BEGIN

/* If @Word or @Phrase is NULL the function returns 0 */
IF @Word IS NULL OR @Phrase IS NULL RETURN 0

/* Calculate and store the SOUNDEX value of the word */
DECLARE @SoundexWord CHAR(4)
SELECT @SoundexWord = SOUNDEX(@Word)

/* Eliminate bogus characters from phrase */
SELECT @Phrase = REPLACE(@Phrase, ',', ' ')
SELECT @Phrase = REPLACE(@Phrase, '.', ' ')
SELECT @Phrase = REPLACE(@Phrase, '!', ' ')
SELECT @Phrase = REPLACE(@Phrase, '?', ' ')
SELECT @Phrase = REPLACE(@Phrase, ';', ' ')
SELECT @Phrase = REPLACE(@Phrase, '-', ' ')

/* Necessary because LEN doesn't calculate trailing spaces */
SELECT @Phrase = RTRIM(@Phrase)

/* Check every word in the phrase */
DECLARE @NextSpacePos SMALLINT
DECLARE @ExtractedWord VARCHAR(20)
DECLARE @Matches SMALLINT

SELECT @Matches = 0

WHILE LEN(@Phrase)>0
  BEGIN
     SELECT @NextSpacePos = CHARINDEX(' ', @Phrase)
     IF @NextSpacePos = 0 
       BEGIN
         SELECT @ExtractedWord = @Phrase
         SELECT @Phrase=''
       END
     ELSE
       BEGIN
         SELECT @ExtractedWord = LEFT(@Phrase, @NextSpacePos-1)
         SELECT @Phrase = RIGHT(@Phrase, LEN(@Phrase)-@NextSpacePos)
       END

     IF @SoundexWord = SOUNDEX(@ExtractedWord)
       SELECT @Matches = @Matches + 1
  END

/* Return the number of occurences of @Word in @Phrase */
RETURN @Matches
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[Category] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
	[DepartmentID] [int] NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Department] (
	[DepartmentID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OrderDetail] (
	[OrderID] [int] NOT NULL ,
	[ProductID] [int] NOT NULL ,
	[ProductName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Quantity] [int] NOT NULL ,
	[UnitCost] [money] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Orders] (
	[OrderID] [int] IDENTITY (1, 1) NOT NULL ,
	[DateCreated] [smalldatetime] NOT NULL ,
	[DateShipped] [smalldatetime] NULL ,
	[Verified] [bit] NOT NULL ,
	[Completed] [bit] NULL ,
	[Canceled] [bit] NOT NULL ,
	[Comments] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ShippingAddress] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerEmail] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product] (
	[ProductID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Price] [money] NULL ,
	[ImagePath] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OnCatalogPromotion] [bit] NOT NULL ,
	[OnDepartmentPromotion] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductCategory] (
	[ProductID] [int] NOT NULL ,
	[CategoryID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ShoppingCart] (
	[CartID] [char] (36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ProductID] [int] NOT NULL ,
	[Quantity] [int] NOT NULL ,
	[DateProductAdded] [datetime] NOT NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE AddCategory
(@DepartmentID int,
@CategoryName varchar(50),
@CategoryDescription varchar(50))
AS

INSERT INTO Category (DepartmentID, [Name], [Description])
VALUES (@DepartmentID, @CategoryName, @CategoryDescription)

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE AddDepartment
(@DepartmentName varchar(50),
@DepartmentDescription varchar(1000))
AS

INSERT INTO Department ([Name], [Description])
VALUES (@DepartmentName, @DepartmentDescription)

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure AddProductToCart
(@CartID char(36),
 @ProductID int)
As

IF EXISTS 
   (SELECT CartID 
    FROM ShoppingCart 
    WHERE ProductID = @ProductID AND CartID = @CartID)

    UPDATE ShoppingCart
    SET Quantity = Quantity + 1
    WHERE ProductID = @ProductID AND CartID = @CartID
ELSE
    IF EXISTS (SELECT Name FROM Product WHERE ProductID=@ProductID)
        INSERT INTO ShoppingCart (CartID, ProductID, Quantity, DateProductAdded)
        VALUES (@CartID, @ProductID, 1, GETDATE())

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE AssignProductToCategory
(@ProductID int, @CategoryID int)
AS

IF EXISTS
  (SELECT [Name]
   FROM Product
   WHERE ProductID=@ProductID)
  AND EXISTS
  (SELECT [Name]
   FROM Category
   WHERE CategoryID=@CategoryID)
  AND NOT EXISTS
  (SELECT *
   FROM ProductCategory
   WHERE CategoryID=@CategoryID AND ProductID=@ProductID)
INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES (@ProductID, @CategoryID)

RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE CleanShoppingCart
   (@Days smallint)
AS
DELETE FROM ShoppingCart
WHERE CartID IN
  (SELECT CartID
   FROM ShoppingCart
   GROUP BY CartID
   HAVING MIN(DATEDIFF(dd,DateProductAdded,GETDATE()))>@Days)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE CountOldShoppingCartElements
   (@Days smallint)
AS
SELECT COUNT(CartID) 
FROM ShoppingCart
WHERE CartID IN
  (SELECT CartID
   FROM ShoppingCart
   GROUP BY CartID
   HAVING MIN(DATEDIFF(dd,DateProductAdded,GETDATE()))>@Days)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE CreateOrder 
(@CartID char(36))
AS

DECLARE @OrderID int
INSERT INTO Orders (DateCreated, Verified, Completed, Canceled)
VALUES (GETDATE(), 0, 0, 0)
SET @OrderID = @@IDENTITY

INSERT INTO OrderDetail 
     (OrderID, ProductID, ProductName, Quantity, UnitCost)
SELECT 
     @OrderID, Product.ProductID, Product.Name, 
     ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID

EXEC EmptyShoppingCart @CartID

SELECT @OrderID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE CreateProductToCategory
(@CategoryID int,
 @ProductName varchar(50),
 @ProductDescription varchar(1000),
 @ProductPrice Money,
 @ProductImage varchar(50),
 @OnDepartmentPromotion bit,
 @OnCatalogPromotion bit)
AS

DECLARE @ProductID int

INSERT INTO Product ([Name], [Description], Price, ImagePath, OnDepartmentPromotion, OnCatalogPromotion )
VALUES (@ProductName, @ProductDescription, CONVERT(money,@ProductPrice), @ProductImage, @OnDepartmentPromotion, @OnCatalogPromotion)

SELECT @ProductID = @@Identity

INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES (@ProductID, @CategoryID)

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE DeleteCategory
(@CategoryID int)
AS

DELETE FROM Category
WHERE CategoryID = @CategoryID

RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE DeleteDepartment
(@DepartmentID int)
AS

DELETE FROM Department
WHERE DepartmentID = @DepartmentID

RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE EmptyShoppingCart 
(@CartID char(36))
AS

DELETE FROM ShoppingCart
WHERE CartID = @CartID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetCategoriesForNotProduct
(@ProductID int)
AS

SELECT Category.CategoryID, Name
FROM Category 
WHERE CategoryID NOT IN 
(SELECT Category.CategoryID 
FROM Category INNER JOIN ProductCategory
ON Category.CategoryID = ProductCategory.CategoryID
WHERE ProductCategory.ProductID = @ProductID)

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetCategoriesForProduct
(@ProductID int)
AS

SELECT Category.CategoryID, Name
FROM Category INNER JOIN ProductCategory
ON Category.CategoryID = ProductCategory.CategoryID
WHERE ProductCategory.ProductID = @ProductID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetCategoriesInDepartment
      (@DepartmentID int)
AS

SELECT CategoryID, [Name]
FROM Category
WHERE DepartmentID = @DepartmentID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetCategoriesWithDescriptions
(@DepartmentID int)
AS

SELECT CategoryID, [Name], [Description]
FROM Category
WHERE DepartmentID = @DepartmentID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetCategoryDetails 
      (@CategoryID int,
       @CategoryName varchar(50) OUTPUT,
       @CategoryDescription varchar(200) OUTPUT)
AS

SELECT 
       @CategoryName = [Name],
       @CategoryDescription = [Description]
FROM Category
WHERE CategoryID = @CategoryID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE GetDepartmentDetails
      (@DepartmentID int,
       @DepartmentName varchar(50) OUTPUT,
       @DepartmentDescription varchar(200) OUTPUT)
AS

SELECT @DepartmentName=[Name], @DepartmentDescription=[Description]
FROM Department
WHERE DepartmentID = @DepartmentID

RETURN




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetDepartments AS

SELECT DepartmentID, Name
FROM Department

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetDepartmentsWithDescriptions AS

SELECT DepartmentID, Name, Description FROM Department

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetMostRecentOrders 
(@Count smallint)
AS

SET ROWCOUNT @Count

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
ORDER BY DateCreated DESC

SET ROWCOUNT 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetOrderDetails
(@OrderID int)
AS

SELECT Orders.OrderID, 
       ProductID, 
       ProductName, 
       Quantity, 
       UnitCost, 
       Quantity*UnitCost AS Subtotal
FROM OrderDetail JOIN Orders
ON Orders.OrderID = OrderDetail.OrderID
WHERE Orders.OrderID = @OrderID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetOrderInfo
(@OrderID int)
AS

SELECT OrderID, 
       (SELECT SUM(UnitCost*Quantity) FROM OrderDetail WHERE OrderID = @OrderID) 
       AS TotalAmount, 
       DateCreated, 
       DateShipped, 
       Verified, 
       Completed, 
       Canceled, 
       Comments, 
       CustomerName, 
       ShippingAddress, 
       CustomerEmail
FROM Orders
WHERE OrderID = @OrderID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetOrdersBetweenDates 
(@StartDate smalldatetime,
 @EndDate smalldatetime)
AS

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
WHERE DateCreated BETWEEN @StartDate AND @EndDate
ORDER BY DateCreated DESC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetProductsInCategory
      (@CategoryID int)
AS 

SELECT Product.ProductID,Product.[Name], Product.[Description], 
       Product.Price, Product.ImagePath, Product.OnDepartmentPromotion, 
       Product.OnCatalogPromotion
FROM Product INNER JOIN ProductCategory
ON Product.ProductID = ProductCategory.ProductID
WHERE ProductCategory.CategoryID = @CategoryID

RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetProductsOnCatalogPromotion
AS

SELECT Product.ProductID,Product.[Name], Product.[Description], 
       Product.Price, Product.ImagePath
FROM Product 
WHERE Product.OnCatalogPromotion = 1

RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetProductsOnDepartmentPromotion
  (@DepartmentID int)
AS

SELECT DISTINCT Product.ProductID,Product.[Name], Product.[Description],
                Product.Price, Product.ImagePath
FROM Product 
INNER JOIN ProductCategory
ON Product.ProductID = ProductCategory.ProductID
INNER JOIN Category
ON ProductCategory.CategoryID = Category.CategoryID
WHERE Product.OnDepartmentPromotion = 1 
      AND Category.DepartmentID=@DepartmentID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetShoppingCartProducts 
(@CartID char(36))
AS

SELECT Product.ProductID, Product.Name, Product.Price, ShoppingCart.Quantity, Product.Price*ShoppingCart.Quantity AS Subtotal
FROM ShoppingCart
INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetSimilarProducts
(@CartID CHAR(36))
AS
--- Returns the products that were bought by customers that
--- bought the products in the mentioned shopping cart
SELECT Product.ProductID, Product.Name, Product.Description,
       Product.Price, Product.ImagePath, Product.OnDepartmentPromotion, 
       Product.OnCatalogPromotion
FROM Product
WHERE ProductID IN
   (
   -- Returns the products that exist in a list of orders
   SELECT TOP 4 ProductID
   FROM OrderDetail
   WHERE OrderID IN
      (
      -- Returns the orders that contain certain products
      SELECT DISTINCT OrderID 
      FROM OrderDetail 
      WHERE ProductID IN
         (
         -- Returns the products in the specified shopping cart
         SELECT ProductID 
         FROM ShoppingCart
         WHERE CartID = @CartID
         )
      )
   -- Must not include products that already exist in the visitor's cart
   AND ProductID NOT IN
      (
      -- Returns the products in the specified shopping cart
      SELECT ProductID 
      FROM ShoppingCart
      WHERE CartID = @CartID
      )
   -- Group the ProductID so we can calculate the rank
   GROUP BY ProductID
   -- Order descending by rank
   ORDER BY COUNT(ProductID) DESC
   )

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetTotalAmount
(@CartID char(36))
AS

DECLARE @Amount money

SELECT @Amount = SUM(Product.Price*ShoppingCart.Quantity)
FROM ShoppingCart
INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

IF @Amount IS NULL 
	SELECT 0
ELSE
	SELECT @Amount

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetUnverifiedUncanceledOrders
AS

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
WHERE Verified=0 AND Canceled=0
ORDER BY DateCreated DESC


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetVerifiedUncompletedOrders
AS

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
WHERE Verified=1 AND Completed=0
ORDER BY DateCreated DESC


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE MarkOrderAsCanceled
(@OrderID int)
AS

UPDATE Orders
SET Canceled = 1
WHERE OrderID = @OrderID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE MarkOrderAsCompleted
(@OrderID int)
AS

UPDATE Orders
SET Completed = 1,
    DateShipped = getdate()
WHERE OrderID = @OrderID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE MarkOrderAsVerified
(@OrderID int)
AS

UPDATE Orders
SET Verified = 1
WHERE OrderID = @OrderID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE MoveProductToCategory
(@ProductID int, @OldCategoryID int, @NewCategoryID int)
AS

UPDATE ProductCategory
SET CategoryID=@NewCategoryID
WHERE CategoryID=@OldCategoryID
  AND ProductID=@ProductID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE RemoveFromCategoryOrDeleteProduct
(@ProductID int, @CategoryID int)
AS

IF (SELECT COUNT(*) FROM ProductCategory WHERE ProductID=@ProductID)>1
  DELETE FROM ProductCategory
  WHERE CategoryID=@CategoryID AND ProductID=@ProductID
ELSE
 BEGIN
   DELETE FROM ShoppingCart WHERE ProductID=@ProductID
   DELETE FROM ProductCategory WHERE ProductID=@ProductID
   DELETE FROM Product where ProductID=@ProductID
 END

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE RemoveProductFromCart
(@CartID char(36),
 @ProductID int)
AS

DELETE FROM ShoppingCart
WHERE CartID = @CartID and ProductID = @ProductID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE SearchCatalog 
(
@PageNumber tinyint,
@ProductsOnPage tinyint,
@HowManyResults smallint OUTPUT,
@AllWords bit,
@Word1 varchar(15) = NULL,
@Word2 varchar(15) = NULL,
@Word3 varchar(15) = NULL,
@Word4 varchar(15) = NULL,
@Word5 varchar(15) = NULL)
AS

/* Create the temporary table that will contain the search results */
CREATE TABLE #SearchedProducts
(RowNumber SMALLINT NOT NULL IDENTITY(1,1),
 ProductID INT,
 Name VARCHAR(50),
 Description VARCHAR(1000),
 Price MONEY,
 ImagePath VARCHAR(50),
 Rank INT)

/* Populate #SearchedProducts for an any-words search */
IF @AllWords = 0 
   INSERT INTO #SearchedProducts 
          (ProductID, Name, Description, Price, ImagePath, Rank)
   SELECT Product.ProductID, Product.Name, Product.Description, 
          Product.Price, Product.ImagePath,
          3*dbo.WordCount(@Word1, Name)+dbo.WordCount(@Word1, Description)+
          3*dbo.WordCount(@Word2, Name)+dbo.WordCount(@Word2, Description)+
          3*dbo.WordCount(@Word3, Name)+dbo.WordCount(@Word3, Description)+
          3*dbo.WordCount(@Word4, Name)+dbo.WordCount(@Word4, Description)+
          3*dbo.WordCount(@Word5, Name)+dbo.WordCount(@Word5, Description) 
          AS TotalRank
   FROM Product
   ORDER BY TotalRank DESC
   

/* Populate #SearchedProducts for an all-words search */
IF @AllWords = 1 
   INSERT INTO #SearchedProducts 
          (ProductID, Name, Description, Price, ImagePath, Rank)
   SELECT Product.ProductID, Product.Name, Product.Description, 
          Product.Price, Product.ImagePath,
          (3*dbo.WordCount(@Word1, Name)+dbo.WordCount(@Word1, Description)) *
          CASE 
             WHEN @Word2 IS NULL THEN 1 
             ELSE 3*dbo.WordCount(@Word2, Name)+dbo.WordCount(@Word2, Description)
          END *
          CASE 
             WHEN @Word3 IS NULL THEN 1 
             ELSE 3*dbo.WordCount(@Word3, Name)+dbo.WordCount(@Word3, Description)
          END *
          CASE 
             WHEN @Word4 IS NULL THEN 1 
             ELSE 3*dbo.WordCount(@Word4, Name)+dbo.WordCount(@Word4, Description)
          END *
          CASE 
             WHEN @Word5 IS NULL THEN 1 
             ELSE 3*dbo.WordCount(@Word5, Name)+dbo.WordCount(@Word5, Description)
          END
          AS TotalRank
   FROM Product
   ORDER BY TotalRank DESC

/* Save the number of searched products in an output variable */
SELECT @HowManyResults=COUNT(*) FROM #SearchedProducts WHERE Rank>0

/* Send back the requested products */
SELECT ProductID, Name, Description, Price, ImagePath, Rank
FROM #SearchedProducts
WHERE Rank > 0
  AND RowNumber BETWEEN (@PageNumber-1) * @ProductsOnPage + 1 
                    AND @PageNumber * @ProductsOnPage
ORDER BY Rank DESC


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure UpdateCartItem
(@CartID char(36),
 @ProductID int,
 @Quantity int)
As

IF @Quantity<=0 
  EXEC RemoveProductFromCart @CartID, @ProductID
ELSE
  UPDATE ShoppingCart
  SET Quantity = @Quantity, DateProductAdded=GETDATE()
  WHERE ProductID = @ProductID AND CartID = @CartID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE UpdateCategory
(@CategoryID int,
@CategoryName varchar(50),
@CategoryDescription varchar(1000))
AS

UPDATE Category
SET [Name] = @CategoryName, [Description] = @CategoryDescription
WHERE CategoryID = @CategoryID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE UpdateDepartment
(@DepartmentID int,
@DepartmentName varchar(50),
@DepartmentDescription varchar(1000))

AS
UPDATE Department
SET Name = @DepartmentName, Description = @DepartmentDescription
WHERE DepartmentID = @DepartmentID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE UpdateOrder
(@OrderID int,
 @DateCreated smalldatetime,
 @DateShipped smalldatetime = NULL,
 @Verified bit,
 @Completed bit,
 @Canceled bit,
 @Comments varchar(200),
 @CustomerName varchar(50),
 @ShippingAddress varchar(200),
 @CustomerEmail varchar(50))
AS

UPDATE Orders
SET DateCreated=@DateCreated,
    DateShipped=@DateShipped,
    Verified=@Verified,
    Completed=@Completed,
    Canceled=@Canceled,
    Comments=@Comments,
    CustomerName=@CustomerName,
    ShippingAddress=@ShippingAddress,
    CustomerEmail=@CustomerEmail
WHERE OrderID = @OrderID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE UpdateProduct
(@ProductID int,
 @ProductName varchar(50),
 @ProductDescription varchar(1000),
 @ProductPrice money,
 @ProductImage varchar(50),
 @OnDepartmentPromotion bit,
 @OnCatalogPromotion bit)
AS

UPDATE Product
SET [Name] = @ProductName,
    [Description] = @ProductDescription,
    Price = CONVERT(money,@ProductPrice),
    ImagePath = @ProductImage,
    OnDepartmentPromotion = @OnDepartmentPromotion,
    OnCatalogPromotion = @OnCatalogPromotion
WHERE ProductID = @ProductID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE UpdateProductPicture
      (@ProductID int,
       @ImageFileName varchar(50))
AS

UPDATE Product
SET ImagePath = @ImageFileName
WHERE ProductID = @ProductID

RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

