CREATE PROCEDURE MoveProductToCategory
(@ProductID int, @OldCategoryID int, @NewCategoryID int)
AS

UPDATE ProductCategory
SET CategoryID=@NewCategoryID
WHERE CategoryID=@OldCategoryID
  AND ProductID=@ProductID

RETURN
