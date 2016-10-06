CREATE PROCEDURE GetCategoriesWithDescriptions
(@DepartmentID int)
AS

SELECT CategoryID, [Name], [Description]
FROM Category
WHERE DepartmentID = @DepartmentID

RETURN
