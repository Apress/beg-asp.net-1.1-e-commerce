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

