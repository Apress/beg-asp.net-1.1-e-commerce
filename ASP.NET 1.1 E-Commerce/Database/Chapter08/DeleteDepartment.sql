CREATE PROCEDURE DeleteDepartment
(@DepartmentID int)
AS

DELETE FROM Department
WHERE DepartmentID = @DepartmentID

RETURN

