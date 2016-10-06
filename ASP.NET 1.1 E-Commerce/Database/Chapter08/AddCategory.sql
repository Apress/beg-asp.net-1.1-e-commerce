CREATE PROCEDURE AddCategory
(@DepartmentID int,
@CategoryName varchar(50),
@CategoryDescription varchar(50))
AS

INSERT INTO Category (DepartmentID, [Name], [Description])
VALUES (@DepartmentID, @CategoryName, @CategoryDescription)

RETURN
