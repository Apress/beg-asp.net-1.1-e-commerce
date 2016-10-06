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
