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
