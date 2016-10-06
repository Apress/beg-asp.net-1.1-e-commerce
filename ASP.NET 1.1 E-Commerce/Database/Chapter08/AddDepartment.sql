CREATE PROCEDURE AddDepartment
(@DepartmentName varchar(50),
@DepartmentDescription varchar(1000))
AS

INSERT INTO Department ([Name], [Description])
VALUES (@DepartmentName, @DepartmentDescription)

RETURN
