CREATE PROCEDURE GetCustomerIDPassword
(@Email varchar(50))
AS

SELECT CustomerID, [Password]
FROM Customer
WHERE Email = @Email

GO

CREATE PROCEDURE AddCustomer
(@Name varchar(50),
 @Email varchar(50),
 @Password varchar(50),
 @Phone varchar(100))
AS

DECLARE @CustomerID AS int

INSERT INTO Customer ([Name], Email, [Password], Phone)
VALUES (@Name, @Email, @Password, @Phone)
SET @CustomerID = @@IDENTITY

SELECT @CustomerID

GO

CREATE PROCEDURE GetCustomer
(@CustomerID varchar(50))
AS

SELECT CustomerID, [Name], [Password], Email, CreditCard, Address1, Address2, City,
 Region, PostalCode, Country, Phone
FROM Customer
WHERE CustomerID = @CustomerID

GO

CREATE PROCEDURE UpdateCustomerDetails
(@CustomerID int,
 @Name varchar(50),
 @Email varchar(50),
 @Password varchar(50),
 @Phone varchar(100))

AS
UPDATE Customer
SET [Name] = @Name, Email = @Email, [Password] = @Password, Phone = [Phone]
WHERE CustomerID = @CustomerID

GO

CREATE PROCEDURE UpdateAddress
(@CustomerID int,
 @Address1 varchar(100),
 @Address2 varchar(100),
 @City varchar(100),
 @Region varchar(100),
 @PostalCode varchar(100),
 @Country varchar(100)
)

AS
UPDATE Customer
SET Address1 = @Address1, Address2 = @Address2, City = @City, Region = @Region,
 PostalCode = @PostalCode, Country = @Country
WHERE CustomerID = @CustomerID

GO

CREATE PROCEDURE UpdateCreditCard
(@CustomerID int,
 @CreditCard varchar(512))

AS
UPDATE Customer
SET CreditCard = @CreditCard
WHERE CustomerID = @CustomerID

GO