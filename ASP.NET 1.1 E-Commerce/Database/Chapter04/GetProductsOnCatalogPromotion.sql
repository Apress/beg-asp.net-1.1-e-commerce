CREATE PROCEDURE GetProductsOnCatalogPromotion
AS

SELECT Product.ProductID,Product.[Name], Product.[Description], 
       Product.Price, Product.ImagePath
FROM Product 
WHERE Product.OnCatalogPromotion = 1

RETURN

