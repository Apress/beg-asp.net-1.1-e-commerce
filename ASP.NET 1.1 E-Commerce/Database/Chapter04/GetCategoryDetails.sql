CREATE PROCEDURE GetCategoryDetails 
      (@CategoryID int,
       @CategoryName varchar(50) OUTPUT,
       @CategoryDescription varchar(200) OUTPUT)
AS

SELECT 
       @CategoryName = [Name],
       @CategoryDescription = [Description]
FROM Category
WHERE CategoryID = @CategoryID

RETURN
