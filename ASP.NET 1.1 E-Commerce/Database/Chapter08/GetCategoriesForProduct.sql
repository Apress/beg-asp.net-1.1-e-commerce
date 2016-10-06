CREATE PROCEDURE GetCategoriesForProduct
(@ProductID int)
AS

SELECT Category.CategoryID, Name
FROM Category INNER JOIN ProductCategory
ON Category.CategoryID = ProductCategory.CategoryID
WHERE ProductCategory.ProductID = @ProductID

RETURN
