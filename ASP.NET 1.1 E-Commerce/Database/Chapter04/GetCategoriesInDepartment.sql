CREATE PROCEDURE GetCategoriesInDepartment
      (@DepartmentID int)
AS

SELECT CategoryID, [Name]
FROM Category
WHERE DepartmentID = @DepartmentID

RETURN
