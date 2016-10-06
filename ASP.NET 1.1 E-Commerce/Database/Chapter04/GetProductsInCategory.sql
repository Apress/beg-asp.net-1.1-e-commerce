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

