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
