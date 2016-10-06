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
