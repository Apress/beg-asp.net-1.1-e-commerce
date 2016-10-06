CREATE PROCEDURE GetDepartmentDetails
      (@DepartmentID int,
       @DepartmentName varchar(50) OUTPUT,
       @DepartmentDescription varchar(200) OUTPUT)
AS

SELECT @DepartmentName=[Name], @DepartmentDescription=[Description]
FROM Department
WHERE DepartmentID = @DepartmentID

RETURN
