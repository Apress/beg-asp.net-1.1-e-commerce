CREATE PROCEDURE GetDepartmentsWithDescriptions AS

SELECT DepartmentID, Name, Description FROM Department

RETURN
