CREATE PROCEDURE DeleteCategory
(@CategoryID int)
AS

DELETE FROM Category
WHERE CategoryID = @CategoryID

RETURN

