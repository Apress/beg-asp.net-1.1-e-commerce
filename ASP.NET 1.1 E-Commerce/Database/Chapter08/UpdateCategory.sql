CREATE PROCEDURE UpdateCategory
(@CategoryID int,
@CategoryName varchar(50),
@CategoryDescription varchar(1000))
AS

UPDATE Category
SET [Name] = @CategoryName, [Description] = @CategoryDescription
WHERE CategoryID = @CategoryID

RETURN
