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
